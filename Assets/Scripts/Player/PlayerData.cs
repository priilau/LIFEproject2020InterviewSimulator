﻿using Assets.Scripts.UI.Feedback.FeedbackInfo;
using Assets.Scripts.UI.ItemSelection;
using System.Collections.Generic;

public static class PlayerData
{
    public static List<Item> selectedItems = new List<Item>();
    public static List<InfoCon> cons = new List<InfoCon>();
    public static List<InfoPro> pros = new List<InfoPro>();
    public static List<Info> info = new List<Info>();
    public static string playerName;
}
