using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]public float bulletSpeed;

    Rigidbody2D mybody;

    private void Awake()
    {
        mybody = GetComponent<Rigidbody2D>();

        if (transform.localRotation.z > 0)
        {
            mybody.AddForce(new Vector2(-1, 0) * bulletSpeed, ForceMode2D.Impulse);
        }
       else
        {
            mybody.AddForce(new Vector2(1, 0) * bulletSpeed, ForceMode2D.Impulse);
        }
        
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //tao chuc nang va cham voi vien dan
    public void removeForce()
    {
        mybody.velocity = new Vector2(0, 0);
    }
}
