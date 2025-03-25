using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [Header("기본 정보")]
    [SerializeField] private string characterName;
    [SerializeField] private string job;
    [SerializeField] private string description;
    [SerializeField] private int level;
    [SerializeField] private float exp;
    [SerializeField] private float maxExp;
    [SerializeField] private int gold;

    [Header("스탯")]
    [SerializeField] private float attack;
    [SerializeField] private float defense;
    [SerializeField] private float health;
    [SerializeField] private float critical;

    [Header("장비")]
    [SerializeField] private Item weapon;
    [SerializeField] private Item armor;
    [SerializeField] private Item accessory;

    private List<Item> inventory = new List<Item>();
    private Dictionary<ItemType, Item> equippedItems = new Dictionary<ItemType, Item>();

    public string Name => characterName;
    public string Job => job;
    public string Description => description;
    public int Level => level;
    public float Exp => exp;
    public float MaxExp => maxExp;
    public int Gold => gold;
    public float Attack => attack;
    public float Defense => defense;
    public float Health => health;
    public float Critical => critical;
    public List<Item> Inventory => inventory;
    public Dictionary<ItemType, Item> EquippedItems => equippedItems;

    private void Start()
    {
        InitializeEquippedItems();
    }

    private void InitializeEquippedItems()
    {
        equippedItems[ItemType.Weapon] = weapon;
        equippedItems[ItemType.Armor] = armor;
        equippedItems[ItemType.Accessory] = accessory;
    }

    public void AddItem(Item item)
    {
        if (item == null) return;
        inventory.Add(item);
        UpdateStats();
    }

    public void RemoveItem(Item item)
    {
        if (item == null) return;
        inventory.Remove(item);
        UpdateStats();
    }

    public void EquipItem(Item item)
    {
        if (item == null) return;

        // 이미 장착된 아이템이 있다면 해제
        if (equippedItems.ContainsKey(item.Type))
        {
            UnEquipItem(equippedItems[item.Type]);
        }

        // 새 아이템 장착
        equippedItems[item.Type] = item;
        item.IsEquipped = true;
        UpdateStats();
    }

    public void UnEquipItem(Item item)
    {
        if (item == null) return;

        if (equippedItems.ContainsKey(item.Type) && equippedItems[item.Type] == item)
        {
            equippedItems[item.Type] = null;
            item.IsEquipped = false;
            UpdateStats();
        }
    }

    private void UpdateStats()
    {
        // 기본 스탯 초기화
        float baseAttack = attack;
        float baseDefense = defense;
        float baseHealth = health;
        float baseCritical = critical;

        // 장착된 아이템의 스탯 적용
        foreach (var equippedItem in equippedItems.Values)
        {
            if (equippedItem != null)
            {
                baseAttack += equippedItem.Attack;
                baseDefense += equippedItem.Defense;
                baseHealth += equippedItem.Health;
                baseCritical += equippedItem.Critical;
            }
        }

        // 최종 스탯 업데이트
        attack = baseAttack;
        defense = baseDefense;
        health = baseHealth;
        critical = baseCritical;
    }

    public void GainExp(float amount)
    {
        exp += amount;
        while (exp >= maxExp)
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        level++;
        exp -= maxExp;
        maxExp *= 1.2f; // 레벨업마다 필요 경험치 20% 증가

        // 레벨업 시 스탯 증가
        attack += 5;
        defense += 3;
        health += 20;
        critical += 0.5f;

        UpdateStats();
    }

    public void AddGold(int amount)
    {
        if (amount > 0)
        {
            gold += amount;
        }
    }

    public bool SpendGold(int amount)
    {
        if (amount > 0 && gold >= amount)
        {
            gold -= amount;
            return true;
        }
        return false;
    }

    public List<Item> GetInventoryItems()
    {
        return inventory;
    }

    public Item GetEquippedItem(ItemType type)
    {
        return equippedItems.ContainsKey(type) ? equippedItems[type] : null;
    }

    public void SetInitialStats(string name, string job, string description, int level, float exp, float maxExp, int gold, 
        float attack, float defense, float health, float critical)
    {
        this.characterName = name;
        this.job = job;
        this.description = description;
        this.level = level;
        this.exp = exp;
        this.maxExp = maxExp;
        this.gold = gold;
        this.attack = attack;
        this.defense = defense;
        this.health = health;
        this.critical = critical;
        UpdateStats();
    }
}
