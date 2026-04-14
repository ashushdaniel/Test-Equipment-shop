using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentShop : MonoBehaviour
{
    public List<TextMeshProUGUI> itemsNamesText;
    public List<TextMeshProUGUI> itemsCostsText;
    public List<TextMeshProUGUI> itemsDiscriptionText;
    public List<Image> itemsImages;
    public List<Button> itemsBuyButtons;

    [SerializeField] GameObject shopWindow;

    [SerializeField] List<EquipmentData> equipments = new List<EquipmentData>();

    List<bool> itemsSold = new List<bool>();
    GameObject customer;

    void Start()
    {
        for (int i = 0; i < equipments.Count; i++)
        {
            itemsNamesText[i].text = equipments[i].equipmentName;
            itemsCostsText[i].text = equipments[i].goldValue.ToString();
            itemsDiscriptionText[i].text = equipments[i].discription;
            itemsImages[i].sprite = equipments[i].sprite;
            itemsSold.Add(false);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        customer = collision.gameObject;
        customer.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        customer.GetComponent<PlayerMovement>().canMove = false;
        shopWindow.SetActive(true);
    }
    public void ExitShop()
    {
        customer.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        customer.GetComponent<PlayerMovement>().canMove = true;
        shopWindow.SetActive(false);
    }
    public void BuyItem(int index)
    {
        int equipmentCost = equipments[index].goldValue;
        if (customer.GetComponent<PlayerGold>().GetPlayerGold() >= equipmentCost)
        {
            customer.GetComponent<PlayerGold>().ReduceGold(equipmentCost);
            customer.GetComponent<PlayerInventory>().AddEquipment(equipments[index]);
            RemoveItem(index);
        }
        else
        {
            Debug.Log("not enough gold");
        }
    }
    void RemoveItem(int index)
    {
        itemsSold[index] = true;
        itemsBuyButtons[index].enabled = false;
        itemsImages[index].color = Color.gray;
        itemsCostsText[index].text = "SOLD";
    }
}
