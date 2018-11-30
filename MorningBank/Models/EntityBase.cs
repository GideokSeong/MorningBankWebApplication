using MorningBank.DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;

namespace MorningBank
{
    [Serializable]
    public class EntityBase : IEntity
    {
        public void SetFields(DataRow dr)
        {
            // use reflection to set the fields from DataRow             
            Type tp = this.GetType();
            foreach (PropertyInfo pi in tp.GetProperties())
            {
                if (null != pi && pi.CanWrite)
                {
                    string nm = pi.PropertyType.Name.ToUpper();
                    string nmfull = pi.PropertyType.FullName.ToUpper();
                    if (nm.IndexOf("ENTITY") >= 0)
                        // In LINQ to SQL Classes, last properties are links to other tables                         
                        break;
                    if (nmfull.IndexOf("SYSTEM") < 0) // In LINQ to SQL Classes, properties without System. are links to other tables                         
                        break;
                    if (pi.PropertyType.Name.ToUpper() != "BINARY")
                        pi.SetValue(this, dr[pi.Name], null);
                }
            }
        }
    }
}