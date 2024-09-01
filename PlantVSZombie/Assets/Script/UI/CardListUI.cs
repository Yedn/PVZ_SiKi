using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CardListUI : MonoBehaviour
{
    public List<Card> cardList;

    private void Start()
    {
        DisableCardList();
        //ShowCardListUI();
    }
    public void ShowCardListUI()
    {
        GetComponent<RectTransform>().DOLocalMoveY(461.5f, 1f);
        EnableCardList();
    }
    void DisableCardList()
    {
        foreach (var card in cardList)
        {
            card.DisableCard();
        }
    }
    void EnableCardList()
    {
        foreach (var card in cardList)
        {
            card.EnableCard();
        }
    }

}
