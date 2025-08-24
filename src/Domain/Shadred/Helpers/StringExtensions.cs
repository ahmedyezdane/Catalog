using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Domain.Shadred.Helpers;

public static class StringExtensions
{
    public static string ToSlug(this string value, int maxLength = 150)
    {
        if (string.IsNullOrWhiteSpace(value))
            return string.Empty;

        string normalized = value.Normalize(NormalizationForm.FormD);
        var sb = new StringBuilder();

        foreach (var c in normalized)
        {
            var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
            if (unicodeCategory != UnicodeCategory.NonSpacingMark)
            {
                sb.Append(c);
            }
        }

        string result = sb.ToString().Normalize(NormalizationForm.FormC);

        result = result.ToLowerInvariant();

        // Replace non-alphanumeric with hyphens
        result = Regex.Replace(result, @"[^a-z0-9\s-]", "");

        // Replace whitespace with single hyphen
        result = Regex.Replace(result, @"\s+", "-").Trim('-');

        // Replace multiple hyphens with single hyphen
        result = Regex.Replace(result, @"-+", "-");

        if (result.Length > maxLength)
            result = result.Substring(0, maxLength).Trim('-');

        return result;
    }
}
