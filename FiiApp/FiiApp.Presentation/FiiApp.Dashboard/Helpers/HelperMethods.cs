using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiiApp.Dashboard.Helpers
{
  public static class HelperMethods
  {
    public static string DateTimeToString(DateTime? date, string dateFormat)
    {
      if (date.HasValue)
      {
        return date.Value.ToString(dateFormat);
      }
      return string.Empty;
    }

    public static string DecimalToString(decimal? grade)
    {
      if (grade.HasValue)
      {
        var value = string.Format("{0:0.00}", grade.Value);
        if (value.Contains(","))
        {
          value = value.Replace(",", ".");
        }
        return value;
      }
      return string.Empty;
    }

    public static decimal? TruncateDecimal(decimal? value)
    {
      if(value.HasValue)
      {
        var truncValue = Math.Truncate(100 * value.Value) / 100;
        return truncValue;
      }
      return null;
    }
  }
}
