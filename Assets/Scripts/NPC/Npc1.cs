using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc1 : MonoBehaviour
{
    public GameObject triggerText;
    public GameObject DialogueObject;

    private void OnTriggerStay(Collider other) 
    {
        if(other.gameObject.tag == "Player")
        {
            triggerText.SetActive(true);

            if(Input.GetKeyDown(KeyCode.E))
            {
                DialogueObject.SetActive(true);
            }
        }   
    }

    private void OnTriggerExit(Collider other) 
    {
        if(other.gameObject.tag == "Player")
        {
           triggerText.SetActive(false); 
        }
        
    }
}
