using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

[Serializable]
public class DialogueOBJ
{
    public string[] Dialogues;
    public string CharacterName;
    public int questNumber;
}

public class DialogueObject : MonoBehaviour
{
    public PlayerData data;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI DialogueText;
    public PlayerMovement rigid;

    private int currentDialogueNum = 0;
    private DialogueOBJ curDialogue = null;

    [Header("Dialogue object")]
    public DialogueOBJ dialogue1;


    private void OnEnable()
    {
        switch (data.DialogueNumber)
        {
            case 1:
                PlayDialogue(dialogue1);
                curDialogue = dialogue1;
                break;
        }
    }

    void PlayDialogue(DialogueOBJ tempobj)
    {
        nameText.text = tempobj.CharacterName;
        if (currentDialogueNum < tempobj.Dialogues.Length)
        {
            DialogueText.text = tempobj.Dialogues[currentDialogueNum];
        }
        else
        {
            rigid.enabled = true;
            //Cursor.lockState = CursorLockMode.Locked;
            //Cursor.visible = false;
            data.DialogueNumber = 0;
            currentDialogueNum = 0;
            data.questNumber = curDialogue.questNumber;
            curDialogue = null;
            this.gameObject.SetActive(false);
        }
    }

    public void next()
    {
        if(curDialogue != null)
        {
            currentDialogueNum++;
            PlayDialogue(curDialogue);
        }
    }
}
