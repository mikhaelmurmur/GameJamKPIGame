using UnityEngine;
using System.Collections;
using DG.Tweening;

public class CodeController : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Fell the power of the code!!");
        EventManager.instance.CallEvent(GlobalEvents.AddScore, new object[] { 30 });
        Destroy(this.gameObject);
    }

    void Start()
    {
        StartCoroutine(Moving());
    }

    IEnumerator Moving()
    {
        while (true)
        {
            transform.DOLocalMoveY(3, 1f);
            yield return new WaitForSeconds(0.5f);
            transform.DOLocalMoveY(1.5f, 1f);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
