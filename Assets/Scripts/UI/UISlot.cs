using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UISlot : MonoBehaviour
{
    [SerializeField] private Image itemIcon;
    private Item item;
    public UnityEvent<Item> onItemClicked;

    private void Awake()
    {
        if(onItemClicked == null)
            onItemClicked = new UnityEvent<Item>();
    }

    public void SetItem(Item newItem)
    {
        item = newItem;
        if (item != null)
        {
            itemIcon.sprite = item.Icon;
            itemIcon.enabled = true;
        }
        else
        {
            itemIcon.sprite = null;
            itemIcon.enabled = false;
        }
    }

    public void OnClick()
    {
        if (item != null)
        {
            onItemClicked.Invoke(item);
        }
    }
}