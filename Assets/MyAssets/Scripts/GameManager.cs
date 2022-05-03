using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public CardList ParentCardList;
    public CardList ChildCardList;

    public List<GameObject> ParentCards;

    public int Stage;

    private void Start()
    {
        StartCoroutine(GameSystem());
    }

    private IEnumerator GameSystem()
    {
        Stage++;
        GenerateRandomStage();

        while (!IsGameClear())
        {
            yield return null;
        }

        Debug.Log("Clear");

        yield return new WaitUntil(() => Input.GetMouseButton(0));

        ParentCardList.InitializeCards();
        ChildCardList.InitializeCards();

        if (Stage == 6) yield break;
        StartCoroutine(GameSystem());
    }

    private int Level()
    {
        if (Stage < 4)
        {
            return 1;
        }
        else if (Stage < 6)
        {
            return 2;
        }
        else
        {
            return 3;
        }
    }

    private void GenerateRandomStage()
    {
        ParentCards.Shuffle();

        for (int i = 0; i < Level(); ++i)
        {
            ParentCardList.AddCard(ParentCards[i]);
        }
    }

    private bool IsGameClear()
    {
        if (ParentCardList.Cards.Count != ChildCardList.Cards.Count) return false;

        for (int i = 0; i < ChildCardList.Cards.Count; ++i)
        {
            if (ParentCardList.Cards[i].name != ChildCardList.Cards[i].name)
            {
                return false;
            }
        }

        return true;
    }
}
