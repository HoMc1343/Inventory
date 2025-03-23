using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIInventory : MonoBehaviour
{
    [SerializeField] private Transform slotParent;
    [SerializeField] private GameObject slotPrefab;

    public void SetCharacterData(Character player)
    {
        foreach (Transform child in slotParent) Destroy(child.gameObject);

        foreach (var item in player.Inventory)
        {
            GameObject slotObj = Instantiate(slotPrefab, slotParent);
            UISlot slot = slotObj.GetComponent<UISlot>();
            slot.SetItem(item);
        }
    }
}