using System;
using Ampla.LogReader.Excel.Reader;
using ClosedXML.Excel;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace Ampla.LogReader.Excel
{
    public class ExcelCell
    {
        private readonly ICellReader cellReader;

        public ExcelCell(ICellReader cellReader)
        {
            this.cellReader = cellReader;
        }

        public bool IsEmpty
        {
            get 
            { 
                string value = GetValue<string>();
                return string.IsNullOrEmpty(value);
            }
            
        }

        public string Address
        {
            get { return cellReader.Address; }
            
        }

        public void AssertValue<T>(IResolveConstraint resolveConstraint)
        {
            T value = GetValue<T>();
            Assert.That(value, resolveConstraint);
        }

        public T GetValue<T>()
        {
            object val = cellReader.Value;

            if (val is XLCellValue xlVal)
            {
                if (xlVal.IsBlank)
                {
                    return default(T);
                }

                // Handle common target types directly from XLCellValue
                if (typeof(T) == typeof(string))
                {
                    return (T)(object)xlVal.ToString();
                }
                if (typeof(T) == typeof(int) && xlVal.IsNumber)
                {
                    return (T)(object)(int)xlVal.GetNumber();
                }
                if (typeof(T) == typeof(double) && xlVal.IsNumber)
                {
                    return (T)(object)xlVal.GetNumber();
                }
                if (typeof(T) == typeof(bool) && xlVal.IsBoolean)
                {
                    return (T)(object)xlVal.GetBoolean();
                }
                if (typeof(T) == typeof(DateTime) && xlVal.IsDateTime)
                {
                    return (T)(object)xlVal.GetDateTime();
                }

                // Fallback string representation
                return (T)Convert.ChangeType(xlVal.ToString(), typeof(T));
            }

            if (val == null || val == DBNull.Value)
            {
                return default(T);
            }

            if (typeof(T).IsAssignableFrom(val.GetType()))
            {
                return (T)val;
            }

            return (T)Convert.ChangeType(val, typeof(T));
        }
    }
}