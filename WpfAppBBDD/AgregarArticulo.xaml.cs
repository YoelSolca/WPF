using System;
using System.Collections.Generic;
using System.Configuration;
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
    /// Lógica de interacción para AgregarArticulo.xaml
    /// </summary>
    public partial class AgregarArticulo : Window
    {
        private SqlConnection conn;
        private int id;

        public AgregarArticulo(int idCliente)
        {
            InitializeComponent();

            id = idCliente;

            conn = MainWindow.EspecificacionDeConsultas();
        }


        //Añadir un nuevo articulo
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (id == 0 && !String.IsNullOrEmpty(insertarSeccion.Text) && !String.IsNullOrEmpty(insertaNombreArticulo.Text)
                && !String.IsNullOrEmpty(insertaFecha.Text) && !String.IsNullOrEmpty(insertaPaisOrigen.Text))
            {

                string consulta = "INSERT INTO ARTICULO (seccion, nombreArticulo, precio, fecha, paisOrigen) VALUES (@seccion, @nombreArticulo, @precio, @fecha, @paisOrigen)";

                SqlCommand command = new SqlCommand(consulta, conn);

                conn.Open();

                command.Parameters.AddWithValue("@seccion", insertarSeccion.Text);
                command.Parameters.AddWithValue("@nombreArticulo", insertaNombreArticulo.Text);
                command.Parameters.AddWithValue("@precio", insertaPrecio.Text);
                command.Parameters.AddWithValue("@fecha", insertaFecha.Text);
                command.Parameters.AddWithValue("@paisOrigen", insertaPaisOrigen.Text);

                //ejecutar este tipo de consulta
                command.ExecuteNonQuery();

                conn.Close();


                MessageBox.Show("Articulo creado correctamente");
                this.Close();
            }

            else if (id != 0)
            {
                EditarArticulo();
            }
            else
            {
                MessageBox.Show("Debe completar todos los campos", "Error", MessageBoxButton.OK, MessageBoxImage.Stop);
            }
        }

        private void EditarArticulo()
        {
            string consulta = "UPDATE ARTICULO SET seccion = @seccion, nombreArticulo = @nombreArticulo, precio = @precio, fecha = @fecha, paisOrigen = @paisOrigen WHERE Id= " + id;


            SqlCommand command = new SqlCommand(consulta, conn);

            conn.Open();
            command.Parameters.AddWithValue("@nombreArticulo", insertaNombreArticulo.Text);
            command.Parameters.AddWithValue("@seccion", insertarSeccion.Text);
            command.Parameters.AddWithValue("@precio", insertaPrecio.Text);
            command.Parameters.AddWithValue("@fecha", insertaFecha.Text);
            command.Parameters.AddWithValue("@paisOrigen", insertaPaisOrigen.Text);

            //ejecutar este tipo de consulta
            command.ExecuteNonQuery();

            conn.Close();

            MessageBox.Show("Articulo actualizado correctamente");

            this.Close();
        }

    }
}
