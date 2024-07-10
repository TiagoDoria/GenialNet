using System.Text.RegularExpressions;

namespace Application.Utils
{
    public static class Validations
    {
        public static bool ValidarCnpj(string cnpj)
        {
            var regex = new Regex(@"^\d{2}\.\d{3}\.\d{3}\/\d{4}\-\d{2}$");
            if(!regex.IsMatch(cnpj))
                return false;

            cnpj = new string(cnpj.Where(char.IsDigit).ToArray());
            var aux = cnpj.Substring(0, 12);
            var soma = 0;
            var primeirodigito = new int[] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            var segundodigito = new int[] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            if (cnpj.Length != 14)
                return false;           

            for (var i = 0; i < 12; i++)
                soma += int.Parse(aux[i].ToString()) * primeirodigito[i];

            var resto = (soma % 11);

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            var digito = resto.ToString();
            aux += digito;
            soma = 0;

            for (var i = 0; i < 13; i++)
                soma += int.Parse(aux[i].ToString()) * segundodigito[i];

            resto = (soma % 11);

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito += resto.ToString();

            if(cnpj.EndsWith(digito)) return true;
            return false;
        }
    }
}
