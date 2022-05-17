using System.Collections.Generic;
using Classes;
using DefaultNamespace;

public static class BigData
{
    public static Player Player { get; set; }
    public static Dictionary<MonsterParameters, Monster> MonstersMap = new Dictionary<MonsterParameters, Monster>();

    public static void ReloadData()
    {
        Player = null;
        MonstersMap = new Dictionary<MonsterParameters, Monster>();
    }
}