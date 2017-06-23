using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

public class DataManager : MonoBehaviour {

    public DataHolder dataHolder;

	public void Awake () {
        dataHolder = Load();
	}

    public DataHolder Load()    {
        var serializer = new XmlSerializer(typeof(DataHolder));
        using (var stream = new FileStream(Application.dataPath + "/InventorySystemSave.xml", FileMode.Open))   {
            return serializer.Deserialize(stream) as DataHolder;
        }
    }

    public void OnApplicationQuit() {
        var serializer = new XmlSerializer(typeof(DataHolder));
        using (var stream = new FileStream(Application.dataPath + "/InventorySystemSave.xml", FileMode.Create)) {
            serializer.Serialize(stream, dataHolder);
        }
    }
}
