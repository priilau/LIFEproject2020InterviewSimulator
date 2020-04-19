using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.UI.JSONReader
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
