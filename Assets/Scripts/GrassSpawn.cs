using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassSpawn : MonoBehaviour
{
    public GameObject rockGrass; // ロックグラスのプレハブ
    public GameObject wineGrass; // ワイングラスのプレハブ
    public GameObject cakGrass; // カクテルグラスのプレハブ
    public Transform spawnPoint; // スポーン位置
    public bool OneFinish = false; // 1つ目のスパウン完了フラグ

    RamdomNumber ramdomNumber; // ランダム番号管理クラス
    BoolManager boolManager; // BoolManagerのインスタンス
    private bool OneSpawn = false; // 一度だけスパウンするためのフラグ
    public GameObject SpawnGrass; // スポーンされたグラスのインスタンス
    GameManager gameManager; // ゲーム管理クラス

    void Start()
    {
        // BoolManagerとGameManagerのインスタンスを取得
        boolManager = FindObjectOfType<BoolManager>();
        gameManager = FindObjectOfType<GameManager>();
        ramdomNumber = GameObject.FindObjectOfType<RamdomNumber>();

        // ランダムスポーンのコルーチンを開始
        StartCoroutine(RamdomSpawn());
    }



    IEnumerator RamdomSpawn()
    {
        // BoolManagerのランダム番号に応じてスポーンするグラスを決定
        if (boolManager.ramdomNumber == 0)
        {
            SpawnGrass = Instantiate(rockGrass, spawnPoint.position, Quaternion.identity); // ロックグラスをスポーン

            yield return new WaitUntil(() => SpawnGrass != null); // スポーンが成功するまで待機

            gameManager.grass = SpawnGrass; // GameManagerにスポーンされたグラスを設定

            yield return new WaitUntil(() => gameManager.grass != null); // GameManagerがグラスを取得するまで待機
            gameManager.grassPower = gameManager.grass.GetComponent<GrassPower>(); // GrassPowerを取得
        }
        else if (boolManager.ramdomNumber == 1)
        {
            SpawnGrass = Instantiate(wineGrass, spawnPoint.position, Quaternion.identity); // ワイングラスをスポーン

            yield return new WaitUntil(() => SpawnGrass != null); // スポーンが成功するまで待機

            gameManager.grass = SpawnGrass; // GameManagerにスポーンされたグラスを設定

            yield return new WaitUntil(() => gameManager.grass != null); // GameManagerがグラスを取得するまで待機
            gameManager.grassPower = gameManager.grass.GetComponent<GrassPower>(); // GrassPowerを取得
        }
        else if (boolManager.ramdomNumber == 2)
        {
            SpawnGrass = Instantiate(cakGrass, spawnPoint.position, Quaternion.identity); // カクテルグラスをスポーン

            yield return new WaitUntil(() => SpawnGrass != null); // スポーンが成功するまで待機

            gameManager.grass = SpawnGrass; // GameManagerにスポーンされたグラスを設定

            yield return new WaitUntil(() => gameManager.grass != null); // GameManagerがグラスを取得するまで待機
            gameManager.grassPower = gameManager.grass.GetComponent<GrassPower>(); // GrassPowerを取得
        }
    }
}
