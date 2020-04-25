﻿using System;

namespace Assets.Scripts.UI.ItemSelection
{
    [Serializable]
    public class Item
    {
        public string gameObjectName;
        public string itemName;
        public bool required;
        public bool distracting;
    }
}