using System.Collections;

namespace RandomCinema.Application.Utils;

public class ListAlgorithms
{
    private static Random _rng = new Random();

    public static void Shuffle(IList list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = _rng.Next(n + 1);
            var value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}