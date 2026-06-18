using System;
using System.Collections.Generic;
using System.Text;

namespace Hours.Domain.Shared.Helpers
{
    public static class UsefulFunctions
    {
        public static bool ValidDate(this string pData)
        {
            try
            {
                if (pData != "")
                    Convert.ToDateTime(pData);
                else
                    return false;
            }
            catch
            {
                return false;
            }
            return true;
        }

        public static bool ValidField(this Guid pGuid)
        {
            return (pGuid != null);
        }

        public static bool ValidField(this string pString)
        {
            return (pString ?? "").Trim().Length > 0;
        }

        public static bool ValidField(this int pInt)
        {
            return !((pInt.ToString() ?? "").Trim() == "" || pInt == 0);
        }

        public static bool ValidField(this int? pInt)
        {
            return !((pInt.ToString() ?? "").Trim() == "" || pInt == 0);
        }

        public static bool ValidField(this Decimal? pDecimal)
        {
            return (pDecimal ?? 0m) > 0m;
        }

        public static bool ValidField(this Decimal pDecimal)
        {
            return pDecimal > 0m;
        }

        public static bool ValidField(this long? pLong)
        {
            return (pLong ?? 0m) > 0m;
        }

        public static bool ValidField(this long pLong)
        {
            return pLong > 0m;
        }


    }
}
