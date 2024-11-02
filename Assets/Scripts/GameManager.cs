using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance; // シングルトンパターン用のインスタンス
    public GameObject grass; // グラスオブジェクト
    [SerializeField]
    GameObject qupid; // キューピッドオブジェクト

    public GameObject push; // プッシュボタンオブジェクト
    GrassSpawn grassSpawn; // GrassSpawnインスタンス
    public GrassPower grassPower; // GrassPowerインスタンス
    CountCollider countCollider; // CountColliderインスタンス
    Scenemanager scenemanager; // SceneManagerインスタンス
    BoolManager boolManager; // BoolManagerインスタンス
    public bool OnCount = false; // カウント状態を管理

    RamdomNumber ramdomNumber; // ランダム番号を管理するオブジェクト

    // Startメソッドはゲームオブジェクトが有効になったときに呼び出される
    void Start()
    {
        StartCoroutine(TimeStop()); // 時間を停止するコルーチンを開始
        // 各種コンポーネントを取得
        grassSpawn = FindObjectOfType<GrassSpawn>();
        boolManager = FindObjectOfType<BoolManager>();
        countCollider = FindObjectOfType<CountCollider>();
        scenemanager = FindObjectOfType<Scenemanager>();

        // BoolManagerのフラグを初期化
        boolManager.isJust = false;
        boolManager.isOver = false;
        boolManager.isStop = false;
        boolManager.isRock = false;
        boolManager.isWine = false;
        boolManager.isCaktail = false;

        // SceneManagerのフラグを初期化
        scenemanager.OneClear = false;
        scenemanager.OneFade = false;
    }

    // Updateメソッドはフレームごとに呼び出される
    void Update()
    {
        // スペースキーが押された時に時間を再開
        if (Input.GetKeyDown(KeyCode.Space) && Time.timeScale == 0)
        {
            Time.timeScale = 1f; // 時間を通常に戻す
            push.SetActive(false); // プッシュボタンを非表示にする
        }

        // GrassPowerを取得
        grassPower = FindFirstObjectByType<GrassPower>();

        // グラスが存在する場合
        if (grass != null)
        {
            // グラスがキューピッドより右にあるかを判定
            if (grass.transform.position.x < qupid.transform.position.x)
            {
                OnCount = true; // カウントを有効にする
            }
            else
            {
                OnCount = false; // カウントを無効にする
            }

            // GrassPowerが終了したら判断を行う
            if (grassPower.Finish)
            {
                Judge(); // 判定メソッドを呼び出す
            }
        }
    }

    // 時間を停止するコルーチン
    IEnumerator TimeStop()
    {
        yield return new WaitForSeconds(1f); // 1秒待機
        Time.timeScale = 0; // 時間を停止
    }

