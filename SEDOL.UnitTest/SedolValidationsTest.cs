namespace SEDOL.UnitTest
{
    using Validations;
    using Xunit;

    public class SedolValidationsTest
    {
        [Theory]
        [InlineData("9123451")]
        [InlineData("9ABCDE8")]
        [InlineData("9123458")]
        [InlineData("9ABCDE1")]
        public void Is_Sedol_User_Defined(string input)
        {
            SedolValidations sedolValidations = new SedolValidations(input);
            var actualResult = sedolValidations.IsUserDefined;
            Assert.True(actualResult);
        }

        [Theory]
        [InlineData("1234567")]
        [InlineData("0709954")]
        [InlineData("B0YBKJ7")]
        public void Is_Sedol_Non_User_Defined(string input)
        {
            SedolValidations sedolValidations = new SedolValidations(input);
            var actualResult = sedolValidations.IsUserDefined;
            Assert.False(actualResult);
        }

        [Theory]
        [InlineData("1234567")]
        [InlineData("0709954")]
        [InlineData("B0YBKJ7")]
        public void Is_Sedol_Have_Valid_Characters(string input)
        {
            SedolValidations sedolValidations = new SedolValidations(input);
            var actualResult = sedolValidations.IsValidCharcters;
            Assert.False(actualResult);
        }

        [Theory]
        [InlineData("123.567")]
        [InlineData("#709&%5")]
        [InlineData("90_B*J7")]
        public void Is_Sedol_Have_Invalid_Characters(string input)
        {
            SedolValidations sedolValidations = new SedolValidations(input);
            var actualResult = sedolValidations.IsValidCharcters;
            Assert.True(actualResult);
        }

        [Theory]
        [InlineData("1234567")]
        [InlineData("0709954")]
        [InlineData("B0YBKJ7")]
        public void Is_Sedol_Have_Valid_Length(string input)
        {
            SedolValidations sedolValidations = new SedolValidations(input);
            var actualResult = sedolValidations.IsValidLength;
            Assert.False(actualResult);
        }

        [Theory]
        [InlineData("123")]
        [InlineData("123456789")]
        [InlineData("90_B*J790")]
        [InlineData("null")]
        [InlineData("")]
        [InlineData(null)]
        public void Is_Sedol_Have_Invalid_Length(string input)
        {
            SedolValidations sedolValidations = new SedolValidations(input);
            var actualResult = sedolValidations.IsValidLength;
            Assert.True(actualResult);
        }

        [Theory]
        [InlineData("0709954")]
        [InlineData("B0YBKJ7")]
        [InlineData("9123458")]
        [InlineData("9ABCDE1")]
        public void Is_Sedol_Valid(string input)
        {
            SedolValidations sedolValidations = new SedolValidations(input);
            var actualResult = sedolValidations.IsValidSedol(input);
            Assert.True(actualResult);
        }

        [Theory]
        [InlineData("1234567")]
        [InlineData("9123451")]
        [InlineData("9ABCDE8")]
        [InlineData("9ABCDER")]
        [InlineData("B0YBKJA")]
        public void Is_Sedol_InValid(string input)
        {
            SedolValidations sedolValidations = new SedolValidations(input);
            var actualResult = sedolValidations.IsValidSedol(input);
            Assert.False(actualResult);
        }
    }
}
