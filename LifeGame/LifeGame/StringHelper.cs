using System.Text;

namespace LifeGame
{
    static class StringHelper
    {
        const int STRING_BEGIN = 0;
        const int FOUR_OCTETS = 32;

        public static string Reverse(this string str)
        {
            string buffer = string.Empty;
            foreach (char chr in str)
                buffer += chr.ToString();
            return buffer;
        }

        public static string AdjustNumberOfBitsToN(this string binary, int numberOfBits = FOUR_OCTETS)
        {
            StringBuilder adjustedBinary = new StringBuilder(binary);
            int bitsToAddUntilN = numberOfBits - adjustedBinary.Length;

            for (int i = 0; i < bitsToAddUntilN; i++)
                adjustedBinary.Insert(STRING_BEGIN, "0");

            return adjustedBinary.ToString();
        }
    }
}
