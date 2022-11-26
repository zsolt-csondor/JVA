namespace Primes.API.Core
{
    public interface IPrimesManager
    {
        int[] GetPrimesToLimit(int limit);
    }
}