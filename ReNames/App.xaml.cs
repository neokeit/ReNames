using System.Globalization;
using System.Windows;

namespace ReNames
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {

        }
        internal static void SetLanguague(string language)
        {
            if(!string.IsNullOrEmpty(language))
            {
                var cultureInfo = new CultureInfo(language);
                CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
                CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
            }
        }
    }
}
