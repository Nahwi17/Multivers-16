using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnablePickup : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;

    public bool isCD;
    public float cooldown = 20f;
    [SerializeField] float timer;

    public string InteractionPrompt => _prompt;

    public GameObject objectView;
    public ItemBase item;

    public bool Interact(Interactor interactor)
    {
        if (isCD)
        {
            return false;
        }

        var inventory = interactor.GetComponent<Inventory>();
        inventory.itemList.Add(item);

        timer = cooldown;
        objectView.SetActive(false);
        isCD = true;
        
        return true;
    }

    private void Update()
    {
        if (isCD)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                isCD = false;
                objectView.SetActive(true);
            }
        }
    }
}
