using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluacion_NASACore.EntityObjects
{
    public class CLS_DBCURSOS_info
    {
        #region DataBase FielNames...
        public class FieldNames
        {
            public const string Id = "NUM_DOC";
            public const string id_curso = "id_curso";
            public const string id_categoria = "id_categoria";
            public const string nomcurso = "nomcurso";
            public const string costo = "costo";
            public const string importe = "importe";
        }
        #endregion

        #region Propiedades...
        public int Id { get; set; }
        public int id_curso { get; set; }
        public int id_categoria { get; set; }
        public string nomcurso { get; set; }
        public float costo { get; set; }
        public float importe { get; set; }
        #endregion
    }
}
