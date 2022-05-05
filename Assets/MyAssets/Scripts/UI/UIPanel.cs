using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIPanel : MonoBehaviour
{
    private List<TextMeshProUGUI> texts;
    public TextMeshProUGUI SelectNumText;
    public TextMeshProUGUI LevelText;

    private void Awake()
    {
        texts = new List<TextMeshProUGUI>();
    }

    public void HandlePanel(TextMeshProUGUI text)
    {
        if (string.IsNullOrEmpty(text.text))
        {
            texts.Add(text);
        }
        else
        {
            texts.Remove(text);
            text.SetText("");
        }

        FetchText();
    }

    private void FetchText()
    {
        for (int i = 0; i < texts.Count; ++i)
        {
            texts[i].SetText($"{i + 1}");
        }

        SelectNumText.SetText($"{texts.Count}");
    }

    public void ResetAllTexts()
    {
        foreach (var text in texts)
        {
            text.SetText("");
        }
        texts = new List<TextMeshProUGUI>();

        SelectNumText.SetText("0");
    }
}
