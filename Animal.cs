using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using BcaVeterinaria;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics.Eventing.Reader;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.SqlClient;

namespace Veterinaria
{
    public partial class Animal : Form
    {
        public Animal()
        {
            InitializeComponent();

            #region NO TOCAR
            label1.Parent = pictureEdit3;
            label2.Parent = pictureEdit3;
            label3.Parent = pictureEdit3;
            label4.Parent = pictureEdit3;
            label5.Parent = pictureEdit3;
            label6.Parent = pictureEdit3;
            label7.Parent = pictureEdit3;
            label8.Parent = pictureEdit3;
            simpleButton1.Parent = pictureEdit3;
            simpleButton2.Parent = pictureEdit3;
            simpleButton3.Parent = pictureEdit3;
            simpleButton4.Parent = pictureEdit3;
            pictureEdit1.Parent = pictureEdit3;
            pictureEdit2.Parent = pictureEdit3;
            gridControl1.Visible = false;
            #endregion

        }

        Class1 class1 = new Class1();

        #region BOTON DE GUARDAR
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            String id = textEdit1.Text;
            String nombre = textEdit2.Text;
            String especie = textEdit3.Text;
            String raza = textEdit4.Text;
            String peso = textEdit5.Text;
            String talla = textEdit6.Text;
            DateTime fecha = dateTimePicker1.Value;

            try
            {
                // Convertir los valores a los tipos de datos adecuados
                int ID = int.Parse(id);
                float Peso = float.Parse(peso);
                float Talla = float.Parse(talla);
                
                bool resultado = class1.InsertarDatosAnimal(ID, nombre, especie, raza, Peso, Talla, fecha.Date);
                if (resultado)
                {

                    MessageBox.Show("se inserto correctamente");
                   
                }
                else
                {
                   

                    MessageBox.Show("ocurrio un error");
                }
            }
            catch (FormatException fe)
            {
                MessageBox.Show("Error en el formato de entrada: " + fe.Message);
            }
            textEdit1.Text = "";
            textEdit2.Text = "";
            textEdit3.Text = "";
            textEdit4.Text = "";
            textEdit5.Text = "";
            textEdit6.Text = "";
            gridControl1.Visible = false;
        }
        #endregion

