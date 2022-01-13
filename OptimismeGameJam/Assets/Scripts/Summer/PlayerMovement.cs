using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float maxSpeed = 3f;
    [SerializeField] public float jumpHeight = 6f;
    [SerializeField] Camera mainCamera;

    [SerializeField] GameObject gameManager;
    EnergyManager energyManage;

    bool facingRight = true;
    float moveDir = 0;
    bool isGrounded = false;
    Vector3 cameraPos;
    Rigidbody2D rb;

    void Start()
    {
        energyManage = gameManager.GetComponent<EnergyManager>();
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        facingRight = transform.localScale.x > 0;

        if (mainCamera)
            cameraPos = mainCamera.transform.position;
    }

    void Update()
    {
        //Movement controls
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            moveDir = Input.GetKey(KeyCode.A) ? -1 : 1;

        else if (isGrounded || rb.velocity.magnitude < 0.01f || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
            moveDir = 0;

        //Change look direction
        if (moveDir != 0)
        {
            if (moveDir > 0 && !facingRight)
            {
                facingRight = true;
                //transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
                GetComponent<SpriteRenderer>().flipX = true;
            }
            if (moveDir < 0 && facingRight)
            {
                facingRight = false;
                //transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
                GetComponent<SpriteRenderer>().flipX = false;
            }
        }

        //Jumping
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
            isGrounded = false;
        }

        //Camera follow
        if (mainCamera)
            mainCamera.transform.position = new Vector3(transform.position.x, cameraPos.y, cameraPos.z);
    }

    void FixedUpdate()
    {       
        //Moving
        rb.velocity = new Vector2(moveDir * maxSpeed, rb.velocity.y);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 7)
            isGrounded = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
            energyManage.ResetTimer();
    }
}
