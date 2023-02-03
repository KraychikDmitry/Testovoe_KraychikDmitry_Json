using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardModel : MonoBehaviour
{
    private CardView cardView;
    private DataBase dataBase;

    private int _cardID;
    public int cardID
    {
        get
        {
            return _cardID;
        }
        set
        {
            _cardID = value;
            cardView.ChangeCardValues(value, dataBase);
        }
    }

    private RectTransform model;
    private RectTransform rectTransform;

    private void Awake()
    {
        dataBase = transform.parent.parent.GetComponent<DataBase>();
        cardView = GetComponent<CardView>();
        model = transform.parent.parent.GetComponent<RectTransform>();
        rectTransform = GetComponent<RectTransform>();
    }

    private Vector3[] modelCorners = new Vector3[4];
    private Vector3[] thisCorners = new Vector3[4];
    private void Update()
    {
        rectTransform.GetWorldCorners(thisCorners);
        model.GetWorldCorners(modelCorners);
        if (thisCorners[1].y < modelCorners[0].y || thisCorners[0].y > modelCorners[1].y)
        {
            gameObject.SetActive(false);
        }
    }
}
