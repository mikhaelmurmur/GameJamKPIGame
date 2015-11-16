using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    private GameObject spawner;
    private int points;
    // Use this for initialization
    void Start()
    {
        spawner = GameObject.FindWithTag("Respawn");
        Reset();
    }

    void OnEnable()
    {
        EventManager.Instance.AddEventHandler(GlobalEvents.AddScore, ChangeScore);
        EventManager.Instance.AddEventHandler(GlobalEvents.SubstractScore, ChangeScore);
    }

    private void OnDisable()
    {
        Debug.Log("On disable");
        if (EventManager.Instance)
        {
            EventManager.Instance.RemoveEventHandler(GlobalEvents.AddScore, ChangeScore);
            EventManager.Instance.RemoveEventHandler(GlobalEvents.SubstractScore, ChangeScore);
        }
    }

    void ChangeScore(object[] scores)
    {
        int difference = (int)scores[0];
        points += difference;
        Debug.Log("Points: " + points.ToString());
    }

    void Reset()
    {
        points = 0;
        spawner.SendMessage("InitialSpawn");
    }


    // Update is called once per frame
    void Update()
    {

    }
}
