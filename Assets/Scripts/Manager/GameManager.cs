using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("캐릭터")]
    [SerializeField] private GameObject playerPrefab;
    public Character Player { get; private set; }

    [Header("아이템 데이터베이스")]
    [SerializeField] private ItemDatabase itemDatabase;

    [Header("초기 아이템")]
    [SerializeField] private string[] initialItemNames = new string[] { "Sword", "Armor", "Ring" };

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
        CreatePlayer();
        AddInitialItems();
    }

    private void CreatePlayer()
    {
        GameObject playerObject = Instantiate(playerPrefab);
        Player = playerObject.GetComponent<Character>();

        Player.SetInitialStats(
            name: "Alex CoCo",
            job: "Coder",
            description: "Going To Home!",
            level: 5,
            exp: 10,
            maxExp: 100,
            gold: 3000,
            attack: 35,
            defense: 40,
            health: 100,
            critical: 25
        );
    }

    private void AddInitialItems()
    {
        foreach (string itemName in initialItemNames)
        {
            Item item = itemDatabase.GetItem(itemName);
            if (item != null)
            {
                Player.AddItem(item);
                Player.EquipItem(item);
            }
            else
            {
                Debug.LogWarning($"GameManager: {itemName} 아이템을 찾을 수 없습니다!");
            }
        }
    }

    public Character GetPlayer()
    {
        return Player;
    }
}