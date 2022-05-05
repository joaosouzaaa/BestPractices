namespace BestPractices.Domain.Extensions
{
    public static class StringFormatExtension
    {
        public static string FormatTo(this string message, params object[] args)
        {
            return string.Format(message, args);
        }
    }
}
