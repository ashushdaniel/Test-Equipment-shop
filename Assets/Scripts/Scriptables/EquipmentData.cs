using UnityEngine;

[CreateAssetMenu(fileName = "NewEquipmentData", menuName = "Game/Equipment Data")]
public class EquipmentData : ScriptableObject
{
    public enum EquipmentType
    {
        Sword,
        Bow,
        Shield,
        boots
    }
    public EquipmentType equipmentType;

    public StatData.StatsType statBonusType;

    public Sprite sprite;
    public string equipmentName;
    public string discription;
    public int bonusAmount;
    public int goldValue;
}