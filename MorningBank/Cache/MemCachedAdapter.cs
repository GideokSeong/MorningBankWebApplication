using Couchbase;
using Couchbase.Configuration.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MorningBank.Cache
{
    public class MemCachedAdapter : IWebCache
    {
        static ClientConfiguration config = null;
        private readonly Cluster cluster = null;

        public MemCachedAdapter()
        {
            config = new ClientConfiguration
            {
                Servers = new List<Uri>
                {

                    //new Uri("http://localhost:8091/index.html"),
                    //new Uri("http://127.0.0.1:8091/ui"),
                    //new Uri("http://127.0.0.1:8091/pools"),
                    //new Uri("http://127.0.0.1:8091/ui/index.html#!/buckets?openedBucket=default"),
                    new Uri("http://localhost:8091/pools"),
                    //new Uri("http://localhost:53436/pools"),
                    //new Uri("http://192.168.56.102:8091/pools"),                     
                    //new Uri("http://192.168.56.103:8091/pools"),                     
                    //new Uri("http://192.168.56.104:8091/pools"),                 
                }
            };
            cluster = new Cluster(config);
        }

        // for Memcached product         
        //#region IWebCache Members 

        public void Remove(string key)
        {
            try
            {
                using (var cluster = new Cluster(config))
                {
                    using (var bucket = cluster.OpenBucket())
                    {
                        var upsert = bucket.Remove(key);
                    }
                }
            } catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void Store(string key, object obj)
        {
            try {
                using (var cluster = new Cluster(config))
                {
                    using (var bucket = cluster.OpenBucket())
                    {
                        var upsert = bucket.Upsert(key, obj);
                    }
                }
            } catch (Exception ex)
            {
                throw (ex);
            }
        }

        public T Retrieve<T>(string key)
        {
            T cachedData = default(T);

            using (var cluster = new Cluster(config))
            {
                using (var bucket = cluster.OpenBucket())
                {
                    var data = bucket.GetDocument<T>(key);
                    cachedData = data.Document.Content;
                }
            }
            return cachedData;
            //return default(T);             
            //throw new NotImplementedException();         
        }

    }

}