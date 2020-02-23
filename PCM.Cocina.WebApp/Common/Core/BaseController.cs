
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;


namespace PCM.Cocina.WebApp.Common.Core
{
    public class BaseController : Controller
    {
        public void ExecuteHandledOperation<T>(Action actionToExecute)
        {
            try
            {
                actionToExecute.Invoke();
            }
            catch (Exception ex)
            {

            }
        }

        public T ExecuteHandledOperation<T>(Func<T> actionToExecute)
        {
            try
            {
                return actionToExecute.Invoke();
            }
            catch (Exception ex)
            {
                return default(T);
                //loggg 
            }
        }

        public T ExecuteHandledOperation<T>(Func<T> actionToExecute, Func<T> actionToExecuteOnError)
        {
            try
            {
                return actionToExecute.Invoke();
            }
            catch (Exception ex)
            {
                return actionToExecuteOnError.Invoke();
            }
        }
        //public UserViewModel CurrentUser
        //{
        //    get
        //    {
        //        return new UserViewModel(this.User as ClaimsPrincipal);
        //    }
        //}
        //public string GetUserName()
        //{
        //    if (CurrentUser.UserName != null)
        //    {
        //        return CurrentUser.UserName;
        //    }
        //    else
        //    {
        //        return "anónimo";

        //    }
        //}
    }
}