using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Evaluacion_NASA.Clases
{
    public class CLS_MenuOptions : NASA.CONSOFT.WinForms.Common.BaseMenuOptions
    {
        public CLS_MenuOptions(string OptionKey) : base(OptionKey)
        {
            
        }
        public override void PerformOption()
        {
            switch (this.OptionKeys)
            {
                case "CHK":
                    perfomCHK();
                    break;
                case "ENAA":
                    PerformCategoria();
                    break;
                case "ENAB":
                    PerformCursos();
                    break;
                case "ENAC":
                    PerformRegistros();
                    break;
                case "ENAD":
                    PerformCorte();
                    break;
                case "ENAE":
                    PerformGraficos();
                    break;
                case "CPC":
                    PerformCarga();
                    break;
                default:
                    MessageBox.Show($"No existe la opción {this.OptionKeys}.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private void PerformCursos()
        {
            using (var frm = new Evaluacion_NASAWinForms.Forms.xENC130010())
            {
                frm.ShowDialog();
            }
        }
        private void PerformRegistros()
        {
            using (var frm = new Evaluacion_NASAWinForms.Forms.xENC140010())
            {
                frm.ShowDialog();
            }
        }
        private void PerformCorte()
        {
            using (var frm = new Evaluacion_NASAWinForms.Forms.xENC150010())
            {
                frm.ShowDialog();
            }
        }
        private void PerformGraficos()
        {
            using (var frm = new Evaluacion_NASAWinForms.Forms.xENC160010())
            {
                frm.ShowDialog();
            }
        }
        private void perfomCHK()
        {
            try
            {
                if (MessageBox.Show("¿Confirma que desea ejecutar el proceso de verificación de tablas?", "Verificación de tablas", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Evaluacion_NASACore.BusinessLayer.CLS_EN_CHK CHK = new Evaluacion_NASACore.BusinessLayer.CLS_EN_CHK();
                    using (NASA.CONSOFT.WinForms.xFrmProgress frm = new NASA.CONSOFT.WinForms.xFrmProgress(CHK.ProgressTable))
                    {
                        frm.Show();
                        frm.ProgressBarControl1.EditValue = CHK.ExecuteAssemblyBookStructure();
                        frm.ProgressBarControl1.Refresh();
                        System.Threading.Thread.Sleep(500);
                        frm.Close();
                    }

                    MessageBox.Show("Proceso de verificación de tablas finalizado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"PerformCHK: {ex.Message}");
            }
        }
        private void PerformCarga()
        {
            using (var frm = new Evaluacion_NASAWinForms.Forms.xENC120010())
            {
                frm.ShowDialog();
            }
        }
    }
}
