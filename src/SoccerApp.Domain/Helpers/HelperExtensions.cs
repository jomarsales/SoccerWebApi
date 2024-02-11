using System.Text.RegularExpressions;

namespace SoccerApp.Domain.Helpers
{
    public static class HelperExtensions
    {
        #region CPF

        public static long NormalizeCpf(this string cpf)
        {
            return long.Parse(Regex.Replace(cpf, @"\D", ""));
        }

        public static string DisplayCpf(this long cpf)
        {
            var cpfString = cpf.ToString("00000000000");

            return $"{cpfString.Substring(0, 3)}.{cpfString.Substring(3, 3)}.{cpfString.Substring(6, 3)}-{cpfString.Substring(9)}";
        }

        #endregion
    }
}
