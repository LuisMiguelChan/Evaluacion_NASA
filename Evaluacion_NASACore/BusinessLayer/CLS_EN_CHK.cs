using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NASA.CONSOFT.CoreFoundation.eBook.BusinessLayer;
using NASA.CONSOFT.CoreFoundation.Estuder.BusinessLayer.MOD_ACTION_TYPES;

namespace Evaluacion_NASACore.BusinessLayer
{
    public class CLS_EN_CHK : CLS_AssemblyStructure
    {
        #region variables globales...
        private const string AssemblyName = "EvaluacionNASA";
        private const string Evaluacion_NASAWinForms = "Evaluacion_NASA.exe";
        #endregion
        #region funciones ...
        public override string GetAssemblyDescription()
        {
            return "Modulo de evaluacion";
        }

        public override System.Drawing.Image GetAssemblyIcon()
        {
            return null;
        }

        public override string GetAssemblyName()
        {
            return AssemblyName;
        }

        public override string GetAssemblyUrl()
        {
            return "";
        }

        public override List<CLS_BookStructure> GetDefaultBookStruct()
        {
            List<CLS_BookStructure> books = new List<CLS_BookStructure>();
            CLS_DBCATALOGOS_BAL catalogos_bal = new CLS_DBCATALOGOS_BAL();
            CLS_DBCURSOS_BAL cursos_bal = new CLS_DBCURSOS_BAL();
            CLS_REGISTRO_BAL REGISTRO_bal = new CLS_REGISTRO_BAL();
            books.Add(catalogos_bal.GetBookStructure(AssemblyName));
            books.Add(cursos_bal.GetBookStructure(AssemblyName));
            books.Add(REGISTRO_bal.GetBookStructure(AssemblyName));
            return books;
        }
        public override int ExecuteAssemblyBookStructure()
        {
            NASA.PROCNASA.Clases.CLS_CHKConnections CHKConnections = new NASA.PROCNASA.Clases.CLS_CHKConnections();
            int Result = 0;
            try
            {
                CHKConnections.StartConnectionsAndTransactions();
                bool isNull = CHKConnections.GetType().GetProperties().All(p => p.GetValue(CHKConnections) == null);

                if (!isNull)
                {
                    NASA.PROCNASA.DataAccess.SqlHelper.CHKConnections = CHKConnections;
                    // Ejecuta la verificación estandar de los books...
                    Result = base.ExecuteAssemblyBookStructure();
                    
                    //Sub conjuntos
                    //VerifySubsetConfigurations();

                    //verifica el menú
                    //VerifyFrontMenu();

                    //Verifica el Ribbon
                    //VerifyFrontRibbon();

                    CHKConnections.CloseWithCommit();

                    return Result;
                }

            }
            catch (Exception ex)
            {
                if (NASA.PROCNASA.DataAccess.SqlHelper.CHKConnections != null)
                {
                    CHKConnections.CloseWithRollBack(); // ROLLBACK
                }

                throw new Exception(string.Format("ExecuteAssemblyBookStructure: {0}", ex.Message));
            }
            return Result;
        }
        private void VerifyFrontMenu()
        {
            try
            {
                NASA.CONSOFT.CoreFoundation.Estuder.EntityObjects.CLS_MenuInfo nMenu = new NASA.CONSOFT.CoreFoundation.Estuder.EntityObjects.CLS_MenuInfo
                {
                    ParentId = 0,
                    ProgramCode = AssemblyName
                };

                NASA.CONSOFT.CoreFoundation.Estuder.BusinessLayer.CLS_MENU MenuBAL = new NASA.CONSOFT.CoreFoundation.Estuder.BusinessLayer.CLS_MENU();
                List<NASA.CONSOFT.CoreFoundation.Estuder.EntityObjects.CLS_MenuInfo> Menus = MenuBAL.FindBy(nMenu);
                NASA.CONSOFT.CoreFoundation.eBOOK.BusinessLayer.CLS_Book BookBAL = new NASA.CONSOFT.CoreFoundation.eBOOK.BusinessLayer.CLS_Book();
                NASA.CONSOFT.CoreFoundation.eBook.BusinessLayer.InternalBooks.CLS_SubSet SubSetBAL = new NASA.CONSOFT.CoreFoundation.eBook.BusinessLayer.InternalBooks.CLS_SubSet();


                /////////////////////////////////// OPCIONES DEL MENU
                int Nivel0 = CreateMenuItem(MenuBAL, Menus, 0, AssemblyName, "", AssemblyName);
                
                NASA.CONSOFT.CoreFoundation.eBOOK.EntityObjects.InternalBooks.CLS_IntegratorConfig_Info integratorConfig_Info = new NASA.CONSOFT.CoreFoundation.eBOOK.EntityObjects.InternalBooks.CLS_IntegratorConfig_Info();
                
                NASA.CONSOFT.CoreFoundation.eBOOK.BusinessLayer.InternalBooks.CLS_eSchedulesConfig_BAL SchedulesConfigBal = new NASA.CONSOFT.CoreFoundation.eBOOK.BusinessLayer.InternalBooks.CLS_eSchedulesConfig_BAL();
                NASA.CONSOFT.CoreFoundation.eBOOK.EntityObjects.InternalBooks.CLS_eSchedulesConfig_Info SchedulesConfigInfo = new NASA.CONSOFT.CoreFoundation.eBOOK.EntityObjects.InternalBooks.CLS_eSchedulesConfig_Info();
                SchedulesConfigInfo.Id = SchedulesConfigBal.GetId("cal001");

                int Nivel1 = CreateMenuItem(MenuBAL, Menus, Nivel0, "Opciones", "", AssemblyName);
                int Nivel11 = CreateMenuOption2(MenuBAL, Menus, Nivel1, "Catalogos", "", MOD_ACTION_TYPES.SUBSET, (new NASA.CONSOFT.CoreFoundation.eBook.BusinessLayer.InternalBooks.CLS_SubSet()).GetSubSetConfiguration(CLS_DBCATALOGOS_BAL.Subset_Catalogos).Id, null, "", AssemblyName, "N11");
                int Nivel12 = CreateMenuOption2(MenuBAL, Menus, Nivel1, "Cursos", "", MOD_ACTION_TYPES.SUBSET, (new NASA.CONSOFT.CoreFoundation.eBook.BusinessLayer.InternalBooks.CLS_SubSet()).GetSubSetConfiguration(CLS_DBCURSOS_BAL.Subset_Cursos).Id, null, "", AssemblyName, "N12");
                int Nivel13 = CreateMenuOption2(MenuBAL, Menus, Nivel1, "Inscritos", "", MOD_ACTION_TYPES.SUBSET, (new NASA.CONSOFT.CoreFoundation.eBook.BusinessLayer.InternalBooks.CLS_SubSet()).GetSubSetConfiguration(CLS_REGISTRO_BAL.Subset_Registros).Id, null, "", AssemblyName, "N13");
                int Nivel14 = CreateMenuOption(MenuBAL, Menus, Nivel1, "Inscripciones", "", MOD_ACTION_TYPES.EXE, Evaluacion_NASAWinForms, "&USR &PASS CPC 0", null, "", AssemblyName, "N14");
                int Nivel15 = CreateMenuOption(MenuBAL, Menus, Nivel1, "Corte", "", MOD_ACTION_TYPES.EXE, Evaluacion_NASAWinForms, $"&USR &PASS BE 0", null, "", AssemblyName, "N15");
                //int Nivel15 = CreateMenuOption(MenuBAL, Menus, Nivel1, "Dashboard", "", MOD_ACTION_TYPES.DASHBOARD, CLS_REGISTRO_BAL.DashboardNameGraficosMensuales, $"&USR &PASS {new CLS_REGISTRO_BAL().GetOrCreateDashboardGraficosComparativosMensuales()}", null, "", AssemblyName, "N15");
                int Nivel2 = CreateMenuItem(MenuBAL, Menus, Nivel0, "Procesos", "", AssemblyName);
                int Nivel21 = CreateMenuOption(MenuBAL, Menus, Nivel2, "Verificador tablas", "", MOD_ACTION_TYPES.EXE, Evaluacion_NASAWinForms, $"&USR &PASS CHK 0", null, "", AssemblyName, "N21");
                int Nivel22 = CreateMenuOption(MenuBAL, Menus, Nivel2, "Data Service", "", MOD_ACTION_TYPES.EXE, Evaluacion_NASAWinForms, $"&USR &PASS DS 0", null, "", AssemblyName, "N22");
            }
            catch (Exception ex) { throw new Exception(string.Format("verifyFrontMenu: {0}", ex.Message)); }
        }
        private void VerifyFrontRibbon()
        {
            //Verificacion del Menú

            int PageId;
            int GroupId;
            List<string> MenuOption;
            NASA.CONSOFT.CoreFoundation.Estuder.BusinessLayer.CLS_RibbonConfiguration RibbonConfigurationBAL = new NASA.CONSOFT.CoreFoundation.Estuder.BusinessLayer.CLS_RibbonConfiguration();

            try
            {
                PageId = RibbonConfigurationBAL.RibbonAddPage("Opciones", AssemblyName);
                RibbonConfigurationBAL.RibbonFixGroupProgramCode(PageId, AssemblyName);

                GroupId = RibbonConfigurationBAL.RibbonAddGroup(PageId, 0, "General", AssemblyName);
                MenuOption = new List<string>();
                MenuOption.Add("Catalogos");
                MenuOption.Add("Cursos");
                MenuOption.Add("Inscritos");
                RibbonConfigurationBAL.RibbonAddItems(GroupId, MenuOption, AssemblyName);
                RibbonConfigurationBAL.RibbonRemoveMissingItems(GroupId, MenuOption);

                GroupId = RibbonConfigurationBAL.RibbonAddGroup(PageId, 1, "Acciones", AssemblyName);
                MenuOption = new List<string>();
                MenuOption.Add("Inscripciones");
                MenuOption.Add("Corte");
                RibbonConfigurationBAL.RibbonAddItems(GroupId, MenuOption, AssemblyName);
                RibbonConfigurationBAL.RibbonRemoveMissingItems(GroupId, MenuOption);

                //GroupId = RibbonConfigurationBAL.RibbonAddGroup(PageId, 2, "Recursos", AssemblyName);
                //MenuOption = new List<string>();
                //MenuOption.Add("Dashboard");
                //RibbonConfigurationBAL.RibbonAddItems(GroupId, MenuOption, AssemblyName);
                //RibbonConfigurationBAL.RibbonRemoveMissingItems(GroupId, MenuOption);
                
                PageId = RibbonConfigurationBAL.RibbonAddPage("Procesos", AssemblyName);
                RibbonConfigurationBAL.RibbonFixGroupProgramCode(PageId, AssemblyName);

                GroupId = RibbonConfigurationBAL.RibbonAddGroup(PageId, 3, "Verificadores", AssemblyName);
                MenuOption = new List<string>();
                MenuOption.Add("Verificador tablas");
                RibbonConfigurationBAL.RibbonAddItems(GroupId, MenuOption, AssemblyName);
                RibbonConfigurationBAL.RibbonRemoveMissingItems(GroupId, MenuOption);

                GroupId = RibbonConfigurationBAL.RibbonAddGroup(PageId, 4, "Import Data", AssemblyName);
                MenuOption = new List<string>();
                MenuOption.Add("Data Service");
                RibbonConfigurationBAL.RibbonAddItems(GroupId, MenuOption, AssemblyName);
                RibbonConfigurationBAL.RibbonRemoveMissingItems(GroupId, MenuOption);
                
                RibbonConfigurationBAL.RibbonRemoveEmptyGroups(PageId);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("verifyFrontRibbon: {0}", ex.Message));
            }
        }
        static void VerifySubsetConfigurations()
        {
            try
            {
                CLS_DBCATALOGOS_BAL TABCATBAL = new CLS_DBCATALOGOS_BAL();
                TABCATBAL.GetOrCreateSubset();
                CLS_DBCURSOS_BAL TABCURBAL = new CLS_DBCURSOS_BAL();
                TABCURBAL.GetOrCreateSubset();
                CLS_REGISTRO_BAL TABREGBAL = new CLS_REGISTRO_BAL();
                TABREGBAL.GetOrCreateSubset();
            }
            catch (Exception Ex)
            {
                throw new Exception(string.Format("VerifySubsetConfigurations: {0}", Ex.Message));
            }
        }

