using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CatScript : MonoBehaviour
{
    [SerializeField] protected Animator animator;
    [SerializeField] float movespeed;

    Collider2D col;

    protected bool moving;

    Vector2 target;

    GameObject G_target;

    Vector3 direction;

    private protected virtual void Start()
    {
        moving = false;
        col = GetComponent<BoxCollider2D>();

        G_target = GameObject.Find("CatsPet");
    }

    private protected virtual void Update()
    {

        if (moving)
        {
            target = new Vector2(G_target.transform.position.x, G_target.transform.position.y);
            direction = target - new Vector2(transform.position.x, transform.position.y);
            transform.Translate(direction * movespeed * Time.deltaTime, Space.World);
        }
    }

    private protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            moving = true;
            col.enabled = false;
            StartCoroutine(SpinToTarget());
        }
    }

    private protected virtual IEnumerator SpinToTarget()
    {
        animator.SetTrigger("Start");

        yield return new WaitForSeconds(1);

        StartCoroutine(AddCatToNumber.PlayAnimation());
        LevelLoader.catsPet++;
        Destroy(gameObject);
    }
}
