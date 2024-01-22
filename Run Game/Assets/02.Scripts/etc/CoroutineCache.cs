using System.Collections.Generic;
using UnityEngine;

public class CoroutineCache
{
    class FloatCompare : IEqualityComparer<float>
    {
        public bool Equals(float x, float y)
        {
            return x == y;
        }

        public int GetHashCode(float obj)
        {
            return obj.GetHashCode();
        }
    }

    private static readonly Dictionary<float, WaitForSeconds> timeInterval = new(new FloatCompare());

    public static WaitForSeconds waitForSeconds(float time)
    {
        if (!timeInterval.TryGetValue(time, out WaitForSeconds waitForSeconds))
        {
            timeInterval.Add(time, waitForSeconds = new WaitForSeconds(time));
        }

        return waitForSeconds;
    }
}