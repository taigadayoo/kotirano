using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ResultAnim : MonoBehaviour
{
    BoolManager boolManager;
    Scenemanager scenemanager;
    private bool OneMove = false;

    [SerializeField]
    SpriteRenderer spriteRenderer;

    [SerializeField]
    Sprite rock;
    [SerializeField]
    Sprite wine;
    [SerializeField]
    Sprite caktail;
    // Start is called before the first frame update
    void Start()
    {
        boolManager = FindObjectOfType<BoolManager>();
        scenemanager = FindObjectOfType<Scenemanager>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (boolManager != null && OneMove == false)
        {
            if (boolManager.isStop)
            {
                if(boolManager.isRock)
                {
                    spriteRenderer.sprite = rock;
                }
                if(boolManager.isWine)
                {
                    spriteRenderer.sprite = wine;
                }
                if(boolManager.isCaktail)
                {
                    spriteRenderer.sprite = caktail;
                }
                this.transform.DOMove(new Vector3(3.83f, -0.8f, 0f), 2f);
                OneMove = true;
                StartCoroutine(GameOver());
                StartCoroutine(isStopAnim());
            }
            if(boolManager.isJust)
            {
                if (boolManager.isRock)
                {
                    spriteRenderer.sprite = rock;
                }
                if (boolManager.isWine)
                {
                    spriteRenderer.sprite = wine;
                }
                if (boolManager.isCaktail)
                {
                    spriteRenderer.sprite = caktail;
                }
                this.transform.DOMove(new Vector3(6.54f, -0.8f, 0f), 2.5f);
                OneMove = true;
                StartCoroutine(Clear());
                StartCoroutine(isJustAnim());
            }
            if(boolManager.isOver)
            {
                if (boolManager.isRock)
                {
                    spriteRenderer.sprite = rock;
                }
                if (boolManager.isWine)
                {
                    spriteRenderer.sprite = wine;
                }
                if (boolManager.isCaktail)
                {
                    spriteRenderer.sprite = caktail;
                }
                this.transform.DOMove(new Vector3(13f, -0.8f, 0f), 2.5f);
                OneMove = true;
                StartCoroutine(GameOver());
                StartCoroutine(IsOverAnim());
            }
        }
    }
    IEnumerator isJustAnim()
    {
        yield return new WaitForSeconds(1.5f);
        SampleSoundManager.Instance.PlaySe(SeType.SE5);
    }
    IEnumerator IsOverAnim()
    {
        yield return new WaitForSeconds(1f);
        SampleSoundManager.Instance.PlaySe(SeType.SE3);
        yield return new WaitForSeconds(1f);
        SampleSoundManager.Instance.PlaySe(SeType.SE4);
    }
    IEnumerator isStopAnim()
    {
        yield return new WaitForSeconds(1f);
        SampleSoundManager.Instance.PlaySe(SeType.SE6);
    }
    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(3.5f);

        scenemanager.GameOver();
    }
    IEnumerator Clear()
    {
        yield return new WaitForSeconds(3f);

        scenemanager.GameClear();
    }
}
