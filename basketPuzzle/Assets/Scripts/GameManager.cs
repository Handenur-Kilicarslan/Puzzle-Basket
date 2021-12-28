using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Fruits { 
    Apple, Orange, Papaya, Pear, WaterMelon, Fig

    //state i randomize etmek tpecasting
    //whichFruit = (Fruits)Random.Range(0, 6);
};


public class GameManager : MonoBehaviour
{
    public FlipMovement flipMovement;

    [Header("Which Fruit")]
    public Fruits whichFruit;
    public GameObject playPanel;
    [Space(10)]



    [Space(10)]
    [Header("Level Fruits")]
    public GameObject ThisLevelBalls;
    public GameObject AppleLevelBalls;
    public GameObject OrangeLevelBalls;
    public GameObject PearLevelBalls;

    [Space(10)]
    [Header("Fruits UI Letters List")]
    public List<GameObject> WordUI;
    public List<GameObject> AppleWordUI;
    public List<GameObject> OrangeWordUI;
    public List<GameObject> PearWordUI;

    [Header("Tap to Start Panels")]
    public GameObject AppleWordsPanel;
    public GameObject OrangeWordsPanel;
    public GameObject PearWordsPanel;

    [Header("LEVEL INFO")]
    public GameObject rightSideBallsBarrier;
    public static int diziBoyut = 1;
    public static List<char> MainWord;
    public static List<char> AppleWord = new List<char> { 'A', 'P', 'P', 'L', 'E' };
    public static List<char> OrangeWord = new List<char> { 'O', 'R' , 'A', 'N', 'G', 'E'};
    public static List<char> PearWord = new List<char> { 'P', 'E', 'A', 'R' };

    public GameObject fireWork;
    public bool endGame = false;
    public bool panelControl = false;
    public bool AnotherBool = true;

    private bool isNextLevelPressed = false;


    void Start()
    {
        endGame = false;
        flipMovement.enabled = false;
        AppleLevelBalls.SetActive(false);
        OrangeLevelBalls.SetActive(false);
    }
    public static GameManager instance;
    private void Awake()
    {
        instance = this;
    }

    void Update()
    {
        Debug.Log("PANEL CONTROL" + panelControl);
        Debug.Log("state : " + whichFruit);
        switch (whichFruit)
        {
            case Fruits.Apple:

                AppleLevelBalls.SetActive(true);
                MainWord = AppleWord;
                WordUI = AppleWordUI;
                diziBoyut = MainWord.Count;

                if (panelControl && AnotherBool)
                {
                    AppleWordsPanel.SetActive(false);
                    AppleLevelBalls.SetActive(false);

                    UýManager.instance.AppleWordsPanel.SetActive(false);

                    MakeBooleanThings();
                    SwichFruitStatus();
                    
                }
                break;
            case Fruits.Orange:
                MakeTrueorFalse(endGame, false);

                if (isNextLevelPressed)
                {
                    OrangeLevelBalls.SetActive(true);
                    isNextLevelPressed = false;
                }

                MainWord = OrangeWord;
                WordUI = OrangeWordUI;
                diziBoyut = MainWord.Count;

                if (panelControl && AnotherBool)
                {
                    OrangeWordsPanel.SetActive(false);
                    OrangeLevelBalls.SetActive(false);

                    UýManager.instance.OrangeWordsPanel.SetActive(false);

                    MakeBooleanThings();
                    SwichFruitStatus();
                }
                break;
            case Fruits.Papaya:
                break;
            case Fruits.Pear:

                MakeTrueorFalse(endGame, false);
                if (isNextLevelPressed)
                {
                    PearLevelBalls.SetActive(true);
                    isNextLevelPressed = false;
                }

                MainWord = PearWord;
                WordUI = PearWordUI;
                diziBoyut = MainWord.Count;

                if (panelControl && AnotherBool)
                {
                    PearWordsPanel.SetActive(false);
                    PearLevelBalls.SetActive(false);
                    panelControl = false;
                    UýManager.instance.PearWordsPanel.SetActive(false);


                    MakeBooleanThings();
                    SwichFruitStatus();

                }


                break;

            case Fruits.WaterMelon:
                break;

            case Fruits.Fig:
                break;
        }

    }
    
    
    public void Win()
    {
        Debug.Log("Win Fonksiyonu;");
        panelControl = true;
        StartCoroutine(PanelOpening()); //win uý açar

        //Daha sonra butona basarak next level eski fonksiyonunu çalýþtýrýyor 
    }


    public void NextLevelEski() //buton
    {
        Debug.Log("next level eski fonksiyonu");
        UýManager.instance.NextLevelUI();

        AnotherBool = true;
        isNextLevelPressed = true;

    }


    public IEnumerator PanelOpening()
    {
        yield return new WaitForSeconds(1f);
        UýManager.instance.WinUI();
    }
    

    public void SwichFruitStatus()
    {
        if (whichFruit == Fruits.Orange)
        {
            Debug.Log("---------Orange -> Pear --------");
            whichFruit = Fruits.Pear;

            AnotherBool = false;
            return;
        }
        else if (whichFruit == Fruits.Apple)
        {
            Debug.Log("-------- Apple -> Orange ------");
            whichFruit = Fruits.Orange;

            AnotherBool = false;
            return;
        }
        else if(whichFruit == Fruits.Pear)
        {
            Debug.Log("--------------------------------PEARDAYIM GEÇEYÝM MÝ------------------------------------------");
        }
       

    }

    public IEnumerator MakeTrueorFalse(bool gonnaChange , bool isTrue)
    {
        yield return new WaitForSeconds(2f);
        if (isTrue)
            gonnaChange = true;
        else
            gonnaChange = false;
    }

    public void GameOver()
    {
        UýManager.instance.FaiUI();
    }
    public void NextLevel()
    {
        UýManager.instance.WinUI();
        whichFruit = (Fruits)Random.Range(0, 6); // rastgele meyve döndürmeli

    }
    public void Restart()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        whichFruit = Fruits.Orange;
    }

    void MakeBooleanThings()
    {
        panelControl = false;
        endGame = true;
        AnotherBool = false;
    }
}


/*
 * if(Input.GetMouseButtonDown(0) && endGame)
                {
                    OrangeLevelBalls.SetActive(true);
                }
 */