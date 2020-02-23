using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCE.Cocina.Service.ViewModel.Core.AttributeFlags
{
    public class StorableMethod : Attribute
    {
        public bool IsStorable
        {
            get { return true; }
        }
    }
}
