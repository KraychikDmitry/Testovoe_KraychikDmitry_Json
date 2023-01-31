using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIModel : MonoBehaviour
{
    [SerializeField] private Transform cardsContainer;
    [SerializeField] private GameObject cardPrefab;
    private DataBase dataBase;
    private int CardsCountAtPage = 8;
    private List<CardView> cardViews = new();

    private int currentPage = 1;
    private int lastPage;

    public void OpenPage(int indexIncrementor)
    {
        if (currentPage + indexIncrementor < 1 || currentPage + indexIncrementor > lastPage)
            return;

        currentPage += indexIncrementor;
        ChangeCardsValues(currentPage);
    }

    protected virtual void ChangeCardsValues(int page)
    {
        int pageIndex = page * CardsCountAtPage - CardsCountAtPage;
        int cardDataIndex;

        for (int i = 0; i < CardsCountAtPage; i++)
        {
            cardDataIndex = pageIndex + i;
            CardValues currentCardData = dataBase.cardsData.data[cardDataIndex];
            cardViews[i].ChangeCardValues(currentCardData.id,
                                          currentCardData.first_name,
                                          currentCardData.last_name,
                                          currentCardData.email,
                                          currentCardData.gender,
                                          currentCardData.ip_address);
        }
    }

    private void Start()
    {
        dataBase = GetComponent<DataBase>();

        for (int i = 0; i < CardsCountAtPage; i++)
        {
            GameObject a = Instantiate(cardPrefab,cardsContainer);
            cardViews.Add(a.GetComponent<CardView>());
        }

        ChangeCardsValues(1);

        lastPage = (int)Mathf.Ceil(dataBase.cardsData.data.Length / CardsCountAtPage);
    }
}
