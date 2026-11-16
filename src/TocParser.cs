using System;
using System.Text.RegularExpressions;

namespace WoWAddonChecker;

public class TocData
{
    public int InterfaceVersion { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Notes { get; set; } = string.Empty;

    public string SavedVariables { get; set; } = string.Empty;
}

public class TocParser
{
    private static readonly Regex InterfaceRegex = new Regex(@"^##\s+Interface:\s*(\d+)", RegexOptions.Multiline | RegexOptions.IgnoreCase);

    private static readonly Regex TitleRegex = new Regex(@"^##\s+Title:\s*(.*)", RegexOptions.Multiline | RegexOptions.IgnoreCase);

    private static readonly Regex NotesRegex = new Regex(@"^##\s+Notes:\s*(.*)", RegexOptions.Multiline | RegexOptions.IgnoreCase);

    private static readonly Regex SavedVariablesRegex = new Regex(@"^##\s+SavedVariables:\s*(.*)", RegexOptions.Multiline | RegexOptions.IgnoreCase);

    public TocData Parse(string tocPath)
    {
        if (!System.IO.File.Exists(tocPath))
        {
            throw new System.IO.FileNotFoundException("TOC file was not found.", tocPath);
        }

        string content = System.IO.File.ReadAllText(tocPath);

        Match interfaceMatch = InterfaceRegex.Match(content);

        if (!interfaceMatch.Success)
        {
            throw new InvalidOperationException("TOC file has no Interface line: " + tocPath);
        }

        int interfaceVersion = int.Parse(interfaceMatch.Groups[1].Value);

        Match titleMatch = TitleRegex.Match(content);

        Match notesMatch = NotesRegex.Match(content);

        Match savedVariablesMatch = SavedVariablesRegex.Match(content);

        return new TocData
        {
            InterfaceVersion = interfaceVersion,
            Title = titleMatch.Success ? titleMatch.Groups[1].Value.Trim() : string.Empty,
            Notes = notesMatch.Success ? notesMatch.Groups[1].Value.Trim() : string.Empty,
            SavedVariables = savedVariablesMatch.Success ? savedVariablesMatch.Groups[1].Value.Trim() : string.Empty
        };
    }
}
