using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Material : ItemBase
{
    public override void UseItem()
    {
        base.UseItem();
        Actions.AddItemToMixer(this);
    }
}
