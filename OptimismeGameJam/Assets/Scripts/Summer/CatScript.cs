using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CatScript : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] float movespeed;

    Collider2D col;

    bool moving;

    Transform target;

    Vector3 direction;

    private void Start()
    {
        moving = false;
        col = GetComponent<BoxCollider2D>();
        target = GameObject.Find("CatsPetPosition").transform;
    }

    private void Update()
    {
        Debug.Log(target.name + target.position);
        if (moving)
        {
            Debug.Log("Moving");
            direction = target.position - transform.position;
            transform.Translate(direction.x * movespeed * Time.deltaTime, direction.y * movespeed * Time.deltaTime, transform.position.z, Space.World);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            moving = true;
            col.enabled = false;
            StartCoroutine(SpinToTarget());
        }
    }

    IEnumerator SpinToTarget()
    {
        animator.SetTrigger("Start");

        LevelLoader.catsPet++;

        yield return new WaitForSeconds(1);

        Destroy(gameObject);
    }
}
