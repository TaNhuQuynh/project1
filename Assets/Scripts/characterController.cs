using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour
{
    [SerializeField] SpriteRenderer playerSprite;
    [SerializeField] float speed = 1;

    public float direction = -1;

    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        Move();
    }
    void Move()
    {
        Vector3 position = transform.position;
        if (direction == 1 && position.x > 34.16)
        {
            SetDirecton(dir: -1);
        }
        if (direction == -1 && position.x < 28.84)
        {
            SetDirecton(dir: 1);
        }

        position.x += direction * speed * Time.deltaTime;
        transform.position = position;
    }
    private void SetDirecton(int dir)
    {
        direction = dir;
        playerSprite.flipX = dir == 1;
    }
}
