using UnityEngine;
using System.Collections;
using System.Threading.Tasks;
using Parse;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject winnerMenu, scoreMenu;
    public Text scoreText;
    public InputField nameText, vkIDText;
    public CameraFollow cameraMain;
    public Text TotalPointsText;
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
        TotalPointsText.text = points.ToString();
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
            vkIDText.text = PlayerPrefs.GetString("VKID");
        }
        winnerMenu.SetActive(true);
        scoreMenu.SetActive(false);
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
            PlayerPrefs.SetString("Name", nameText.text);
            PlayerPrefs.SetString("VKID", vkIDText.text);
            Task saveTask = winnerData.SaveAsync();
            cameraMain.transform.position = new Vector3(0, 0, -10);
            spawner.SendMessage("Reset");
            winnerMenu.SetActive(false);
            scoreMenu.SetActive(true);
            points = 0;
            InitialSetUp();
        }
        else
        {

        }
    }


    // Update is called once per frame
    void Update()
    {

    }
}
