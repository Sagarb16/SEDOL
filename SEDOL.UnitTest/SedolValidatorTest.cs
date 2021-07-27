namespace SEDOL.UnitTest
{
    using Interfaces;
    using Xunit;

    public class SedolValidatorTest
    {
        private readonly ISedolValidator sedolValidator;
        public SedolValidatorTest()
        {
            sedolValidator = new SedolValidator();
        }

        [Theory]
        [InlineData("123456789")]
        [InlineData("1235")]
        [InlineData("null")]
        [InlineData(null)]
        [InlineData("")]
        public void Is_Sedol_Null_OR_Is_Sedol_Empty_OR_Is_Sedol_Not_Seven_Characters(string inputSedol)
        {
            var actualResult = sedolValidator.ValidateSedol(inputSedol);
            var ExpectedResult = new SedolValidationResult();
            Assert.Equal(inputSedol, actualResult.InputString);
            Assert.False(actualResult.IsValidSedol);
            Assert.False(actualResult.IsUserDefined);
            Assert.Equal(Constants.INAVLID_INPUT_STRING, actualResult.ValidationDetails);
        }

        [Theory]
        [InlineData("123.567")]
        [InlineData("67AB@67")]
        [InlineData("95!67R5")]
        [InlineData("0678+U5")]
        public void Is_Sedol_Contain_Invalid_Characters(string inputSedol)
        {
            var actualResult = sedolValidator.ValidateSedol(inputSedol);
            var ExpectedResult = new SedolValidationResult();
            Assert.Equal(inputSedol, actualResult.InputString);
            Assert.False(actualResult.IsValidSedol);
            Assert.False(actualResult.IsUserDefined);
            Assert.Equal(Constants.INAVLID_INPUT_CHARACTERS, actualResult.ValidationDetails);
        }

        [Theory]
        [InlineData("1234567")]
        public void Is_Sedol_NonUserDefined_With_Invalid_Checksum(string inputSedol)
        {
            var actualResult = sedolValidator.ValidateSedol(inputSedol);
            var ExpectedResult = new SedolValidationResult();
            Assert.Equal(inputSedol, actualResult.InputString);
            Assert.False(actualResult.IsValidSedol);
            Assert.False(actualResult.IsUserDefined);
            Assert.Equal(Constants.INVALID_CHECKSUM_DIGIT, actualResult.ValidationDetails);
        }

        [Theory]
        [InlineData("0709954")]
        [InlineData("B0YBKJ7")]
        public void Is_Sedol_NonUserDefined_With_Valid_Checksum(string inputSedol)
        {
            var actualResult = sedolValidator.ValidateSedol(inputSedol);
            var ExpectedResult = new SedolValidationResult();
            Assert.Equal(inputSedol, actualResult.InputString);
            Assert.True(actualResult.IsValidSedol);
            Assert.False(actualResult.IsUserDefined);
            Assert.Null(actualResult.ValidationDetails);
        }

        [Theory]
        [InlineData("9123451")]
        [InlineData("9ABCDE8")]
        public void Is_Sedol_UserDefined_With_InValid_Checksum(string inputSedol)
        {
            var actualResult = sedolValidator.ValidateSedol(inputSedol);
            var ExpectedResult = new SedolValidationResult();
            Assert.Equal(inputSedol, actualResult.InputString);
            Assert.False(actualResult.IsValidSedol);
            Assert.True(actualResult.IsUserDefined);
            Assert.Equal(Constants.INVALID_CHECKSUM_DIGIT, actualResult.ValidationDetails);
        }

        [Theory]
        [InlineData("9123458")]
        [InlineData("9ABCDE1")]
        public void Is_Sedol_UserDefined_With_Valid_Checksum(string inputSedol)
        {
            var actualResult = sedolValidator.ValidateSedol(inputSedol);
            var ExpectedResult = new SedolValidationResult();
            Assert.Equal(inputSedol, actualResult.InputString);
            Assert.True(actualResult.IsValidSedol);
            Assert.True(actualResult.IsUserDefined);
            Assert.Null(actualResult.ValidationDetails);
        }
    }
}
