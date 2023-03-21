using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyHealth : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]public float maxHealth;
    float currentHealth;

    // cac bien de tao thanh mau enemy
    //public Slider EnemyHealthSlider;

    void Start()
    {
        currentHealth = maxHealth;
        //EnemyHealthSlider.maxValue = maxHealth;
        //EnemyHealthSlider.value = maxHealth;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addDamage(float damage)
    {
        //EnemyHealthSlider.gameObject.SetActive(true);
        currentHealth -= damage;
        //EnemyHealthSlider.value=currentHealth;

        if (currentHealth <= 0)
        {
            makeDead();
            Debug.Log(message: "DESTROYED");
        }
    }

    void makeDead()
    {
        Destroy(gameObject);
    }
}
