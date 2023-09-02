namespace ReNames.Models
{
    public class SettingsModel
    {
        public SettingsModel()
        {
            HideExtensions = true;
            ShowOnlyChanges=true;
            Language = "";
        }
        public string Language { get; set; }
        public bool HideExtensions { get; set; }
        public bool ShowOnlyChanges { get; set; }
    }
}
