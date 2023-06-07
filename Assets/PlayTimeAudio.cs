using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayTimeAudio : MonoBehaviour
{
    public float time = 30f; //30 seconds for you
    public AudioSource audio;
 
    public void Update()
    {
        if (time > 0) {
            time -= Time.deltaTime;
        }
        else 
        {
            Debug.Log("Play Audio Here -- Timer Over!!");
            GetComponent<AudioSource>().Play();
        }
    }
}
