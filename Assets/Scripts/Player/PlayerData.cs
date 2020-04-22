using Assets.Scripts.UI.Feedback.FeedbackInfo;
using Assets.Scripts.UI.ItemSelection;
using System.Collections.Generic;

public static class PlayerData
{
    private static List<Item> selectedItems;
    private static List<InfoCon> cons;
    private static List<InfoPro> pros;
    private static List<Info> info;
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
    public static List<InfoPro> Pros
    {
        get
        {
            return pros;
        }

        set
        {
            pros = value;
        }
    }
    public static List<InfoCon> Cons
    {
        get
        {
            return cons;
        }

        set
        {
            cons = value;
        }
    }
    public static List<Info> Info
    {
        get
        {
            return info;
        }

        set
        {
            info = value;
        }
    }
}
