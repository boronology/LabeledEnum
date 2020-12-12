using System;
using Xunit;
using LabeledEnum;

namespace UnitTestProject
{
    public class UnitTest2
    {
        const string LABELED = "ラベルあり";

        public enum PartiallyLabeled 
        {
            None,
            [EnumLabel(LABELED)]
            Labeled,
            NotLabeled,

        }

        [Theory]
        [InlineData(PartiallyLabeled.None, null)]
        [InlineData(PartiallyLabeled.Labeled, LABELED)]
        [InlineData(PartiallyLabeled.NotLabeled, null)]
        public void PartiallyLabeledToLabelTest(PartiallyLabeled enumValue, string label)
        {
            //ToLabel
            Assert.Equal(label, enumValue.ToLabelString());
        }

        [Theory]
        [InlineData(LABELED, PartiallyLabeled.Labeled, true)]
        [InlineData("None", PartiallyLabeled.None, false)]
        [InlineData("Anything", PartiallyLabeled.None, false)]
        public void PartiallyLabeledParseTest(string label, PartiallyLabeled expected, bool canParse )
        {
            
            try
            {
                var result = EnumLabel.Parse<PartiallyLabeled>(label);
                Assert.Equal(expected, result);
                Assert.True(canParse);
            }
            catch
            {
                Assert.False(canParse);
            }
        }

        [Theory]
        [InlineData(LABELED, PartiallyLabeled.Labeled, true)]
        [InlineData("None", PartiallyLabeled.None, false)]
        [InlineData("Anything", PartiallyLabeled.None, false)]
        public void PartiallyLabeledTryParseTest(string label, PartiallyLabeled expected, bool canParse )
        {
            bool canParsed = EnumLabel.TryParse<PartiallyLabeled>(label, out PartiallyLabeled result);
            Assert.Equal(expected, result);
            Assert.Equal(canParse, canParsed);
        }
    }
}