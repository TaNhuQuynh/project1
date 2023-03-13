using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletHit : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] ProjectileController myPC;
    [SerializeField] public GameObject bulletExplosion;
    [SerializeField]public float weaponDamage;

    private void Awake()
    {
        myPC = GetComponentInParent<ProjectileController>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "shootable")
        {
            myPC.removeForce();
            Instantiate(bulletExplosion, transform.position, transform.rotation);
            Destroy(gameObject);

            if (other.gameObject.layer == LayerMask.NameToLayer("enemy"))
            {
                enemyHealth hurtEnemy = other.gameObject.GetComponent<enemyHealth>();
                hurtEnemy.addDamage(weaponDamage);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "shootable")
        {
            myPC.removeForce();
            Instantiate(bulletExplosion, transform.position, transform.rotation);
            Destroy(gameObject);

            if (other.gameObject.layer == LayerMask.NameToLayer("enemy"))
            {
                enemyHealth hurtEnemy = other.gameObject.GetComponent<enemyHealth>();
                hurtEnemy.addDamage(weaponDamage);
            }
        }
    }
}
