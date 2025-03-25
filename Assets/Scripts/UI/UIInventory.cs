using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIInventory : MonoBehaviour
{
    [Header("슬롯 설정")]
    [SerializeField] private GameObject slotPrefab;
    [SerializeField] private Transform slotParent;
    [SerializeField] private int maxSlots = 20;

    [Header("아이템 정보 UI")]
    [SerializeField] private GameObject itemInfoPanel;
    [SerializeField] private TextMeshProUGUI itemNameText;
    [SerializeField] private TextMeshProUGUI itemTypeText;
    [SerializeField] private TextMeshProUGUI itemDescriptionText;

    [Header("버튼")]
    [SerializeField] private Button backButton;

    private List<UISlot> slots = new List<UISlot>();
    private Character player;

    private void Start()
    {
        InitializeSlots();
        if (backButton != null)
        {
            backButton.onClick.AddListener(() => UIManager.Instance.OpenMainMenu());
        }
    }

    private void InitializeSlots()
    {
        // 기존 슬롯 제거
        foreach (Transform child in slotParent)
        {
            Destroy(child.gameObject);
        }
        slots.Clear();

        // 새 슬롯 생성
        for (int i = 0; i < maxSlots; i++)
        {
            GameObject slotObj = Instantiate(slotPrefab, slotParent);
            UISlot slot = slotObj.GetComponent<UISlot>();
            slots.Add(slot);
        }
    }

    public void SetCharacterData(Character character)
    {
        player = character;
        UpdateInventoryUI();
    }

    private void UpdateInventoryUI()
    {
        if (player == null) return;

        var items = player.GetInventoryItems();
        for (int i = 0; i < slots.Count; i++)
        {
            if (i < items.Count)
            {
                slots[i].SetItem(items[i]);
            }
            else
            {
                slots[i].SetItem(null);
            }
        }
    }

    public void ShowItemInfo(Item item)
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
    }
}