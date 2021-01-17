using System;
using System.Collections.Generic;
using System.Text;

namespace MovieDB
{
    public static class SafeConvert
    {
        public static List<string> EmptyList = new List<string>() { "", "N/A", "NA", "TBD", "UNKNOWN" };

        public static bool HasValue(this string Value)
        {
            return !string.IsNullOrEmpty(Value.SafeTrim())
                && !SafeConvert.EmptyList.Contains(Value.SafeTrim().ToUpper());
        }

        public static string SafeTrim(this object Value)
        {
            return ToSafeString(Value, string.Empty).Trim();
        }

		public static string ToSafeString(this object Value)
		{
			return ToSafeString(Value, string.Empty);
		}

		public static string ToSafeString(this object Value, string defaultValue)
		{
			try
			{
				if (Value == null)
				{
					return defaultValue;
				}
				else
				{
					return Value.ToString();
				}
			}
			catch
			{
				return defaultValue;
			}
		}

		public static decimal ToDecimal(this object value)
		{
			return ToDecimal(value, 0);
		}

		public static decimal ToDecimal(this object value, decimal defaultValue)
		{
			try
			{
				if (value == null)
				{
					return defaultValue;
				}
				else
				{
					return Convert.ToDecimal(value);
				}
			}
			catch
			{
				return defaultValue;
			}
		}

		public static Int32 ToInt32(this object Value)
		{
			return ToInt32(Value, default(Int32));
		}

		public static Int32 ToInt32(object Value, Int32 defaultValue)
		{
			try
			{
				if (Value == null)
				{
					return defaultValue;
				}
				else
				{
					return Convert.ToInt32(Value);
				}
			}
			catch
			{
				return defaultValue;
			}
		}

		public static Int64 ToInt64(this object Value)
        {
			return ToInt64(Value, default(Int64));
        }

		public static Int64 ToInt64(object Value, Int64 defaultValue)
        {
            try
            {
                if (Value == null)
                {
					return defaultValue;
                }
                else
                {
					return Convert.ToInt64(Value);
                }
            }
            catch
            {
				return defaultValue;
            }
        }
	}
}
