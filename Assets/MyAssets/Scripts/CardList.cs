using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardList : MonoBehaviour
{
    public List<GameObject> Cards;

    [SerializeField] private Vector3 POSITION_OFFSET;

    private void Awake()
    {
        Cards = new List<GameObject>();
    }

    public void HandleCard(GameObject card)
    {
        if (card.activeSelf)
        {
            RemoveCard(card);
        }
        else
        {
            AddCard(card);
        }
    }

    public void AddCard(GameObject card)
    {
        Cards.Add(card);
        SortCards();
        card.SetActive(true);
    }

    public void RemoveCard(GameObject card)
    {
        Cards.Remove(card);
        card.SetActive(false);
    }

    public void InitializeCards()
    {
        foreach (var card in Cards)
        {
            card.SetActive(false);
        }

        Cards = new List<GameObject>();
    }

    public void SortCards()
    {
        for (int i = 0; i < Cards.Count; ++i)
        {
            Vector3 zCorrection = new Vector3(0, 0, i * .0001f);
            Cards[i].transform.position = POSITION_OFFSET - zCorrection;
        }
    }
}
