using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public Character Player { get; private set; }

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
        SetData();
    }

    private void SetData()
    {
        if (Player == null)
        {
            Player = new Character("Coder", "Alex CoCo", 5, 10, "Going To Home!", 3000, 35, 40, 100, 25);

            Item sword = new Item("강철검", ItemType.Weapon, "기본적인 강철로 만든 검", 15, 0, 0, 5);
            Item magicStaff = new Item("마법지팡이", ItemType.Weapon, "마법력을 증폭시키는 지팡이", 20, 0, 0, 10);

            Item shield = new Item("철방패", ItemType.Armor, "기본적인 방어구", 0, 15, 20, 0);
            Item leatherArmor = new Item("가죽갑옷", ItemType.Armor, "가볍고 유연한 갑옷", 0, 10, 15, 5);

            Item ring = new Item("힘의 반지", ItemType.Accessory, "힘을 증가시키는 반지", 5, 5, 10, 5);
            Item necklace = new Item("보호의 목걸이", ItemType.Accessory, "방어력을 증가시키는 목걸이", 0, 10, 15, 0);

            Player.AddItem(sword);
            Player.AddItem(magicStaff);
            Player.AddItem(shield);
            Player.AddItem(leatherArmor);
            Player.AddItem(ring);
            Player.AddItem(necklace);

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