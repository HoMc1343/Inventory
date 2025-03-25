using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UISlot : MonoBehaviour
{
    [SerializeField] private Image itemIcon;
    private Item item;

    public void SetItem(object obj)
    {
        if (obj is Item newItem)
        {
            item = newItem;
            itemIcon.sprite = item.Icon;
            itemIcon.enabled = true;
        }
        else
        {
            item = null;
            itemIcon.sprite = null;
            itemIcon.enabled = false;
        }
    }
}