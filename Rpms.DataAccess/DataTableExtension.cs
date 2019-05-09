using Rpms.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;


 
public static class DataTableExtension
{
    /// <summary>
    /// Converts a DataTable to a list with generic objects
    /// </summary>
    /// <typeparam name="T">Generic object</typeparam>
    /// <param name="table">DataTable</param>
    /// <returns>List with generic objects</returns>
    public static List<T> DataTableToList<T>(this DataTable table) 
    {
        try
        {
            List<T> list = new List<T>();

            foreach (var row in table.AsEnumerable())
            {
                T obj = (T)Activator.CreateInstance(typeof(T));

                foreach (var prop in obj.GetType().GetProperties())
                {
                    try
                    {
                        PropertyInfo propertyInfo = obj.GetType().GetProperty(prop.Name);
                        var columnName = string.Empty;
                        object[] attrs = prop.GetCustomAttributes(true);
                        if (attrs.Length == 0)
                        {
                            columnName = prop.Name;
                        }
                        else
                        {
                            foreach (object attr in attrs)
                            {
                                ColumnAttribute columnAttr = attr as ColumnAttribute;
                                if (columnAttr != null)
                                {
                                    columnName = columnAttr.Name;
                                }
                                else
                                {
                                    columnName = prop.Name;
                                }
                            }
                        }

                        if (propertyInfo.PropertyType == typeof(Guid))
                        {
                            propertyInfo.SetValue(obj, Convert.ChangeType(Guid.Parse(row[columnName].ToString()), propertyInfo.PropertyType), null);
                        }
                        else {
                            propertyInfo.SetValue(obj, Convert.ChangeType(row[columnName], propertyInfo.PropertyType), null);

                        }

                    }
                    catch (Exception exc)
                    {
                        continue;
                    }
                }

                list.Add(obj);
            }

            return list;
        }
        catch
        {
            return null;
        }
    }


    public static DataTable Find(this DataTable dataTable, string key, string [] columns = null)
    {
        try
        {
            var filteredDataTable = dataTable.Clone();
            var filteredRow = dataTable
                .Rows
                .Cast<DataRow>()
                .Where(r => r.ItemArray.Any(
                    c => c.ToString().IndexOf(key, StringComparison.OrdinalIgnoreCase) >= 0
                )).ToArray();

            foreach (DataRow row in filteredRow)
            {
                filteredDataTable.ImportRow(row);
            }

            return filteredDataTable;

        }
        catch
        {
            return null;
        }
    }
}


