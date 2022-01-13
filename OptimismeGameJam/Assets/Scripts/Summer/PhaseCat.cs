using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseCat : CatScript
{
    private protected override IEnumerator SpinToTarget()
    {
        GameObject.Find("Player").GetComponent<PlayerMovement>().shouldPhase = true;
        return base.SpinToTarget();
    }
}
