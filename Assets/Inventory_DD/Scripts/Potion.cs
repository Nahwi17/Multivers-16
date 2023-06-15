using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : ItemBase
{

    public override void UseItem()
    {
        base.UseItem();
        Actions.IncreaseHP(value);
    }
}