        public int CreateMenuItem(NASA.CONSOFT.CoreFoundation.Estuder.BusinessLayer.CLS_MENU MenuBAL, List<NASA.CONSOFT.CoreFoundation.Estuder.EntityObjects.CLS_MenuInfo> Menus, int ParentId, string Caption, string Description, string ProgramCode)
        {
            if (Menus != null)
            {
                NASA.CONSOFT.CoreFoundation.Estuder.EntityObjects.CLS_MenuInfo MenuOption = Menus.Find(x => x.OptionName == Caption && x.IsActive == true);
                if (MenuOption != null)
                {
                    return MenuOption.Id;
                }
            }
            return MenuBAL.CreateMenuItem(ParentId, Caption, Description, ProgramCode);
        }

        public int CreateMenuOption(NASA.CONSOFT.CoreFoundation.Estuder.BusinessLayer.CLS_MENU MenuBAL, List<NASA.CONSOFT.CoreFoundation.Estuder.EntityObjects.CLS_MenuInfo> Menus, int ParentId, string Caption, string Description, string OptionType, string AssemblyPath, string Parameters, byte[] Icon, string UrlDocumentacion, string ProgramCode, string Clave = "")
        {
            if (Menus != null)
            {
                NASA.CONSOFT.CoreFoundation.Estuder.EntityObjects.CLS_MenuInfo MenuOption = Menus.Find(x => x.OptionName == Caption && x.IsActive == true);
                if (MenuOption != null)
                {
                    return MenuOption.Id;
                }
            }
            
            return MenuBAL.CreateMenuOption(ParentId, Caption, Description, OptionType, AssemblyPath, Parameters, Icon, UrlDocumentacion, ProgramCode, Clave);
        }

        public int CreateMenuOption2(NASA.CONSOFT.CoreFoundation.Estuder.BusinessLayer.CLS_MENU MenuBAL, List<NASA.CONSOFT.CoreFoundation.Estuder.EntityObjects.CLS_MenuInfo> Menus, int ParentId, string Caption, string Description, string OptionType, int OptionId, byte[] Icon, string UrlDocumentacion, string ProgramCode, string Clave = "")
        {
            if (Menus != null)
            {
                NASA.CONSOFT.CoreFoundation.Estuder.EntityObjects.CLS_MenuInfo MenuOption = Menus.Find(x => x.OptionName == Caption && x.IsActive == true);
                if (MenuOption != null)
                {
                    return MenuOption.Id;
                }
            }
            return MenuBAL.CreateMenuOption(ParentId, Caption, Description, OptionType, OptionId, Icon, UrlDocumentacion, ProgramCode, Clave);
        }
        #endregion
    }
}
