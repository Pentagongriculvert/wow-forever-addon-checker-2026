using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using WoWAddonChecker;

namespace WoWAddonChecker;

public partial class MainWindow : Window
{
    private readonly AddonScanner _addonScanner = new AddonScanner();

    private string _addonsPath = string.Empty;

    private List<AddonInfo> _addons = new List<AddonInfo>();

    public MainWindow()
    {
        InitializeComponent();
    }

    private void SelectFolderButton_Click(object sender, RoutedEventArgs e)
    {
        Microsoft.Win32.FolderBrowserDialog dialog = new Microsoft.Win32.FolderBrowserDialog();

        if (dialog.ShowDialog() == true)
        {
            _addonsPath = dialog.SelectedPath;
            ScanButton.IsEnabled = true;
            StatusTextBlock.Text = "Addons folder selected: " + _addonsPath;
        }
    }

    private void ScanButton_Click(object sender, RoutedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(_addonsPath))
        {
            StatusTextBlock.Text = "Select an addons folder before scanning.";
            return;
        }

        try
        {
            _addons = _addonScanner.Scan(_addonsPath);
            ResultsDataGrid.ItemsSource = _addons;
            StatusTextBlock.Text = "Scan complete. Found " + _addons.Count + " addon(s).";
        }
        catch (Exception ex)
        {
            StatusTextBlock.Text = "Scan failed: " + ex.Message;
        }
    }
}
