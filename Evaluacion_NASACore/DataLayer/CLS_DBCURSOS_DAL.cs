using NASA.PROCNASA.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluacion_NASACore.DataLayer
{
    public class CLS_DBCURSOS_DAL
    {
        #region Variables globales...
        public const string BookName = "DB_CURSOS";
        #endregion

        #region Propiedades...
        public string ConnectionString { get; set; }
        #endregion

        #region Constructores...
        public CLS_DBCURSOS_DAL()
        {
            if (NASA.PROCNASA.GLOBAL.CONFIG != null && !string.IsNullOrWhiteSpace(NASA.PROCNASA.GLOBAL.CONFIG.SystemConnectionString))
            {
                ConnectionString = NASA.PROCNASA.GLOBAL.CONFIG.SystemConnectionString;
            }
        }
        #endregion

        #region Funciones...
        public EntityObjects.CLS_DBCURSOS_info GetEntityObject(int Id, CLS_SqlCommandWithTransaction Trans = null)
        {
            try
            {
                NASA.CONSOFT.CoreFoundation.eBOOK.DataLayer.CLS_MAESTRA Maestra = new NASA.CONSOFT.CoreFoundation.eBOOK.DataLayer.CLS_MAESTRA() { ConnectionString = this.ConnectionString };
                string HeaderTableName = (Trans == null) ? Maestra.GetHeaderTableName(BookName) : Maestra.GetHeaderTableName(BookName, Trans);

                StringBuilder sql = new StringBuilder();
                sql.AppendFormat("SELECT TOP 1 * FROM {0} WHERE NUM_DOC = {1}", HeaderTableName, Id);

                DataTable dt = (Trans == null) ? SqlHelper.ExecuteDatatable(sql.ToString(), ConnectionString) : Trans.ExecuteDatable(sql.ToString());
                if (dt != null && dt.Rows.Count > 0) return GetEntityObject(dt.Rows[0]);

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception($"GetEntityObject: {ex.Message}");
            }
        }

        public EntityObjects.CLS_DBCURSOS_info GetEntityObject(DataRow EntityRow)
        {
            try
            {
                EntityObjects.CLS_DBCURSOS_info EntityInfo = new EntityObjects.CLS_DBCURSOS_info();
                if (EntityRow[EntityObjects.CLS_DBCURSOS_info.FieldNames.Id] != DBNull.Value) EntityInfo.Id = Convert.ToInt32(EntityRow[EntityObjects.CLS_DBCURSOS_info.FieldNames.Id]);
                if (EntityRow[EntityObjects.CLS_DBCURSOS_info.FieldNames.id_curso] != DBNull.Value) EntityInfo.id_curso = Convert.ToInt32(EntityRow[EntityObjects.CLS_DBCURSOS_info.FieldNames.id_curso]);
                if (EntityRow[EntityObjects.CLS_DBCURSOS_info.FieldNames.id_categoria] != DBNull.Value) EntityInfo.id_categoria = Convert.ToInt32(EntityRow[EntityObjects.CLS_DBCURSOS_info.FieldNames.id_categoria]);
                if (EntityRow[EntityObjects.CLS_DBCURSOS_info.FieldNames.costo] != DBNull.Value) EntityInfo.costo = Convert.ToInt32(EntityRow[EntityObjects.CLS_DBCURSOS_info.FieldNames.costo]);
                if (EntityRow[EntityObjects.CLS_DBCURSOS_info.FieldNames.importe] != DBNull.Value) EntityInfo.importe = Convert.ToInt32(EntityRow[EntityObjects.CLS_DBCURSOS_info.FieldNames.importe]);
                if (EntityRow[EntityObjects.CLS_DBCURSOS_info.FieldNames.nomcurso] != DBNull.Value) EntityInfo.nomcurso = Convert.ToString(EntityRow[EntityObjects.CLS_DBCURSOS_info.FieldNames.nomcurso]);
                return EntityInfo;
            }
            catch (Exception ex)
            {
                throw new Exception($"GetEntityObject: {ex.Message}");
            }
        }

        public DataTable GetTable(NASA.PROCNASA.DataAccess.CLS_SqlCommandWithTransaction Transaction = null)
        {
            try
            {
                NASA.CONSOFT.CoreFoundation.eBOOK.DataLayer.CLS_MAESTRA Maestra = new NASA.CONSOFT.CoreFoundation.eBOOK.DataLayer.CLS_MAESTRA() { ConnectionString = this.ConnectionString };
                string HeaderTableName = Transaction != null ? Maestra.GetHeaderTableName(BookName, Transaction) : Maestra.GetHeaderTableName(BookName);

                StringBuilder sql = new StringBuilder();
                sql.AppendFormat("SELECT * FROM {0} WHERE NUM_DOC > 0", HeaderTableName);

                return Transaction != null ? Transaction.ExecuteDatable(sql.ToString()) : SqlHelper.ExecuteDatatable(sql.ToString(), ConnectionString);
            }
            catch (Exception ex)
            {
                throw new Exception($"GetTable: {ex.Message}");
            }
        }

        private List<NASA.CONSOFT.CoreFoundation.Common.DataLayer.CLS_FieldValues> GetHeaderFieldValues(EntityObjects.CLS_DBCURSOS_info EntityInfo)
        {
            try
            {
                List<NASA.CONSOFT.CoreFoundation.Common.DataLayer.CLS_FieldValues> FieldValues = new List<NASA.CONSOFT.CoreFoundation.Common.DataLayer.CLS_FieldValues>();
                DateTime MinDate = new DateTime(1753, 1, 1);

                FieldValues.Add(new NASA.CONSOFT.CoreFoundation.Common.DataLayer.CLS_FieldValues(EntityObjects.CLS_DBCURSOS_info.FieldNames.id_curso, EntityInfo.id_curso.ToString(), NASA.CONSOFT.CoreFoundation.eBOOK.DataLayer.ModEnums.FieldType.Numero));
                FieldValues.Add(new NASA.CONSOFT.CoreFoundation.Common.DataLayer.CLS_FieldValues(EntityObjects.CLS_DBCURSOS_info.FieldNames.id_categoria, EntityInfo.id_categoria.ToString(), NASA.CONSOFT.CoreFoundation.eBOOK.DataLayer.ModEnums.FieldType.Numero));
                FieldValues.Add(new NASA.CONSOFT.CoreFoundation.Common.DataLayer.CLS_FieldValues(EntityObjects.CLS_DBCURSOS_info.FieldNames.costo, EntityInfo.costo.ToString(), NASA.CONSOFT.CoreFoundation.eBOOK.DataLayer.ModEnums.FieldType.Numero));
                FieldValues.Add(new NASA.CONSOFT.CoreFoundation.Common.DataLayer.CLS_FieldValues(EntityObjects.CLS_DBCURSOS_info.FieldNames.importe, EntityInfo.importe.ToString(), NASA.CONSOFT.CoreFoundation.eBOOK.DataLayer.ModEnums.FieldType.Numero));
                FieldValues.Add(new NASA.CONSOFT.CoreFoundation.Common.DataLayer.CLS_FieldValues(EntityObjects.CLS_DBCURSOS_info.FieldNames.nomcurso, string.IsNullOrWhiteSpace(EntityInfo.nomcurso) ? "" : EntityInfo.nomcurso.ToString(), NASA.CONSOFT.CoreFoundation.eBOOK.DataLayer.ModEnums.FieldType.Texto));
                return FieldValues;
            }
            catch (Exception ex)
            {
                throw new Exception($"GetHeaderFieldValues: {ex.Message}");
            }
        }

        public int Insert(EntityObjects.CLS_DBCURSOS_info EntityInfo, CLS_SqlCommandWithTransaction Transaction = null)
        {
            try
            {
                List<NASA.CONSOFT.CoreFoundation.Common.DataLayer.CLS_FieldValues> FieldValues = GetHeaderFieldValues(EntityInfo);
                if (Transaction == null)
                    return NASA.CONSOFT.CoreFoundation.eBOOK.DataLayer.Functions.InsertinBook(BookName, FieldValues, null, ConnectionString);
                else
                    return NASA.CONSOFT.CoreFoundation.eBOOK.DataLayer.Functions.InsertinBook(BookName, FieldValues, null, Transaction);
            }
            catch (Exception ex)
            {
                throw new Exception($"Insert: {ex.Message}");
            }
        }

        public int Update(EntityObjects.CLS_DBCURSOS_info EntityInfo, CLS_SqlCommandWithTransaction Transaction = null)
        {
            try
            {
                List<NASA.CONSOFT.CoreFoundation.Common.DataLayer.CLS_FieldValues> FieldValues = GetHeaderFieldValues(EntityInfo);
                if (Transaction == null)
                    return NASA.CONSOFT.CoreFoundation.eBOOK.DataLayer.Functions.UpdateinBook(BookName, FieldValues, null, EntityInfo.Id, ConnectionString);
                else
                    return NASA.CONSOFT.CoreFoundation.eBOOK.DataLayer.Functions.UpdateinBook(BookName, FieldValues, null, EntityInfo.Id, Transaction);
            }
            catch (Exception ex)
            {
                throw new Exception($"Update: {ex.Message}");
            }
        }

        public int Delete(int Id)
        {
            try
            {
                List<NASA.CONSOFT.CoreFoundation.Common.DataLayer.CLS_FieldValues> FieldValues = new List<NASA.CONSOFT.CoreFoundation.Common.DataLayer.CLS_FieldValues>
                {
                    new NASA.CONSOFT.CoreFoundation.Common.DataLayer.CLS_FieldValues(EntityObjects.CLS_DBCURSOS_info.FieldNames.Id, (-Id).ToString(), NASA.CONSOFT.CoreFoundation.eBOOK.DataLayer.ModEnums.FieldType.Numero)
                };

                return NASA.CONSOFT.CoreFoundation.eBOOK.DataLayer.Functions.UpdateinBook(BookName, FieldValues, null, Id, ConnectionString);
            }
            catch (Exception ex)
            {
                throw new Exception($"Delete: {ex.Message}");
            }
        }

        public int SetField(int Id, string Field, string Value, NASA.CONSOFT.CoreFoundation.eBOOK.DataLayer.ModEnums.FieldType FieldType, NASA.PROCNASA.DataAccess.CLS_SqlCommandWithTransaction Transaction = null)
        {
            try
            {
                List<NASA.CONSOFT.CoreFoundation.Common.DataLayer.CLS_FieldValues> FieldValues = new List<NASA.CONSOFT.CoreFoundation.Common.DataLayer.CLS_FieldValues>
                {
                    new NASA.CONSOFT.CoreFoundation.Common.DataLayer.CLS_FieldValues(Field, Value, FieldType)
                };

                if (Transaction != null)
                    return NASA.CONSOFT.CoreFoundation.eBOOK.DataLayer.Functions.UpdateinBook(BookName, FieldValues, null, Id, Transaction);
                else
                    return NASA.CONSOFT.CoreFoundation.eBOOK.DataLayer.Functions.UpdateinBook(BookName, FieldValues, null, Id, ConnectionString);

            }
            catch (Exception ex)
            {
                throw new Exception($"SetField: {ex.Message}");
            }
        }
        #endregion
    }
}
