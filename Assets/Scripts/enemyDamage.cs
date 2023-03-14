using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDamage : MonoBehaviour
{
    public float damage;
    float dameRate = 0.5f;
    public float pushBackForce;
    float nextDamage;
    // Start is called before the first frame update
    void Start()
    {
        nextDamage = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && nextDamage < Time.time)
        {
            Debug.Log(message: "va cham");
            PlayerHealth thePlayerHealth = other.gameObject.GetComponent<PlayerHealth>();
            thePlayerHealth.addDamage(damage);
            nextDamage = dameRate + Time.time;

            pushBack(other.transform);
        }
    }
   void pushBack(Transform pushedObject)
    {
        Vector2 pushDirection = new Vector2(0, (pushedObject.position.y - transform.position.y)).normalized;//tra ve gia tri vector=1
        pushDirection *= pushBackForce;

        Rigidbody2D pushRb = pushedObject.gameObject.GetComponent<Rigidbody2D>();
        pushRb.velocity = Vector2.zero;
        pushRb.AddForce(pushDirection, ForceMode2D.Impulse);
    }
}
