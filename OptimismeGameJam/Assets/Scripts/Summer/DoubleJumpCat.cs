using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJumpCat : CatScript
{
    private protected override IEnumerator SpinToTarget()
    {
        animator.SetTrigger("Start");
        var playerMove = GameObject.Find("Player").GetComponent<PlayerMovement>();
        playerMove.jumpHeight += playerMove.jumpHeight - 2;

        yield return new WaitForSeconds(1);

        playerMove.jumpHeight -= playerMove.jumpHeight / 2 + 2;

        StartCoroutine(AddCatToNumber.PlayAnimation());
        LevelLoader.catsPet++;
        Destroy(gameObject);
    }
}
