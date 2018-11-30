using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace MorningBank.Utils
{
    public static class MyExtensions
    {
        public static string LosSerialize(this Object obj)
        {
            // extending the object class and adding a method called LosSerialize             
            var sw = new StringWriter();
            var formatter = new LosFormatter();  // encrypts, then does base64 encoding             
            formatter.Serialize(sw, obj);  // class object being serialized             
            return sw.ToString();       // has to be marked with [Serializable] attribute         
        }

        public static Object LosDeserialize(this String losEncData)
        {
            if (String.IsNullOrEmpty(losEncData))
                return null;
            var formatter = new LosFormatter();
            return formatter.Deserialize(losEncData);
        }
    }
}