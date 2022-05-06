using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIDescription : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI stageText;
    [SerializeField] private TextMeshProUGUI levelText;

    public void ShowDescription(bool isActive)
    {
        if (isActive)
        {
            stageText.SetText($"{GameManager.Instance.Stage}");
            levelText.SetText($"{GameManager.Instance.Level()}");
        }

        gameObject.SetActive(isActive);
    }
}
