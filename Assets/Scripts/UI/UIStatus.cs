using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIStatus : MonoBehaviour
{
    [Header("스탯 정보")]
    [SerializeField] private TextMeshProUGUI attackText;
    [SerializeField] private TextMeshProUGUI defenseText;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private TextMeshProUGUI criticalText;

    [Header("버튼")]
    [SerializeField] private Button backButton;

    private void Start()
    {
        if (backButton != null)
        {
            backButton.onClick.AddListener(() => UIManager.Instance.OpenMainMenu());
        }
    }

    public void SetCharacterData(Character player)
    {
        if (player == null) return;

        attackText.text = $"{player.Attack}";
        defenseText.text = $"{player.Defense}";
        healthText.text = $"{player.Health}";
        criticalText.text = $"{player.Critical}";
    }
}
