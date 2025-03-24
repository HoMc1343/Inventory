using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character
{
    public string Job { get; private set; }
    public string Name { get; private set; }
    public int Level { get; private set; }
    public int Exp { get; private set; }
    public string Description { get; private set; }
    public int Gold { get; private set; }
    public int Attack { get; private set; }
    public int Defense { get; private set; }
    public int Health { get; private set; }
    public int Critical { get; private set; }
    public List<Item> Inventory { get; private set; }

    private int baseAttack, baseDefense, baseHealth, baseCritical;

    public Character(string job, string name, int level, int exp, string description, int gold, int attack, int defense, int health, int critical)
    {
        Job = job;
        Name = name;
        Level = level;
        Exp = exp;
        Description = description;
        Gold = gold;

        baseAttack = attack;
        baseDefense = defense;
        baseHealth = health;
        baseCritical = critical;

        Attack = baseAttack;
        Defense = baseDefense;
        Health = baseHealth;
        Critical = baseCritical;

        Inventory = new List<Item>();
    }

    public void AddItem(Item item)
    {
        if (item != null)
        {
            Inventory.Add(item);
        }
    }

    public void EquipItem(Item item)
    {
        if (Inventory.Contains(item) && !item.IsEquipped)
        {
            item.Equip();
            UpdateStats(item, true);
        }
    }

    public void UnEquipItem(Item item)
    {
        if (Inventory.Contains(item) && item.IsEquipped)
        {
            item.UnEquip();
            UpdateStats(item, false);
        }
    }

    private void UpdateStats(Item item, bool isEquipping)
    {
        int multiplier = isEquipping ? 1 : -1;
        Attack += item.Attack * multiplier;
        Defense += item.Defense * multiplier;
        Health += item.Health * multiplier;
        Critical += item.Critical * multiplier;
    }
}