using Unity.Mathematics;
using UnityEngine;
using Random = Unity.Mathematics.Random;

public static class HelpMethods
{
    public static bool IsNear(Transform first, Transform second, double distance)
    {
        return (first.position - second.position).Length() < distance;
    }

    public static int GetRandomIndex(int min, int max)
    {
        return new Random().NextInt(min, max);
    }
}