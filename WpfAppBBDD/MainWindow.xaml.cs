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
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static SqlConnection conn;
        private static string conexion;

        public MainWindow()
        {
            InitializeComponent();

            //Llamada a las funciones de la cadena de conexion y de la consultas Sql
            DevolverCadenaConexion();

            EspecificacionDeConsultas();

            //Instancio la clase creada
            MuestraClientes();
        }

        //Cadena de conexion a la base de datos
        public static string DevolverCadenaConexion()
        {
            conexion = ConfigurationManager.ConnectionStrings["WpfAppBBDD.Properties.Settings.BasedeDatos1ConnectionString"].ConnectionString;

            return conexion;
        }

        //Le especifico que voy a hacer consultas sql,
        //con la conexion a la base de datos creada arriba
        public static SqlConnection EspecificacionDeConsultas()
        {
            conn = new SqlConnection(conexion);

            return conn;
        }

        private void MuestraClientes()
        {

            try
            {

                //Consulta => devuelve una tabla con registros
                string consulta = "SELECT * FROM CLIENTE";

                //Adaptar las tablas de la base de datos a una
                //estructura donde se pueda almacenar toda esa información.

                //Se le especifica al adapter que usando la conexion con la base de datos
                //ejecutar la consulta creada arriba.
                SqlDataAdapter adapter = new SqlDataAdapter(consulta, conn);


                //Almacenar en un datatable, la informacion que viene de la tabla Cliente.
                using (adapter)
                {
                    //clientaTabla => va almacer toda la info de la tabla Clientes
                    DataTable cliientesTabla = new DataTable();

                    //Relleno con la informacion que viene de la tabla.
                    adapter.Fill(cliientesTabla);

                    //Especificar el unico campo que quiero mostrar
                    listaClientes.DisplayMemberPath = "nombre";

                    //Campo clave => para usarlo para actualizar,
                    //eliminar, ver mas informacion etc.
                    listaClientes.SelectedValuePath = "Id";

                    //Origen de los datos
                    listaClientes.ItemsSource = cliientesTabla.DefaultView;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void MuestraPedidos()
        {

            try
            {
                if (listaClientes.SelectedValue != null)
                {

                    string consulta = "SELECT * FROM PEDIDO P INNER JOIN CLIENTE C ON C.ID = P.cCliente" +
                        " WHERE C.ID=@ClienteId";

                    //Ejecutar una consulta sql con parametros
                    SqlCommand sqlcommand = new SqlCommand(consulta, conn);

                    SqlDataAdapter adapter = new SqlDataAdapter(sqlcommand);


                    using (adapter)
                    {
                        sqlcommand.Parameters.AddWithValue("@ClienteId", listaClientes.SelectedValue);

                        DataTable pedidostabla = new DataTable();

                        adapter.Fill(pedidostabla);

                        pedidosCliente.DisplayMemberPath = "fechaPedido";

                        pedidosCliente.SelectedValuePath = "Id";

                        pedidosCliente.ItemsSource = pedidostabla.DefaultView;

                        var pedido = Convert.ToInt32(pedidostabla.DefaultView.Count);

                        if(pedido == 0)
                        {
                            MessageBox.Show("Este cliente no tiene ningun pedido", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }
                }
                else
                {
                    pedidosCliente.ItemsSource = null;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }

        private void ListaClientes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MuestraPedidos();
        }
 
      
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Agregar ventanaAgregar = new Agregar();
            ventanaAgregar.Btn.Content = "Agregar";

            ventanaAgregar.ShowDialog();

            MuestraClientes();
        }

        private void BtnMoreInfo_Click(object sender, RoutedEventArgs e)
        {
            if (listaClientes.SelectedValue != null)
            {
                MasInfo ventanaMasInfo = new MasInfo((int)listaClientes.SelectedValue);

                try
                {
                    string consulta = "Select * FROM CLIENTE WHERE Id=@ClienteId";



                    string consulta2 = "SELECT *, CONCAT(A.Id, ' - ', A.nombreArticulo, ' ', P.fechaPedido, ' ', P.formadePago)" +
                                        " AS INFOCOMPLETA FROM PEDIDO P " +
                                        "INNER JOIN Cliente C ON C.Id = P.cCliente " +
                                        "INNER JOIN ARTICULO A ON A.ID = P.cArticulo " +
                                        "WHERE P.cCliente = @ClienteId";

                    SqlCommand sqlCommand = new SqlCommand(consulta, conn);
                    SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);

                    using (adapter)
                    {
                        sqlCommand.Parameters.AddWithValue("@ClienteId", listaClientes.SelectedValue);

                        DataTable clientetabla = new DataTable();
                        adapter.Fill(clientetabla);

                        ventanaMasInfo.insertaNombreCliente.Text = clientetabla.Rows[0]["nombre"].ToString();
                        ventanaMasInfo.insertaDireccionCliente.Text = clientetabla.Rows[0]["direccion"].ToString();
                        ventanaMasInfo.insertaPoblacionCliente.Text = clientetabla.Rows[0]["poblacion"].ToString();
                        ventanaMasInfo.insertaTelefonoCliente.Text = clientetabla.Rows[0]["telefono"].ToString();
                        ventanaMasInfo.BtnUpdate.Content = "Editar";
                    }

                    SqlCommand sqlCommand2 = new SqlCommand(consulta2, conn);
                    SqlDataAdapter adapter2 = new SqlDataAdapter(sqlCommand2);

                    using (adapter2)
                    {
                        sqlCommand2.Parameters.AddWithValue("@ClienteId", listaClientes.SelectedValue);

                        DataTable clientetabla = new DataTable();

                        adapter2.Fill(clientetabla);

                        ventanaMasInfo.pedidosCliente.DisplayMemberPath = "INFOCOMPLETA";
                        ventanaMasInfo.pedidosCliente.SelectedValuePath = "Id";
                        ventanaMasInfo.pedidosCliente.ItemsSource = clientetabla.DefaultView;
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());

                }


                //detiene el flujo de ejecucion
                ventanaMasInfo.ShowDialog();

                MuestraClientes();

                //MessageBox.Show("Cliente actualizado correctamenente");
            }
            else
            {
                MessageBox.Show("Debe seleccionar algun cliente", "Error", MessageBoxButton.OK, MessageBoxImage.Stop);
            }
        }


        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Actualizar ventanaPedidos = new Actualizar(0);

            ventanaPedidos.Btn.Content = "Agregar articulo";

            ventanaPedidos.BtnExit.Content = "Eliminar";

            ventanaPedidos.BtnEdit.Content = "Editar";

            ventanaPedidos.FormaPago.Visibility = Visibility.Hidden;
            ventanaPedidos.insertaFormaPago.Visibility = Visibility.Hidden;

            ventanaPedidos.ShowDialog();
        }
        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            TodosPedidos ventanaPedidos = new TodosPedidos();


            ventanaPedidos.ShowDialog();

            MuestraPedidos();
        }



    }
}
