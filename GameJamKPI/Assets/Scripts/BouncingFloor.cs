using UnityEngine;
using System.Collections;

public class BouncingFloor : MonoBehaviour
{
    public float bounceFactor = 4f;
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger entered");
        other.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        other.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bounceFactor, ForceMode2D.Impulse);
    }
}
