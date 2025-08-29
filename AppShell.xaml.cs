using Microsoft.Maui.Controls;

namespace BleScannerMaui
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            // Optional explicit route registrations
            Routing.RegisterRoute("scanner", typeof(MainPage));
            Routing.RegisterRoute("wifi", typeof(Pages.WifiProvisioningPage));
        }
    }
}
