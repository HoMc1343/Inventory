using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
    [Header("캐릭터 정보")]
    [SerializeField] private TextMeshProUGUI jobText;
    [SerializeField] private TextMeshProUGUI nameText;
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
    }

    public void SetCharacterData(Character player)
    {
        if (player == null) return;

        jobText.text = player.Job;
        nameText.text = player.Name;
        levelText.text = $"Lv. {player.Level}";
        expText.text = $"Exp. {player.Exp}";
        goldText.text = $"{player.Gold} G";
        descriptionText.text = player.Description;
    }
}