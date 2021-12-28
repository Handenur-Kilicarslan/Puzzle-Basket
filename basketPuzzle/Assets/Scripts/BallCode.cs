using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCode : MonoBehaviour
{
    [Header("My Letter Info")]
    public char Letter;
    public static bool isBasket = false;
    public bool enableBallCode = false;


    [Header("Basket Informations")]
    public GameObject fireWork;
    public bool isBottomPartTouched = false;
    public bool isUpperPartTouched = false;


    [Header("Game Objects")]
    public GameObject bottomBasketBarrier;
    private GameObject child;
    private Rigidbody rb;
    private MeshRenderer mr;

    int n;
    private bool controlBool = true;

    //ilk harfi kes;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.endGame = false;
        fireWork = GameManager.instance.fireWork;
        child = transform.GetChild(0).gameObject;
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        mr = GetComponent<MeshRenderer>();
        bottomBasketBarrier = GameObject.FindGameObjectWithTag("BottomBasketBarrier");
        isUpperPartTouched = false;
        isBottomPartTouched = false;

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && GameManager.instance.endGame != true && GameManager.instance.panelControl == false)
        {
            UýManager.instance.TapToStartUI();
            GameManager.instance.flipMovement.enabled = true;
            rb.isKinematic = false;
        }
        n = GameManager.diziBoyut;
        if (enableBallCode == true)
        {
            Debug.Log("My Letter is : " + Letter);
            n = GameManager.diziBoyut;
            
            if (isUpperPartTouched && isBottomPartTouched)
            {
                Debug.Log("------------------BASKET------------------------------");
                isBasket = true;
                StartCoroutine(CloseMeshAndGetBall(mr));

                //ball ýn mesh rendererini kapat
                n = GameManager.diziBoyut;
                for (int i = 0; i < n; i++)
                {
                    if (GameManager.MainWord[i] == Letter)
                    {
                       // fireWork.transform.position = transform.position;
                       // fireWork.GetComponent<ParticleSystem>().Play();

                        GameObject e = Instantiate(fireWork) as GameObject;
                        e.transform.position = transform.position;

                       // Debug.Log("letter " + i + " = " + GameManager.MainWord[i]);
                       
                        GameManager.instance.WordUI[i].SetActive(true);
                        GameManager.MainWord.RemoveAt(i);
                        GameManager.instance.WordUI.RemoveAt(i);
                        //return;
                    }
                    else
                    {
                        Debug.Log("Farklý bir harf else e kaç kere giriyor");
                    }

                }

                isUpperPartTouched = false;
                isBottomPartTouched = false;
            }

        }

        if (GameManager.diziBoyut <= 0 && controlBool==true)
        {
            enableBallCode = false;
            GameManager.instance.endGame = true;
            GameManager.instance.AnotherBool = true;

            GameManager.instance.rightSideBallsBarrier.GetComponent<BoxCollider>().isTrigger = false;
            
            Debug.Log("TÜM HARFLERÝ TAMAMLADIN! boyut" + GameManager.diziBoyut);

            GameManager.instance.Win();
            controlBool = false; // butona týklayýnca false olsun
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Border" && isBasket == false)
        {
            isUpperPartTouched = false;
            isBottomPartTouched = false;
            transform.position = new Vector3(3.48f, 12f, -0.17f);
            StartCoroutine(JustBarrierOpening());
            //GameManager.instance.Restart();
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "EnableBallCode") //FOR START EVERTHÝNG
        {
            enableBallCode = true;
            isUpperPartTouched = false;
            isBottomPartTouched = false;
        }
        if (other.gameObject.tag == "BasketScore")
        {
            isUpperPartTouched = true;
        }
        if (other.gameObject.tag == "BottomBasketBarrier")
        {
            isBottomPartTouched = true;
        }
        
    }



    public IEnumerator MakeTrueThenFalse(bool gonnaChange)
    {
        gonnaChange = true;
        yield return new WaitForSeconds(1f);
        gonnaChange = false;
    }
    public IEnumerator CloseMeshAndGetBall(MeshRenderer mr)
    {
        yield return new WaitForSeconds(.5f);
        mr.enabled = false;
        Destroy(child);
        yield return new WaitForSeconds(1.5f);
        GameManager.instance.rightSideBallsBarrier.GetComponent<BoxCollider>().isTrigger = true;
        yield return new WaitForSeconds(.4f);
        GameManager.instance.rightSideBallsBarrier.GetComponent<BoxCollider>().isTrigger = false;
        Destroy(gameObject);
        isBasket = false;

    }
    public IEnumerator JustBarrierOpening()
    {
        GameManager.instance.rightSideBallsBarrier.GetComponent<BoxCollider>().isTrigger = true;
        yield return new WaitForSeconds(.4f);
        GameManager.instance.rightSideBallsBarrier.GetComponent<BoxCollider>().isTrigger = false;

    }

    void yazdýr()
    {
        int k = GameManager.diziBoyut;
        for (int i = 0; i < k; i++)
        {
            Debug.Log("letter " + i + " = " + GameManager.MainWord[i]);
        }
    }
}



/*
            for (int i = 0; i < n; i++)
            {
                Debug.Log("dýþ letter " + i + " = " + GameManager.MainWord[i]);

            }
            Debug.Log(" 0. indis " + GameManager.MainWord[0] + " 1. indis " + GameManager.MainWord[1] + " 2. indis " + GameManager.MainWord[2]);
            */

