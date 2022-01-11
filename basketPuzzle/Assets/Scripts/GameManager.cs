using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Fruits { 
    Apple, Orange, Papaya, Pear, Fig

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

    public int GoldCount;

    [Space(10)]
    [Header("Level Fruits")]
    public GameObject ThisLevelBalls;
    public GameObject AppleLevelBalls;
    public GameObject OrangeLevelBalls;
    public GameObject PearLevelBalls;
    public GameObject FigLevelBalls;

    [Space(10)]
    [Header("Fruits UI Letters List")]
    public List<GameObject> WordUI;
    public List<GameObject> AppleWordUI;
    public List<GameObject> OrangeWordUI;
    public List<GameObject> PearWordUI;
    public List<GameObject> FigWordUI;

    [Header("Tap to Start Panels")]
    public GameObject AppleWordsPanel;
    public GameObject OrangeWordsPanel;
    public GameObject PearWordsPanel;
    public GameObject FigWordsPanel;

    [Header("LEVEL INFO")]
    public GameObject rightSideBallsBarrier;
    public static int diziBoyut = 1;
    public static List<char> MainWord;
    public static List<char> AppleWord = new List<char> { 'A', 'P', 'X', 'L', 'E' };
    public static List<char> OrangeWord = new List<char> { 'O', 'R' , 'A', 'N', 'G', 'E'};
    public static List<char> PearWord = new List<char> { 'P', 'E', 'A', 'R' };
    public static List<char> FigWord = new List<char> { 'F', 'I', 'G' };

    public GameObject fireWork;
    public GameObject wrongBallParticle;
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
        Application.targetFrameRate = 60;
    }

    void Update()
    {
        Debug.Log("PANEL CONTROL" + panelControl);
        Debug.Log("state : " + whichFruit);
        switch (whichFruit)
        {
            case Fruits.Apple:

                MakeTrueorFalse(endGame, false);

                AppleLevelBalls.SetActive(true);
                MainWord = AppleWord;
                WordUI = AppleWordUI;
                diziBoyut = MainWord.Count;

                if (panelControl && AnotherBool)
                {
                    GoldCount += 50;
                    AppleWordsPanel.SetActive(false);
                    AppleLevelBalls.SetActive(false);

                    UIManager.instance.AppleWordsPanel.SetActive(false);

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
                    GoldCount += 50;
                    OrangeWordsPanel.SetActive(false);
                    OrangeLevelBalls.SetActive(false);

                    UIManager.instance.OrangeWordsPanel.SetActive(false);

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

                    GoldCount += 50;
                    PearWordsPanel.SetActive(false);
                    PearLevelBalls.SetActive(false);

                    UIManager.instance.PearWordsPanel.SetActive(false);

                    MakeBooleanThings();
                    SwichFruitStatus();
                }
                break;

            case Fruits.Fig:

                MakeTrueorFalse(endGame, false);

                if (isNextLevelPressed)
                {
                    FigLevelBalls.SetActive(true);
                    isNextLevelPressed = false;
                }

                MainWord = FigWord;
                WordUI = FigWordUI;
                diziBoyut = MainWord.Count;

                if(panelControl && AnotherBool)
                {

                    GoldCount += 50;
                    FigWordsPanel.SetActive(false);
                    PearLevelBalls.SetActive(false);

                    UIManager.instance.FigWordsPanel.SetActive(false);


                    MakeBooleanThings();
                    SwichFruitStatus();
                    
                }

                break;
        }

    }
    
    
    public void Win()
    {
        Debug.Log("Win Fonksiyonu;");
        panelControl = true;
        StartCoroutine(PanelOpening()); //win u� a�ar
        //Daha sonra butona basarak next level eski fonksiyonunu �al��t�r�yor 
    }

    public void NextLevelEski() //buton
    {
        Debug.Log("next level eski fonksiyonu");
        UIManager.instance.NextLevelUI();

        AnotherBool = true;
        isNextLevelPressed = true;
        /*
        if(whichFruit == Fruits.Fig && endGame)
        {
            Application.Quit();
        }
        */
    }


    public IEnumerator PanelOpening()
    {
        yield return new WaitForSeconds(1f);
        UIManager.instance.WinUI();
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
            Debug.Log("-------- Pear -> Fig ------");
            whichFruit = Fruits.Fig;

            AnotherBool = false;
            return;
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
        UIManager.instance.FaiUI();
    }

    public void NextLevel()
    {
        UIManager.instance.WinUI();
        whichFruit = (Fruits)Random.Range(0, 6); // rastgele meyve d�nd�rmeli
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