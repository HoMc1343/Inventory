using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI playerJobText;
    [SerializeField] private TextMeshProUGUI playerNameText;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI expText;
    [SerializeField] private TextMeshProUGUI goldText;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private Button statusButton;
    [SerializeField] private Button inventoryButton;

    public void SetCharacterData(Character player)
    {        
        playerJobText.text = player.Job;
        playerNameText.text = player.Name;
        levelText.text = $"Lv. {player.Level}";
        expText.text = $"Exp. {player.Exp}";
        descriptionText.text = $"{player.Description}";
        goldText.text = $"{player.Gold} G";
    }
}
