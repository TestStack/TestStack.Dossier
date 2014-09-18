using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Reflection;

namespace NTestDataBuilder.DataSources.FileData
{
    internal static class FileDataSourceHelpers
    {
        internal static IEnumerable<T> AsEnumerable<T>(this DataTable table) where T : new()
        {
            if (table == null)
                throw new NullReferenceException("DataTable");
            int propertiesLength = typeof(T).GetProperties().Length;
            if (propertiesLength == 0)
                throw new NullReferenceException("Properties");
            var objList = new List<T>();

            foreach (DataRow row in table.Rows)
            {
                var obj = new T();
                PropertyInfo[] objProperties = obj.GetType().GetProperties();
                for (int i = 0; i < propertiesLength; i++)
                {
                    PropertyInfo property = objProperties[i];
                    if (table.Columns.Contains(property.Name))
                    {
                        object objValue = row[property.Name];
                        var propertyType = property.PropertyType;
                        if (propertyType.IsGenericType && propertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                            propertyType = propertyType.GetGenericArguments()[0];
                        objProperties[i].SetValue(obj, Convert.ChangeType(objValue, propertyType, System.Globalization.CultureInfo.CurrentCulture), null);
                    }
                }
                objList.Add(obj);
            }
            return objList;
        }

        internal static DataTable ConvertCsvToDataTable(string embeddedFilename)
        {
            var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(embeddedFilename);
            var sr = new StreamReader(stream);
            var headers = sr.ReadLine().Split(',');
            var dt = new DataTable();
            foreach (string header in headers)
            {
                dt.Columns.Add(header);
            }
            while (!sr.EndOfStream)
            {
                var rows = sr.ReadLine().Split(',');
                var dr = dt.NewRow();
                for (int i = 0; i < headers.Length; i++)
                {
                    dr[i] = rows[i];
                }
                dt.Rows.Add(dr);
            }
            return dt;
        } 
    }
}