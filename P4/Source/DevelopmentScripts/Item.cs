using System;
using UnityEngine;

[System.Serializable]
public class Item {

    public ItemDataBase itemData;
    public DataHolder serializationItem;

    public string itemName;
    public string description;
    public int itemID;
    public int itemAmount;
    public int price;
    public string gameObjectName;

    public Item(string iName, string iDescription, int id, int iAmount, int iPrice) {
        iName = itemName;
        iDescription = description;
        id = itemID;
        iAmount = itemAmount;
        iPrice = price;
    }

    public void Awake() {
        itemData = GameObject.Find("InventoryDataBase").GetComponent<ItemDataBase>();
        serializationItem = GameObject.Find("Loader").GetComponent<DataHolder>();

        itemData.InventoryDat[itemID] = this;
        serializationItem.items[itemID] = this;

        

    }
}