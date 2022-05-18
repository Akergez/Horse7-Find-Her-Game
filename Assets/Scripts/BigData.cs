using System.Collections.Generic;

public static class BigData
{
    public static PlayerParameters Player { get; set; }

    public static void ReloadData()
    {
        Player = null;
    }
}