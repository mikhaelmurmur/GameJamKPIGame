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
        EventManager.instance.AddEventHandler(GlobalEvents.AddScore, ChangeScore);
        EventManager.instance.AddEventHandler(GlobalEvents.SubstractScore, ChangeScore);
    }

    void OnDisable()
    {
        if (EventManager.instance != null)
        {
            EventManager.instance.RemoveEventHandler(GlobalEvents.AddScore, ChangeScore);
            EventManager.instance.RemoveEventHandler(GlobalEvents.SubstractScore, ChangeScore);
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
