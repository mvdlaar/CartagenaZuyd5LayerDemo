using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace CartagenaZuyd5LayerDemo.Util
{
    public class CartagenaUtil
    {
        /// <summary>
        /// Fills a Dictionary object based on a given object using Reflection
        /// </summary>
        /// <author>Lucas Jones (edited by Miguel van de Laar)</author>
        /// <source>http://stackoverflow.com/questions/737151/how-to-get-the-list-of-properties-of-a-class</source>
        /// <param name="atype">Object of any type</param>
        /// <returns>Datadictionary with attribute names as key and values from parameter object</returns>
        public static Dictionary<string, object> DictionaryFromType(object atype)
        {
            if (atype == null) return new Dictionary<string, object>();
            Type t = atype.GetType();
            PropertyInfo[] props = t.GetProperties();
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            foreach (PropertyInfo prp in props)
            {
                TypeCode typeCode = Type.GetTypeCode(prp.PropertyType);
                // The if-statement below is to avoid complex types
                // Add any needed classtypes
                if (typeCode == TypeCode.String || typeCode == TypeCode.Int32 || typeCode == TypeCode.Boolean || typeCode == TypeCode.DateTime || typeCode == TypeCode.Decimal)
                {
                    object value = prp.GetValue(atype, new object[] { });
                    dictionary.Add(prp.Name, value);
                }
            }
            return dictionary;
        }

        /// <summary>
        /// Updates a given object to reflect changes in values from a DataDictionary object
        /// </summary>
        /// <author>Miguel van de Laar</author>
        /// <param name="atype">The object to be updated</param>
        /// <param name="dictionary">The Dictionary object containing keyvalues matching attribute names with (new) values</param>
        public static void UpdateTypeFromDictionary(object atype, Dictionary<string, object> dictionary)
        {
            Type t = atype.GetType();
            PropertyInfo[] props = t.GetProperties();
            foreach (PropertyInfo prp in props)
            {
                if (dictionary[prp.Name] != null)
                {
                    object value = prp.GetValue(atype, new object[] { });
                    if (value != Convert.ChangeType(dictionary[prp.Name], prp.PropertyType)) // Only update if changed
                    {
                        prp.SetValue(atype, Convert.ChangeType(dictionary[prp.Name], prp.PropertyType), null);
                    }
                }
            }
        }

        /// <summary>
        /// Function below makes a DataTable out of an array
        /// This enables you to make a DataTable out of a set of Entity Framework entities and then bind this to a Data component
        /// To do this simply link the DataTable to the component, eg  dvComponent.DataSource = GetDataTable(myDataArray);
        /// And then (IMPORTANT!!!) bind the data, eg                  dvComponent.DataBind();
        /// </summary>
        /// <author>Bob Tossaint</author>
        /// <param name="data">An Array of entity elements, for instance the result of an Entity Framework LINQ query</param>
        /// <returns>A DataTable filled with the elements from the data Array. Each element in the array is turned into a column in the DataTable</returns>
        public static DataTable GetDataToTable(Array data)
        {
            DataTable dt = new DataTable();

            for (int i = 0; i < data.Length; i++)
            {
                Dictionary<string, object> dict = DictionaryFromType(data.GetValue(i));
                if (i == 0)
                {
                    foreach (KeyValuePair<String, object> kvp in dict)
                    {
                        dt.Columns.Add(kvp.Key);    // Name columns
                    }
                }
                DataRow dr = dt.NewRow();
                foreach (KeyValuePair<String, object> kvp in dict)
                {
                    dr[kvp.Key] = kvp.Value;        // Add values to columns
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }

    }
}