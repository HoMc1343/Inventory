using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemDatabase", menuName = "Game/Item Database")]
public class ItemDatabase : ScriptableObject
{
    [System.Serializable]
    public class ItemData
    {
        public string Name;
        public ItemType Type;
        public string Description;
        public Sprite Icon;
        public float Attack;
        public float Defense;
        public float Health;
        public float Critical;
    }

    [SerializeField] private List<ItemData> items = new List<ItemData>();
    private Dictionary<string, ItemData> itemDictionary = new Dictionary<string, ItemData>();

    private void OnEnable()
    {
        InitializeDictionary();
    }

    private void InitializeDictionary()
    {
        itemDictionary.Clear();
        foreach (var item in items)
        {
            if (!string.IsNullOrEmpty(item.Name) && !itemDictionary.ContainsKey(item.Name))
            {
                itemDictionary.Add(item.Name, item);
            }
        }
    }

    public Item GetItem(string itemName)
    {
        if (itemDictionary.TryGetValue(itemName, out ItemData itemData))
        {
            return CreateItemFromData(itemData);
        }
        return null;
    }

    private Item CreateItemFromData(ItemData data)
    {
        Item item = ScriptableObject.CreateInstance<Item>();
        item.Initialize(
            name: data.Name,
            type: data.Type,
            description: data.Description,
            icon: data.Icon,
            attack: data.Attack,
            defense: data.Defense,
            health: data.Health,
            critical: data.Critical
        );
        return item;
    }

    public List<ItemData> GetAllItems()
    {
        return items;
    }
} 