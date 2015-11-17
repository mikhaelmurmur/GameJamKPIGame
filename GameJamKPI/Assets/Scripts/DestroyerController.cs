using UnityEngine;
using System.Collections;

public class DestroyerController : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Player is dead!");
            EventManager.Instance.CallEvent(GlobalEvents.GameIsOver, new object[] { });
        }
        Debug.Log("Destroy!");
        Destroy(other.gameObject);
    }

}
