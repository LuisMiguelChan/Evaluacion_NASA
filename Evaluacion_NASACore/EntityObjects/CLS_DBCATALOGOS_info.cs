using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluacion_NASACore.EntityObjects
{
    public class CLS_DBCATALOGOS_info
    {
        #region DataBase FielNames...
        public class FieldNames
        {
            public const string Id = "NUM_DOC";
            public const string id_categoria = "id_categoria";
            public const string nomcat = "nomcat";
        }
        #endregion

        #region Propiedades...
        public int Id { get; set; }
        public int id_categoria { get; set; }
        public string nomcat { get; set; }
        #endregion
    }
}
