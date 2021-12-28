using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager2 : MonoBehaviour
{

    public FlipMovement flipMovement;

    [Header("Single Scene Data")]
    public Level[] levels;
    public GameStatus status = GameStatus.empty;
    public int whichLevel = 0;
    public GameObject gameArea;


    [Space(10)]
    [Header("Level Fruits")]
    public GameObject AppleLevelBalls;
    public GameObject OrangeLevelBalls;
    public GameObject PearLevelBalls;

    [Header("LEVEL INFO")]
    public GameObject rightSideBallsBarrier;
    public static int diziBoyut = 1;
    public static List<char> MainWord;
    public static List<char> AppleWord = new List<char> { 'A', 'P', 'P', 'L', 'E' };
    public static List<char> OrangeWord = new List<char> { 'O', 'R', 'A', 'N', 'G', 'E' };
    public static List<char> PearWord = new List<char> { 'P', 'E', 'A', 'R' };


    public GameObject fireWork;
    public bool endGame = false;
    public bool panelControl = false;
    public bool AnotherBool = true;

    public static GameManager2 instance;
    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

        endGame = false;
        flipMovement.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        switch (status)
        {
            case GameStatus.empty:

                gameArea = Instantiate(levels[whichLevel].LevelObj, new Vector3(-57.03f, -6.81f, 963.0879f), Quaternion.identity);


                status = GameStatus.initalize;





                break;
            case GameStatus.initalize:
                break;
            case GameStatus.start:
                break;
            case GameStatus.stay:
                break;
            case GameStatus.restart:
                break;
            case GameStatus.next:
                break;
        }

        /*
        public void GameOver()
        {
            UýManager.instance.FaiUI();
        }

        public void Win()
        {
            Debug.Log("Win Fonksiyonu;");
            ThisLevelBalls.SetActive(false);
            Debug.Log("PANEL CONTROL" + panelControl);
            panelControl = true;


            Debug.Log("PANEL CONTROL" + panelControl);
            StartCoroutine(PanelOpening());

        }

        public IEnumerator PanelOpening()
        {
            yield return new WaitForSeconds(1f);
            UýManager.instance.WinUI();

        }
        */

    }
}