﻿using System;

namespace GreatestCommonDivisor
{
    /// <summary>
    /// Searches for the greatest common divisor.
    /// </summary>
    public class FindGCD
    {
        /// <summary>
        /// Calculates the greatest common divisor by the Euclid algorithm with two input parameters.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>GCD</returns>
        public long SearchByEuclid(long x, long y)
        {
            if (x == 0 || y == 0)
                throw new ArgumentException();

            while (x != y)
            {
                if (x > y)
                {
                    long temp = x;
                    x = y;
                    y = temp;
                }
                y = y - x;
            }
            return x; ;
        }

        /// <summary>
        /// Calculates the greatest common divisor by the Euclid algorithm with an array of input parameters.
        /// </summary>
        /// <param name="array"></param>
        /// <returns>GCD</returns>
        public long SearchByEuclid(long[] array)
        {
            if (array == null)
                throw new ArgumentNullException();

            if (array.Length < 2)
                throw new ArgumentException();

            long gcd = SearchByEuclid(array[0], array[1]);

            for (int i = 2; i < array.Length; i++)
            {
                gcd = SearchByEuclid(gcd, array[i]);
            }
            return gcd;
        }

        /// <summary>
        /// Calculates the greatest common divisor by the Stein algorithm with two input parameters.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>GCD</returns>
        public long SearchByStein(long x, long y)
        {
            long gcd = 0;

            if (x == 0 || y == 0)
                throw new ArgumentException();
            else if (x == y)
                gcd = x;

            if (gcd != 0)
                return gcd;

            if ((x & 1) == 0)
                gcd = ((y & 1) == 0)
                    ? SearchByStein(x >> 1, y >> 1) << 1
                    : SearchByStein(x >> 1, y);
            else
                gcd = ((y & 1) == 0)
                    ? SearchByStein(x, y >> 1)
                    : SearchByStein(y, x > y ? x - y : y - x);
            return gcd;
        }

        /// <summary>
        /// Calculates the greatest common divisor by the Stein algorithm with an array of input parameters.
        /// </summary>
        /// <param name="array"></param>
        /// <returns>GCD</returns>
        public long SearchByStein(long[] array)
        {
            if (array == null)
                throw new ArgumentNullException();

            if (array.Length < 2)
                throw new ArgumentException();

            long gcd = SearchByStein(array[0], array[1]);

            for (int i = 0; i < array.Length; i++)
            {
                gcd = SearchByStein(gcd, array[i]);
            }
            return gcd;
        }
    }
}
