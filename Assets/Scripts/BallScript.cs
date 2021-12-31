using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public bool inPlay;
    public Transform paddle;
    public float speed;
    public Transform Explosion;
    public GameManager gm;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent("Rigidbody2D") as Rigidbody2D;

        rb.AddForce(Vector2.up * 450);
    }

    // Update is called once per frame
    void Update()
    {
        if (!inPlay)
        {
            transform.position = paddle.position;
        }

        if (Input.GetButtonDown("Jump") && !inPlay)
        {
            inPlay = true;
            rb.AddForce(Vector2.up * 485);
        }

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.activeSelf)
        {
            Debug.Log("Ball hit the bottom of the screen");
            rb.velocity = Vector2.zero;
            inPlay = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Brick")
        {
           Transform newExplosion = Instantiate(Explosion, collision.transform.position, collision.transform.rotation);
            Destroy(newExplosion.gameObject, 2.5f);
            Destroy(collision.gameObject);
        }
    }
}