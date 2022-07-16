namespace BestPractices.Business.Settings.NotificationSettings
{
    public class DomainNotification
    {
        public string Key { get; set; }
        public string Value { get; set; }

        public DomainNotification(string key, string value)
        {
            Key = key;
            Value = value;
        }

        public static IEnumerable<DomainNotification> Create(Dictionary<string, string> errors)
        {
            foreach(var error in errors)
                yield return new DomainNotification(error.Key, error.Value);
        }
    }
}
