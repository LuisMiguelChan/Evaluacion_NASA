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
    public partial class xENC130010 : NASA.CONSOFT.WinForms.ConsoftMainMenuRibbonMDIForm
    {
        public xENC130010()
        {
            InitializeComponent();
        }

        private void xENC130010_Load(object sender, EventArgs e)
        {
            blblForma.Caption = this.Name;
            Evaluacion_NASACore.BusinessLayer.CLS_DBCURSOS_BAL CursosBal = new Evaluacion_NASACore.BusinessLayer.CLS_DBCURSOS_BAL();
            DataTable data = CursosBal.GetTable();
            dataGridView1.DataSource = data;
        }
    }
}
