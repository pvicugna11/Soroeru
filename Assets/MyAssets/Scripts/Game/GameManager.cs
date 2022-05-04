using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public CardList ParentCardList;
    public CardList ChildCardList;
    public List<GameObject> ParentCards;

    public UIPanel Panel;
    public UIDescription Description;
    public GameObject Clear;
    public UISceneManager Fade;

    public int Stage;
    public int MaxStage = 6;

    private void Start()
    {
        if (Instance)
        {
            Destroy(Instance);
            return;
        }

        Instance = this;

        StartCoroutine(GameSystem());
    }

    private IEnumerator GameSystem()
    {
        Stage++;

        Description.ShowDescription(true);

        yield return new WaitForSeconds(3);

        Description.ShowDescription(false);
        Panel.gameObject.SetActive(true);
        GenerateRandomStage();

        yield return new WaitUntil(() => IsGameClear());

        Panel.gameObject.SetActive(false);
        Clear.SetActive(true);

        yield return new WaitForSeconds(3);

        ParentCardList.InitializeCards();
        ChildCardList.InitializeCards();
        Panel.ResetAllTexts();

        if (Stage == 6)
        {
            Fade.StartResult();
            yield break;
        }

        Clear.SetActive(false);

        StartCoroutine(GameSystem());
    }

    public int Level()
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
            ParentCardList.HandleCard(ParentCards[i]);
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
