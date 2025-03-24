using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Weapon,
    Armor,
    Accessory
}

[CreateAssetMenu(fileName = "NewItem", menuName = "Item/Create New Item")]
public class Item : ScriptableObject
{
    public string Name { get; private set; }
    public ItemType Type { get; private set; }
    public string Description { get; private set; }
    public int Attack { get; private set; }
    public int Defense { get; private set; }
    public int Health { get; private set; }
    public int Critical { get; private set; }
    public bool IsEquipped { get; private set; }
    public Sprite Icon { get; private set; }

    public void Initialize(string name, ItemType type, string description, int attack, int defense, int health, int critical, Sprite icon)
    {
        Name = name;
        Type = type;
        Description = description;
        Attack = attack;
        Defense = defense;
        Health = health;
        Critical = critical;
        Icon = icon;
        IsEquipped = false;
    }

    public void Equip() => IsEquipped = true;
    public void UnEquip() => IsEquipped = false;
}