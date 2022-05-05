using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButton : MonoBehaviour
{
    public float AlphaModifiers;
    public Material ButtonMaterial;

    private void Update()
    {
        ButtonMaterial.SetFloat("_AlphaModifiers", AlphaModifiers);
    }
}
