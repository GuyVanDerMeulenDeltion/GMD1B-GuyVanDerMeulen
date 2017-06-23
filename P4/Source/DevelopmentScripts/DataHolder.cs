using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

[System.Serializable]
public class DataHolder {

    public List<Item> items = new List<Item>();
    public List<InventorySlots> inventoryData = new List<InventorySlots>();

}
