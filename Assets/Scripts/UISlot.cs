using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UISlot : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI itemNameText;
    [SerializeField] private Button equipButton;
    [SerializeField] private Image itemIcon;

    private Item item;

    public event Action<Item> OnSlotClicked;

    public void SetItem(Item newItem)
    {
        item = newItem;
        if (item != null)
        {
            itemNameText.text = item.IsEquipped ? $"{item.Name} (착용 중)" : item.Name;
            itemIcon.gameObject.SetActive(true);
            equipButton.gameObject.SetActive(true);

            equipButton.onClick.RemoveAllListeners();
            equipButton.onClick.AddListener(() => ToggleEquip());
        }
        else
        {
            itemNameText.text = "";
            itemIcon.gameObject.SetActive(false);
            equipButton.gameObject.SetActive(false);
        }
    }

    public void OnClick()
    {
        OnSlotClicked?.Invoke(item);
    }

    private void ToggleEquip()
    {
        if (item == null) return;

        if (item.IsEquipped)
        {
            GameManager.Instance.Player.UnEquipItem(item);
        }
        else
        {
            GameManager.Instance.Player.EquipItem(item);
        }

        SetItem(item);
        UIManager.Instance.OpenStatusUI();
    }
}