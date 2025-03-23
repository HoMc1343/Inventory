using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [SerializeField] private UIMainMenu uiMainMenu;
    [SerializeField] private GameObject uiMainMenuButton;
    [SerializeField] private UIStatus uiStatus;
    [SerializeField] private UIInventory uiInventory;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        OpenMainMenu();
    }

    public void OpenMainMenu()
    {
        uiMainMenu.gameObject.SetActive(true);
        uiMainMenuButton.SetActive(true);
        uiStatus.gameObject.SetActive(false);
        uiInventory.gameObject.SetActive(false);
    }

    public void OpenStatus()
    {
        uiMainMenu.gameObject.SetActive(true);
        uiMainMenuButton.SetActive(false);
        uiStatus.gameObject.SetActive(true);
        uiInventory.gameObject.SetActive(false);
        uiStatus.SetCharacterData(GameManager.Instance.Player);
    }

    public void OpenInventoryUI()
    {
        uiMainMenu.gameObject.SetActive(true);
        uiMainMenuButton.SetActive(false);
        uiStatus.gameObject.SetActive(false);
        uiInventory.gameObject.SetActive(true);
        uiInventory.SetCharacterData(GameManager.Instance.Player);
    }

    public void SetCharacterData(Character player)
    {
        uiMainMenu.SetCharacterData(player);
    }
}