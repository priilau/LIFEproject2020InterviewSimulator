using UnityEngine;

public static class NPCData
{
    public static int npcComfortValue;
    private static int npcComfort = 1;
    private static int maxNpcComfort = 4;
    private static int minNpcComfort = -4;
    public static void AddToComfortValue(int additionalVal)
    {
        npcComfortValue = npcComfort;
        if (npcComfort > minNpcComfort && npcComfort < maxNpcComfort)
        {
            npcComfort += additionalVal;
        }
        else if (npcComfort == minNpcComfort && additionalVal > 0)
        {
            npcComfort += additionalVal;
        }
        else if (npcComfort == maxNpcComfort && additionalVal < 0)
        {
            npcComfort += additionalVal;
        }
    }

    public static void SetMaxComfortValue(int distractingValue)
    {
        npcComfort -= distractingValue;
        maxNpcComfort -= distractingValue;
    }
    public static string GetComfortValue()
    {
        if (npcComfort < 0)
        {
            return "" + npcComfort;
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