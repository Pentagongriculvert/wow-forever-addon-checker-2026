# Developer Notes

## Scope

This tool is a read-only add-on compatibility checker for World of Warcraft: Forever.

## Scanner

The scanner reads the `.toc` files inside the selected add-ons folder.

## Parser

The TOC parser reads the `## Interface:` line and the other standard fields of the file.

## Compatibility Rules

- Interface version 120000 or higher is marked Green.
- Interface version between 110000 and 119999 is marked Yellow.
- Interface version below 110000 is marked Red.

## Limitations

Some old add-ons may work without a TOC update, but this is not guaranteed.
