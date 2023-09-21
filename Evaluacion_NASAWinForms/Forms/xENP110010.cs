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

namespace Evaluacion_NASAWinForms.Forms
{
    public partial class xENP110010 : NASA.CONSOFT.WinForms.ConsoftMainMenuRibbonMDIForm
    {
        public xENP110010()
        {
            InitializeComponent();
        }

        private void xENP110010_Load(object sender, EventArgs e)
        {
            blblForma.Caption = this.Name;
            Evaluacion_NASACore.BusinessLayer.CLS_DBCATALOGOS_BAL CatalogosBal = new Evaluacion_NASACore.BusinessLayer.CLS_DBCATALOGOS_BAL();
            DataTable data = CatalogosBal.GetTable();
            dataGridView1.DataSource = data;
        }

        private async void GuardarbarButtonItem_ItemClick(object sender, EventArgs e)
        {
            
        }
    }
}
