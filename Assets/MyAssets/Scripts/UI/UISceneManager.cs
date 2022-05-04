using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UISceneManager : MonoBehaviour
{
    public Animator Anim;

    private int fadeOutHash;
    private int fadeInHash;

    private void Awake()
    {
        fadeOutHash = Animator.StringToHash("FadeOut");
        fadeInHash = Animator.StringToHash("FadeIn");
    }

    public void StartTitle() => StartScene((int)SceneType.Title);
    public void StartMain() => StartScene((int)SceneType.Main);
    public void StartResult() => StartScene((int)SceneType.Result);

    private void StartScene(int sceneBuildIndex)
    {
        StartCoroutine(StartSceneSystem(sceneBuildIndex));
    }

    private IEnumerator StartSceneSystem(int sceneBuildIndex)
    {
        Anim.SetTrigger(fadeOutHash);

        yield return new WaitForSeconds(.5f);

        SceneManager.LoadScene(sceneBuildIndex);
    }
}

public enum SceneType
{
    Title,
    Main,
    Result,
}
