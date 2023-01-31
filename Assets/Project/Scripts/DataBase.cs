using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CardValues
{
    public int id;
    public string first_name;
    public string last_name;
    public string email;
    public string gender;
    public string ip_address;
}

public class DataBase : MonoBehaviour
{
    public class Data
    {
        public CardValues[] data;
    }

    public Data cardsData;

    private void Awake()
    {
        cardsData = JsonUtility.FromJson<Data>(Resources.Load<TextAsset>("test_task_mock_data").text); // jsonFile.text
    }
}
