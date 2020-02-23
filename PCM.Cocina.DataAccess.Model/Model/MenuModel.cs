using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCM.Cocina.DataAccess.Model.Model
{
    public class MenuModel
    {
        public int IdMenu { get; set; }
        public int IdEntrada1 { get; set; }
        public string DescriEntrada1 { get; set; }
        public int IdEntrada2 { get; set; }
        public string DescriEntrada2 { get; set; }
        public int IdPlatoDeFondo1 { get; set; }

        public string DescriPlatoDeFondo1{ get; set; }
        public int IdPlatoDeFondo2 { get; set; }

        public string DescriPlatoDeFondo2 { get; set; }
        public int IdRefresco { get; set; }

        public string DescriRefresco { get; set; }

        public string Menu { get; set; }
        public int TotalRows { get; set; }
        public int RowNumber { get; set; }
    }
}
