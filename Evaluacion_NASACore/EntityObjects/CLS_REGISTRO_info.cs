using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluacion_NASACore.EntityObjects
{
    public class CLS_REGISTRO_info
    {
        #region DataBase FielNames...
        public class FieldNames
        {
            public const string Id = "NUM_DOC";
            public const string nompart = "nompart";
            public const string id_curso = "id_curso";
            public const string importe = "importe";
            public const string pago = "pago";
        }
        #endregion

        #region Propiedades...
        public int Id { get; set; }
        public string nompart { get; set; }
        public int id_curso { get; set; }
        public float importe { get; set; }
        public string pago { get; set; }
        #endregion
    }
}
