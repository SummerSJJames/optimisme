using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleSpeedCat : CatScript
{
    private protected override IEnumerator SpinToTarget()
    {
        animator.SetTrigger("Start");
        catMeow.Play();
        var playerMove = GameObject.Find("Player").GetComponent<PlayerMovement>();
        playerMove.maxSpeed += playerMove.maxSpeed;

        yield return new WaitForSeconds(1);

        playerMove.maxSpeed -= playerMove.maxSpeed / 2;

        StartCoroutine(AddCatToNumber.PlayAnimation());
        LevelLoader.catsPet++;
        Destroy(transform.parent.gameObject);
    }
}
