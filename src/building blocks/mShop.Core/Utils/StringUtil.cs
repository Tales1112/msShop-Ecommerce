using System.Linq;

namespace mShop.Core.Utils
{
    public static class StringUtil
    {
        public static string ApenasNumero(this string str, string input)
        {
            return new string(input.Where(char.IsDigit).ToArray());
        }
    }
}
