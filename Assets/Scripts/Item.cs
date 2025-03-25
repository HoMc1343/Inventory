using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Weapon,
    Armor,
    Accessory
}

[CreateAssetMenu(fileName = "New Item", menuName = "Game/Item")]
public class Item : ScriptableObject
{
    [Header("기본 정보")]
    [SerializeField] private string itemName;
    [SerializeField] private ItemType type;
    [SerializeField] private string description;
    [SerializeField] private Sprite icon;

    [Header("스탯")]
    [SerializeField] private float attack;
    [SerializeField] private float defense;
    [SerializeField] private float health;
    [SerializeField] private float critical;

    public string Name => itemName;
    public ItemType Type => type;
    public string Description => description;
    public Sprite Icon => icon;
    public float Attack => attack;
    public float Defense => defense;
    public float Health => health;
    public float Critical => critical;
    public bool IsEquipped { get; set; }

    public void Equip() => IsEquipped = true;
    public void UnEquip() => IsEquipped = false;

    public static Item CreateInstance(string name, ItemType itemType, string desc, Sprite itemIcon, float atk, float def, float hp, float crit)
    {
        Item newItem = ScriptableObject.CreateInstance<Item>();
        newItem.itemName = name;
        newItem.type = itemType;
        newItem.description = desc;
        newItem.icon = itemIcon;
        newItem.attack = atk;
        newItem.defense = def;
        newItem.health = hp;
        newItem.critical = crit;
        return newItem;
    }
}