using UnityEngine;
using System.Collections;
using DG.Tweening;

public class SlowpokeController : MonoBehaviour
{



    void Start()
    {
        StartCoroutine(Moving());
    }

    IEnumerator Moving()
    {
        transform.DOLocalMoveX(-2, 1f);
        yield return new WaitForSeconds(1);
        while (true)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y);
            transform.DOLocalMoveX(2, 1f);
            yield return new WaitForSeconds(1);
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y);
            transform.DOLocalMoveX(-2, 1f);
            yield return new WaitForSeconds(1);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("SlowPOKE POWER!!!");
        EventManager.instance.CallEvent(GlobalEvents.SubstractScore, new object[] { -10 });
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
