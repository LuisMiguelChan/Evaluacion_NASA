using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Evaluacion_NASA.Forms
{
    public partial class xENM100010 : NASA.CONSOFT.WinForms.ConsoftMainMenuRibbonMDIForm
    {

        #region Variables globales...

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
        #endregion

        #region Funciones...

        #endregion

    }
}
