using SoccerApp.Domain.Helpers;
using SoccerApp.Domain.Services;
using System.Text.RegularExpressions;

namespace SoccerApp.Domain.ValueObjects
{
    public class Cpf
    {
        public long Number { get; private set; }

        protected Cpf() { }

        public Cpf(string number)
        {
            AssertionConcern.AssertTrue(ValidateCPF(number), "CPF Inválido!");

            Number = number.NormalizeCpf();
        }

        public override string ToString()
        {
            return Number.DisplayCpf();
        }

        private static bool ValidateCPF(string cpf)
        {
            cpf = Regex.Replace(cpf, @"\D", "");

            if (cpf.Length != 11)
                return false;

            if (IsAllDigitsSame(cpf))
                return false;

            int soma = 0;
            
            for (int i = 0; i < 9; i++)
            {
                soma += int.Parse(cpf[i].ToString()) * (10 - i);
            }
            
            int resto = soma % 11;
            int digitoVerif1 = resto < 2 ? 0 : 11 - resto;

            if (digitoVerif1 != int.Parse(cpf[9].ToString()))
                return false;

            soma = 0;
            
            for (int i = 0; i < 10; i++)
            {
                soma += int.Parse(cpf[i].ToString()) * (11 - i);
            }
            
            resto = soma % 11;
            
            int digitoVerif2 = resto < 2 ? 0 : 11 - resto;

            if (digitoVerif2 != int.Parse(cpf[10].ToString()))
                return false;

            return true;
        }

        private static bool IsAllDigitsSame(string input)
        {
            for (int i = 1; i < input.Length; i++)
            {
                if (input[i] != input[0])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
