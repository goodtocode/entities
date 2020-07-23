using System;

namespace GoodToCode.Shared.Extensions
{
    public static class StringExtensions
    {
        public static Guid ToGuid(this string item)
        {
            Guid result;
            return Guid.TryParse(item, out result) ? result : Guid.Empty;
        }
    }
}
