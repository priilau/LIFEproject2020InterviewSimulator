using Assets.Scripts.UI.ItemSelection;
using System.Collections.Generic;

public static class PlayerData
{
    private static List<Item> selectedItems;
    public static string playerName;
    public static List<Item> SelectedItems
    {
        get
        {
            return selectedItems;
        }
        set
        {
            selectedItems = value;
        }
    }
}
