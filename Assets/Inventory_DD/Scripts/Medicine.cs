using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medicine : ItemBase
{
    
    public override void UseItem()
    {
        base.UseItem();
        Actions.GiveItemToNpc();
    }
}

