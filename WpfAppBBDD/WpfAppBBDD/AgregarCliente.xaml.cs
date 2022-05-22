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
    /// Lógica de interacción para Agregar.xaml
    /// </summary>
    public partial class AgregarCliente : Window
    {
        SqlConnection conn;
        public AgregarCliente()
        {
            InitializeComponent();

            conn = MainWindow.EspecificacionDeConsultas();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(!String.IsNullOrEmpty(insertaNombreCliente.Text) && !String.IsNullOrEmpty(insertaDireccionCliente.Text)
                && !String.IsNullOrEmpty(insertaPoblacionCliente.Text) && !String.IsNullOrEmpty(insertaTelefonoCliente.Text))
            {

                string consulta = "INSERT INTO CLIENTE (nombre, direccion, poblacion, telefono) VALUES (@nombre, @direccion, @poblacion, @telefono)";



                SqlCommand command = new SqlCommand(consulta, conn);

                conn.Open();

                    command.Parameters.AddWithValue("@nombre", insertaNombreCliente.Text);
                    command.Parameters.AddWithValue("@direccion", insertaDireccionCliente.Text);
                    command.Parameters.AddWithValue("@poblacion", insertaPoblacionCliente.Text);
                    command.Parameters.AddWithValue("@telefono", insertaTelefonoCliente.Text);

                //ejecutar este tipo de consulta
                command.ExecuteNonQuery();

                conn.Close();

                MessageBox.Show("Cliente agregado correctamente");

                this.Close();

            }
            else
            {
                MessageBox.Show("Debe completar todos los campos", "Error", MessageBoxButton.OK, MessageBoxImage.Stop);
            }
        }
    }
}
