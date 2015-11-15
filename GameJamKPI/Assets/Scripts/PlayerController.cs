using System;
using UnityEngine;
using System.Collections;

[Serializable]
public class Boundary
{
    public float xMin, xMax, yMin, yMax;
}

public class PlayerController : MonoBehaviour
{
    public float speed = 2f;
    public float jumpHeight = 10f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(moveHorizontal*speed, rb.velocity.y);
        rb.velocity = movement;
    }

    //void OnCollisionEnter2D(Collision2D other)
    //{
    //    if (other.gameObject.tag == "Platform")
    //    {
    //        StartCoroutine(Jumping());
    //    }
    //}

    //IEnumerator Jumping()
    //{
    //    Physics2D.gravity = new Vector2(0, 40);
    //    Physics2D.IgnoreLayerCollision(8, 9, true);
    //    yield return new WaitForSeconds(0.3f);
    //    Physics2D.gravity = new Vector2(0, 0);
    //    Physics2D.IgnoreLayerCollision(8, 9, false);
    //    yield return new WaitForSeconds(0.05f);
    //    Physics2D.gravity = new Vector2(0, -40);
    //}
}
