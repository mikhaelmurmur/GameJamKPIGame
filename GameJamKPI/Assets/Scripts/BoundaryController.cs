using UnityEngine;
using System.Collections;

public class BoundaryController : MonoBehaviour
{
    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Hello!");
        other.transform.position = new Vector3(-other.transform.position.x, other.transform.position.y);
    }
}
