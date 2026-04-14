using UnityEngine;

[CreateAssetMenu(fileName = "NewStatData", menuName = "Game/Stat Data")]
public class StatData : ScriptableObject
{
    public enum StatsType
    {
        Hp,
        Melee_Strength,
        Ranged_Strength,
        movement_Speed
    }

    public StatsType type;
    public int value;

}