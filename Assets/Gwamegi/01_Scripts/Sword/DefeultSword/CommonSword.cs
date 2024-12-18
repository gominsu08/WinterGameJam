using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonSword : Sword
{


    public override void ThrowSword(Vector2 location)
    {
        DistanceCalculation(location);


    }


}
