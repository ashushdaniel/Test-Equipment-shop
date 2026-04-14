using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] int inventorySize;

    [SerializeField] List<GameObject> equipButtons;
    [SerializeField] List<GameObject> unEquipButtons;

    List<EquipmentData> playerEquipments = new List<EquipmentData>();
    List<bool> isEquiped = new List<bool>();

    UIManager uIManager;

    void Start()
    {
        uIManager = FindFirstObjectByType<UIManager>();
        for (int i = 0; i < inventorySize; i++)
        {
            isEquiped.Add(false);
        }
    }

    public void AddEquipment(EquipmentData newEquipment)
    {
        //prevents player from stacking items of the same type
        for (int i = 0; i < playerEquipments.Count; i++)
        {
            if (playerEquipments[i].equipmentType == newEquipment.equipmentType)
            {
                UnEquip(i);
                playerEquipments[i] = newEquipment;
                equipButtons[i].SetActive(true);
                unEquipButtons[i].SetActive(false);
                return;
            }
        }

        playerEquipments.Add(newEquipment);
        equipButtons[playerEquipments.Count - 1].SetActive(true);
        uIManager.UpdateInventoryUI(playerEquipments);
    }

    public void Equip(int index)
    {
        //prevents player from equipping twice
        if (isEquiped[index] == false)
        {
            GetComponent<PlayerStats>().AddStats(playerEquipments[index].bonusAmount, playerEquipments[index].statBonusType);
            isEquiped[index] = true;
            equipButtons[index].SetActive(false);
            unEquipButtons[index].SetActive(true);
        }
    }

    public void UnEquip(int index)
    {
        //prevents player from unequipping twice
        if (isEquiped[index] == true)
        {
            GetComponent<PlayerStats>().ReduceStats(playerEquipments[index].bonusAmount, playerEquipments[index].statBonusType);
            isEquiped[index] = false;
            unEquipButtons[index].SetActive(false);
            equipButtons[index].SetActive(true);
        }
    }
}
