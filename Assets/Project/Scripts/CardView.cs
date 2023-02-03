using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CardView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI id;
    [SerializeField] private TextMeshProUGUI first_name;
    [SerializeField] private TextMeshProUGUI last_name;
    [SerializeField] private TextMeshProUGUI email;
    [SerializeField] private TextMeshProUGUI gender;
    [SerializeField] private TextMeshProUGUI ip_address;

    public virtual void ChangeCardValues(int id, DataBase dataBase)
    {
        id--;
        this.id.text = dataBase.cardsData.data[id].id.ToString();
        this.first_name.text = dataBase.cardsData.data[id].first_name;
        this.last_name.text = dataBase.cardsData.data[id].last_name;
        this.email.text = dataBase.cardsData.data[id].email;
        this.gender.text = dataBase.cardsData.data[id].gender;
        this.ip_address.text = dataBase.cardsData.data[id].ip_address;
    }
}
