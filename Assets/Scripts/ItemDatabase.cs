using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemDatabase", menuName = "Item/Create Item Database")]
public class ItemDatabase : ScriptableObject
{
    [System.Serializable]
    public class ItemData
    {
        public string name;
        public ItemType type;
        public string description;
        public int attack;
        public int defense;
        public int health;
        public int critical;
        public Sprite icon;
    }

    public List<ItemData> items = new List<ItemData>();

    public ItemData GetItemData(string itemName)
    {
        return items.Find(item => item.name == itemName);
    }
} 