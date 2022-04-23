using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities.Helper
{
    public static class StringHelper
    {

        public static string FormatDateBrazilToUS(string dtValue, string inDelimiter = null, string outDelimiter = null)
        {
            var dd = ""; var mm = ""; var yyyy = "";
            var res = "";


            if (!String.IsNullOrEmpty(dtValue))
            {
                inDelimiter = String.IsNullOrEmpty(inDelimiter) ? "/" : inDelimiter;
                outDelimiter = String.IsNullOrEmpty(outDelimiter) ? "/" : outDelimiter;

                string[] dtArray = dtValue.Split(inDelimiter);

                dd = dtArray[0];
                mm = dtArray[1];
                yyyy = dtArray[2];

                if (int.TryParse(dd, out _) && int.TryParse(mm, out _) && int.TryParse(yyyy, out _))
                {
                    if (dd.Length <= 2 && mm.Length <= 2 && (yyyy.Length == 2 || yyyy.Length == 4))
                    {
                        var firstTwoDigits = DateTime.Today.Year.ToString().Substring(0, 2);
                        yyyy = yyyy.Length == 2 ? (firstTwoDigits + yyyy) : yyyy;

                        dtArray = new string[] { mm, dd, yyyy };

                        res = String.Join(outDelimiter, dtArray);
                    }
                }
            }

            return res;
        }
    }
}
