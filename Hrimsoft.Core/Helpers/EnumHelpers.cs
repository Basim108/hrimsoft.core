using System;

namespace Hrimsoft.Core.Helpers
{
    /// <summary>
    /// Helpers for working with Enums
    /// </summary>
    public static class EnumHelpers
    {
        /// <summary>
        /// Ожидается что в БД все время храниться валидные данные, но это не так.
        /// В нашей компании многие любят работать с БД на прямую.
        /// Если требуется валидировать данные и если они не валидны подставлять значение по умолчанию, то пользуйтесь этим методом.
        /// </summary>
        /// <param name="value">Значение из БД, которое требуется проверить и распарсить</param>
        /// <param name="defaultValue">Значение, которое убдет возвращаено в случаи не валидности value</param>
        public static TEnum ParseAnyway<TEnum>(string value, TEnum defaultValue)
            where TEnum : struct
        {
            return Enum.TryParse<TEnum>(value, true, out var result) 
                ? result 
                : defaultValue;
        }
        
    }
}