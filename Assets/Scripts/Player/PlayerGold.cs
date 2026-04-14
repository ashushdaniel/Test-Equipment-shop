using UnityEngine;

public class PlayerGold : MonoBehaviour
{
    UIManager uIManager;
    int playerGold;

    void Start()
    {
        playerGold = 0;
        uIManager = FindFirstObjectByType<UIManager>();
        UpdateGoldText();
    }

    public int GetPlayerGold() { return playerGold; }

    public void AddGold(int amount) { playerGold += amount; UpdateGoldText(); }

    public void ReduceGold(int amount) { playerGold -= amount; UpdateGoldText(); }

    void UpdateGoldText() { uIManager.UpdateGoldText(playerGold); }
}
