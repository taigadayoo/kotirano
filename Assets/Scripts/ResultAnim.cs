using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ResultAnim : MonoBehaviour
{
    BoolManager boolManager; // BoolManagerのインスタンス
    Scenemanager scenemanager; // SceneManagerのインスタンス
    private bool OneMove = false; // アニメーションが一度だけ実行されるようにするフラグ

    [SerializeField]
    SpriteRenderer spriteRenderer; // スプライトを描画するためのSpriteRenderer

    [SerializeField]
    Sprite rock; // 岩のスプライト
    [SerializeField]
    Sprite wine; // ワインのスプライト
    [SerializeField]
    Sprite caktail; // カクテルのスプライト

    // Start is called before the first frame update
    void Start()
    {
        // BoolManagerとSceneManagerを見つける
        boolManager = FindObjectOfType<BoolManager>();
        scenemanager = FindObjectOfType<Scenemanager>();
    }

    // Update is called once per frame
    void Update()
    {
        // BoolManagerが存在し、アニメーションがまだ実行されていない場合
        if (boolManager != null && OneMove == false)
        {
            // 停止状態の処理
            if (boolManager.isStop)
            {
                // スプライトを岩に設定
                if (boolManager.isRock)
                {
                    spriteRenderer.sprite = rock;
                }
                // スプライトをワインに設定
                if (boolManager.isWine)
                {
                    spriteRenderer.sprite = wine;
                }
                // スプライトをカクテルに設定
                if (boolManager.isCaktail)
                {
                    spriteRenderer.sprite = caktail;
                }
                // 位置を移動させる
                this.transform.DOMove(new Vector3(3.83f, -0.8f, 0f), 2f);
                OneMove = true; // アニメーションが実行されたことを記録
                StartCoroutine(GameOver()); // ゲームオーバーの処理を開始
                StartCoroutine(isStopAnim()); // 停止アニメーションのサウンドを開始
            }
            // 確認状態の処理
            if (boolManager.isJust)
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
                StartCoroutine(Clear()); // ゲームクリアの処理を開始
                StartCoroutine(isJustAnim()); // 確認アニメーションのサウンドを開始
            }
            // 終了状態の処理
            if (boolManager.isOver)
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
                StartCoroutine(GameOver()); // ゲームオーバーの処理を開始
                StartCoroutine(IsOverAnim()); // 終了アニメーションのサウンドを開始
            }
        }
    }

    // 確認状態のアニメーション
    IEnumerator isJustAnim()
    {
        yield return new WaitForSeconds(1.5f); // 1.5秒待つ
        SampleSoundManager.Instance.PlaySe(SeType.SE5); // サウンドを再生
    }

    // 終了状態のアニメーション
    IEnumerator IsOverAnim()
    {
        yield return new WaitForSeconds(1f); // 1秒待つ
        SampleSoundManager.Instance.PlaySe(SeType.SE3); // サウンドを再生
        yield return new WaitForSeconds(1f); // 1秒待つ
        SampleSoundManager.Instance.PlaySe(SeType.SE4); // サウンドを再生
    }

    // 停止状態のアニメーション
    IEnumerator isStopAnim()
    {
        yield return new WaitForSeconds(1f); // 1秒待つ
        SampleSoundManager.Instance.PlaySe(SeType.SE6); // サウンドを再生
    }

    // ゲームオーバーの処理
    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(3.5f); // 3.5秒待つ
        scenemanager.GameOver(); // ゲームオーバーを呼び出す
    }

    // ゲームクリアの処理
    IEnumerator Clear()
    {
        yield return new WaitForSeconds(3f); // 3秒待つ
        scenemanager.GameClear(); // ゲームクリアを呼び出す
    }
}
