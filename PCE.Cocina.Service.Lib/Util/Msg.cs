using PCE.Cocina.Service.Lib.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCM.Cocina.Service.Lib.Util
{
    public class Msg
    {
        public bool Sucess { set; get; }
        public string Message { set; get; }
        public string MessageType { set; get; }
        public string Data { set; get; }
        public int idRegister { set; get; }



        public Msg()
        {
            this.Sucess = false;
            this.MessageType = MessageTypes.Error.Value;
        }
        public Msg(string msg)
        {
            this.Sucess = false;
            this.MessageType = MessageTypes.Error.Value;
            this.Message = msg;
        }
        public void Success(string msg)
        {
            this.Sucess = true;
            this.MessageType = MessageTypes.Sucess.Value;
            this.Message = msg;
        }

        public void Success(string msg, int id)
        {
            Success(msg);
            this.idRegister = id;
        }

        public void Warning(string msg)
        {
            this.Sucess = true;
            this.MessageType = MessageTypes.Warming.Value;
            this.Message = msg;
        }
        public void Error(string msg)
        {
            this.Sucess = false;
            this.MessageType = MessageTypes.Error.Value;
            this.Message = msg;
        }
        public void Info(string msg)
        {
            this.Sucess = true;
            this.MessageType = MessageTypes.Info.Value;
            this.Message = msg;
        }
        public void Check(Int64 result, String msg)
        {
            if (result > 0)
            {
                this.Sucess = true;
                this.MessageType = MessageTypes.Sucess.Value;
                this.Message = msg;
            }
        }
    }
}
