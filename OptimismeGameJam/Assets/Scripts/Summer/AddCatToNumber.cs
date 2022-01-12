using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddCatToNumber : MonoBehaviour
{
    static Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public static IEnumerator PlayAnimation()
    {
        animator.SetTrigger("Start");
        yield return new WaitForSeconds(1);
        //animator.SetBool("Play", false);
    }
}
