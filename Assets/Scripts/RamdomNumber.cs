using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RamdomNumber : MonoBehaviour
{
    public float spinDuration = 3f; // スロットがスピンし続ける時間
    public GameObject[] images; // スロットの画像の配列
    public GameObject[] powerNamber; // 効果の画像の配列
    private int targetNumber; // スロットが止まるターゲットの番号
    public bool spinning = false; // スロットがスピン中かどうかを示すフラグ
    [SerializeField] private string sceneName; // 次のシーン名
    [SerializeField] private Color fadeColor; // フェード時の色
    [SerializeField] private float fadeSpeed; // フェード速度

    BoolManager boolManager; // BoolManagerのインスタンス

    public bool OneGrass = false; // 1回だけグラスを処理するためのフラグ

    // Start is called before the first frame update
    private void Start()
    {
        boolManager = FindObjectOfType<BoolManager>(); // BoolManagerのインスタンスを取得
        spinning = false; // スピン状態を初期化
        OneGrass = false; // 1回の処理フラグを初期化

        // 全ての画像を非表示にする
        foreach (GameObject image in images)
        {
            image.SetActive(false);
        }
        foreach (GameObject powerNam in powerNamber)
        {
            powerNam.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!OneGrass) // まだグラスの処理を行っていない場合
        {
            if (Input.GetKeyDown(KeyCode.Space) && !spinning) // スペースキーが押され、スピン中でない場合
            {
                SampleSoundManager.Instance.PlaySe(SeType.SE1); // 効果音を再生
                spinning = true; // スピン開始フラグを立てる
                boolManager.ramdomNumber = Random.Range(0, images.Length); // ランダムな画像番号を取得
                OneGrass = true; // グラス処理フラグを立てる
                boolManager.randomPower = Random.Range(0, 3); // ランダムなパワー番号を取得
                Debug.Log(boolManager.ramdomNumber); // ランダム番号をデバッグ出力
                Debug.Log(boolManager.randomPower); // ランダムパワーをデバッグ出力
                StartCoroutine(SpinSlot()); // スロットスピンのコルーチンを開始
                StartCoroutine(SceneChange()); // シーン変更のコルーチンを開始
            }
        }
    }

    IEnumerator SpinSlot()
    {
        float spinTimer = 0f; // スピンタイマーの初期化
        while (spinTimer < spinDuration) // スピン時間が経過するまでループ
        {
            // ランダムに画像を表示
            foreach (GameObject image in images)
            {
                image.SetActive(false); // 画像を非表示にする
            }
            int randomIndex = Random.Range(0, images.Length); // ランダムなインデックスを取得
            images[randomIndex].SetActive(true); // ランダムに選んだ画像を表示

            spinTimer += Time.deltaTime; // スピンタイマーを更新
            yield return null; // 次のフレームまで待機
        }

        // ターゲット番号に到達したら止まる
        foreach (GameObject image in images)
        {
            image.SetActive(false); // 画像を非表示にする
        }
        images[boolManager.ramdomNumber].SetActive(true); // ターゲット画像を表示

        yield return new WaitForSeconds(0.5f); // 0.5秒待機
        RandomPower(); // ランダムなパワーを処理

        spinning = false; // スピン状態をリセット
    }

    private IEnumerator SceneChange()
    {
        yield return new WaitForSeconds(6.5f); // 6.5秒待機
        Initiate.Fade(sceneName, fadeColor, fadeSpeed); // シーン遷移を実行
    }

    private void RandomPower()
    {
        // ランダムパワーに基づいて画像を表示
        if (boolManager.randomPower == 0)
        {
            powerNamber[0].SetActive(true); // パワー1を表示
        }
        else if (boolManager.randomPower == 1)
        {
            powerNamber[1].SetActive(true); // パワー2を表示
        }
        else if (boolManager.randomPower == 2)
        {
            powerNamber[2].SetActive(true); // パワー3を表示
        }
    }
}
