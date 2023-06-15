using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestUIManager : MonoBehaviour
{
    public Inventory inventory;
    public GameObject QuestMasterUI;
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

        QuestMasterUI.SetActive(true);

        SetupInventoryUI();
    }

    public void HideInventory()
    {
        QuestMasterUI.SetActive(false);
    }

    public void SetupInventoryUI()
    {
        for (int i = 0; i < inventory.itemList.Count; i++)
        {
            if (inventory.itemList[i].itemType == ItemType.Medicine)
            {
                inventoryDetail.inventory = inventory; 
                inventoryDetail.questUiManager = this;
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
        if (Input.GetKeyDown(KeyCode.E) && !isOpen)
        {
            Debug.Log("i is pressed");
            ShowInventory();
            Cursor.lockState = CursorLockMode.None;
            isOpen = true;
        }
        else if (Input.GetKeyDown(KeyCode.E) && isOpen)
        {
            HideInventory();
            // if (!CraftingSystem.Instance.isOpen)
            // {
            Cursor.lockState = CursorLockMode.Locked;
            // }

            isOpen = false;
        }
    }
}
