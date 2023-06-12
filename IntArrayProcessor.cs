using System.Linq;

namespace Task5
{
    public class IntArrayProcessor
    {
        public static int[] ProcessIntArray(int[] numbers, int p)
        {
            return numbers
                .Where(x => x > 0)
                .Distinct()
                .OrderBy(x => x % p)
                .ThenByDescending(x => x)
                .ToArray();
        }
    }
}