public static class NPCData
{
    private static int npcComfort = 0;
    public static void AddToComfortValue(int additionalVal)
    {
        if (npcComfort >= -4 && npcComfort <= 4)
        {
            npcComfort += additionalVal;
        }
    }

    public static string GetComfortValue()
    {
        if (npcComfort > 0 && npcComfort <= 4)
        {
            return "-" + npcComfort;
        }
        else if (npcComfort == 0) 
        {
            return "" + npcComfort;
        }
        else
        {
            return "+" + npcComfort;
        }
    }
}