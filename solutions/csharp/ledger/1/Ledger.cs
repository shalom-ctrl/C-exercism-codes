using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

public class LedgerEntry
{
    public LedgerEntry(DateTime date, string desc, decimal chg)
    {
        Date = date;
        Desc = desc;
        Chg = chg;
    }

    public DateTime Date { get; }
    public string Desc { get; }
    public decimal Chg { get; }
}

public static class Ledger
{
    public static LedgerEntry CreateEntry(string date, string desc, int chng) =>
        new LedgerEntry(DateTime.Parse(date, CultureInfo.InvariantCulture), desc, chng / 100.0m);

    private static CultureInfo CreateCulture(string cur, string loc)
    {
        if (cur != "USD" && cur != "EUR") throw new ArgumentException("Invalid currency");
        if (loc != "nl-NL" && loc != "en-US") throw new ArgumentException("Invalid locale");

        var culture = new CultureInfo(loc);
        culture.NumberFormat.CurrencySymbol = cur == "USD" ? "$" : "€";
        
        // Setting specific negative patterns required by the tests
        if (loc == "nl-NL")
        {
            culture.NumberFormat.CurrencyNegativePattern = 12; // Formats as: € -1,23
            culture.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
        }
        else
        {
            culture.NumberFormat.CurrencyNegativePattern = 0; // Formats as: ($1.23)
            culture.DateTimeFormat.ShortDatePattern = "MM/dd/yyyy";
        }

        return culture;
    }

    private static string GetHeader(string loc) => loc switch
    {
        "en-US" => "Date       | Description               | Change       ",
        "nl-NL" => "Datum      | Omschrijving              | Verandering  ",
        _ => throw new ArgumentException("Invalid locale")
    };

    private static string FormatDescription(string desc) =>
        desc.Length > 25 ? $"{desc[..22]}..." : desc;

    private static string FormatChange(CultureInfo culture, decimal change)
    {
        // Enforce the specific padding/spacing required by the ledger alignment
        string formatted = change.ToString("C", culture);
        return culture.Name == "en-US" && change < 0 ? formatted : $"{formatted} ";
    }

    public static string Format(string currency, string locale, LedgerEntry[] entries)
    {
        var culture = CreateCulture(currency, locale);
        var sb = new StringBuilder(GetHeader(locale));

        var sortedEntries = entries
            .OrderBy(e => e.Date)
            .ThenBy(e => e.Desc)
            .ThenBy(e => e.Chg);

        foreach (var entry in sortedEntries)
        {
            sb.Append("\n");
            sb.Append(entry.Date.ToString("d", culture).PadRight(10));
            sb.Append(" | ");
            sb.Append(FormatDescription(entry.Desc).PadRight(25));
            sb.Append(" | ");
            sb.Append(FormatChange(culture, entry.Chg).PadLeft(13));
        }

        return sb.ToString();
    }
}