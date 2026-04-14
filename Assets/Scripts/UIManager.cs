using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI goldText;
    [SerializeField] List<Image> InventoryImages;
    [SerializeField] List<TextMeshProUGUI> statsTexts;

    public void UpdateGoldText(int value)
    {
        goldText.text = "Gold:\n" + value.ToString();
    }
    public void UpdateInventoryUI(List<EquipmentData> equipments)
    {
        for (int i = 0; i < InventoryImages.Count && i < equipments.Count; i++)
        {
            InventoryImages[i].sprite = equipments[i].sprite;
        }
    }
    public void UpdateStats(List<StatData> statDatas)
    {
        for (int i = 0; i < statsTexts.Count && i < statDatas.Count; i++)
        {
            statsTexts[i].text = statDatas[i].type.ToString() + ": " + statDatas[i].value.ToString();
        }
    }

}
