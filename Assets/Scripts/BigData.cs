using System.Collections.Generic;
using Classes;

public static class BigData
{
    public static Player Player { get; set; }
    public static Dictionary<MonsterBehaviour, Monster> MonstersMap = new Dictionary<MonsterBehaviour, Monster>();

    public static void ReloadData()
    {
        Player = null;
        MonstersMap = new Dictionary<MonsterBehaviour, Monster>();
    }
}