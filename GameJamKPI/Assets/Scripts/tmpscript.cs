using UnityEngine;
using System.Collections;

public class tmpscript : MonoBehaviour {

    // Use this for initialization
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            collision.rigidbody.AddRelativeForce(transform.up * 100, ForceMode2D.Impulse);
            //rb.velocity = new Vector2(0, jumpHeight);
            Debug.Log("Collision entered");
            //Vector2 movement = new Vector2(0, jumpHeight);
            //rb.velocity = movement;
            //StartCoroutine(Jumping());
            //transform.Translate(transform.up*50*Time.fixedDeltaTime);
            //Physics2D.gravity = new Vector2(0,10);
            //rb.AddForce(transform.up *3000);
        }
    }
}
