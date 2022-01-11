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

    RectTransform rect;
    Vector3 direction;

    private void Start()
    {
        moving = false;
        col = GetComponent<BoxCollider2D>();
        target = GameObject.Find("CatsPet").transform;
        rect = target.GetComponent<RectTransform>();
    }

    private void Update()
    {
        if (moving)
        {
            RectTransformUtility.ScreenPointToWorldPointInRectangle(rect, Camera.main.transform.position, Camera.main, out Vector3 point);
            point = new Vector3(Mathf.Abs(point.x), Mathf.Abs(point.y), Mathf.Abs(point.z));
            direction = point - transform.position;

            transform.Translate(direction * movespeed * Time.deltaTime, Space.Self);

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
