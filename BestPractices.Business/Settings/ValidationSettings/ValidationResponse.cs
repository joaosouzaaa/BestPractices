namespace BestPractices.Business.Settings.ValidationSettings
{
    public class ValidationResponse
    {
        public Dictionary<string, string> Errors { get; set; }
        public bool Valid => Errors.Count == 0;

        private ValidationResponse(Dictionary<string, string> errors) =>
            Errors = errors;

        public static ValidationResponse CreateValidation(Dictionary<string, string> errors) =>
            new ValidationResponse(errors);
    }
}
