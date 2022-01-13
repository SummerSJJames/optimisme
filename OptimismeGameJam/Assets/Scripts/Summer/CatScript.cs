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

        //target = new Vector2(GameObject.Find("CatsPet").transform.position.x, GameObject.Find("CatsPet").transform.position.y);
    }

    private protected virtual void Update()
    {
        //target = GameObject.Find("CatsPet").transform;
        //rect = target.GetComponent<RectTransform>();

        if (moving)
        {
            //RectTransformUtility.ScreenPointToWorldPointInRectangle(rect, Camera.main.transform.position, Camera.main, out Vector3 point);

            //Vector3 point = Camera.main.ScreenToWorldPoint(target.position);
            //point = new Vector2(Mathf.Abs(point.x), Mathf.Abs(point.y), Mathf.Abs(point.z));
            target = new Vector2(G_target.transform.position.x, G_target.transform.position.y);
            direction = target - new Vector2(transform.position.x, transform.position.y);
            transform.Translate(direction * movespeed * Time.deltaTime, Space.World);

            //float step = movespeed * Time.deltaTime;
            //transform.position = Vector2.MoveTowards(transform.position, target, step);

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
