using BcaVeterinaria;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Veterinaria
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            #region NO BORRAR
            label1.Parent = pictureEdit1;
            label2.Parent = pictureEdit1;
            simpleButton1.Parent = pictureEdit1;
            simpleButton2.Parent = pictureEdit1;
            simpleButton3.Parent = pictureEdit1;
            #endregion
        }

        #region MUESTRA EL FORMS DE ANIMALES
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            
            Animal animal = new Animal();   
            animal.Show();
        }
        #endregion

        #region BOTON CITA
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Cita cta = new Cita();  
            cta.Show();
        }
        #endregion

        #region NO BORRAR
        private void Form1_Load(object sender, EventArgs e)
        {
           
        }
        #endregion

        #region BOTON DEL REPORTE
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            Reporte report = new Reporte();
            report.Show();
        }
        #endregion
    }
}
