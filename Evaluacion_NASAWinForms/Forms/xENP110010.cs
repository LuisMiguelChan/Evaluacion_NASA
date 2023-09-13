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
    public partial class xENP110010 : NASA.CONSOFT.WinForms.ConsoftMainMenuRibbonMDIForm
    {
        public xENP110010()
        {
            InitializeComponent();
        }

        private void xENP110010_Load(object sender, EventArgs e)
        {
            blblForma.Caption = this.Name;
        }
    }
}
