using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scrrenbuton : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
