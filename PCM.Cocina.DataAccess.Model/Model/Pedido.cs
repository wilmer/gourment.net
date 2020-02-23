using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCM.Cocina.DataAccess.Model.Model
{
    public  class Pedido
    {
        public int id_pedido { get; set; }
        public string correlativo { get; set; }
        public int IdMenu { get; set; }
        //public string descriMenu { get; set; }
        public int idestado { get; set; }
        public string estadopedido { get; set; }
        public string Menu { get; set; }
        public int Cantidad { get; set; }
        //public DateTime fecha_creacion { get; set; }
        //public int id_usuario_creador { get; set; }

        public string Detalle { get; set; }
        public int TotalRows { get; set; }
        public int RowNumber { get; set; }
    }
}
