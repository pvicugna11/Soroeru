using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ShuffleExtensions
{
    public static void Shuffle<T> (this IList<T> array)
    {
        for (var i = array.Count - 1; i > 0; --i)
        {
            var j = Random.Range(0, i + 1);

            var tmp = array[i];
            array[i] = array[j];
            array[j] = tmp;
        }
    }
}
