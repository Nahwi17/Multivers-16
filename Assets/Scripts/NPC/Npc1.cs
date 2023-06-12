using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Npc1 : MonoBehaviour
{
    public GameObject triggerText;
    public GameObject DialogueObject;
    // public bool hasTalked = false;
    // public bool isInDialogue = false;
    // public string npcName;
    // private PlayerData data;
    // public ObjectData woodenSword;
    // private bool hasGottenSword;
    // private Questobj obj;
    public PlayerMovement rigid;

    // private void Start()
    // {
    //     data = FindObjectOfType<PlayerData>();
    //     // obj = FindObjectOfType<Questobj>();
    // }

    private void OnTriggerStay(Collider other) 
    {
        if(other.gameObject.tag == "Player")// && !isInDialogue)
        {
            triggerText.SetActive(true);
            triggerText.GetComponent<TextMeshProUGUI>().text = "Press E to talk to "; //+ npcName;

            if(Input.GetKeyDown(KeyCode.E))
            {
                // isInDialogue = true;
                // if (!hasTalked)
                // {
                    other.gameObject.GetComponent<PlayerData>().DialogueNumber = 1;
                    DialogueObject.SetActive(true);
                    rigid.enabled = false;
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true; 
                    // triggerText.SetActive(false);
                    // other.gameObject.GetComponent<PlayerData>().questNumber  = 1 ;
                // }
                // else
                // {
                    // for (int i = 0; i < data.Hotbar.Length; i++)
                    // {
                    //     if(data.Hotbar[i] == woodenSword)
                    //     {
                    //         hasGottenSword = true;
                    //     }
                    // }
                    // if (!hasGottenSword)
                    // {
                    //     // other.gameObject.GetComponent<PlayerData>().DialogueNumber = 1.5f;
                    //     DialogueObject.SetActive(true);
                    //     // rb.enabled = false;
                    //     Cursor.lockState = CursorLockMode.None;
                    //     Cursor.visible = true; 
                    //     triggerText.SetActive(false);
                    // }
                    // else
                    // {
                    //     // other.gameObject.GetComponent<PlayerData>().DialogueNumber = 1.6f;
                    //     other.gameObject.GetComponent<PlayerData>().questNumber  = -1 ;
                    //     // obj.target = null;
                    //     DialogueObject.SetActive(true);
                    //     // rb.enabled = false;
                    //     Cursor.lockState = CursorLockMode.None;
                    //     Cursor.visible = true; 
                    //     triggerText.SetActive(false);
                    // }
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


