using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIInventory : MonoBehaviour
{
    [Header("슬롯 설정")]
    [SerializeField] private Transform slotParent;
    [SerializeField] private GameObject slotPrefab;

    [Header("아이템 정보 UI")]
    [SerializeField] private GameObject itemInfoPanel;
    [SerializeField] private TextMeshProUGUI itemNameText;
    [SerializeField] private TextMeshProUGUI itemTypeText;
    [SerializeField] private TextMeshProUGUI itemDescriptionText;
    [SerializeField] private TextMeshProUGUI itemStatsText;

    [Header("버튼")]
    [SerializeField] private Button backButton;

    private List<UISlot> slots = new List<UISlot>();

    private void Start()
    {
        if (backButton != null)
        {
            backButton.onClick.AddListener(() => UIManager.Instance.OpenMainMenu());
        }
    }

    public void SetCharacterData(Character player)
    {
        if (slotParent == null || slotPrefab == null)
        {
            Debug.LogError("UIInventory: 필수 컴포넌트가 없어 인벤토리를 표시할 수 없습니다.");
            return;
        }

        ClearSlots();

        if (player?.Inventory == null)
        {
            Debug.LogError("UIInventory: Player 또는 Inventory가 null입니다.");
            return;
        }

        CreateSlots(player.Inventory);
    }

    private void ClearSlots()
    {
        foreach (Transform child in slotParent)
        {
            Destroy(child.gameObject);
        }
        slots.Clear();
    }

    private void CreateSlots(List<Item> inventory)
    {
        foreach (var item in inventory)
        {
            GameObject slotObj = Instantiate(slotPrefab, slotParent);
            UISlot slot = slotObj.GetComponent<UISlot>();
            if (slot != null)
            {
                slot.SetItem(item);
                slot.OnSlotClicked += ShowItemInfo;
                slots.Add(slot);
            }
            else
            {
                Debug.LogError("UIInventory: slotPrefab에 UISlot 컴포넌트가 없습니다!");
            }
        }
    }

    private void ShowItemInfo(Item item)
    {
        if (item == null)
        {
            itemInfoPanel.SetActive(false);
            return;
        }

        itemInfoPanel.SetActive(true);
        itemNameText.text = item.Name;
        itemTypeText.text = item.Type.ToString();
        itemDescriptionText.text = item.Description;

        string stats = "";
        if (item.Attack > 0) stats += $"공격력: +{item.Attack}\n";
        if (item.Defense > 0) stats += $"방어력: +{item.Defense}\n";
        if (item.Health > 0) stats += $"체력: +{item.Health}\n";
        if (item.Critical > 0) stats += $"치명타: +{item.Critical}\n";

        itemStatsText.text = stats;
    }
}