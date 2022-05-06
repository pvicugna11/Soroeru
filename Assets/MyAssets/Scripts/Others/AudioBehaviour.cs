using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioBehaviour : MonoBehaviourEventTrigger
{
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}
