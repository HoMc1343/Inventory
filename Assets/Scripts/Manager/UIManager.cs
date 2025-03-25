using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [Header("UI 패널")]
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject mainMenuButton;
    [SerializeField] private GameObject statusPanel;
    [SerializeField] private GameObject inventoryPanel;

    [Header("UI 컴포넌트")]
    [SerializeField] private UIMainMenu uiMainMenu;
    [SerializeField] private GameObject uiMainMenuButton;
    [SerializeField] private UIStatus uiStatus;
    [SerializeField] private UIInventory uiInventory;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (uiMainMenu != null)
        {
            uiMainMenu.UpdateCharacterInfo();
        }
    }

    public void OpenMainMenu()
    {
        mainMenuPanel.SetActive(true);
        mainMenuButton.SetActive(true);
        statusPanel.SetActive(false);
        inventoryPanel.SetActive(false);
        if (uiMainMenu != null)
        {
            uiMainMenu.UpdateCharacterInfo();
        }
    }

    public void OpenStatusUI()
    {
        mainMenuPanel.SetActive(true);
        mainMenuButton.SetActive(false);
        statusPanel.SetActive(true);
        inventoryPanel.SetActive(false);
        if (uiStatus != null)
        {
            uiStatus.SetCharacterData(GameManager.Instance.GetPlayer());
        }
    }

    public void OpenInventoryUI()
    {
        mainMenuPanel.SetActive(true);
        mainMenuButton.SetActive(false);
        statusPanel.SetActive(false);
        inventoryPanel.SetActive(true);
        if (uiInventory != null)
        {
            uiInventory.SetCharacterData(GameManager.Instance.GetPlayer());
        }
    }

    public void SetCharacterData(Character player)
    {
        uiMainMenu.UpdateCharacterInfo();
    }
}