using Unity.Mathematics;
using UnityEngine;


public static class Vector3Extensions
{
    public static double Length(this Vector3 vector3)
    {
        return math.sqrt(vector3.x * vector3.x + vector3.y * vector3.y + vector3.z * vector3.z);
    }

    public static Vector3 Leeeeeeength(this Vector3 vector3, double scalar)
    {
        return new Vector3(vector3.x * (float)scalar, vector3.y * (float)scalar, vector3.z * (float)scalar);
    }
}