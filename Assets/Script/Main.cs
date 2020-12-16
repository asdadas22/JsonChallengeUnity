using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class Main : MonoBehaviour
{
    // grilla contenedora de la informacion
    public GameObject grilla;

    // Prefab del textmesh pro que utilizare para agregarlo a la grilla
    public GameObject textInfoPrefab;

    public GameObject title;

    // Clase que contiene los elementos leidos del json
    [System.Serializable]
    public class ReadJson
    {
        public string Title;
        //public List<ColumnHeader> ColumnHeaders = new List<ColumnHeader>();
        public List<DataTeam> Data = new List<DataTeam>();
    }
    
    [System.Serializable]
    public class DataTeam
    {
        public string ID;
        public string Name;
        public string Role;
        public string NickName;
    }

    public ReadJson data = new ReadJson();

    // Start is called before the first frame update
    void Start()
    {
        string path = Application.dataPath + "/StreamingAssets/JsonChallenge.json";
        string json = File.ReadAllText(path);
        data = Newtonsoft.Json.JsonConvert.DeserializeObject<ReadJson>(json);
        title.GetComponent<TextMeshProUGUI>().SetText(data.Title);
        AddDataToGrid(data.Data);
    }

    public void AddDataToGrid(List<DataTeam> dataList)
    {
        foreach (var data in dataList)
        {
            GameObject id_txt = Instantiate(textInfoPrefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
            id_txt.GetComponent<TextMeshProUGUI>().SetText(data.ID);
            id_txt.transform.SetParent(grilla.transform, false);

            GameObject name_txt = Instantiate(textInfoPrefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
            name_txt.GetComponent<TextMeshProUGUI>().SetText(data.Name);
            name_txt.transform.SetParent(grilla.transform, false);

            GameObject role_txt = Instantiate(textInfoPrefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
            role_txt.GetComponent<TextMeshProUGUI>().SetText(data.Role);
            role_txt.transform.SetParent(grilla.transform, false);

            GameObject nick_txt = Instantiate(textInfoPrefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
            nick_txt.GetComponent<TextMeshProUGUI>().SetText(data.NickName);
            nick_txt.transform.SetParent(grilla.transform, false);
        }
    }
}
