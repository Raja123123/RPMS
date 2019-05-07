using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Rpms.DataAccess
{
    public class Utility
    {
        public Utility()
        {

        }


        public string GetSheetName<T>()
        {
            var dnAttribute = typeof(T).GetCustomAttributes(
                typeof(SheetAttribute), true
            ).FirstOrDefault() as SheetAttribute;
            if (dnAttribute != null)
            {
                return dnAttribute.Name;
            }
            return null;
        }

        public Dictionary<string, string> GetColumns<T>()
        {
            Dictionary<string, string> _dict = new Dictionary<string, string>();

            PropertyInfo[] props = typeof(T).GetProperties();


            foreach (PropertyInfo prop in props)
            {


                object[] attrs = prop.GetCustomAttributes(true);
                if (attrs.Length == 0)
                {
                    _dict.Add(prop.Name, prop.Name);

                }
                else
                {
                    foreach (object attr in attrs)
                    {
                        ColumnAttribute columnAttr = attr as ColumnAttribute;
                        if (columnAttr != null)
                        {
                            _dict.Add(prop.Name, columnAttr.Name);
                        }
                        else
                        {
                            _dict.Add(prop.Name, prop.Name);
                        }
                    }
                }
            }

            return _dict;
        }

        public Dictionary<string, string> GetAllColumnValues<T>(T obj)
        {
            Dictionary<string, string> _dict = new Dictionary<string, string>();

            PropertyInfo[] props = typeof(T).GetProperties();
            foreach (PropertyInfo prop in props)
            {
                var value = obj.GetType().GetProperty(prop.Name).GetValue(obj, null);

                object[] attrs = prop.GetCustomAttributes(true);
                if (attrs.Length == 0)
                {
                    _dict.Add(prop.Name, value?.ToString());
                }
                else
                {
                    foreach (object attr in attrs)
                    {
                        ColumnAttribute columnAttr = attr as ColumnAttribute;
                        if (columnAttr != null)
                        {
                            _dict.Add(columnAttr.Name, value?.ToString());
                        }
                        else
                        {
                            _dict.Add(prop.Name, value?.ToString());
                        }
                    }
                }
            }

            return _dict;
        }

        public Dictionary<string, string> GetRuntimeColumnValues<T>(T obj)
        {
            Dictionary<string, string> _dict = new Dictionary<string, string>();


            string retString = String.Empty;

            var bindingFlags = System.Reflection.BindingFlags.Instance |
                                System.Reflection.BindingFlags.NonPublic |
                                System.Reflection.BindingFlags.Public | BindingFlags.DeclaredOnly;
            
            var props = typeof(T).GetProperties(bindingFlags);
            foreach (PropertyInfo prop in props)
            {
                var value = obj.GetType().GetProperty(prop.Name).GetValue(obj, null);
                if (value != null)
                {
                    object[] attrs = prop.GetCustomAttributes(true);
                    if (attrs.Length == 0)
                    {
                        _dict.Add(prop.Name, value?.ToString());
                    }
                    else
                    {
                        foreach (object attr in attrs)
                        {
                            ColumnAttribute columnAttr = attr as ColumnAttribute;
                            if (columnAttr != null)
                            {
                                _dict.Add(columnAttr.Name, value?.ToString());
                            }
                            else
                            {
                                _dict.Add(prop.Name, value?.ToString());
                            }
                        }
                    }
                }
            }

            return _dict;
        }

    }
}
