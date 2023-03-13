using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public bool grounded;
    [SerializeField]public bool facingRight;
    [SerializeField] public float maxSpeed;
    [SerializeField] public float jumpH;
    //[SerializeField] private AudioSource sound;
    //[SerializeField] private AudioClip runSfx;
    //[SerializeField] private AudioClip jumpSfx;

    Rigidbody2D mybody;
    Animator myanim;

    //khai bao bien de ban
    [SerializeField] public Transform gunTip;
    [SerializeField] public GameObject bullet;
    [SerializeField] float fireRate = 0.5f;
    [SerializeField] float nextFire = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(message: "idle");
        mybody = GetComponent<Rigidbody2D>();
        myanim = GetComponent<Animator>();

        facingRight = true;//mặc định mặt quay phải
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");
        float jump=Input.GetAxis("Vertical");

        //myanim.SetBool("jump", true);
        myanim.SetFloat("speed", Mathf.Abs(move));
        mybody.velocity = new Vector2(move * maxSpeed, mybody.velocity.y);
        myanim.SetFloat("jump1", Mathf.Abs(jump));

        if (move > 0 && !facingRight)
        {
            Debug.Log(message: "turnright");
            flip();
        }
        else if(move < 0 && facingRight)
        {
            Debug.Log(message: "turnleft");
            flip();
        }

        if (jump>0)//nhảy-điều kiện nhảy // if(input.GetKey(KeyCode.Space))
        {
            Debug.Log(message: "jump");
            
            if (grounded)
            {
                grounded = false;
                mybody.velocity = new Vector2(mybody.velocity.x, jumpH);
            }
        }

        // chuc nang ban
        if (Input.GetAxisRaw("Fire1") > 0)
        {
            attack();
            fireBullet();
        }
        else if (Input.GetAxisRaw("Fire1") == 0)
        {
            attack1();
        }

        //var isRun = Mathf.Abs(move) > 0.1f;
        //if (!isRun && sound.isPlaying)
        //{
        //    sound.Stop();
        //}
        //else if (isRun && !sound.isPlaying)
        //{
        //    sound.Play();
        //}



    }

    //void StopSfx()
    //{
    //    sound.Stop();
    //}

    //void PlaySfx(AudioClip clip,bool loop = true)
    //{

    //}


    void flip()//quay mặt sang trái phải
    {
        facingRight = !facingRight;
        Vector3 theSacle = transform.localScale;
        theSacle.x *= -1;
        transform.localScale = theSacle;
    }

    
   void die()
    {
        Debug.Log(message: "dead");
        myanim.SetBool("die", true);
    }

    void attack()
    {
        Debug.Log(message: "attack");
        myanim.SetBool("attack", true);
    }
    void attack1()
    {
        myanim.SetBool("attack", false);
    }

    //chuc nang ban
    void fireBullet()
    {
        if (Time.time > nextFire)
        {
            
            nextFire = Time.time + fireRate;
            if (facingRight)
            {
                Instantiate(bullet, gunTip.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            }
            else if (!facingRight)
            {
                Instantiate(bullet, gunTip.position, Quaternion.Euler(new Vector3(0, 0, 180)));
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)//điều kiện va chạm để nhảy
    {
        if (other.gameObject.tag == "grouned")
        {
            grounded = true;
            Debug.Log(message: "on the ground");
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "DeadTouch")
        {
            die();
        }
    }


}
