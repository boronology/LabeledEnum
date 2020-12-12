using System;

namespace LabeledEnum
{
    public static class ExtensionMethods
    {
        /// <summary>
        /// Enumの値からラベルに指定した文字列を取得する。
        /// Labelが指定されていないときはnullを返す。
        /// </summary>
        /// <param name="e">変換元のEnum値</param>
        /// <returns></returns>
        public static string ToLabelString(this Enum e)
        {
            return null;
        }
    }
}
