using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Consumable,
    Medicine,
    Material
}

public abstract class ItemBase : MonoBehaviour
{
    public ItemType itemType;
    public string itemName;
    public int value;
    public virtual void UseItem()
    {
        Debug.Log("Use Item :" + itemName);
    }

    
    public virtual void AddItem()
    {
      /*     itemToAdd = Instantiate(Resources Load<GameObject>(itemName))
            itemToAdd.transform.SetParent();//whatSlotToEquip.transform)

            itemList.Add(itemName);
      */
    }

    public virtual void GiveItem()
    {

    }
}

