using System;
using System.Text;

namespace BinaryNumberRepresentation
{
    /// <summary>
    /// Get a string binary representation of a double precision real number in IEEE 754 format.
    /// </summary>
    public static class StringRepresentationOfaNumber
    {
        const char NEGATIVE_OR_ZERO_NUMBER = '0';
        const char POSITIVE_NUMBER = '1';

        const int EXPONENT = 11;
        const int MANTISSA = 52;
        const int ORDER = 1023;

        /// <summary>
        /// Extension method that converts a number to binary in IEEE 754 format.
        /// </summary>
        /// <param name="number"></param>
        /// <returns>String representation of a number.</returns>
        public static string ToBinary(this double number)
        {
            var stringBuilder = new StringBuilder();

            char sign = GetSign(number);
            stringBuilder.Append(sign);

            if (sign == POSITIVE_NUMBER)
                number = -number;

            int exponent = GetExponent(number);
            double fraction = GetMantissa(number, exponent);

            stringBuilder.Append(GetExponentBinaryRepresentation(exponent));
            stringBuilder.Append(GetMantissaBinaryRepresentation(fraction));

            return stringBuilder.ToString();
        }

        /// <summary>
        /// Specifies the sign of a number.
        /// </summary>
        /// <param name="number"></param>
        /// <returns>Binary representation of a sign.</returns>
        private static char GetSign(double number)
        {
            if (number < 0)
                return POSITIVE_NUMBER;
            return NEGATIVE_OR_ZERO_NUMBER;
        }

        /// <summary>
        /// Defines a binary representation of an exponent.
        /// </summary>
        /// <param name="number"></param>
        /// <returns>Exponent in binary representation.</returns>
        private static string GetExponentBinaryRepresentation(int number)
        {
            char[] bits = new char[EXPONENT];

            for (int i = 0; i < EXPONENT; i++)
            {
                if ((number & 1) == 1)
                {
                    bits[EXPONENT - 1 - i] = POSITIVE_NUMBER;
                }
                else
                {
                    bits[EXPONENT - 1 - i] = NEGATIVE_OR_ZERO_NUMBER;
                }
                number >>= 1;
            }
            return new string(bits);
        }

        /// <summary>
        /// Defines a binary representation of an mantissa.
        /// </summary>
        /// <param name="fraction"></param>
        /// <returns>Mantissa in binary representation.</returns>
        private static string GetMantissaBinaryRepresentation(double fraction)
        {
            char[] bits = new char[MANTISSA];

            for (int i = 0; i < bits.Length; i++)
            {
                fraction *= 2;

                if (fraction < 1)
                {
                    bits[i] = NEGATIVE_OR_ZERO_NUMBER;
                }
                else
                {
                    bits[i] = POSITIVE_NUMBER;
                    fraction -= 1;
                }
            }
            return new string(bits);
        }

        /// <summary>
        /// Finds the order of the exponent.
        /// </summary>
        /// <param name="number"></param>
        /// <returns>Exponent order.</returns>
        private static int GetExponent(double number)
        {
            int power = 0;

            double fraction = number / Math.Pow(2, power) - 1;
            while (fraction < 0 || fraction >= 1)
            {
                power++;
                fraction = number / Math.Pow(2, power) - 1;
            }
            return power += ORDER; ;
        }

        /// <summary>
        /// Finds the order of the mantissa.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="exponent"></param>
        /// <returns>Mantissa order.</returns>
        private static double GetMantissa(double number, int exponent)
        {
            double fraction;

            exponent -= ORDER;
            fraction = number / Math.Pow(2, exponent) - 1;
            return fraction;
        }
    }
}
