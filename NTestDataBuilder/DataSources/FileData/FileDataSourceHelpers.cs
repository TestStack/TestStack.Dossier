using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Reflection;
using Castle.Core.Internal;

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
            if (embeddedFilename.IsNullOrEmpty())
            {
                throw new ArgumentException("embeddedFilename cannot be null or empty");
            }
            var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(embeddedFilename);
            if (stream == null)
            {
                throw new InvalidOperationException("embeddedFilename must contain the fully qualified name of a CSV embedded resource");
            }
            
            var table = new DataTable();
            var reader = new StreamReader(stream);

            var headers = reader.ReadLine().Split(',');
            foreach (string header in headers)
            {
                table.Columns.Add(header.RemoveSurroundingQuotationMarks());
            }

            while (!reader.EndOfStream)
            {
                var columns = reader.ReadLine().Split(',');
                var row = table.NewRow();
                for (int index = 0; index < headers.Length; index++)
                {
                    row[index] = columns[index].RemoveSurroundingQuotationMarks();
                }
                table.Rows.Add(row);
            }
            return table;
        }

        private static string RemoveSurroundingQuotationMarks(this string original)
        {
            original = original.Remove(0, 1);
            return original.Remove(original.Length - 1);
        }
    }
}