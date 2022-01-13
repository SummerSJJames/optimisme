using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJumpCat : CatScript
{
    private protected override IEnumerator SpinToTarget()
    {
        animator.SetTrigger("Start");
        catMeow.Play();
        var playerMove = GameObject.Find("Player").GetComponent<PlayerMovement>();
        playerMove.jumpHeight += playerMove.jumpHeight - 2;

        yield return new WaitForSeconds(1);

        playerMove.jumpHeight = playerMove.startJumpHeight;

        StartCoroutine(AddCatToNumber.PlayAnimation());
        LevelLoader.catsPet++;
        Destroy(transform.parent.gameObject);
    }
}
