using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
using System.Windows.Shapes;

namespace WpfAppBBDD
{
    /// <summary>
    /// Lógica de interacción para MasInfo.xaml
    /// </summary>
    public partial class MasInfo : Window
    {
        private int id;
        private SqlConnection conn;

        public MasInfo(int idCliente)
        {
            id = idCliente;

            conn = MainWindow.EspecificacionDeConsultas(); 

            InitializeComponent();
        }

        private void MuestraTodosPedidos()
        {
            try
            {
                string consulta = "SELECT *, CONCAT(A.Id, ' - ', A.nombreArticulo, ' ', P.fechaPedido, ' ', P.formadePago)" +
                                         " AS INFOCOMPLETA FROM PEDIDO P " +
                                         "INNER JOIN Cliente C ON C.Id = P.cCliente " +
                                         "INNER JOIN ARTICULO A ON A.ID = P.cArticulo " +
                                         "WHERE P.cCliente = @ClienteId";

                SqlCommand sqlCommand = new SqlCommand(consulta, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);

                using (adapter)
                {
                    sqlCommand.Parameters.AddWithValue("@ClienteId", id);

                    DataTable clientetabla = new DataTable();
                    adapter.Fill(clientetabla);

                    pedidosCliente.DisplayMemberPath = "INFOCOMPLETA";
                    pedidosCliente.SelectedValuePath = "@ClienteId";
                    pedidosCliente.ItemsSource = clientetabla.DefaultView;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            ActualizarArticulo ventanaArticulos = new ActualizarArticulo(id);

            ventanaArticulos.Btn.Content = "Añadir";

            ventanaArticulos.BtnExit.Content = "Cancelar";


            ventanaArticulos.BtnEdit.Visibility = Visibility.Hidden;

            ventanaArticulos.menu.Visibility = Visibility.Hidden;

            ventanaArticulos.ShowDialog();


            MuestraTodosPedidos();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var resp = MessageBox.Show("¿Esta seguro que desea eliminar este cliente, toda información respecto a este sera borrado?", "", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (resp.ToString() == "Yes")
            {
                string consulta = "DELETE FROM CLIENTE WHERE ID =@CLIENTEID";

                string consulta2 = "DELETE FROM PEDIDO WHERE cCliente = @CLIENTEID";

                SqlCommand command = new SqlCommand(consulta, conn);
                SqlCommand sqlcommand = new SqlCommand(consulta2, conn);

                conn.Open();

                command.Parameters.AddWithValue("@CLIENTEID", id);

                sqlcommand.Parameters.AddWithValue("@CLIENTEID", id);


                sqlcommand.ExecuteNonQuery();

                command.ExecuteNonQuery();

                conn.Close();

                MessageBox.Show("Cliente eliminado correctamenente");
                this.Close();
            }
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            string consulta = "UPDATE CLIENTE SET nombre = @nombre, direccion = @direccion, poblacion = @poblacion, telefono = @telefono WHERE Id= " + id;


            SqlCommand command = new SqlCommand(consulta, conn);

            conn.Open();

            command.Parameters.AddWithValue("@nombre", insertaNombreCliente.Text);
            command.Parameters.AddWithValue("@direccion", insertaDireccionCliente.Text);
            command.Parameters.AddWithValue("@poblacion", insertaPoblacionCliente.Text);
            command.Parameters.AddWithValue("@telefono", insertaTelefonoCliente.Text);

            //ejecutar este tipo de consulta
            command.ExecuteNonQuery();

            conn.Close();

            MessageBox.Show("Cliente actualizado correctamente");

            this.Close();
        }
    }
}
