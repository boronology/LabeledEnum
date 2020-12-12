using System;

namespace LabeledEnum
{
    public class EnumLabel
    {
        public static T Parse<T>(string label) where T : Enum
        {
            return default;
        }

        public static bool TryParse<T>(string label, out T result) where T : Enum
        {
            result = default;
            return false;
        }
    }
}