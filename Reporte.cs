using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BcaVeterinaria;
using DevExpress.XtraGrid.Columns;

namespace Veterinaria
{
    public partial class Reporte : Form
    {
        public Reporte()
        {
            InitializeComponent();
            #region NO BORRAR
            radioButton1.Parent = pictureEdit2;
            radioButton2.Parent = pictureEdit2;
            simpleButton1.Parent = pictureEdit2;
            pictureEdit1.Parent = pictureEdit2;
            label1.Parent = pictureEdit2;
            gridControl1.Visible = false;
            gridControl2.Visible = false;
            #endregion
        }

        Class1 class1 = new Class1();

        #region LOAD REPORTE
        private void Reporte_Load(object sender, EventArgs e)
        {

        }
        #endregion

        #region BOTON DE BUSCAR
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    gridControl1.Visible = false;
            //    gridControl2.Visible = false;
            //    // Limpiar los DataSource antes de asignar uno nuevo
            //    gridControl1.DataSource = null;
            //    gridControl2.DataSource = null;

            //    DateTime FechaInicio = dateTimePicker1.Value.Date;
            //    DateTime FechaFinal = dateTimePicker2.Value.Date;

            //    DataTable datosAnimal = null;
            //    DataTable datosCita = null;

            //    if (radioButton1.Checked)
            //    {
            //        datosAnimal = class1.ConsultarPorFechaAAnimal(FechaInicio, FechaFinal);
            //        // Asegurarse de que ambos gridControls sean visibles
            //        gridControl1.Visible = true;
            //    }
            //    else if (radioButton2.Checked)
            //    {
            //        datosCita = class1.ConsultarPorFechaACita(FechaInicio, FechaFinal);
            //        gridControl2.Visible = true;
            //    }

            //    // Asignar la fuente de datos y ajustar columnas para gridControl1
            //    if (datosAnimal != null && datosAnimal.Rows.Count > 0)
            //    {
            //        gridControl1.DataSource = datosAnimal;
            //        gridView1.PopulateColumns();
            //        gridView1.BestFitColumns();
            //        gridControl1.RefreshDataSource();
            //    }
            //    else if (radioButton1.Checked)
            //    {
            //        MessageBox.Show("No se encontraron datos para el rango de fechas seleccionado (Animal).");
            //    }

            //    // Asignar la fuente de datos y ajustar columnas para gridControl2
            //    if (datosCita != null && datosCita.Rows.Count > 0)
            //    {
            //        gridControl2.DataSource = datosCita;
            //        gridView2.PopulateColumns();
            //        gridView2.BestFitColumns();
            //        gridControl2.RefreshDataSource();
            //    }
            //    else if (radioButton2.Checked)
            //    {
            //        MessageBox.Show("No se encontraron datos para el rango de fechas seleccionado (Cita).");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Error: " + ex.Message);
            //}
            try
            {
                gridControl1.Visible = false;
                gridControl2.Visible = false;
                // Limpiar los DataSource antes de asignar uno nuevo
                gridControl1.DataSource = null;
                gridControl2.DataSource = null;

                DateTime FechaInicio = dateTimePicker1.Value.Date;
                DateTime FechaFinal = dateTimePicker2.Value.Date;

                DataTable datosAnimal = null;
                DataTable datosCita = null;

                Class1 class1 = new Class1();

                if (radioButton1.Checked)
                {
                    datosAnimal = class1.ConsultarPorFechaAAnimal(FechaInicio, FechaFinal);
                    // Asegurarse de que ambos gridControls sean visibles
                    gridControl1.Visible = true;

                    // Asignar la fuente de datos y ajustar columnas para gridControl1
                    if (datosAnimal != null && datosAnimal.Rows.Count > 0)
                    {
                        gridControl1.DataSource = datosAnimal;
                        gridView1.PopulateColumns();
                        gridView1.BestFitColumns();
                        gridControl1.RefreshDataSource();
                    }
                    else
                    {
                        MessageBox.Show("No se encontraron datos para el rango de fechas seleccionado (Animal).");
                    }
                }
                else if (radioButton2.Checked)
                {
                    datosCita = class1.ConsultarPorFechaACita(FechaInicio, FechaFinal);
                    gridControl2.Visible = true;

                    // Asignar la fuente de datos y ajustar columnas para gridControl2
                    if (datosCita != null && datosCita.Rows.Count > 0)
                    {
                        gridControl2.DataSource = datosCita;

                        // Configurar el formato de visualización de la columna de fecha y hora
                        gridView2.PopulateColumns();
                        gridView2.Columns["FechaYHora"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                        gridView2.Columns["FechaYHora"].DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"; // Ajusta el formato según tus preferencias
                        gridView2.BestFitColumns();
                        gridControl2.RefreshDataSource();
                    }
                    else
                    {
                        MessageBox.Show("No se encontraron datos para el rango de fechas seleccionado (Cita).");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }
            #endregion

            #region NO BORRAR
            private void gridControl1_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region LOAD DE HORA
        private void gridControl2_Load(object sender, EventArgs e)
        {
         
        }
        #endregion
    }
}
