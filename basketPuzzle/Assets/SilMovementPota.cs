using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SilMovementPota : MonoBehaviour
{

    public Ease easeMode;
    public Transform basket2;


    [SerializeField] private float yEkseni;
    // Start is called before the first frame update
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

            StartCoroutine(MoveTheBasketRandomly(yEkseni));
        }

    }
    public IEnumerator MoveTheBasketRandomly(float yEkseni)
    {

        transform.DOMoveX(transform.position.x - 2, 1f).SetEase(easeMode);
        yield return new WaitForSeconds(1.1f);
        transform.DOMoveY(yEkseni + 1f, 0.1f);
        transform.DOMoveX(transform.position.x + 2f, 1f).SetEase(easeMode);
    }
}
