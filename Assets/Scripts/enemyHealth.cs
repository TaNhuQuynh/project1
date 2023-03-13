using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]public float maxHealth;
    float currenHealth;

    void Start()
    {
        currenHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addDamage(float damage)
    {
        currenHealth -= damage;
        if (currenHealth <= 0)
        {
            makeDead();
            Debug.Log(message: "detroyed");
        }
    }

    void makeDead()
    {
        Destroy(gameObject);
    }
}
