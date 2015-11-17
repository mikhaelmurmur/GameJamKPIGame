using UnityEngine;
using System.Collections;
using System.Threading.Tasks;
using Parse;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject winnerMenu;
    public Text scoreText, nameText, vkIDText;
    public CameraFollow cameraMain;
    private GameObject spawner;
    private int points;

    // Use this for initialization
    void Start()
    {
        spawner = GameObject.FindWithTag("Respawn");
        InitialSetUp();
    }

    void OnEnable()
    {
        EventManager.Instance.AddEventHandler(GlobalEvents.AddScore, ChangeScore);
        EventManager.Instance.AddEventHandler(GlobalEvents.SubstractScore, ChangeScore);
        EventManager.Instance.AddEventHandler(GlobalEvents.GameIsOver, GameIsOver);
    }

    private void OnDisable()
    {
        if (EventManager.Instance)
        {
            EventManager.Instance.RemoveEventHandler(GlobalEvents.AddScore, ChangeScore);
            EventManager.Instance.RemoveEventHandler(GlobalEvents.SubstractScore, ChangeScore);
            EventManager.Instance.RemoveEventHandler(GlobalEvents.GameIsOver, GameIsOver);
        }
    }

    void ChangeScore(object[] scores)
    {
        int difference = (int)scores[0];
        points += difference;
        Debug.Log("Points: " + points.ToString());
    }

    void GameIsOver(object[] param)
    {
        scoreText.text = points.ToString();
        if (PlayerPrefs.HasKey("Name"))
        {
            nameText.text = PlayerPrefs.GetString("Name");
        }
        if (PlayerPrefs.HasKey("VKID"))
        {
            nameText.text = PlayerPrefs.GetString("VKID");
        }
        winnerMenu.SetActive(true);
    }

    void InitialSetUp()
    {
        cameraMain.player = Instantiate(player);
        spawner.SendMessage("InitialSpawn");
    }

    public void Reset()
    {
        if ((nameText.text != "") && (vkIDText.text != ""))
        {
            ParseObject winnerData = new ParseObject("WinnersData");
            winnerData["Score"] = points;
            winnerData["Name"] = nameText.text;
            winnerData["idVk"] = vkIDText.text;
            Task saveTask = winnerData.SaveAsync();
            cameraMain.transform.position = new Vector3(0, 0, -10);
            spawner.SendMessage("Reset");
            winnerMenu.SetActive(false);
            points = 0;
            InitialSetUp();
        }
    }


    // Update is called once per frame
    void Update()
    {

    }
}
