using System;
using Xunit;
using LabeledEnum;


namespace UnitTestProject
{
    public class UnitTest1
    {
        private const string ADELIE = "アデリー";
        private const string HUMBOLDT = "フンボルト";
        private const string ROCKHOPPER = "イワトビ";
        private const string GENTOO = "ジェンツー";
        private const string CHINSTRAP = "ヒゲ";

        public enum EnumWithAttribute
        {
            [EnumLabel(ADELIE)]
            Adelie,
            [EnumLabel(HUMBOLDT)]
            Humboldt,
            [EnumLabel(ROCKHOPPER)]
            Rockhopper,
            [EnumLabel(GENTOO)]
            Gentoo,
            [EnumLabel(CHINSTRAP)]
            Chinstrap,

        }

        public enum EnumWithoutAttribute
        {
            Apple,
            Orange,
            Lemon,
        }


        [Theory]
        [InlineData(EnumWithAttribute.Adelie, ADELIE)]
        [InlineData(EnumWithAttribute.Chinstrap, CHINSTRAP)]
        [InlineData(EnumWithAttribute.Gentoo, GENTOO)]
        [InlineData(EnumWithAttribute.Humboldt, HUMBOLDT)]
        [InlineData(EnumWithAttribute.Rockhopper, ROCKHOPPER)]
        public void ToLabelStringTest(EnumWithAttribute argument, string expected)
        {
            Assert.Same(expected, argument.ToLabelString());
        }


        [Theory]
        [InlineData(ADELIE, EnumWithAttribute.Adelie)]
        [InlineData(CHINSTRAP, EnumWithAttribute.Chinstrap)]
        [InlineData(GENTOO, EnumWithAttribute.Gentoo)]
        [InlineData(HUMBOLDT, EnumWithAttribute.Humboldt)]
        [InlineData(ROCKHOPPER, EnumWithAttribute.Rockhopper)]
        public void ParseTest(string argument, EnumWithAttribute expected)
        {
            Assert.Same(expected, EnumLabel.Parse<EnumWithAttribute>(argument));
        }


        [Theory]
        [InlineData(ADELIE, EnumWithAttribute.Adelie, true)]
        [InlineData(CHINSTRAP, EnumWithAttribute.Chinstrap, true)]
        [InlineData(GENTOO, EnumWithAttribute.Gentoo, true)]
        [InlineData(HUMBOLDT, EnumWithAttribute.Humboldt, true)]
        [InlineData(ROCKHOPPER, EnumWithAttribute.Rockhopper, true)]
        [InlineData("エンペラー", default(EnumWithAttribute), false)]
        public void TryParseTest(string argument, EnumWithAttribute value, bool canParse)
        {
            bool isSuccess = EnumLabel.TryParse(argument, out EnumWithAttribute result);
            Assert.Same(canParse, isSuccess);

            Assert.Same(value, result);
        }


    }
}
