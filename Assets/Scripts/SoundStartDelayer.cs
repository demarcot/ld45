using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundStartDelayer : MonoBehaviour
{
    float timeDelay;

    // Start is called before the first frame update
    void Start()
    {
        timeDelay = Random.Range(0.0f, 0.4f);
        AudioSource audio = GetComponent<AudioSource>();
        audio.PlayDelayed(timeDelay);
    }
}
