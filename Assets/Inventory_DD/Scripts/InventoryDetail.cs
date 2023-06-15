using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryDetail : MonoBehaviour
{
    public Inventory inventory;
    public InventoryUIManager inventoryUiManager;
    public CraftingUIManager craftingUiManager;
    public QuestUIManager questUiManager;
    public ItemBase itemBase;
    public TextMeshProUGUI textName;

    public void UseFromInventory()
    {
        itemBase.UseItem();

        if (inventory.itemList.Contains(itemBase))
        {
            inventory.itemList.Remove(itemBase);
        }

        if (inventoryUiManager.inventoryUIList.Contains(this.gameObject))
        {
            inventoryUiManager.inventoryUIList.Remove(this.gameObject);
            Destroy(this.gameObject);
            inventoryUiManager.ShowInventory();
        }


        if (craftingUiManager.inventoryUIList.Contains(this.gameObject))
        {
            craftingUiManager.inventoryUIList.Remove(this.gameObject);
            Destroy(this.gameObject);
            craftingUiManager.ShowInventory();
        }

        if (questUiManager.inventoryUIList.Contains(this.gameObject))
        {
            questUiManager.inventoryUIList.Remove(this.gameObject);
            Destroy(this.gameObject);
            questUiManager.ShowInventory();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            UseFromInventory();
        }
    }
}
