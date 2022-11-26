using System;
using System.Collections.Generic;
using System.Linq;

namespace Primes.API.Core
{
    public class PrimesManager : IPrimesManager
    {
        public int[] GetPrimesToLimit(int limit)
        {
            if (limit < 0 || limit > 100) 
            {
                throw new ArgumentOutOfRangeException($"{nameof(limit)} is out of range: it should be between 1 and 100 (inclusive).");
            }

            return ComputePrimesToLimit(limit);
        }

        // Sieve of Eratostehenes
        private int[] ComputePrimesToLimit(int limit)
        {
            List<int> primes = new();

            for (int i = 0; i <= limit; i++)
            {
                primes.Add(i);
            }

            primes[0] = 0;
            primes[1] = 0;

            int p = 2;
            while (p <= limit)
            {
                for (int i = p * p; i <= limit; i += p)
                {
                    primes[i] = 0;
                }

                p++;
            }

            return primes.Where(p => p != 0).ToArray();
        }
    }
}
