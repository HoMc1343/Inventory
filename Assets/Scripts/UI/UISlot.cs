using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UISlot : MonoBehaviour
{
    [Header("UI 요소")]
    [SerializeField] private Image itemIcon;
    [SerializeField] private TextMeshProUGUI itemNameText;
    [SerializeField] private Button equipButton;
    [SerializeField] private TextMeshProUGUI equipButtonText;

    private Item currentItem;

    public event Action<Item> OnSlotClicked;

    private void Start()
    {
        if (equipButton != null)
        {
            equipButton.onClick.RemoveAllListeners();
            equipButton.onClick.AddListener(HandleEquipButtonClick);
        }
    }

    private void HandleEquipButtonClick()
    {
        if (currentItem == null) return;

        if (currentItem.IsEquipped)
        {
            GameManager.Instance.GetPlayer().UnEquipItem(currentItem);
        }
        else
        {
            GameManager.Instance.GetPlayer().EquipItem(currentItem);
        }

        UpdateUI();
        UIManager.Instance.OpenStatusUI();
    }

    public void SetItem(Item item)
    {
        currentItem = item;
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (currentItem != null)
        {
            itemIcon.gameObject.SetActive(true);
            itemIcon.sprite = currentItem.Icon;
            itemNameText.text = currentItem.IsEquipped ? $"{currentItem.Name} (착용 중)" : currentItem.Name;
            equipButton.gameObject.SetActive(true);
            equipButtonText.text = currentItem.IsEquipped ? "해제" : "장착";
        }
        else
        {
            itemIcon.gameObject.SetActive(false);
            itemNameText.text = "";
            equipButton.gameObject.SetActive(false);
        }
    }
}