        #region NO BORRAR
        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }
        #endregion

        #region DESABILITA EL BOTON DE GUARDAR CUANDO YA EXISTA UN ID
        private void CheckIdField()
        {
            if (!string.IsNullOrEmpty(textEdit1.Text))
            {
                if (int.TryParse(textEdit1.Text, out int id))
                {
                    if (IdExists(id))
                    {
                        simpleButton1.Enabled = false;
                    }
                    else
                    {
                        ClearFields();
                        simpleButton1.Enabled = true;
                    }
                }
            }
        }
        #endregion

        #region COMPRUEBA SI HAY UN ID
        private bool IdExists(int id)
        {
            bool exists = false;
            try
            {
                using (SqlConnection conn = class1.AbrirConexion())
                {
                    string query = "SELECT COUNT(*) FROM Animal WHERE ID = @ID";
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@ID", id);
                        int count = (int)command.ExecuteScalar();
                        conn.Close();
                        exists = count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al comprobar el ID: {ex.Message}");
            }
            return exists;
        }
        #endregion

        #region LIMPIA LOS CAMPOS 
        private void ClearFields()
        {
            // Limpiar los campos del formulario
            textEdit2.Text = string.Empty;
            textEdit3.Text = string.Empty;
            textEdit4.Text = string.Empty;
            textEdit5.Text = string.Empty;
            textEdit6.Text = string.Empty;
            dateTimePicker1.Value = DateTime.Now; // O algún valor por defecto
        }
        #endregion

        #region BOTON CONSULTAR
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                Class1 clase = new Class1();
                DataTable resultadoConsulta = clase.ConsultarAnimal();
                gridControl1.DataSource = resultadoConsulta;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            gridControl1.Visible = true;
        }
        #endregion

        #region BOTON DE ELIMINAR
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            try
            {
                // Mostrar un diálogo de confirmación
                DialogResult confirmResult = MessageBox.Show("¿DESEAS ELIMINAR?", "Confirmación", MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    // Mostrar un cuadro de diálogo para ingresar el ID
                    string idInput = Microsoft.VisualBasic.Interaction.InputBox("INGRESE SU ID", "Eliminar Animal", "");

                    if (int.TryParse(idInput, out int id))
                    {
                        Class1 class2 = new Class1();
                        bool result = class2.EliminarAnimalPorID(id);

                        if (result)
                        {
                            MessageBox.Show("Animal eliminado exitosamente.");
                        }
                        else
                        {
                           MessageBox.Show("No se encontró el animal con el ID proporcionado.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("ID inválido. Por favor ingrese un número entero.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            textEdit1.Text = "";
            textEdit2.Text = "";
            textEdit3.Text = "";
            textEdit4.Text = "";
            textEdit5.Text = "";
            textEdit6.Text = "";
            gridControl1.Visible= false;
        }
        #endregion

        bool animales = false;

        #region CARGA LOS DATOS CUANDO TE SALES DEL TEXTEEDIT
        private void textEdit1_Leave(object sender, EventArgs e)
        {

            if (textEdit1.Text != "")
            {
                try
                {
                    string cadenaconexion = class1.Cadenaconexion();
                    DataTable data = new DataTable();
                    using (SqlConnection conexion = new SqlConnection(cadenaconexion))
                    {
                        conexion.Open();
                        string Query = "SELECT Nombre, Especie, Raza, Peso, Talla, FechadeNacimiento FROM Animal WHERE ID = @ID";
                        SqlCommand command = new SqlCommand(Query, conexion);
                        command.Parameters.AddWithValue("@ID", textEdit1.Text);
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            // Mostrar datos si el ID existe
                            textEdit2.Text = reader["Nombre"].ToString();
                            textEdit3.Text = reader["Especie"].ToString();
                            textEdit4.Text = reader["Raza"].ToString();
                            textEdit5.Text = reader["Peso"].ToString();
                            textEdit6.Text = reader["Talla"].ToString();
                            dateTimePicker1.Value = Convert.ToDateTime(reader["FechadeNacimiento"]);
                            animales = true; // Bandera que indica que se encontraron datos
                        }
                        else
                        {
                            // Permitir el registro de nuevos datos si el ID no existe
                            MessageBox.Show("El ID especificado no existe en la base de datos. Puedes proceder con el registro.");
                            animales = false; // Bandera que indica que no se encontraron datos
                                              // Aquí puedes habilitar los controles necesarios para el registro de nuevos datos
                            textEdit2.Text = ""; // Limpiar los campos para que el usuario pueda ingresar nuevos datos
                            textEdit3.Text = "";
                            textEdit4.Text = "";
                            textEdit5.Text = "";
                            textEdit6.Text = "";
                            dateTimePicker1.Value = DateTime.Today;
                        }
                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al recuperar datos: " + ex.Message);
                }
            }


        }
        #endregion

        #region BONTON DE MODIFICAR
        private void simpleButton4_Click(object sender, EventArgs e)
        {
            // Crear una instancia de la clase que contiene la función ActualizarDatosAnimal
            Class1 class1 = new Class1();

            // Obtener los datos de los controles
            int id = int.Parse(textEdit1.Text);
            string nombre = textEdit2.Text;
            string especie = textEdit3.Text;
            string raza = textEdit4.Text;
            float peso = float.Parse(textEdit5.Text);
            float talla = float.Parse(textEdit6.Text);
            DateTime fechadeNacimiento = dateTimePicker1.Value;

            // Llamar a la función ActualizarDatosAnimal
            bool resultado = class1.ActualizarDatosAnimal(id, nombre, especie, raza, peso, talla, fechadeNacimiento);

            // Verificar el resultado
            if (resultado)
            {
                MessageBox.Show("Datos actualizados correctamente.");
            }
            else
            {
                MessageBox.Show("Error al actualizar los datos.");
            }
            textEdit1.Text = "";
            textEdit2.Text = "";
            textEdit3.Text = "";
            textEdit4.Text = "";
            textEdit5.Text = "";
            textEdit6.Text = "";
            gridControl1.Visible = false;
        }
        #endregion

        #region COMPRUEBA SI EXISTE EL ID CUANDO ESTE SE ESCRIBE EN EL TEXTEDIT
        private void textEdit1_TextChanged(object sender, EventArgs e)
        {
            CheckIdField();
        }
        #endregion

        #region INHABILITAR PARA ESCRIBIR EN EL GRID
        private void Animal_Load(object sender, EventArgs e)
        {
            //CheckIdField();
            gridView1.OptionsBehavior.Editable = false;
        }
        #endregion

        #region NO BORRAR
        private void gridControl1_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region ESCONDE EL GRID CUANDO TE SALES DEL BOTON 
        private void simpleButton2_Leave(object sender, EventArgs e)
        {
            gridControl1.Visible = false;
        }
        #endregion


    }
}
