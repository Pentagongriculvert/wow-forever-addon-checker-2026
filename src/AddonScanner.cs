using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace WoWAddonChecker;

public class AddonInfo
{
    public string Name { get; set; } = string.Empty;

    public string TocPath { get; set; } = string.Empty;

    public int InterfaceVersion { get; set; }

    public DateTime LastModified { get; set; }

    public string Status { get; set; } = string.Empty;
}

public class AddonScanner
{
    public const int CompatibleInterfaceVersion = 120000;

    public const int LegacyInterfaceVersion = 110000;

    public List<AddonInfo> Scan(string addonsPath)
    {
        if (!Directory.Exists(addonsPath))
        {
            throw new DirectoryNotFoundException("Addons folder was not found: " + addonsPath);
        }

        List<AddonInfo> results = new List<AddonInfo>();

        string[] tocFiles = Directory.GetFiles(addonsPath, "*.toc", SearchOption.TopDirectoryOnly);

        foreach (string tocPath in tocFiles)
        {
            TocData tocData = new TocParser().Parse(tocPath);

            AddonInfo addonInfo = new AddonInfo
            {
                Name = ResolveAddonName(tocPath),
                TocPath = tocPath,
                InterfaceVersion = tocData.InterfaceVersion,
                LastModified = File.GetLastWriteTime(tocPath),
                Status = ResolveStatus(tocData.InterfaceVersion)
            };

            results.Add(addonInfo);
        }

        return results;
    }

    private string ResolveAddonName(string tocPath)
    {
        return Path.GetFileNameWithoutExtension(tocPath);
    }

    private string ResolveStatus(int interfaceVersion)
    {
        if (interfaceVersion >= CompatibleInterfaceVersion)
        {
            return "Green";
        }

        if (interfaceVersion >= LegacyInterfaceVersion)
        {
            return "Yellow";
        }

        return "Red";
    }
}
