using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ÑardModel : MonoBehaviour
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

    private RectTransform viewport;
    private RectTransform rectTransform;

    private void Awake()
    {
        dataBase = transform.parent.parent.GetComponent<DataBase>();
        viewport = transform.parent.parent.GetComponent<RectTransform>();
        cardView = GetComponent<CardView>();
        rectTransform = GetComponent<RectTransform>();
    }

    private Vector3[] viewportCorners = new Vector3[4];
    private Vector3[] thisCorners = new Vector3[4];
    private void Update()
    {
        rectTransform.GetWorldCorners(thisCorners);
        viewport.GetWorldCorners(viewportCorners);
        if (thisCorners[1].y < viewportCorners[0].y || thisCorners[0].y > viewportCorners[1].y)
        {
            gameObject.SetActive(false);
        }
    }
}
