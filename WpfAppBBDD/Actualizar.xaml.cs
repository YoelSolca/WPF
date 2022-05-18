using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;

namespace WpfAppBBDD
{
    /// <summary>
    /// Lógica de interacción para Actualizar.xaml
    /// </summary>
    public partial class Actualizar : Window
    {
        SqlConnection conn;

        private int id;
        private string consulta;

        public Actualizar(int idCliente)
        {
            InitializeComponent();

            id = idCliente;

            conn = MainWindow.EspecificacionDeConsultas();

            MostrarArticulos();
        }

        private void MostrarArticulos()
        {

            try
            {

                string consulta = "SELECT *, CONCAT(Id, ' - ' ,seccion, '  ' , nombreArticulo) AS INFOCOMPLETA FROM ARTICULO ORDER BY Id";

                SqlDataAdapter adapter = new SqlDataAdapter(consulta, conn);

                using (adapter)
                {
                    DataTable pedidostabla = new DataTable();

                    adapter.Fill(pedidostabla);

                    todosArticulos.DisplayMemberPath = "INFOCOMPLETA";
                    todosArticulos.SelectedValuePath = "Id";
                    todosArticulos.ItemsSource = pedidostabla.DefaultView;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            TodosPedidos ventanaPedidos = new TodosPedidos();

            this.Close();

            ventanaPedidos.ShowDialog();
        }


        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

      

        //Se divide por vistas (Agregar un nuevo aritulo) y (Listar todos los articulos)
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if(Btn.Content.ToString() != "Agregar articulo" && todosArticulos.SelectedValue != null)
            { 
                consulta = "INSERT INTO PEDIDO (cCLiente, fechaPedido, formadePago, CArticulo) VALUES (@cCliente, @fechaPedido, @formadePago, @CArticulo)";

                SqlCommand command = new SqlCommand(consulta, conn);

                conn.Open();


                command.Parameters.AddWithValue("@cCliente", id);
                command.Parameters.AddWithValue("@fechaPedido", DateTime.Now);
                command.Parameters.AddWithValue("@formadePago", insertaFormaPago.Text);
                command.Parameters.AddWithValue("@CArticulo", todosArticulos.SelectedValue);

                //ejecutar este tipo de consulta
                command.ExecuteNonQuery();

                conn.Close();

                this.Close();
            }
            else if(Btn.Content.ToString() == "Agregar articulo")
            {
                AgregarArticulo agregarArticulo = new AgregarArticulo(0);

                agregarArticulo.ShowDialog();

                MostrarArticulos();
            }
            else
            {
                MessageBox.Show("Debe seleccionar algun articulo al pedido", "Error", MessageBoxButton.OK, MessageBoxImage.Stop);
            }
        }


        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            if(BtnExit.Content.ToString() == "Eliminar" && todosArticulos.SelectedValue != null)
            {
                    var resp = MessageBox.Show("¿Esta seguro que desea eliminar este articulo, esta operación es irreversible?", "", MessageBoxButton.YesNo, MessageBoxImage.Question);

                    if (resp.ToString() == "Yes")
                    {

                    string consulta = "DELETE FROM ARTICULO WHERE ID = @ARTICULOID";
                    string consulta2 = "DELETE FROM PEDIDO WHERE cArticulo = @ARTICULOID";

                    SqlCommand command = new SqlCommand(consulta, conn);
                    SqlCommand command2 = new SqlCommand(consulta2, conn);

                        conn.Open();

                        command2.Parameters.AddWithValue("@ARTICULOID", todosArticulos.SelectedValue);
                        command.Parameters.AddWithValue("@ARTICULOID", todosArticulos.SelectedValue);

                        //ejecutar este tipo de consulta
                        command2.ExecuteNonQuery();
                        command.ExecuteNonQuery();


                    conn.Close();

                    MostrarArticulos();

                    MessageBox.Show("Articulo eliminado correctamenente");

                    }

             }
                else if (BtnExit.Content.ToString() != "Cancelar"  && todosArticulos.SelectedValue == null)
                {
                MessageBox.Show("Debe seleccionar algun articulo", "Error", MessageBoxButton.OK, MessageBoxImage.Stop);
            }

            else
                {
                    this.Close();
                }

        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (todosArticulos.SelectedValue != null)
            {
                AgregarArticulo ventanaAgregarArticulo= new AgregarArticulo((int)todosArticulos.SelectedValue);

                try
                {
                    string consulta = "Select * FROM ARTICULO WHERE Id=@AriculoId";

            

                    SqlCommand sqlCommand = new SqlCommand(consulta, conn);
                    SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);

                    using (adapter)
                    {
                        sqlCommand.Parameters.AddWithValue("@AriculoId", todosArticulos.SelectedValue);

                        DataTable clientetabla = new DataTable();
                        adapter.Fill(clientetabla);

                        ventanaAgregarArticulo.insertaNombreArticulo.Text = clientetabla.Rows[0]["nombreArticulo"].ToString();
                        ventanaAgregarArticulo.insertarSeccion.Text = clientetabla.Rows[0]["seccion"].ToString();
                        ventanaAgregarArticulo.insertaPrecio.Text = clientetabla.Rows[0]["precio"].ToString();
                        ventanaAgregarArticulo.insertaFecha.Text = clientetabla.Rows[0]["fecha"].ToString();
                        ventanaAgregarArticulo.insertaPaisOrigen.Text = clientetabla.Rows[0]["paisOrigen"].ToString();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());

                }


                //detiene el flujo de ejecucion
                ventanaAgregarArticulo.ShowDialog();

                MostrarArticulos();


                //MessageBox.Show("Cliente actualizado correctamenente");
            }
            else
            {
                MessageBox.Show("Debe seleccionar algun articulo", "Error", MessageBoxButton.OK, MessageBoxImage.Stop);
            }

        }

    }
}

