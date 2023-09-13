using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluacion_NASA.Clases
{
    public class CLS_MenuOptions : NASA.CONSOFT.WinForms.Common.BaseMenuOptions
    {
        public CLS_MenuOptions(string OptionKey) : base(OptionKey)
        {
            
        }
        public override void PerformOption()
        {
            switch (OptionKeys)
            {
                case "CHK":
                    break;
                case "ENAA":
                    PerformCategoria();
                    break;
            }
        }

        private void PerformCategoria()
        {
            using (var frm = new Evaluacion_NASAWinForms.Forms.xENP110010())
            {
                frm.ShowDialog();
            }
        }
    }
}
