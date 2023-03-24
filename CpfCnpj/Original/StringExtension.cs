
namespace CpfCnpj.Original
{
    public static partial class StringExtension
    {
        public static string GetDigitsOnly(this string text) => new String(text?.Where(Char.IsDigit).ToArray());
    }
}
