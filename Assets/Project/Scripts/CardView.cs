using System.Collections;
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

    public virtual void ChangeCardValues(int id, string first_name, string last_name, string email, string gender, string ip_address)
    {
        this.id.text = id.ToString();
        this.first_name.text = first_name;
        this.last_name.text = last_name;
        this.email.text = email;
        this.gender.text = gender;
        this.ip_address.text = ip_address;
    }
}
