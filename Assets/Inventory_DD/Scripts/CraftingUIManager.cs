using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingUIManager : MonoBehaviour
{
    public Inventory inventory;
    public GameObject inventoryMasterUI;
    public Transform parentInventory;
    public InventoryDetail inventoryDetail;

    public List<GameObject> inventoryUIList;

    public bool isOpen;

    void start()
    {
        isOpen = false;
    }

    public void ShowInventory()
    {
        if (inventoryUIList.Count > 0)
        {
            for (int i = 0; i < inventoryUIList.Count; i++)
            {
                Destroy(inventoryUIList[i]);
            }
        }

        inventoryUIList = new List<GameObject>();

        inventoryMasterUI.SetActive(true);

        SetupInventoryUI();
    }

    public void HideInventory()
    {
        inventoryMasterUI.SetActive(false);
    }

    public void SetupInventoryUI()
    {
        for (int i = 0; i < inventory.itemList.Count; i++)
        {
            if (inventory.itemList[i].itemType == ItemType.Material)
            {
                inventoryDetail.inventory = inventory;
                inventoryDetail.craftingUiManager = this;
                inventoryDetail.textName.text = inventory.itemList[i].itemName;
                inventoryDetail.itemBase = inventory.itemList[i];
                GameObject tmpObject = Instantiate(inventoryDetail.gameObject, parentInventory.transform);

                inventoryUIList.Add(tmpObject);
            }
        }
    }

    

    private void Update()
    {
        // if (Input.GetKeyDown(KeyCode.I))
        // {
        //     ShowInventory();
        // }

        // if (Input.GetKeyDown(KeyCode.Escape))
        // {
        //     HideInventory();
        // }
        if (Input.GetKeyDown(KeyCode.C) && !isOpen)
        {
            Debug.Log("i is pressed");
            ShowInventory();
            Cursor.lockState = CursorLockMode.None;
            isOpen = true;
        }
        else if (Input.GetKeyDown(KeyCode.C) && isOpen)
        {
            HideInventory();
            // if (!CraftingSystem.Instance.isOpen)
            // {
            Cursor.lockState = CursorLockMode.Locked;
            // }

            isOpen = false;
        }
    }


    //public void AddToInventory(string itemName)
    //{
    //    itemToAdd = Instantiate(Resources.Load<GameObject>(itemName));
    //    //,whatSlotToEquip.transform.position,whatSlotToEquip.transform.totation);
    //    //itemToAdd.transform.SetParent(whatSlotToEquip.transfrom);

    //    itemList.Add(itemName);
    //}

}
