
namespace CpfCnpj.Original
{
    public static class CNPJ
    {
        /// <summary>
        /// Valida um CNPJ.
        /// </summary>
        /// <param name="cnpj">CNPJ.</param>
        /// <returns>Retorna TRUE caso o CNPJ seja válido; FALSE caso contrário.</returns>
        public static bool IsValid(string cnpj)
        {
            try
            {
                int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
                int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
                int soma;
                int resto;
                string digito;
                string tempCnpj;

                cnpj = cnpj.GetDigitsOnly();

                if (cnpj.Length != 14)
                    return false;

                tempCnpj = cnpj.Substring(0, 12);
                soma = 0;

                for (int i = 0; i < 12; i++)
                    soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

                resto = (soma % 11);

                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;

                digito = resto.ToString();
                tempCnpj = tempCnpj + digito;
                soma = 0;

                for (int i = 0; i < 13; i++)
                    soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

                resto = (soma % 11);

                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;

                digito = digito + resto.ToString();

                return cnpj.EndsWith(digito);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Extrai apenas os dígitos do CNPJ e complementa com zeros à esquerda.
        /// </summary>
        /// <param name="cnpj">CNPJ.</param>
        /// <returns>Retorna apenas os dígitos do CNPJ.</returns>
        public static string StripAndPadWitZeros(string cnpj)
        {
            var cnpjWithDigitsOnly = cnpj?.GetDigitsOnly();

            if (string.IsNullOrEmpty(cnpjWithDigitsOnly))
                return null;

            return cnpjWithDigitsOnly.PadLeft(14, '0');
        }
    }
}
