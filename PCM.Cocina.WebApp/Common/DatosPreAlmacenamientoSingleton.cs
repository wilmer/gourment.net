using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Web;

namespace PCM.Cocina.WebApp.Common
{
    public class DatosPreAlmacenamientoSingleton
    {
        private volatile static DatosPreAlmacenamientoSingleton uniqueInstance;
        private static object syncRoot = new object();

        private DatosPreAlmacenamientoSingleton() { }

        public static DatosPreAlmacenamientoSingleton Instance
        {
            get
            {
                if (uniqueInstance == null)
                {
                    lock (syncRoot)
                    {
                        if (uniqueInstance == null)
                        {
                            uniqueInstance = new DatosPreAlmacenamientoSingleton();
                        }
                    }
                }
                return uniqueInstance;
            }
        }

        public T ObtenerDataAlmacenadaSession<T>(HttpSessionStateBase sessionbase, string sessionKey, Func<T> funcToGetData) where T : class
        {
            var dataStored = sessionbase[sessionKey] as T;
            if (dataStored == null)
            {
                dataStored = funcToGetData();
                sessionbase[sessionKey] = dataStored;
            }
            return dataStored;
        }

        public T ObtenerDataAlmacenadaSession_ConClave<T>(HttpSessionStateBase sessionbase, string sessionKey, Func<object[], T> funcToGetData, object[] dataKey) where T : class
        {
            T dataToReturn = default(T);
            var rawData = sessionbase[sessionKey] as Tuple<object[], T>;

            if (rawData != null && rawData.Item1.SequenceEqual(dataKey))
            {
                dataToReturn = rawData.Item2;
            }
            else if (rawData == null || !rawData.Item1.SequenceEqual(dataKey))
            {
                dataToReturn = funcToGetData(dataKey);
                sessionbase[sessionKey] = new Tuple<object[], T>(dataKey, dataToReturn);
            }
            return dataToReturn;
        }

        public T ObtenerDataAlmacenadaCache<T>(string cacheKey, Func<T> funcToGetData) where T : class
        {
            T dataStored = MemoryCache.Default.Get(cacheKey) as T;
            if (dataStored == null)
            {
                dataStored = funcToGetData();
                //var cacheObject = HttpContext.Cache;
                //cacheObject.Add()
                MemoryCache.Default.Set(cacheKey, dataStored, DateTime.Now.AddHours(24));
            }
            return dataStored;
        }
    }
}