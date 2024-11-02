using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountCollider : MonoBehaviour
{
    // コライダー1に衝突したかどうかのフラグ
    private bool collidedWithCollider1 = false;
    // コライダー2に衝突したかどうかのフラグ
    private bool collidedWithCollider2 = false;
    // 衝突回数をカウントする変数
    public int collisionCount = 0;

    // スライドを開始するかどうかのフラグ
    public bool StartSlide = false;
    // GameManagerのインスタンスを保持するためのフィールド
    GameManager gameManager;

    // Startメソッドはゲームオブジェクトが有効になったときに呼び出される
    private void Start()
    {
        // GameManagerのインスタンスを取得
        gameManager = FindObjectOfType<GameManager>();
    }

    // トリガーコライダーに入ったときに呼び出される
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ゲームマネージャーがカウントを有効にしている場合
        if (gameManager.OnCount)
        {
            // Collider1に衝突した場合
            if (collision.gameObject.tag == "Collider1")
            {
                // 効果音を再生
                SampleSoundManager.Instance.PlaySe(SeType.SE2);
                // Collider1に初めて当たった場合
                if (!collidedWithCollider1 && StartSlide)
                {
                    // フラグを設定
                    collidedWithCollider1 = true;
                    collidedWithCollider2 = false; // Collider1に当たったときにCollider2の状態をリセット
                    collisionCount++; // カウントを増やす
                    // 現在のカウントをデバッグ出力
                    Debug.Log("Collision Count: " + collisionCount);
                }
            }
            // Collider2に衝突した場合
            else if (collision.gameObject.tag == "Collider2")
            {
                // 効果音を再生
                SampleSoundManager.Instance.PlaySe(SeType.SE2);
                // Collider2に初めて当たった場合
                if (!collidedWithCollider2 && StartSlide)
                {
                    // フラグを設定
                    collidedWithCollider2 = true;
                    collidedWithCollider1 = false; // Collider2に当たったときにCollider1の状態をリセット
                }
            }
        }
    }
}
