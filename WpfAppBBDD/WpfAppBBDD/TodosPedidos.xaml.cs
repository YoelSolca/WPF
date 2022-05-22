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
    /// Lógica de interacción para TodosPedidos.xaml
    /// </summary>
    public partial class TodosPedidos : Window
    {
        private SqlConnection conn;

        public TodosPedidos()
        {
            InitializeComponent();

            conn = MainWindow.EspecificacionDeConsultas();

            MuestraTodosPedidos();
        }

        private void MuestraTodosPedidos()
        {
            try
            {

                string consulta = "SELECT *, CONCAT(cCliente, ' ' , fechaPedido, ' ', formadePago) AS INFOCOMPLETA FROM PEDIDO";

                SqlDataAdapter adapter = new SqlDataAdapter(consulta, conn);

                using (adapter)
                {
                    DataTable pedidostabla = new DataTable();

                    adapter.Fill(pedidostabla);

                    todosPedidos.DisplayMemberPath = "INFOCOMPLETA";
                    todosPedidos.SelectedValuePath = "Id";
                    todosPedidos.ItemsSource = pedidostabla.DefaultView;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (todosPedidos.SelectedValue != null)
            {

                var resp = MessageBox.Show("¿Esta seguro que desea eliminar este pedido, esta operación es irreversible?", "", MessageBoxButton.YesNo, MessageBoxImage.Question);


                if (resp.ToString() == "Yes")
                {

                    string consulta = "DELETE FROM PEDIDO WHERE ID = @PEDIDOID";

                    SqlCommand command = new SqlCommand(consulta, conn);

                    conn.Open();

                    command.Parameters.AddWithValue("@PEDIDOID", todosPedidos.SelectedValue);

                    //ejecutar este tipo de consulta
                    command.ExecuteNonQuery();

                    conn.Close();


                    MuestraTodosPedidos();

                    MessageBox.Show("Pedido eliminado correctamenente");

                }

            }
            else
            {
                MessageBox.Show("Debe seleccionar algun pedido", "Error", MessageBoxButton.OK, MessageBoxImage.Stop);
            }
        }


        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            ActualizarArticulo ventaArticulos = new ActualizarArticulo(0);

            ventaArticulos.Btn.Content = "Agregar articulo";

            ventaArticulos.BtnEdit.Content = "Editar";

            ventaArticulos.BtnExit.Content = "Eliminar";

            ventaArticulos.FormaPago.Visibility = Visibility.Hidden;
            ventaArticulos.insertaFormaPago.Visibility = Visibility.Hidden;

            this.Close();

            ventaArticulos.ShowDialog();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
