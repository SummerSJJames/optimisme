using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float maxSpeed = 3f;
    [SerializeField] public float jumpHeight = 6f;
    [SerializeField] Camera mainCamera;

    [SerializeField] AudioSource finishedSound;

    [SerializeField] GameObject gameManager;
    EnergyManager energyManage;

    bool facingRight = true;
    float moveDir = 0;
    bool isGrounded = false;
    Vector3 cameraPos;
    Rigidbody2D rb;

    bool isTrigger;

    public bool shouldPhase;

    float timer;

    [SerializeField] ParticleSystem hearts;

    public float startJumpHeight;

    public static bool completedLevel;

    Vector2 stopMoving;
    [SerializeField] GameObject[] allCats;
    [SerializeField] int catsCollected;

    GameObject go;

    void Start()
    {
        stopMoving = transform.position;
        go = GameObject.Find("FindAllCatsText");
        go.GetComponent<TMPro.TextMeshProUGUI>().color = new Color(255, 255, 255, 0);
        catsCollected = 0;
        allCats = GameObject.FindGameObjectsWithTag("Cat");
        isTrigger = false;
        timer = 2;
        startJumpHeight = jumpHeight;
        shouldPhase = false;
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
        if (!Dialogue.dialogueActive && !completedLevel && !IngameMenu.menuIsActive)
        {
            stopMoving = transform.position;
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
                    transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
                    //GetComponent<SpriteRenderer>().flipX = true;
                }
                if (moveDir < 0 && facingRight)
                {
                    facingRight = false;
                    transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
                    //GetComponent<SpriteRenderer>().flipX = false;
                }
            }

            //Jumping
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
                isGrounded = false;
            }

            if (shouldPhase)
            {
                Physics2D.IgnoreLayerCollision(6, 9, true);

                timer -= Time.deltaTime;
            }
            if (timer <= 0)
            {
                shouldPhase = false;
                Physics2D.IgnoreLayerCollision(6, 9, false);
                timer = 2;
            }
        }
        else transform.position = stopMoving;
        //Camera follow
        if (mainCamera)
            mainCamera.transform.position = new Vector3(transform.position.x, transform.position.y, cameraPos.z);
    }

    void FixedUpdate()
    {
        //Moving
        rb.velocity = new Vector2(moveDir * maxSpeed, rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 10 && !isTrigger)
        {
            if (catsCollected >= allCats.Length)
            {
                isTrigger = true;
                stopMoving = transform.position;
                StartCoroutine(LevelComplete());
            }
            else
            {
                StartCoroutine(FindAllCats());
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 7)
            isGrounded = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 7)
            isGrounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            energyManage.ResetTimer();
            catsCollected++;
            hearts.Play();
        }
    }

    IEnumerator LevelComplete()
    {
        finishedSound.Play();
        completedLevel = true;

        Debug.Log("Next level");

        yield return new WaitForSeconds(3);
        completedLevel = false;
        LevelManager.LoadNextLevel();
    }

    IEnumerator FindAllCats()
    {
        go.GetComponent<TMPro.TextMeshProUGUI>().color = new Color(255, 255, 255, 255);

        Debug.Log("Find cats");
        yield return new WaitForSeconds(2);

        go.GetComponent<TMPro.TextMeshProUGUI>().color = new Color(255, 255, 255, 0);
    }
}
