using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUIManager : MonoBehaviour
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
            inventoryDetail.inventory = inventory;
            inventoryDetail.inventoryUiManager = this;
            inventoryDetail.textName.text = inventory.itemList[i].itemName;
            inventoryDetail.itemBase = inventory.itemList[i];
            GameObject tmpObject = Instantiate(inventoryDetail.gameObject, parentInventory.transform);

            inventoryUIList.Add(tmpObject);
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
        if (Input.GetKeyDown(KeyCode.I) && !isOpen)
        {
            Debug.Log("i is pressed");
            ShowInventory();
            Cursor.lockState = CursorLockMode.None;
            isOpen = true;
        }
        else if (Input.GetKeyDown(KeyCode.I) && isOpen)
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
    //     //itemToAdd.transform.SetParent(whatSlotToEquip.transfrom);

    //    itemList.Add(itemName);
        
    //}

    //public void RemoveItem(string nameToRemove, int amountToRemove)
    //{
    //    int counter = amountToRemove;

    //    for(var i = slotList.Count - 1; i >= 0; i--)
    //    {
    //        if(slotList[1].transform.childCount > 0)
    //        {
    //            if(slotList[i].transform.GetChild(0).name == nameToRemove + "(Clone)" && counter !=0 )
    //            {
    //                Destroy(slotList[i].transform.getChild(0).gameObject);

    //                counter -= 1;
    //            }
    //        }
    //    }
    //}

}
