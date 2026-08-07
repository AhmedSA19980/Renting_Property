using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PropertyRenting.ClassGlobal
{
    public class clsConvertListToDataTable<T>
    {
        public static DataTable ToDataTable(List<T> items) { 
        
            DataTable dt = new DataTable(typeof(T).Name);
            PropertyInfo[] props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in props) { 
                dt.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType)?? prop.PropertyType);
            
            }


            foreach (T item in items)
            {
                var Values = new object[props.Length];
                for (int i = 0; i < props.Length; i++)
                {
                    Values[i] = props[i].GetValue(item, null) ?? DBNull.Value;
                    
                }
                dt.Rows.Add(Values);
            }
            return dt;
        }
    }
}
