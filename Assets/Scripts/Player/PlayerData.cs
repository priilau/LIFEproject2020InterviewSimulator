﻿using Assets.Scripts.UI.JSONReader;
using System.Collections.Generic;

public static class PlayerData
{
    private static List<Item> selectedItems;
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