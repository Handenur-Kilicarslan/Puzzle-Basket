using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PotaMovement : MonoBehaviour
{
    public Ease easeMode;
    public Transform basket2;

    // 8.5 4
    [SerializeField] private float yEkseni;
    [SerializeField] private float yEkseni2;
    [SerializeField] private float direction;

    void Start()
    {
        DOTween.Init();
    }

    // Update is called once per frame
    void Update()
    {
        if(BallCode.isBasket == true)
        {
            yEkseni = Random.Range(4.3f, 8f);
            yEkseni2 = Random.Range(4.3f, 6f);
            direction = Random.Range(0, 5);


            StartCoroutine(MoveTheBasketRandomly(yEkseni));

            /*
            if (direction > 2)
                StartCoroutine(MoveTheBasketRandomly(yEkseni));
            else
                StartCoroutine(MoveBasketRandomyLeft(yEkseni2));
            */
            BallCode.isBasket = false;
        }
        
    }

    public IEnumerator MoveTheBasketRandomly(float yEkseni)
    {

        transform.DOMoveX(transform.position.x - 2, 1f).SetEase(easeMode);
        yield return new WaitForSeconds(1.1f);
        transform.DOMoveY(yEkseni + 1f, 0.1f);
        transform.DOMoveX(transform.position.x + 2f, 1f).SetEase(easeMode);
    }

    public IEnumerator MoveBasketRandomyLeft(float yEkseni2)
    {

        transform.DOMoveX(basket2.position.x - 2, 2f).SetEase(easeMode);
        yield return new WaitForSeconds(2f);
        transform.DOMoveY(yEkseni2 + 1f, 0.1f);
        transform.DOMoveX(basket2.position.x + 2f, 1f).SetEase(easeMode);

    }
}
