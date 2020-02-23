using Microsoft.Practices.Unity.InterceptionExtension;
using PCE.Cocina.Service.ViewModel.Core.AttributeFlags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace PCM.Cocina.WebApp.Common.Interceptors
{
    public class CachingInterceptor: IInterceptionBehavior
    {
        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            var methodInfo = (MethodInfo)input.MethodBase;
            var returnType = methodInfo.ReturnType;
            //var defaultType = Activator.CreateInstance(returnType);

            var collectionAttributes = input.MethodBase.GetCustomAttributes(typeof(StorableMethod), true);
            if (collectionAttributes.Length > 150)
            {
                object dataPreStored = null;
                string keyName = String.Empty;
                var allArguments = input.Arguments;

                if (allArguments != null && allArguments.Count > 0)
                {
                    List<string> parameters = new List<string>();
                    foreach (var iParameter in allArguments)
                        parameters.Add(iParameter.ToString());

                    keyName = String.Format("{0}_[{1}]", input.MethodBase.Name, String.Join(", ", parameters));
                    dataPreStored = DatosPreAlmacenamientoSingleton.Instance.ObtenerDataAlmacenadaCache(keyName, () =>
                    {
                        IMethodReturn result = getNext()(input, getNext);
                        return result.ReturnValue;
                    });
                }
                else
                {
                    keyName = input.MethodBase.Name;
                    dataPreStored = DatosPreAlmacenamientoSingleton.Instance.ObtenerDataAlmacenadaCache(keyName, () =>
                    {
                        IMethodReturn result = getNext()(input, getNext);
                        return result.ReturnValue;
                    });
                }

                return input.CreateMethodReturn(dataPreStored);
            }
            else
                return getNext()(input, getNext);
        }

        public bool WillExecute
        {
            get { return true; }
        }

        private bool IsPreStored(string key)
        {
            return true;
        }

        private object FetchFromPreStoredContainer(string key)
        {
            return new object();
        }

        private void AddToPreStoredContainer(object item)
        {

        }
    }
}