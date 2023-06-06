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
        if (Input.GetKeyDown(KeyCode.B))
        {
            ShowInventory();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            HideInventory();
        }
    }


}