using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCE.Cocina.Service.ViewModel.Common
{
    public class MessageExecutionViewModel
    {
        public int RowsAffected { get; set; }
        public bool ResultExecution { get; set; }
        public string MessageResult { get; set; }
    }
}
