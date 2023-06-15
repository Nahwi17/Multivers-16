using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Semua yang kita buat di IInteractable harus dimasukin lagi di Script Chest    
public class Chest : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;

    public string InteractionPrompt => _prompt;

    public bool Interact(Interactor interactor)
    {
        Debug.Log("Opening Chest");
        return true;
    }
}
