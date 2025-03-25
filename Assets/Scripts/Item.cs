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

    public void Initialize(string name, ItemType type, string description, Sprite icon, 
        float attack, float defense, float health, float critical)
    {
        this.itemName = name;
        this.type = type;
        this.description = description;
        this.icon = icon;
        this.attack = attack;
        this.defense = defense;
        this.health = health;
        this.critical = critical;
        this.IsEquipped = false;
    }

    public void Equip() => IsEquipped = true;
    public void UnEquip() => IsEquipped = false;
}