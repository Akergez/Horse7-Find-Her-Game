using System;
using System.Collections.Generic;
using Enums;
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
        return new Vector3(vector3.x * (float) scalar, vector3.y * (float) scalar, vector3.z * (float) scalar);
    }

    public static int GetAngle(this Vector3 firstvector, Vector3 secondVector)
    {
        return (int) (Math.Acos(firstvector.GetScalarProduct(secondVector) /
                                (firstvector.Length() * secondVector.Length())) * (180 / Math.PI));
    }

    public static double GetScalarProduct(this Vector3 firstVector, Vector3 secondVector)
    {
        return firstVector.x * firstVector.x + firstVector.y * secondVector.y + firstVector.z * secondVector.z;
    }

    public static Vector3 RoundToDirectionVector(this Vector3 vector)
    {
        if (vector.GetAngle(Vector3.up) <= 45)
            return Vector3.up;
        if (vector.GetAngle(Vector3.down) <= 45)
            return Vector3.down;
        if (vector.GetAngle(Vector3.left) <= 45)
            return Vector3.left;
        if (vector.GetAngle(Vector3.right) <= 45)
            return Vector3.right;

        return Vector3.zero;
    }
}