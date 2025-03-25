using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemDatabase", menuName = "Game/Item Database")]
public class ItemDatabase : ScriptableObject
{
    [SerializeField] private List<Item> items = new List<Item>();
    private Dictionary<string, Item> itemDictionary = new Dictionary<string, Item>();

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
        return itemDictionary.TryGetValue(itemName, out Item item) ? item : null;
    }

    public List<Item> GetAllItems()
    {
        return items;
    }
}