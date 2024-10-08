using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DistanceDisplay : MonoBehaviour
{
    public GameObject object1; // オブジェクト1
    public GameObject object2; // オブジェクト2
    public Text distanceText; // 距離を表示するテキスト

    private float obj2Pos = 0;
    private float obj1Pos = 0;
    GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

       
    }
    void Update()
    {
       
        if (object1 != null && object2 != null)
        {
            obj2Pos = object2.transform.position.x;
        
            obj1Pos = object1.transform.position.x;
        }
        if (object2 == null)
        {
            object2 = gameManager.grass;
        }
        // オブジェクト間の距離を計算
        if (object2 != null)
        {
            float distance = Mathf.Abs((obj1Pos* 8) -( obj2Pos * 8) + 30);

            //Debug.Log(distance);
           

            // 距離を上に表示する
            distanceText.text = "あの人との距離：" + distance.ToString("F2") + "cm"; // 小数点以下2桁まで表示
        }
    }
}
