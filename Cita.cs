using BcaVeterinaria;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BcaVeterinaria;
using System.Data.SqlClient;
using DevExpress.XtraGrid.Columns;

namespace Veterinaria
{
    public partial class Cita : Form
    {
        public Cita()
        {
            InitializeComponent();
            #region NO TOCAR
            LoadNextFolio();
            LoadAnimalIds();
            label1.Parent = pictureEdit2;
            label2.Parent = pictureEdit2;
            label3.Parent = pictureEdit2;
            label4.Parent = pictureEdit2;
            label5.Parent = pictureEdit2;
            label6.Parent = pictureEdit2;
            label7.Parent = pictureEdit2;
            label8.Parent = pictureEdit2;
            gridControl1.Parent = pictureEdit2;
            gridControl2.Parent = pictureEdit2;
            pictureEdit1.Parent = pictureEdit2;
            simpleButton1.Parent = pictureEdit2;
            simpleButton2.Parent = pictureEdit2;
            gridControl1.Visible = false;
            gridControl2.Visible = false;
            #endregion
        }
        Class1 class1 = new Class1();

        #region # FOLIO
        private void LoadNextFolio()
        {
            try
            {
                int nextFolio = class1.GetNextFolio();
                textEdit1.Text = nextFolio.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener el siguiente folio: " + ex.Message);
            }
            
        }
        #endregion

        #region BOTON GUARDAR
        private void simpleButton1_Click(object sender, EventArgs e)
        {

            try
            {
                // Convertir los valores a los tipos de datos adecuados
                int folio1;
                if (!int.TryParse(textEdit1.Text, out folio1))
                {
                    MessageBox.Show("Error: El valor de Folio no es un número válido.");
                    return;
                }

                string nombreCita = textEdit2.Text;

                string numTelefono = textEdit3.Text;
                int maxLength = 10; // Longitud máxima de la columna NoTelefono
                if (numTelefono.Length > maxLength)
                {
                    numTelefono = numTelefono.Substring(0, maxLength);
                }

                int idAnimal1;
                if (!int.TryParse(comboBox1.Text, out idAnimal1))
                {
                    MessageBox.Show("Error: El valor de ID Animal no es un número válido.");
                    return;
                }

                string comentario = textEdit7.Text;

                float costoCita;
                if (!float.TryParse(textEdit6.Text, out costoCita))
                {
                    MessageBox.Show("Error: El valor de Costo de Cita no es un número válido.");
                    return;
                }

              // DateTime fechaYHora = dateTimePicker1.Value;
              DateTimeOffset fechaYHora = dateTimeOffsetEdit1.DateTimeOffset;

                //// Mostrar los valores obtenidos para verificar
                //MessageBox.Show(folio1.ToString());
                //MessageBox.Show(nombreCita);
                //MessageBox.Show(numTelefono);
                //MessageBox.Show(idAnimal1.ToString());
                //MessageBox.Show(comentario);
                //MessageBox.Show(costoCita.ToString());
               // MessageBox.Show(fechaYHora.ToString());

                // Llamar al método InsertarDatosCita de la clase Class1
                Class1 class1 = new Class1();
                bool resultado = class1.InsertarDatosCita(folio1, nombreCita, numTelefono, idAnimal1, costoCita, comentario, fechaYHora /*fechaYHora*/);

                // Verificar el resultado de la inserción
                if (resultado)
                {
                  //  MessageBox.Show(fechaYHora.ToString());
                    MessageBox.Show("Se insertó correctamente");
                    LoadNextFolio();
                }
                else
                {
                    MessageBox.Show("Ocurrió un error al insertar la cita");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha surgido un error: " + ex.Message);
            }
        }
        #endregion
       
        #region LOAD DE CITA
        private void Cita_Load(object sender, EventArgs e)
        {
            
            //LlenarComboBoxAnimales();
            gridView1.OptionsBehavior.Editable = false;
            gridView2.OptionsBehavior.Editable = false;
        }
        #endregion

        #region BOTON CONSULTAR
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                Class1 clase23 = new Class1();
                DataTable resultadoConsulta = clase23.ConsultarCita();
                gridControl1.DataSource = resultadoConsulta;
                MessageBox.Show("Se Consulto Correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                
            }
            gridControl1.Visible = true;
        }
        #endregion


        #region NO BORRAR   
        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {
            
        }
        #endregion

        #region NO BORRAR
        private void comboBox1_TextChanged(object sender, EventArgs e)
        {

        }
        #endregion

        #region OPCIONES EN COMBOBOX
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idSeleccionado = (int)comboBox1.SelectedItem;
            LoadAnimalDetails(idSeleccionado);
            gridControl2.Visible = true;
        }
        #endregion

        #region CARGA TODOS LOS ANIMALES
        private void LoadAnimalIds()
        {
            string connectionString = class1.Cadenaconexion();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT ID FROM Animal", connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    comboBox1.Items.Add(reader.GetInt32(0));
                }
            }
        }
        #endregion

        #region EXTRAE LA INFO DE UNA ANIMAL EN ESPECIFICO 
        private void LoadAnimalDetails(int id)
        {
            string connectionString = class1.Cadenaconexion();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Animal WHERE ID = @ID", connection);
                command.Parameters.AddWithValue("@ID", id);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                gridControl2.DataSource = dataTable;
            }
        }
        #endregion

        #region NO BORRAR
        private void textEdit1_Leave(object sender, EventArgs e)
        {
            
           
        }
        #endregion

        #region CARGA DE HORA
        private void gridControl1_Load(object sender, EventArgs e)
        {
            // Obtener la columna de fecha y hora
            GridColumn fechaYHoraColumn = gridView1.Columns["FechaYHora"];

            if (fechaYHoraColumn != null)
            {
                // Establecer el formato de visualización de la columna de fecha y hora
                fechaYHoraColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                fechaYHoraColumn.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"; // Ajusta el formato según tus preferencias
            }
        }
        #endregion
    }
}
