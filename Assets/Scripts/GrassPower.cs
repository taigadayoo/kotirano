using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassPower : MonoBehaviour
{
    // グラスの種類を定義する列挙型
    public enum GrassName
    {
        rock, // ロックタイプ
        wine, // ワインタイプ
        cocktail // カクテルタイプ
    }

    // パワーレベルを定義する列挙型
    public enum Power
    {
        one, // レベル1のパワー
        two, // レベル2のパワー
        max // 最大パワーレベル
    }

    public float oneSpeed = 2.0f; // レベル1の速度
    public float twoSpeed = 4.0f; // レベル2の速度
    public float maxSpeed = 6.0f; // 最大パワーの速度

    public bool Finish = false; // 動きが完了したかどうかを示すフラグ

    [SerializeField]
    public Power power; // 現在のパワーレベル
    [SerializeField]
    public GrassName grassName; // 現在のグラスの種類

    private float pulsPower = 0; // 衝突数に基づくパルスパワー
    BoolManager boolManager; // BoolManagerのインスタンス
    CountCollider countCollider; // CountColliderのインスタンス

    private void Awake()
    {
        // BoolManagerのインスタンスを取得
        boolManager = FindObjectOfType<BoolManager>();
    }

    void Start()
    {
        Finish = false; // Finishフラグをリセット
        countCollider = FindObjectOfType<CountCollider>(); // CountColliderのインスタンスを取得

        // BoolManagerのランダム値に基づいてパワーを決定
        if (boolManager.randomPower == 0)
        {
            power = Power.one;
        }
        else if (boolManager.randomPower == 1)
        {
            power = Power.two;
        }
        else if (boolManager.randomPower == 2)
        {
            power = Power.max;
        }
    }

    // Updateはフレームごとに呼び出される
    void Update()
    {
        StartCoroutine(DireySlide()); // スライドコルーチンを開始

        // スライドが開始されるかチェック
        if (countCollider.StartSlide == true)
        {
            // グラスの種類に応じて移動
            if (grassName == GrassName.rock)
            {
                GrassRoockMove();
            }
            if (grassName == GrassName.wine)
            {
                WineGrassMove();
            }
            if (grassName == GrassName.cocktail)
            {
                CaktailGrassMove();
            }
            pulsPower = countCollider.collisionCount * 0.45f; // 衝突数に基づいてパルスパワーを更新
        }
    }

    // ロックグラスの移動
    public void GrassRoockMove()
    {
        // パワーレベルに応じて移動
        if (power == Power.one)
        {
            transform.Translate(Vector3.right * (oneSpeed - 1 + pulsPower) * Time.deltaTime);
        }
        if (power == Power.two)
        {
            transform.Translate(Vector3.right * (twoSpeed - 1 + pulsPower) * Time.deltaTime);
        }
        if (power == Power.max)
        {
            transform.Translate(Vector3.right * (maxSpeed - 1 + pulsPower) * Time.deltaTime);
        }
    }

    // ワイングラスの移動
    public void WineGrassMove()
    {
        // パワーレベルに応じて移動
        if (power == Power.one)
        {
            transform.Translate(Vector3.right * (oneSpeed + 1 + pulsPower) * Time.deltaTime);
        }
        if (power == Power.two)
        {
            transform.Translate(Vector3.right * (twoSpeed + 1 + pulsPower) * Time.deltaTime);
        }
        if (power == Power.max)
        {
            transform.Translate(Vector3.right * (maxSpeed + 1 + pulsPower) * Time.deltaTime);
        }
    }

    // カクテルグラスの移動
    public void CaktailGrassMove()
    {
        // パワーレベルに応じて移動
        if (power == Power.one)
        {
            transform.Translate(Vector3.right * (oneSpeed + 4 + pulsPower) * Time.deltaTime);
        }
        if (power == Power.two)
        {
            transform.Translate(Vector3.right * (twoSpeed + 4 + pulsPower) * Time.deltaTime);
        }
        if (power == Power.max)
        {
            transform.Translate(Vector3.right * (maxSpeed + 4 + pulsPower) * Time.deltaTime);
        }
    }

    // RedLineからの衝突解除時の処理
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "RedLine")
        {
            Finish = true; // RedLineから出た時にFinishをtrueに設定
        }
    }

    // スライド処理を行うコルーチン
    IEnumerator DireySlide()
    {
        yield return new WaitForSeconds(4f); // 4秒待機
        countCollider.StartSlide = true; // スライド開始を許可
    }
}
