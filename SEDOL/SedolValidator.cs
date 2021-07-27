namespace SEDOL
{
    using System;
    using Interfaces;
    using Validations;

    /// <summary>
    /// Validate Input Sedol
    /// </summary>
    public class SedolValidator : ISedolValidator
    {
        /// <summary>
        /// Returns SedolValidationResult Object for the input sedol
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public ISedolValidationResult ValidateSedol(string input)
        {
            var sedolValidationResult = new SedolValidationResult();
            var sedolValidator = new SedolValidations(input);
            try
            {
                sedolValidationResult.InputString = input;
                if (sedolValidator.IsValidLength)
                {
                    sedolValidationResult.ValidationDetails = Constants.INAVLID_INPUT_STRING;
                }
                else if (sedolValidator.IsValidCharcters)
                {
                    sedolValidationResult.ValidationDetails = Constants.INAVLID_INPUT_CHARACTERS;
                }
                else
                {
                    if (sedolValidator.IsUserDefined)
                        sedolValidationResult.IsUserDefined = true;
                    sedolValidationResult.IsValidSedol = sedolValidator.IsValidSedol(input);
                    sedolValidationResult.ValidationDetails = sedolValidationResult.IsValidSedol ? null : Constants.INVALID_CHECKSUM_DIGIT;
                }

                return sedolValidationResult;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }

}
