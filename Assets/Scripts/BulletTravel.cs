using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTravel : MonoBehaviour
{

    public float speed = 10f;
    public Rigidbody2D rb;
    int maxCollisions = 5;
    Vector3 shootingDirection;
    
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
        shootingDirection = rb.velocity;
    }
    private void Update()
    {
        rb.velocity = rb.velocity * speed / Mathf.Sqrt(rb.velocity.x * rb.velocity.x + rb.velocity.y * rb.velocity.y);
        shootingDirection = rb.velocity;
        transform.eulerAngles = new Vector3(0, 0, GetAngleFromVector(shootingDirection));
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Boundary"))
        {
            maxCollisions--;
        }
        if (maxCollisions == 0)
        {
            Destroy(rb.gameObject);
         
        }


    }

    public float GetAngleFromVector(Vector3 dir)
    {
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0)
        {
            n += 360;
        }
        return n;
    }
}
