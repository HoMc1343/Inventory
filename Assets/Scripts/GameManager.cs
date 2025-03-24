using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public Character Player { get; private set; }

    [Header("아이템 데이터베이스")]
    [SerializeField] private ItemDatabase itemDatabase;

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
        ValidateItemDatabase();
        SetData();
    }

    private void ValidateItemDatabase()
    {
        if (itemDatabase == null)
        {
            Debug.LogError("GameManager: 아이템 데이터베이스가 할당되지 않았습니다. Inspector에서 확인해주세요.");
            return;
        }
    }

    private void SetData()
    {
        if (Player == null)
        {
            Player = new Character("Coder", "Alex CoCo", 5, 10, "Going To Home!", 3000, 35, 40, 100, 25);
            StartCoroutine(WaitForUIManager());
        }
    }


    private IEnumerator WaitForUIManager()
    {
        while (UIManager.Instance == null)
        {
            yield return null;
        }
        UIManager.Instance.SetCharacterData(Player);
    }
}