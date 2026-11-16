using System.Collections.Generic;
using System.IO;

namespace WoWAddonChecker;

public class ReportExporter
{
    public void Export(List<AddonInfo> addons, string path)
    {
        using StreamWriter writer = new StreamWriter(path);

        writer.WriteLine("Name,TocPath,InterfaceVersion,LastModified,Status");

        foreach (AddonInfo addon in addons)
        {
            writer.WriteLine(
                Escape(addon.Name) + "," + Escape(addon.TocPath) + "," + addon.InterfaceVersion.ToString() + "," + addon.LastModified.ToString("yyyy-MM-dd HH:mm:ss") + "," + Escape(addon.Status)
            );
        }
    }

    private string Escape(string value)
    {
        return "\"" + value.Replace("\"", "\"\"") + "\"";
    }
}
