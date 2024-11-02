using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceDisplay : MonoBehaviour
{
    public GameObject object1; // オブジェクト1
    public GameObject object2; // オブジェクト2
    public Text distanceText; // 距離を表示するテキスト

    private float obj2Pos = 0; // オブジェクト2の位置
    private float obj1Pos = 0; // オブジェクト1の位置
    GameManager gameManager; // GameManagerのインスタンスを保持

    // Startメソッドはゲームオブジェクトが有効になったときに呼び出される
    private void Start()
    {
        // GameManagerのインスタンスを取得
        gameManager = FindObjectOfType<GameManager>();
    }

    // Updateメソッドはフレームごとに呼び出される
    void Update()
    {
        // object1とobject2が両方存在する場合
        if (object1 != null && object2 != null)
        {
            // オブジェクトのX位置を取得
            obj2Pos = object2.transform.position.x;
            obj1Pos = object1.transform.position.x;
        }

        // object2がnullの場合、gameManagerからgrassを取得
        if (object2 == null)
        {
            object2 = gameManager.grass;
        }

        // オブジェクト間の距離を計算
        if (object2 != null)
        {
            // 距離を計算（スケールとオフセットを考慮）
            float distance = Mathf.Abs((obj1Pos * 8) - (obj2Pos * 8) + 30);

            // 距離をテキストに表示（小数点以下2桁まで表示）
            distanceText.text = "あの人との距離：" + distance.ToString("F2") + "cm";
        }
    }
}
