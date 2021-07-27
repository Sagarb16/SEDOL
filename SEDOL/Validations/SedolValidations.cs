namespace SEDOL.Validations
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using System.Linq;

    /// <summary>
    /// Perform Sedol Validations
    /// </summary>
    public class SedolValidations
    {
        /// <summary>
        /// constants
        /// </summary>
        #region Constants
        private readonly IList<int> sedolWeight = new List<int>() { 1, 3, 1, 7, 3, 9 };
        private const int SEDOL_LENGTH = 7;
        private const char USER_DEFINED_CHARACTER = '9';
        private const int CHECK_DIGIT_INDEX = 6;
        private readonly Regex specialCharRegex = new Regex("[^A-Za-z0-9]");
        private readonly string _sedolInput = null;
        #endregion

        public SedolValidations(string input)
        {
            _sedolInput = input;
        }

        /// <summary>
        /// Properties
        /// </summary>
        #region Property Declaration

        /// <summary>
        /// Property returns true if input Sedol length invalid or null 0r empty
        /// </summary>
        public bool IsValidLength => string.IsNullOrEmpty(_sedolInput) || !_sedolInput.Length.Equals(SEDOL_LENGTH);

        /// <summary>
        /// Property returns true if invalid characters in Sedol
        /// </summary>
        public bool IsValidCharcters => _sedolInput.Length.Equals(SEDOL_LENGTH) && specialCharRegex.IsMatch(_sedolInput);

        /// <summary>
        /// Property returns true if user defined Sedol
        /// </summary>
        public bool IsUserDefined => _sedolInput.StartsWith(USER_DEFINED_CHARACTER.ToString());

        #endregion


        #region Public Method

        /// <summary>
        /// Returns true if valid sedol
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public bool IsValidSedol(string input)
        {
            List<int> sedolCharacters = new List<int>();
            try
            {
                char[] inputArray = input.ToCharArray();
                if (!char.IsLetter(inputArray[CHECK_DIGIT_INDEX]))
                {
                    int checkDigit = Convert.ToInt32(inputArray[CHECK_DIGIT_INDEX].ToString());
                    sedolCharacters = GetCharPosition(inputArray);
                    int sum = (10 - sedolCharacters.Sum() % 10) % 10;
                    return sum == checkDigit;
                }
                return false;
            }
            catch (Exception ex)
            { 
                throw ex; 
            }
        }

        #endregion


        #region Private Method

        /// <summary>
        /// Returns list after multiplying char position in sedol input with sedol weight
        /// </summary>
        /// <param name="inputArray"></param>
        /// <returns></returns>
        private List<int> GetCharPosition(char[] inputArray)
        {
            int charPosition; List<int> sedolCharacters = new List<int>();
            try
            {
                for (var i = 0; i < CHECK_DIGIT_INDEX; i++)
                {
                    charPosition = char.IsLetter(inputArray[i]) ? (char.ToUpper(inputArray[i]) - 55) : (inputArray[i] - 48);
                    sedolCharacters.Add(charPosition * sedolWeight[i]);
                }
                return sedolCharacters;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
