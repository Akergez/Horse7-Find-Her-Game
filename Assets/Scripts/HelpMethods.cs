using UnityEngine;

namespace DefaultNamespace
{
    public static class HelpMethods
    {
        public static bool IsNear(Transform first, Transform second, double distance)
        {
            return (first.position - second.position).Length() < distance;
        }
    }
}