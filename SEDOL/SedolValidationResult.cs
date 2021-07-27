namespace SEDOL
{
    using Interfaces;

    /// <summary>
    /// SEDOL Validation Result Class
    /// </summary>
    public class SedolValidationResult : ISedolValidationResult
    {
        public string InputString { get; set; }
        public bool IsValidSedol { get; set; }
        public bool IsUserDefined { get; set; }
        public string ValidationDetails { get; set; }   
    }
}
