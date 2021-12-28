using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// SORU İŞARETLİ PANELLERİ EKLE
//tap to start pear orange falan

public class UıManager : MonoBehaviour
{
    [Header("Panels")]
    public GameObject startPanel;
    public GameObject playPanel;
    public GameObject winPanel;
    public GameObject failPanel;

    [Header("Play Panels")]
    public GameObject AppleWordsPanel;
    public GameObject OrangeWordsPanel;
    public GameObject PearWordsPanel;

    [Header("Tap To Start Panels")]
    public GameObject whatIsApple;
    public GameObject whatIsOrange;
    public GameObject whatIsPear;


    void Start()
    {
        startPanel.SetActive(true);
        playPanel.SetActive(false);
        failPanel.SetActive(false);
        winPanel.SetActive(false);
        //-------------------------
        AppleWordsPanel.SetActive(false);
        OrangeWordsPanel.SetActive(false);
        PearWordsPanel.SetActive(false);
    }

    public static UıManager instance;
    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (GameManager.instance.whichFruit == Fruits.Apple)
        {
            startPanel = whatIsApple;
            playPanel = AppleWordsPanel;
            
        }
        else if (GameManager.instance.whichFruit == Fruits.Orange)
        {
            startPanel = whatIsOrange;
            playPanel = OrangeWordsPanel;
        }
        else if(GameManager.instance.whichFruit == Fruits.Pear)
        {
            startPanel = whatIsPear;
            playPanel = PearWordsPanel;
        }
    }

    public void TapToStartUI()
    {
        startPanel.SetActive(false);
        playPanel.SetActive(true);
    }

    public void FaiUI()
    {
        playPanel.SetActive(false);
        failPanel.SetActive(true);
    }

    public void WinUI()
    {
        playPanel.SetActive(false);
        winPanel.SetActive(true);
    }

    public void NextLevelUI()
    {
        Debug.Log("wİNPANELİ KAPATMIYOR MUSUN");
        winPanel.SetActive(false);
       // playPanel.SetActive(true);
       startPanel.SetActive(true);
    }
}