using System;
using Xunit;
using LabeledEnum;

namespace UnitTestProject
{
    public class UnitTest3
    {
        const string WHITE = "White";
        const string RED = "Red";
        const string BLUE = "Blue";
        const string GREEN = "Green";
        const string BLACK = "Black";


        public enum DuplicatedLabel
        {
            [EnumLabel(WHITE)]
            Albus,
            [EnumLabel(WHITE)]
            Niveus,
            [EnumLabel(RED)]
            Ruber,
            [EnumLabel(BLUE)]
            Blavus,
            [EnumLabel(GREEN)]
            Viridus,
            [EnumLabel(BLACK)]
            Ater,
        }


        [Theory]
        [InlineData(DuplicatedLabel.Albus, WHITE)]
        [InlineData(DuplicatedLabel.Niveus, WHITE)]
        [InlineData(DuplicatedLabel.Ruber, RED)]
        [InlineData(DuplicatedLabel.Blavus, BLUE)]
        [InlineData(DuplicatedLabel.Viridus, GREEN)]
        [InlineData(DuplicatedLabel.Ater, BLACK)]
        public void DuplicatedLabelToLabelTest(DuplicatedLabel value, string expected)
        {
            Assert.Equal(expected, value.ToLabelString());
        }


        [Theory]
        [InlineData(WHITE, default(DuplicatedLabel), false)]
        [InlineData(RED, DuplicatedLabel.Ruber, true)]
        [InlineData(BLUE, DuplicatedLabel.Blavus, true)]
        [InlineData(GREEN, DuplicatedLabel.Viridus, true)]
        [InlineData(BLACK, DuplicatedLabel.Ater, true)]
        
        public void DuplicatedLabelParseTest(string label, DuplicatedLabel expected, bool canParse)
        {
            try
            {
                var value = EnumLabel.Parse<DuplicatedLabel>(label);
                Assert.Equal(expected, value);
                Assert.True(canParse);
            }
            catch
            {
                Assert.False(canParse);
            }
        }

        [Theory]
        [InlineData(WHITE, default(DuplicatedLabel), false)]
        [InlineData(RED, DuplicatedLabel.Ruber, true)]
        [InlineData(BLUE, DuplicatedLabel.Blavus, true)]
        [InlineData(GREEN, DuplicatedLabel.Viridus, true)]
        [InlineData(BLACK, DuplicatedLabel.Ater, true)]
        public void DuplicatedLabelTryParseTest(string label, DuplicatedLabel expected, bool canParse)
        {

            bool canParsed = EnumLabel.TryParse<DuplicatedLabel>(label, out DuplicatedLabel result);
            Assert.Equal(canParse, canParsed);
            Assert.Equal(expected, result);

        }

    }
}