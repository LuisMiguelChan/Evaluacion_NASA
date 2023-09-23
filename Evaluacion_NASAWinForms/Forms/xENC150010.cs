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
    public partial class xENC150010 : NASA.CONSOFT.WinForms.ConsoftMainMenuRibbonMDIForm
    {
        public xENC150010()
        {
            InitializeComponent();
        }

        private void Corte_Click(object sender, EventArgs e)
        {
            blblForma.Caption = this.Name;
            Evaluacion_NASACore.BusinessLayer.CLS_REGISTRO_BAL RegistrosBal = new Evaluacion_NASACore.BusinessLayer.CLS_REGISTRO_BAL();
            DataTable data = RegistrosBal.GetTable();
            dataGridView1.DataSource = data;
            decimal Total = 0;
            foreach (DataRow row in data.Rows)
            {
                Total = Convert.ToDecimal(row["importe"]);
            }
            textBox1.Text = Total.ToString();
        }
    }
}
