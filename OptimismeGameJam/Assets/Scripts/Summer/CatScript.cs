using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CatScript : MonoBehaviour
{
    [SerializeField] protected Animator animator;
    [SerializeField] float movespeed;

    [SerializeField]protected Collider2D col;

    protected bool moving;

    Transform target;

    RectTransform rect;
    Vector3 direction;

    private protected virtual void Start()
    {
        moving = false;
        col = GetComponent<BoxCollider2D>();     
    }

    private protected virtual void Update()
    {
        target = GameObject.Find("CatsPet").transform;
        rect = target.GetComponent<RectTransform>();

        if (moving)
        {
            //RectTransformUtility.ScreenPointToWorldPointInRectangle(rect, Camera.main.transform.position, Camera.main, out Vector3 point);
            
            Vector3 point = Camera.main.ScreenToWorldPoint(target.position);
            point = new Vector3(Mathf.Abs(point.x), Mathf.Abs(point.y), Mathf.Abs(point.z));
            direction = point - transform.position;

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
