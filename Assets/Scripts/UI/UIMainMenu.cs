using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
    [Header("캐릭터 정보")]
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI jobText;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI expText;
    [SerializeField] private TextMeshProUGUI goldText;
    [SerializeField] private TextMeshProUGUI descriptionText;

    [Header("버튼")]
    [SerializeField] private Button statusButton;
    [SerializeField] private Button inventoryButton;

    private void Start()
    {
        if (statusButton != null)
        {
            statusButton.onClick.AddListener(() => UIManager.Instance.OpenStatusUI());
        }
        if (inventoryButton != null)
        {
            inventoryButton.onClick.AddListener(() => UIManager.Instance.OpenInventoryUI());
        }

        UpdateCharacterInfo();
    }

    public void UpdateCharacterInfo()
    {
        Character player = GameManager.Instance.GetPlayer();
        if (player == null) return;

        if (nameText != null) nameText.text = $"{player.Name}";
        if (jobText != null) jobText.text = $"{player.Job}";
        if (levelText != null) levelText.text = $"{player.Level}";
        if (expText != null) expText.text = $"{player.Exp:F0}/{player.MaxExp:F0}";
        if (goldText != null) goldText.text = $"{player.Gold:N0}";
        descriptionText.text = player.Description;
    }
}