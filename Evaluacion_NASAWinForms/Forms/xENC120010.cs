using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Evaluacion_NASAWinForms.Forms
{
    public partial class xENC120010 : NASA.CONSOFT.WinForms.ConsoftMainMenuRibbonMDIForm
    {
        public xENC120010()
        {
            InitializeComponent();
        }
        private void xENC120010_Load(object sender, EventArgs e)
        {
            blblForma.Caption = this.Name;
            Evaluacion_NASACore.BusinessLayer.CLS_DBCURSOS_BAL CursosBal = new Evaluacion_NASACore.BusinessLayer.CLS_DBCURSOS_BAL();
            DataTable data = CursosBal.GetTable();
            dataGridView1.DataSource = data;
        }

        private void Btn_BuscarArch_Click(object sender, EventArgs e)
        {
            string Ruta = string.Empty;
            OpenFileDialog openFile = new OpenFileDialog();
            if(openFile.ShowDialog() == DialogResult.OK)
            {
                Ruta = openFile.FileName;
            }
            Ruta_text.Text = Ruta;
        }

        private void Guardar_Btn_Click(object sender, EventArgs e)
        {
            if (bEnableEvents)
            {
                bEnableEvents = false;
                try
                {
                    var RegistroInfo = new Evaluacion_NASACore.EntityObjects.CLS_REGISTRO_info();
                    RegistroInfo.nompart = textEdit2.Text;
                    RegistroInfo.id_curso = Convert.ToInt32(id_curso.Text);
                    RegistroInfo.pago = Ruta_text.Text;
                    RegistroInfo.importe = Convert.ToInt32(textBox1.Text);

                    var registrosBal = new Evaluacion_NASACore.BusinessLayer.CLS_REGISTRO_BAL();
                    registrosBal.Save(RegistroInfo);

                    id_curso.Text = "";
                    Ruta_text.Text = "";
                    textEdit2.Text = "";
                    textBox1.Text = "";
                    NameCurs.Text = "";
                    MessageBox.Show("Registros Almacenados Correctamente!","Información",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Buscar_Btn_Click: {ex.Message}");
                }
                finally
                {
                    bEnableEvents = true;
                }

            }
        }

        private void Btn_Cargar_Click(object sender, EventArgs e)
        {
            int id_cur = Convert.ToInt32(id_curso.Text);
            Evaluacion_NASACore.BusinessLayer.CLS_DBCURSOS_BAL cursoBal = new Evaluacion_NASACore.BusinessLayer.CLS_DBCURSOS_BAL();
            Evaluacion_NASACore.EntityObjects.CLS_DBCURSOS_info cursosInfo = cursoBal.GetEntityObject(id_cur);
            textBox1.Text = cursosInfo.importe.ToString();
            NameCurs.Text = cursosInfo.nomcurso;
        }

        private void RibbonControl_Click(object sender, EventArgs e)
        {

        }
    }
}
