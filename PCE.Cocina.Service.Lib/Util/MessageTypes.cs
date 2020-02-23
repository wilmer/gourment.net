using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCE.Cocina.Service.Lib.Util
{
    public class MessageTypes
    {
        private MessageTypes(string value) { Value = value; }
        public string Value { get; set; }

        public static MessageTypes Error { get { return new MessageTypes("alert-danger"); } }
        public static MessageTypes Warming { get { return new MessageTypes("alert-warning"); } }
        public static MessageTypes Sucess { get { return new MessageTypes("alert-success"); } }
        public static MessageTypes Info { get { return new MessageTypes("alert-info"); } }
    }
}
