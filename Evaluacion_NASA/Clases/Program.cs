using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Evaluacion_NASA
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            LoadMainConfiguration();
            Application.Run(new Forms.xENM100010());
        }

        static void LoadMainConfiguration()
        {
            try
            {


                string[] Parameters = Environment.GetCommandLineArgs();

                // Read the Nasa sys connection string configuration...
                if (NASA.PROCNASA.GLOBAL.CONFIG != null || string.IsNullOrEmpty(NASA.PROCNASA.GLOBAL.CONFIG.SystemConnectionString))
                {
                    NASA.PROCNASA.GLOBAL.CONFIG = new NASA.PROCNASA.BusinessLayer.CLS_Config99("NASA");
                    NASA.PROCNASA.GLOBAL.CONFIG.Read();
                    NASA.PROCNASA.GLOBAL.CONFIG.CONN_STRING_SIST = NASA.PROCNASA.GLOBAL.CONFIG.EstuderConnectionString;
                    NASA.PROCNASA.GLOBAL.CONFIG.CONN_STRING_PASS = NASA.PROCNASA.GLOBAL.CONFIG.PassConnectionString;
                    NASA.PROCNASA.GLOBAL.CONFIG.CONN_STRING_BOOK = NASA.PROCNASA.GLOBAL.CONFIG.SystemConnectionString;
                    NASA.PROCNASA.GLOBAL.CONFIG.CLAVE_SISTEMA = Properties.Resources.ProgramName;
                }


                if (NASA.PROCNASA.DataAccess.SqlHelper.VerifyDatabaseConnection(NASA.PROCNASA.GLOBAL.CONFIG.SystemConnectionString))
                {
                    if (Parameters.Length > 2)
                    {
                        if (NASA.PROCNASA.Classes.CLS_USUARIO.ExistUsuario_(Parameters[1], Parameters[2]))
                            NASA.PROCNASA.GLOBAL.gUsuario = NASA.PROCNASA.Classes.CLS_USUARIO.GetUsuaurioByLogin_(Parameters[1]);
                        else
                        {
                            MessageBox.Show("El usuario especificado no existe, favor de verificar los datos.");
                            Environment.Exit(0);
                        }

                        // Handle option parameters...
                        if (Parameters.Length > 3)
                        {
                            string OptionKey = Parameters[3];
                            Clases.CLS_MenuOptions MenuOption = new Clases.CLS_MenuOptions(OptionKey);

                            // Send other parameters...
                            if (Parameters.Length > 4)
                            {
                                for (int i = 4; i < Parameters.Length; i++)
                                {
                                    MenuOption.ParameterList.Add(Parameters[i]);
                                }
                            }

                            // Perform desired option menu...
                            MenuOption.PerformOption();
                            Environment.Exit(0);
                        }
                    }
                }
                else
                {
                    Environment.Exit(0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.TargetSite.Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Environment.Exit(0);
            }
        }
    }
}
