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
    public partial class xENC140010 : NASA.CONSOFT.WinForms.ConsoftMainMenuRibbonMDIForm
    {
        public xENC140010()
        {
            InitializeComponent();
        }

        private void xENC140010_Load(object sender, EventArgs e)
        {
            blblForma.Caption = this.Name;
            Evaluacion_NASACore.BusinessLayer.CLS_REGISTRO_BAL RegistroBal = new Evaluacion_NASACore.BusinessLayer.CLS_REGISTRO_BAL();
            DataTable data = RegistroBal.GetTable();
            dataGridView1.DataSource = data;
        }
    }
}