public void Judge()
    {
        if(grassPower.grassName == GrassPower.GrassName.rock && grassPower.power == GrassPower.Power.one)
        {
            if(countCollider.collisionCount < 13)
            {
                scenemanager.GameResult();
               boolManager.isStop = true;
                boolManager.isRock = true;
            }
            if (countCollider.collisionCount >= 13 && countCollider.collisionCount <= 15)
            {
                scenemanager.GameResult();
               boolManager.isJust = true;
                boolManager.isRock = true;
            }
            if (countCollider.collisionCount > 15)
            {
                scenemanager.GameResult();
              boolManager.isOver = true;
                boolManager.isRock = true;
            }
        }
        if (grassPower.grassName == GrassPower.GrassName.rock && grassPower.power == GrassPower.Power.two)
        {
            if (countCollider.collisionCount < 11)
            {
                scenemanager.GameResult();
                boolManager.isStop = true;
                boolManager.isRock = true;
            }
            if (countCollider.collisionCount >= 11 && countCollider.collisionCount <= 13)
            {
                scenemanager.GameResult();
                boolManager.isJust = true;
                boolManager.isRock = true;
            }
            if (countCollider.collisionCount > 13)
            {
                scenemanager.GameResult();
                boolManager.isOver = true;
                boolManager.isRock = true;
            }
        }
        if (grassPower.grassName == GrassPower.GrassName.rock && grassPower.power == GrassPower.Power.max)
        {
            if (countCollider.collisionCount < 7)
            {
                scenemanager.GameResult();
                boolManager.isStop = true;
                boolManager.isRock = true;
            }
            if (countCollider.collisionCount >= 7 && countCollider.collisionCount <= 9)
            {
                scenemanager.GameResult();
                boolManager.isJust = true;
                boolManager.isRock = true;
            }
            if (countCollider.collisionCount > 9)
            {
                scenemanager.GameResult();
                boolManager.isOver = true;
                boolManager.isRock = true;
            }
        }
        if (grassPower.grassName == GrassPower.GrassName.wine && grassPower.power == GrassPower.Power.one)
        {
            if (countCollider.collisionCount < 9)
            {
                scenemanager.GameResult();
                boolManager.isStop = true;
                boolManager.isWine = true;
            }
            if (countCollider.collisionCount >= 9 && countCollider.collisionCount <= 11)
            {
                scenemanager.GameResult();
                boolManager.isJust = true;
                boolManager.isWine = true;
            }
            if (countCollider.collisionCount > 11)
            {
                scenemanager.GameResult();
                boolManager.isOver = true;
                boolManager.isWine = true;
            }
        }
        if (grassPower.grassName == GrassPower.GrassName.wine && grassPower.power == GrassPower.Power.two)
        {
            if (countCollider.collisionCount < 7)
            {
                scenemanager.GameResult();
                boolManager.isStop = true;
                boolManager.isWine = true;
            }
            if (countCollider.collisionCount >= 7 && countCollider.collisionCount <= 9)
            {
                scenemanager.GameResult();
                boolManager.isJust = true;
                boolManager.isWine = true;
            }
            if (countCollider.collisionCount > 9)
            {
                scenemanager.GameResult();
                boolManager.isOver = true;
                boolManager.isWine = true;
            }
        }
        if (grassPower.grassName == GrassPower.GrassName.wine && grassPower.power == GrassPower.Power.max)
        {
            if (countCollider.collisionCount < 5)
            {
                scenemanager.GameResult();
                boolManager.isStop = true;
                boolManager.isWine = true;
            }
            if (countCollider.collisionCount >= 5 && countCollider.collisionCount <= 7)
            {
                scenemanager.GameResult();
                boolManager.isJust = true;
                boolManager.isWine = true;
            }
            if (countCollider.collisionCount > 7)
            {
                scenemanager.GameResult();
                boolManager.isOver = true;
                boolManager.isWine = true;
            }
        }
        if (grassPower.grassName == GrassPower.GrassName.cocktail && grassPower.power == GrassPower.Power.one)
        {
            if (countCollider.collisionCount < 4)
            {
                scenemanager.GameResult();
                boolManager.isStop = true;
                boolManager.isCaktail = true;
            }
            if (countCollider.collisionCount >= 4 && countCollider.collisionCount <= 6)
            {
                scenemanager.GameResult();
                boolManager.isJust = true;
                boolManager.isCaktail = true;
            }
            if (countCollider.collisionCount > 6)
            {
               
                scenemanager.GameResult();
                boolManager.isOver = true;
                boolManager.isCaktail = true;
            }
        }
        if (grassPower.grassName == GrassPower.GrassName.cocktail && grassPower.power == GrassPower.Power.two)
        {
            if (countCollider.collisionCount < 3)
            {
                scenemanager.GameResult();
                boolManager.isStop = true;
                boolManager.isCaktail = true;
            }
            if (countCollider.collisionCount >= 3 && countCollider.collisionCount <= 5)
            {
                scenemanager.GameResult();
                boolManager.isJust = true;
                boolManager.isCaktail = true;
            }
            if (countCollider.collisionCount > 5)
            {

                scenemanager.GameResult();
                boolManager.isOver = true;
                boolManager.isCaktail = true;
            }
        }
        if (grassPower.grassName == GrassPower.GrassName.cocktail && grassPower.power == GrassPower.Power.max)
        {
            if (countCollider.collisionCount < 2)
            {
                scenemanager.GameResult();
                boolManager.isStop = true;
                boolManager.isCaktail = true;
            }
            if (countCollider.collisionCount >= 2 && countCollider.collisionCount <= 4)
            {
                scenemanager.GameResult();
                boolManager.isJust = true;
                boolManager.isCaktail = true;
            }
            if (countCollider.collisionCount > 4)
            {

                scenemanager.GameResult();
                boolManager.isOver = true;
                boolManager.isCaktail = true;
            }
        }
    }
}
