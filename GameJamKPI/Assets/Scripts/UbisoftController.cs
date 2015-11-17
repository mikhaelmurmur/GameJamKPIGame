using UnityEngine;
using System.Collections;

public class UbisoftController : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        Time.timeScale = 0.001f;
        other.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 100), ForceMode2D.Impulse);
        new WaitForSeconds(5f);
        Time.timeScale = 1f;
        GameObject.FindWithTag("Respawn").SendMessage("SpawnUbi");
        Destroy(this.gameObject);
    }





}
