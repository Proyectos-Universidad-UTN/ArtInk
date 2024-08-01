namespace ArtInk.Utils;

public static class StringExtension
{
    public static String Capitalize(this string value) =>
        String.IsNullOrEmpty(value) ? String.Empty : char.ToUpper(value[0]) + value.Substring(1).ToLower();
}
