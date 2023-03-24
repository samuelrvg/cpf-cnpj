
namespace CpfCnpj.Original
{
    public static class CPF
    {
        /// <summary>
        /// Valida um CPF.
        /// </summary>
        /// <param name="cpf">CPF.</param>
        /// <returns>Retorna TRUE caso o CPF seja válido; FALSE caso contrário.</returns>
        public static bool IsValid(string cpf)
        {
            try
            {
                if (string.IsNullOrEmpty(cpf) || cpf.Length > 11)
                {
                    return false;
                }
                else if (cpf.Length != 11)
                {
                    cpf = cpf.PadLeft(11, '0');
                }

                ReadOnlySpan<char> valor = cpf;

                bool igual = true;

                for (int i = 1; i < 11 && igual; i++)
                {
                    if (valor.Slice(i, 1)[0] != valor.Slice(0, 1)[0])
                    {
                        igual = false;
                    }
                }

                if (igual || valor == "12345678909")
                {
                    return false;
                }

                int[] numeros = new int[11];

                for (int i = 0; i < 11; i++)
                {
                    numeros[i] = int.Parse(valor.Slice(i, 1));
                }

                int soma = 0;

                for (int i = 0; i < 9; i++)
                {
                    soma += (10 - i) * numeros[i];
                }

                int resultado = soma % 11;

                if (resultado == 1 || resultado == 0)
                {
                    if (numeros[9] != 0)
                    {
                        return false;
                    }
                }
                else if (numeros[9] != 11 - resultado)
                {
                    return false;
                }

                soma = 0;

                for (int i = 0; i < 10; i++)
                {
                    soma += (11 - i) * numeros[i];
                }

                resultado = soma % 11;

                if (resultado == 1 || resultado == 0)
                {
                    if (numeros[10] != 0)
                    {
                        return false;
                    }
                }
                else
                {
                    if (numeros[10] != 11 - resultado)
                    {
                        return false;
                    }
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Extrai apenas os dígitos do CPF e complementa com zeros à esquerda.
        /// </summary>
        /// <param name="cpf">CPF.</param>
        /// <returns>Retorna apenas os dígitos do CPF.</returns>
        public static string StripAndPadWitZeros(string cpf)
        {
            var cpfWithDigitsOnly = cpf?.GetDigitsOnly();

            if (string.IsNullOrEmpty(cpfWithDigitsOnly))
                return null;

            return cpfWithDigitsOnly.PadLeft(11, '0');
        }
    }
}
