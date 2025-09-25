using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INT0010._4PS.Services.CodeBase
{
    public  class CommonHelper
    {


        /// <summary>
        /// Metod för att hämta ett strängvärde från ett objekt.
        /// </summary>
        /// <param name="objValue">Objektet som ska konverteras till en sträng.</param>
        /// <param name="strDefaultValue">Default värde om objValue är null.</param>
        /// <returns>Returnerar objValue som sträng om objektet är ok, annars strDefaultValue.</returns>
        public static string GetStringValueFromObject(object objValue, string strDefaultValue)
        {

            if (objValue == null || objValue == DBNull.Value) return strDefaultValue;

            string strValue = strDefaultValue;

            try
            {
                strValue = Convert.ToString(objValue);
            }
            catch
            {
                strValue = strDefaultValue;
            }

            return strValue;
        }

        public static string GetStringValueFromObject(object objValue, string strDefaultValue, int totalWidth)
        {
            return GetStringValueFromObject(objValue, strDefaultValue).PadRight(totalWidth);
        }

        /// <summary>
        /// Metod för att hämta ett datum värde från ett objekt.
        /// </summary>
        /// <param name="objValue">Objektet som ska konverteras till ett datum.</param>
        /// <param name="dtDefaultValue">Default värde om objValue är null.</param>
        /// <returns>Returnerar objValue som datum om objektet är ok, annars dtDefaultValue.</returns>
        public static DateTime GetDateTimeValueFromObject(object objValue, DateTime dtDefaultValue)
        {
            if (objValue == null || objValue == DBNull.Value) return dtDefaultValue;

            DateTime dtValue = dtDefaultValue;

            try
            {
                dtValue = Convert.ToDateTime(objValue);
            }
            catch
            {
                dtValue = dtDefaultValue;
            }

            return dtValue;
        }

        /// <summary>
        /// Metod för att hämta ett heltalsvärde från ett objekt.
        /// </summary>
        /// <param name="objValue">Objektet som ska konverteras till ett heltal.</param>
        /// <param name="nDefaultValue">Default värde om objValue är null.</param>
        /// <returns>Returnerar objValue som heltal om objektet är ok, annars nDefaultValue.</returns>
        public static int GetIntValueFromObject(object objValue, int nDefaultValue)
        {
            if (objValue == null || objValue == DBNull.Value) return nDefaultValue;

            int nValue = nDefaultValue;

            try
            {
                nValue = Convert.ToInt32(objValue);
            }
            catch
            {
                nValue = nDefaultValue;
            }

            return nValue;
        }

        /// <summary>
        /// Metod för att hämta ett double värde från ett objekt.
        /// </summary>
        /// <param name="objValue">Objektet som ska konverteras till en double.</param>
        /// <param name="dDefaultValue">Default värde om objValue är null.</param>
        /// <returns>Returnerar objValue som double om objektet är ok, annars dDefaultValue.</returns>
        public static double GetDoubleValueFromObject(object objValue, double dDefaultValue)
        {
            if (objValue == null || objValue == DBNull.Value) return dDefaultValue;

            double dValue;

            try
            {
                // Om konvertering sker från en sträng kontrollerar vi att
                // konvertering sker med rätt decimaltecken
                if (objValue.GetType() == System.Type.GetType("System.String"))
                {
                    string strObj = (string)objValue;

                    if (strObj.IndexOf(".") > 0)
                    {
                        strObj = strObj.Replace(".", System.Threading.Thread.CurrentThread.CurrentUICulture.NumberFormat.NumberDecimalSeparator);
                        dValue = Convert.ToDouble(strObj, System.Threading.Thread.CurrentThread.CurrentUICulture);
                    }
                    else
                    {
                        if (strObj == String.Empty)
                            dValue = 0;
                        else
                            dValue = Convert.ToDouble(strObj);
                    }
                }
                else
                {
                    dValue = Convert.ToDouble(objValue);
                }
            }
            catch
            {
                dValue = dDefaultValue;
            }

            return dValue;
        }

        /// <summary>
        /// Metod för att hämta ett double värde från ett objekt.
        /// </summary>
        /// <param name="objValue">Objektet som ska konverteras till en double.</param>
        /// <param name="dDefaultValue">Default värde om objValue är null.</param>
        /// <returns>Returnerar objValue som double om objektet är ok, annars dDefaultValue.</returns>
        public static decimal GetDecimalValueFromObject(object objValue, decimal dDefaultValue)
        {
            if (objValue == null || objValue == DBNull.Value) return dDefaultValue;

            decimal dValue;

            try
            {
                // Om konvertering sker från en sträng kontrollerar vi att
                // konvertering sker med rätt decimaltecken
                if (objValue.GetType() == System.Type.GetType("System.String"))
                {
                    string strObj = (string)objValue;

                    if (strObj.IndexOf(".") > 0)
                    {
                        strObj = strObj.Replace(".", System.Threading.Thread.CurrentThread.CurrentUICulture.NumberFormat.NumberDecimalSeparator);
                        dValue = Convert.ToDecimal(strObj, System.Threading.Thread.CurrentThread.CurrentUICulture);
                    }
                    else
                    {
                        if (strObj == String.Empty)
                            dValue = 0;
                        else
                            dValue = Convert.ToDecimal(strObj);
                    }
                }
                else
                {
                    dValue = Convert.ToDecimal(objValue);
                }
            }
            catch
            {
                dValue = dDefaultValue;
            }

            return dValue;
        }

    }
}
