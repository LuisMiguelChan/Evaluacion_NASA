using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluacion_NASACore.BusinessLayer
{
    public class CLS_DBCURSOS_BAL
    {
        #region Variables globales...
        public const string BookName = DataLayer.CLS_DBCURSOS_DAL.BookName;
        public string TemplateVersion = "1.0.0.0";
        public DataLayer.CLS_DBCURSOS_DAL CONFIDal = new DataLayer.CLS_DBCURSOS_DAL();
        public const string viewCONFI = "View_Cursos";
        public const string Subset_Cursos = "Subset_Cursos";
        #endregion
        #region BookStructure...
        public NASA.CONSOFT.CoreFoundation.eBook.BusinessLayer.CLS_BookStructure GetBookStructure(string AssemblyName)
        {
            try
            {
                // Desired Book Configuration...
                string BookDocumentation = $"Book {BookName}";
                NASA.CONSOFT.CoreFoundation.eBook.EntityObjects.CLS_BookInfo Book = new NASA.CONSOFT.CoreFoundation.eBook.EntityObjects.CLS_BookInfo
                {
                    LastUser = NASA.PROCNASA.GLOBAL.gUsuario.Login,
                    Name = BookName,
                    HeaderTableName = $"{BookName}ENC",
                    DetailTableName = $"{BookName}DET",
                    Description = BookName,
                    Status = NASA.CONSOFT.CoreFoundation.eBook.EntityObjects.CLS_BookInfo.eStatus.Active
                };

                // Create desired template configuration.
                NASA.CONSOFT.CoreFoundation.eBook.BusinessLayer.CLS_Template Template = new NASA.CONSOFT.CoreFoundation.eBook.BusinessLayer.CLS_Template
                {
                    Description = BookName,
                    Version = TemplateVersion,
                    Fields = GetTemplateFieldCollection()
                };

                return new NASA.CONSOFT.CoreFoundation.eBook.BusinessLayer.CLS_BookStructure(AssemblyName, Book, BookDocumentation, Template);
            }
            catch (Exception ex)
            {
                throw new Exception($"GetBookStructure: {ex.Message}");
            }
        }

        public NASA.CONSOFT.CoreFoundation.eBOOK.BusinessLayer.CLS_Template_Field_Collection GetTemplateFieldCollection()
        {
            try
            {
                NASA.CONSOFT.CoreFoundation.eBOOK.BusinessLayer.CLS_Template_Field_Collection Fields = new NASA.CONSOFT.CoreFoundation.eBOOK.BusinessLayer.CLS_Template_Field_Collection();
                NASA.CONSOFT.CoreFoundation.eBook.BusinessLayer.CLS_Template_Fields Field;
                //nomcurso
                Field = new NASA.CONSOFT.CoreFoundation.eBook.BusinessLayer.CLS_Template_Fields
                {
                    SectionType = NASA.CONSOFT.CoreFoundation.eBook.BusinessLayer.CLS_SECTION_TYPES.HEADER[0],
                    FieldType = NASA.CONSOFT.CoreFoundation.eBook.BusinessLayer.CLS_FIELD_TYPES.NUMERO,
                    FieldName = EntityObjects.CLS_DBCURSOS_info.FieldNames.id_curso,
                    Description = "id_curso",
                    Documentation = "",
                    Coord_X = 10,
                    Coord_Y = 5,
                    Length = 300,
                    Width = 400,
                    TabIndex = Fields.Count
                };
                Fields.Add(Field);
                //nomcurso
                Field = new NASA.CONSOFT.CoreFoundation.eBook.BusinessLayer.CLS_Template_Fields
                {
                    SectionType = NASA.CONSOFT.CoreFoundation.eBook.BusinessLayer.CLS_SECTION_TYPES.HEADER[0],
                    FieldType = NASA.CONSOFT.CoreFoundation.eBook.BusinessLayer.CLS_FIELD_TYPES.NUMERO,
                    FieldName = EntityObjects.CLS_DBCURSOS_info.FieldNames.id_categoria,
                    Description = "id_categoria",
                    Documentation = "",
                    Coord_X = 10,
                    Coord_Y = Fields.get_Item(Fields.Count - 1).Coord_Y + 21,
                    Length = 300,
                    Width = 400,
                    TabIndex = Fields.Count
                };
                Fields.Add(Field);
                //nomcurso
                Field = new NASA.CONSOFT.CoreFoundation.eBook.BusinessLayer.CLS_Template_Fields
                {
                    SectionType = NASA.CONSOFT.CoreFoundation.eBook.BusinessLayer.CLS_SECTION_TYPES.HEADER[0],
                    FieldType = NASA.CONSOFT.CoreFoundation.eBook.BusinessLayer.CLS_FIELD_TYPES.TEXTO,
                    FieldName = EntityObjects.CLS_DBCURSOS_info.FieldNames.nomcurso,
                    Description = "Nombre curso",
                    Documentation = "",
                    Coord_X = 10,
                    Coord_Y = Fields.get_Item(Fields.Count - 1).Coord_Y + 21,
                    Length = 300,
                    Width = 400,
                    TabIndex = Fields.Count
                };
                Fields.Add(Field);

                //costo
                Field = new NASA.CONSOFT.CoreFoundation.eBook.BusinessLayer.CLS_Template_Fields
                {
                    SectionType = NASA.CONSOFT.CoreFoundation.eBook.BusinessLayer.CLS_SECTION_TYPES.HEADER[0],
                    FieldType = NASA.CONSOFT.CoreFoundation.eBook.BusinessLayer.CLS_FIELD_TYPES.NUMERO,
                    FieldName = EntityObjects.CLS_DBCURSOS_info.FieldNames.costo,
                    Description = "Costo curso",
                    Documentation = "",
                    Coord_X = 10,
                    Coord_Y = Fields.get_Item(Fields.Count - 1).Coord_Y + 21,
                    Length = 300,
                    Width = 400,
                    TabIndex = Fields.Count
                };
                Fields.Add(Field);

                //importe
                Field = new NASA.CONSOFT.CoreFoundation.eBook.BusinessLayer.CLS_Template_Fields
                {
                    SectionType = NASA.CONSOFT.CoreFoundation.eBook.BusinessLayer.CLS_SECTION_TYPES.HEADER[0],
                    FieldType = NASA.CONSOFT.CoreFoundation.eBook.BusinessLayer.CLS_FIELD_TYPES.NUMERO,
                    FieldName = EntityObjects.CLS_DBCURSOS_info.FieldNames.importe,
                    Description = "Importe curso",
                    Documentation = "",
                    Coord_X = 10,
                    Coord_Y = Fields.get_Item(Fields.Count - 1).Coord_Y + 21,
                    Length = 300,
                    Width = 400,
                    TabIndex = Fields.Count
                };
                Fields.Add(Field);

                return Fields;

            }
            catch (Exception ex)
            {
                throw new Exception($"GetTemplateFieldCollection: {ex.Message}");
            }
        }
        #endregion
        #region Propiedades...
        public string ConnectionString
        {
            get
            {
                return CONFIDal.ConnectionString;
            }
            set
            {
                CONFIDal.ConnectionString = value;
            }
        }
        #endregion

        #region Funciones...
        public NASA.CONSOFT.CoreFoundation.eBook.EntityObjects.InternalBooks.CLS_SubsetInfo GetOrCreateSubset()
        {
            try
            {
                NASA.CONSOFT.CoreFoundation.eBook.BusinessLayer.InternalBooks.CLS_SubSet SubsetBAL = new NASA.CONSOFT.CoreFoundation.eBook.BusinessLayer.InternalBooks.CLS_SubSet();
                NASA.CONSOFT.CoreFoundation.eBook.EntityObjects.InternalBooks.CLS_SubsetInfo SubsetInfo = SubsetBAL.GetSubSetConfiguration(Subset_Cursos);

                if (SubsetInfo != null)
                {
                    return SubsetInfo;
                }
                else
                {
                    NASA.CONSOFT.CoreFoundation.eBOOK.BusinessLayer.CLS_Book BookBAL = new NASA.CONSOFT.CoreFoundation.eBOOK.BusinessLayer.CLS_Book();
                    int BookId = BookBAL.GetId(Evaluacion_NASACore.BusinessLayer.CLS_DBCURSOS_BAL.BookName);
                    if (BookId > 0)
                    {
                        SubsetInfo = new NASA.CONSOFT.CoreFoundation.eBook.EntityObjects.InternalBooks.CLS_SubsetInfo()
                        {
                            AllowEdit = false,
                            AllowNew = true,
                            AllowDelete = true,
                            Code = Subset_Cursos,
                            DisplayEmailButton = false,
                            DisplayExcelButton = true,
                            DisplayPreviewButton = true,
                            MultiSelect = false,
                            SourceId = BookId,
                            SourceType = NASA.CONSOFT.CoreFoundation.eBook.EntityObjects.InternalBooks.CLS_SubsetInfo.eSubSetSourceType.Book,
                            Title = " CATALOGO CURSOS "
                        };

                    }
                    SubsetInfo.Id = SubsetBAL.Save(SubsetInfo);
                    return SubsetInfo;
                }

            }
            catch (Exception Ex)
            {
                throw new Exception(string.Format("CLS_ESTATUS_HAB_BAL.getOrCreateSubset: {0}", Ex.Message));
            }
        }
        public EntityObjects.CLS_DBCURSOS_info GetEntityObject(int Id, NASA.PROCNASA.DataAccess.CLS_SqlCommandWithTransaction Transaction = null)
        {
            return CONFIDal.GetEntityObject(Id, Transaction);
        }

        public EntityObjects.CLS_DBCURSOS_info GetEntityObject(DataRow EntityRow)
        {
            return CONFIDal.GetEntityObject(EntityRow);
        }

        public DataTable GetTable(NASA.PROCNASA.DataAccess.CLS_SqlCommandWithTransaction Transaction = null)
        {
            return CONFIDal.GetTable(Transaction);
        }
        public int Save(EntityObjects.CLS_DBCURSOS_info EntityInfo, NASA.PROCNASA.DataAccess.CLS_SqlCommandWithTransaction transaction = null)
        {
            try
            {
                if (EntityInfo.Id > 0)
                {
                    int res = CONFIDal.Update(EntityInfo, transaction);
                    return res > 0 ? EntityInfo.Id : 0;
                }
                else
                {
                    return CONFIDal.Insert(EntityInfo, transaction);
                }
            }
            catch (Exception ex)
            {
                string msg = $"Save: {ex.Message}";
                Console.WriteLine(ex);
                throw new Exception(msg);
            }
        }
        public int Delete(int Id)
        {
            return CONFIDal.Delete(Id);
        }
        public int SetField(int Id, string Field, string Value, NASA.CONSOFT.CoreFoundation.eBOOK.DataLayer.ModEnums.FieldType FieldType, NASA.PROCNASA.DataAccess.CLS_SqlCommandWithTransaction Transaction = null)
        {
            return CONFIDal.SetField(Id, Field, Value, FieldType, Transaction);
        }
        public EntityObjects.CLS_DBCURSOS_info GetConfiConfig(NASA.PROCNASA.DataAccess.CLS_SqlCommandWithTransaction Transaction = null)
        {
            DataTable Confi_Dt = GetTable(Transaction);
            if (Confi_Dt.Rows.Count > 0)
                return GetEntityObject(Confi_Dt.Rows[Confi_Dt.Rows.Count - 1]);
            else
                throw new Exception($"No se pudo obtener la configuración de {BookName}");
        }

        #endregion
    }
}
