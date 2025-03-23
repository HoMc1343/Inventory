using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Weapon,
    Armor,
    Accessory
}

public class Item
{
    public string Name { get; private set; }
    public ItemType Type { get; private set; }
    public string Description { get; private set; }
    public int Attack { get; private set; }
    public int Defense { get; private set; }
    public int Health { get; private set; }
    public int Critical { get; private set; }
    public bool IsEquipped { get; private set; }

    public Item(string name, ItemType type, string description, int attack, int defense, int health, int critical)
    {
        Name = name;
        Type = type;
        Description = description;
        Attack = attack;
        Defense = defense;
        Health = health;
        Critical = critical;
        IsEquipped = false;
    }

    public void Equip() => IsEquipped = true;
    public void UnEquip() => IsEquipped = false;
}