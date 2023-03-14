using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth;
    float currentHealth;

    Animator myanim;

    //khai bao bien UI
    public Slider playerHealthSlider;


    //public GameObject blood;
    // Start is called before the first frame update
    void Start()
    {
        myanim = GetComponent<Animator>();
        currentHealth = maxHealth;

        playerHealthSlider.maxValue = maxHealth;
        playerHealthSlider.value = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addDamage(float damage)
    {
        if (damage <= 0) return;
        currentHealth -= damage;
        playerHealthSlider.value = currentHealth;

        if (currentHealth <= 0) makeDead();

    }

    void makeDead()
    {
        myanim.SetBool("die2", true);
        Destroy(gameObject,3);
        
    }
}
