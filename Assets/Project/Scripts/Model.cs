using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Model : MonoBehaviour
{
	[SerializeField] private GameObject cardPrefab; 
	private ScrollRect scrollRect;
	private DataBase database;

    private static int CardsCountAtPage = 10;
    private RectTransform[] cardsRect = new RectTransform[CardsCountAtPage];
    private �ardModel[] cardsModel = new �ardModel[CardsCountAtPage];

    private float cardHeight;

    private void Awake()
    {
        database = GetComponent<DataBase>();
        
        cardHeight = cardPrefab.GetComponent<RectTransform>().offsetMin.y;
        scrollRect = GetComponent<ScrollRect>();

        scrollRect.onValueChanged.AddListener(OnValueChangeListener);

        RectTransform cardsContainerRect = transform.GetChild(0).GetComponent<RectTransform>();
        for (int i = 0; i < CardsCountAtPage; i++)
        {
            GameObject a = Instantiate(cardPrefab, cardsContainerRect); // ������ ���
            cardsModel[i] = a.GetComponent<�ardModel>(); // �������� ������ ������� ��������
            cardsRect[i] = a.GetComponent<RectTransform>(); // �������� ������ ������ ��������
            cardsRect[i].localPosition = new(cardsRect[0].localPosition.x, cardHeight * i, cardsRect[0].localPosition.z); // ����������� ��� �������� �������� �������
        }
    }

    private void Start()
    {
        for (int i = 0; i < cardsModel.Length; i++)
        {
            cardsModel[i].cardID = i + 1;
        }
    }

    private float valueLastFrame;
    private float valueCurrentFrame;
    private void OnValueChangeListener(Vector2 vectorValue)
    {
        valueLastFrame = valueCurrentFrame;
        valueCurrentFrame = vectorValue.y;

        ReplaceCard((valueLastFrame < valueCurrentFrame)); // ���������� direction ������� � ������������ ��������
    }

    private void ReplaceCard(bool scrollDirectionUp) 
    {
        for (int i = 0; i < cardsRect.Length; i++)
        {
            if (cardsRect[i].gameObject.activeSelf == false) // ���� �������� � ����, ������� � ����������� 
            {
                int minID = scrollDirectionUp ? database.cardsData.data.Length : 0;
                foreach (�ardModel item in cardsModel) // ����� ������� �������� ��������
                {
                    if (item.gameObject.activeSelf == true && (scrollDirectionUp ? (item.cardID < minID) : (item.cardID > minID)))
                    {
                        minID = item.cardID;
                    }
                }
                if (minID > 1 && minID < 2000) // ������� �������� �������� �� ������ ���� ���������
                {                              // ������������ �������� �� ���� �����/����� ������� �������� ��������
                    cardsRect[i].localPosition = new(cardsRect[i].localPosition.x, cardHeight * (minID + (scrollDirectionUp ? -2 : 0)), cardsRect[i].localPosition.z);
                    cardsModel[i].cardID = minID + (scrollDirectionUp ? -1 : 1);
                    cardsRect[i].gameObject.SetActive(true);
                }
            }
        }
    }
}
