using System.Collections.Generic;
using Classes;

namespace DefaultNamespace
{
    public static class BigData
    {
        public static Player Player { get; set; }
        public static Dictionary<MonsterBehaviour, Monster> MonstersMap = new Dictionary<MonsterBehaviour, Monster>();
    }
}