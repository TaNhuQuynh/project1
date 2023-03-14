using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovemenController : MonoBehaviour
{
    public float enemySpeed;//xac dinh toc do dich

    Rigidbody2D enemyRB;
    Animator enemyAnim;

    //khai bao de enemy co the lat duoc
    public GameObject enemyGraphic;
    bool facingRight = true;
    float facingTime = 5f;
    float nextFlip = 0f;
    bool canFlip = true;

    private void Awake()
    {
        enemyRB = GetComponent<Rigidbody2D>();
        enemyAnim = GetComponentInChildren<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextFlip)
        {
            nextFlip = Time.time + facingTime;
            flip();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (facingRight && collision.transform.position.x < transform.position.x)
            {
                flip();
            }
            if (!facingRight && collision.transform.position.x > transform.position.x)
            {
                flip();
            }
            canFlip = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (!facingRight)
            {
                enemyRB.AddForce(new Vector2(-1, 0) * enemySpeed);
            }
            else
            {
                enemyRB.AddForce(new Vector2(1, 0) * enemySpeed);
            }
            enemyAnim.SetBool("run", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            canFlip = true;
            enemyRB.velocity = new Vector2(0, 0);
            enemyAnim.SetBool("run", false);
        }
    }

    void flip()
    {
        if (!canFlip) //tuong duong canFlip=False
            return;
        facingRight = !facingRight;
        Vector3 thescale = enemyGraphic.transform.localScale;
        thescale.x *= -1;
        enemyGraphic.transform.localScale = thescale;
    }
}
