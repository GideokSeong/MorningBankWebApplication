using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MorningBank.Utils
{
    public class GenericFactory<T, I>
        where T : I, new() // T has to implement interface I and provide constructor
    {
        GenericFactory() { }  // hide the constructor         
        public static I GetInstance(params object[] args) // params allows for variable number of parameters         
        {
            return (I)Activator.CreateInstance(typeof(T), args); // T can have a constructor with parameters         
        }
    }
}