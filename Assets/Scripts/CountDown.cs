using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    public Text countdownText;
    public float totalTime = 3f; // カウントダウンの合計時間
    public float goTextDuration = 1f; // "GO!" テキストの表示時間
    private float currentTime;

    void Start()
    {
       
        currentTime = totalTime;
        UpdateCountdownText();
        StartCoroutine(StartCountdown());
    }

    IEnumerator StartCountdown()
    {
        yield return new WaitForSeconds(1f);
        while (currentTime > 0)
        {
            yield return new WaitForSeconds(1f); // 1秒待つ
            currentTime -= 1f; // 時間を減らす
            SampleSoundManager.Instance.PlaySe(SeType.SE7);
            UpdateCountdownText();
        }

        countdownText.text = "擦れ!"; // カウントダウン終了時のテキスト

        yield return new WaitForSeconds(goTextDuration); // GO! を表示した後、指定した時間待つ

        // GO! テキストを非表示にする
        countdownText.enabled = false;
    }

    void UpdateCountdownText()
    {
        countdownText.text = Mathf.CeilToInt(currentTime).ToString(); // 残り時間を表示
    }
}
