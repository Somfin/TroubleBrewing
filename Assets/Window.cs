using UnityEngine;
using System.Collections;

public class Window : Placement
{
    public override bool place(GameObject core){
        Destroy(core);
        return true;
    }
}