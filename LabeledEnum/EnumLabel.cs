using System;
using System.Linq;

namespace LabeledEnum
{
    public class EnumLabel
    {
        public static T Parse<T> (string label) where T : Enum
        {
            if (label is null)
            {
                throw new ArgumentNullException ();
            }

            var valueAndAttribute = GetEnumAndLabel<T> (label);
            if (valueAndAttribute.Length == 0)
            {
                throw new Exception ($"ラベル\"{label}\"を持つ値はEnum\"{typeof(T)}\"に存在しません");
            }
            if (valueAndAttribute.Length > 1)
            {
                throw new Exception ($"ラベル\"{label}\"を持つ値はEnum\"{typeof(T)}\"に複数存在します（{string.Join(",", valueAndAttribute.Select(x => x.Item1))}）");
            }
            return valueAndAttribute[0].Item1;
        }

        public static bool TryParse<T> (string label, out T result) where T : Enum
        {
            if (label is null)
            {
                result = default;
                return false;
            }
            var valueAndAttribute = GetEnumAndLabel<T> (label);
            if (valueAndAttribute.Length == 1)
            {
                result = valueAndAttribute[0].Item1;
                return true;
            }

            result = default;
            return false;
        }

        private static (T, EnumLabelAttribute) [] GetEnumAndLabel<T> (string label) where T : Enum
        {
            var type = typeof (T);

            return Enum.GetValues (type)
                .OfType<T> ()
                .Select (x =>
                {
                    var field = type.GetField (x.ToString ());
                    var attribute = field.GetCustomAttributes (false).OfType<EnumLabelAttribute> ().FirstOrDefault ();
                    return (x, attribute);
                })
                .Where (x => x.attribute?.Label == label)
                .ToArray ();
        }
    }
}