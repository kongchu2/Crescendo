using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combo
{
    public static int combo = 0;
    public Combo()
    {
        combo = 0;
    }
    public static void ComboBreak()
    {
        combo = 0;
    }
}
