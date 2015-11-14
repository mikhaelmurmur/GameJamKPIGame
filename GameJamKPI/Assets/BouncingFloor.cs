using UnityEngine;
using System.Collections;

public class BouncingFloor : MonoBehaviour
{

    public float bounceFactor = 4f;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        other.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        other.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 1, ForceMode2D.Impulse);
    }
}
