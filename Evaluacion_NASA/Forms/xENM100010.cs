using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Evaluacion_NASA.Forms
{
    public partial class xENM100010 : NASA.CONSOFT.WinForms.ConsoftMainMenuRibbonMDIForm
    {

        #region Variables globales...
        private string ConnectionString = String.Empty;
        #endregion

        #region Propiedades...
        #endregion

        #region Constructores...
        public xENM100010()
        {
            InitializeComponent();
        }
        #endregion

        #region Eventos...
        private void xENM100010_Load(object sender, EventArgs e)
        {
            blblForma.Caption = this.Name;
        }
        private void CategoriasbarButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                var option = new Clases.CLS_MenuOptions("ENAA");
                option.PerformOption();
            }
            catch(Exception ex)
            {
                MessageBox.Show($"CategoriasbarButtonItem_ItemClick: {ex}","Información",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        private void chk_Button_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                var option = new Clases.CLS_MenuOptions("CHK");
                option.PerformOption();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"chk_Button_ItemClick: {ex}", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                var option = new Clases.CLS_MenuOptions("CPC");
                option.PerformOption();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"chk_Button_ItemClick: {ex}", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                var option = new Clases.CLS_MenuOptions("ENAB");
                option.PerformOption();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"chk_Button_ItemClick: {ex}", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                var option = new Clases.CLS_MenuOptions("ENAC");
                option.PerformOption();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"chk_Button_ItemClick: {ex}", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                var option = new Clases.CLS_MenuOptions("ENAD");
                option.PerformOption();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"chk_Button_ItemClick: {ex}", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                var option = new Clases.CLS_MenuOptions("ENAE");
                option.PerformOption();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"chk_Button_ItemClick: {ex}", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void DataServiceButton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GetDataAsync();
        }
        #endregion

        #region Funciones...
        private async System.Threading.Tasks.Task GetDataAsync()
        {
            Clases.CLS_BACKEND backEnd = new Clases.CLS_BACKEND();
            dynamic dataService = await backEnd.ExtracData();
            List<GETDATA> DataList = JsonSerializer.Deserialize<List<GETDATA>>(dataService);
            List<string> identificadores = new List<string>();

            foreach (GETDATA Dataset in DataList)
            {
                string dato = Dataset.ToString();
                string[] palabras = dato.Split(',');
                bool existe = identificadores.Contains(palabras[2]);
                if (existe == false)
                {
                    insertCategoria(palabras[2], palabras[3]);
                }
                insertCurso(palabras[0], palabras[2], palabras[1]);
                identificadores.Add(palabras[2]);
            }
            MessageBox.Show("Datos Registrados Correctamente!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public void insertCategoria(string id, string categoria)
        {
            Evaluacion_NASACore.BusinessLayer.CLS_DBCATALOGOS_BAL CapctBAL = new Evaluacion_NASACore.BusinessLayer.CLS_DBCATALOGOS_BAL();
            Evaluacion_NASACore.EntityObjects.CLS_DBCATALOGOS_info CapctInfo = new Evaluacion_NASACore.EntityObjects.CLS_DBCATALOGOS_info()
            {
                id_categoria = Convert.ToInt32(id),
                nomcat = categoria
            };
            CapctBAL.Save(CapctInfo);
        }
        public void insertCurso(string id, string id_cat, string nomcurso)
        {
            Random r = new Random();
            Evaluacion_NASACore.BusinessLayer.CLS_DBCURSOS_BAL CapctBAL = new Evaluacion_NASACore.BusinessLayer.CLS_DBCURSOS_BAL();
            Evaluacion_NASACore.EntityObjects.CLS_DBCURSOS_info CapctInfo = new Evaluacion_NASACore.EntityObjects.CLS_DBCURSOS_info()
            {
                id_curso = Convert.ToInt32(id),
                id_categoria = Convert.ToInt32(id_cat),
                nomcurso = nomcurso,
                costo = r.Next(100, 2000),
                importe = r.Next(200, 2000)
            };
            CapctBAL.Save(CapctInfo);
        }
        public class GETDATA
        {
            public int id { get; set; }
            public string curso { get; set; }
            public int id_categoria { get; set; }
            public string categoria { get; set; }
            public string fecha_creacion { get; set; }

            public override string ToString()
            {
                return $"{id},{curso},{id_categoria},{categoria},{fecha_creacion}";
            }
        }
        #endregion

        
    }
}
