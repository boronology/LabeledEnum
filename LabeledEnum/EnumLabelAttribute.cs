using System;

namespace LabeledEnum
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public class EnumLabelAttribute : Attribute
    {
        public string Label { get; }
        
        public EnumLabelAttribute(string label)
        {
            Label = label;
        }
    }
}