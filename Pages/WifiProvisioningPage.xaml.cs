using System;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace BleScannerMaui.Pages
{
    public partial class WifiProvisioningPage : ContentPage
    {
        private readonly IBluetoothService _bluetooth;
        private readonly ILogService _log;

        public WifiProvisioningPage(IBluetoothService bluetooth, ILogService log)
        {
            InitializeComponent();
            _bluetooth = bluetooth;
            _log = log;
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            var ssid = SsidEntry.Text?.Trim() ?? string.Empty;
            var password = PasswordEntry.Text ?? string.Empty;

            if (string.IsNullOrWhiteSpace(ssid))
            {
                await DisplayAlert("Missing SSID", "Please enter the Wi‑Fi network name (SSID).", "OK");
                return;
            }

            try
            {
                StatusLabel.Text = "Sending credentials...";
                await _bluetooth.ProvisionWifiAsync(ssid, password);
                StatusLabel.Text = "Credentials sent. Check device status.";
            }
            catch (Exception ex)
            {
                StatusLabel.Text = $"Error: {ex.Message}";
                _log.Append($"Wi‑Fi provisioning error: {ex}");
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }
}
