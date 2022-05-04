using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIStartButton : UIButton
{
    public float Strength;

    public Material PostEffect;

    private void Update()
    {
        ButtonMaterial.SetFloat("_AlphaModifiers", AlphaModifiers);
        PostEffect.SetFloat("_Strength", Strength);
    }

    public void OnClick()
    {
        StartCoroutine(NoiseSystem());
    }

    private IEnumerator NoiseSystem()
    {
        Strength = .5f;

        yield return new WaitForSeconds(.4f);

        Strength = 0;
    }
}
