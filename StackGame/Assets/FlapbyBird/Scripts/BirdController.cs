using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    public float speed;
    public float jumping;
    private float Move;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        rb.velocity = new Vector2(speed * 0.3f, rb.velocity.y);
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector2(rb.velocity.x, jumping));
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
      /*  if(collision.gameObject.CompareTag("Grond") || collision.gameObject.CompareTag("Wiper"))
        {
            
        }*/
    }
}
