using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathItemClassifier
{
    //Public Stash Tabs Query
    struct POEAPI_StashResponseJSON
    {
        public string next_change_id;
        public POEAPI_StashJSON[] stashes;
    }
    struct POEAPI_StashJSON
    {
        public string id;
        public string league;
        public POEAPI_ItemJSON[] items;
    }
    struct POEAPI_ItemJSON
    {
        public string icon;
        public string league;
        public string id;
        public POEAPI_SocketJSON[] sockets;
        public string name;
        public string typeLine;
        public bool identified;
        public int ilvl;
        public string note;
        public bool corrupted;
        public POEAPI_PropertiesJSON[] properties;
        public POEAPI_RequirmentsJSON[] requirements;
        public string[] explicitMods;
        public POEAPI_ExtendedJSON extended;
    }
    struct POEAPI_SocketJSON
    {
        public int group;
        public string attr;
        public string sColour;
    }
    struct POEAPI_PropertiesJSON
    {
        public string name;
        public string[][] values;
        public int type;
    }
    struct POEAPI_RequirmentsJSON
    {
        public string name;
        public string[][] values;
    }
    struct POEAPI_ExtendedJSON
    {
        public string category;
        public string[] subcategories;
    }
}
