using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Brilliantech.MonoScmPrinter.Client
{
    public class Session
    {
        public static void Set(string key, object value)
        {
            if (App.Current.Properties.Contains(key))
                App.Current.Properties.Remove(key);
            App.Current.Properties.Add(key, value);
        }

        public static object Get(string key)
        {
            if (App.Current.Properties.Contains(key))
            {
                return App.Current.Properties[key];
            }
            return null;
        }

        public static void Delete(string key)
        {
            if (App.Current.Properties.Contains(key))
                App.Current.Properties.Remove(key);
        }
    }
}
