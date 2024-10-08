using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class NumberAnim : MonoBehaviour
{
    public float FadeDuration = 0.5f; // フェードインの時間

    public float duration = 1.0f; // 収縮の時間
    public Vector3 targetScale = new Vector3(1f, 1f, 1f);

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        // SpriteRendererコンポーネントを取得
        spriteRenderer = GetComponent<SpriteRenderer>();

        // 初期のアルファ値を0に設定（完全に透明）
        Color color = spriteRenderer.color;
        color.a = 0;
        spriteRenderer.color = color;
        SampleSoundManager.Instance.PlaySe(SeType.SE8);
        StartCoroutine(NumberAnimation());
    }
    IEnumerator NumberAnimation()
    {
      
        FadeInSprite();

        yield return new WaitForSeconds(0.1f);

        ShrinkObject();
    }
    void FadeInSprite()
    {
        // フェードイン（アルファ値を1に変更）
        spriteRenderer.DOFade(1, FadeDuration);
    }
    void ShrinkObject()
    {
        // 収縮（スケールをtargetScaleに変更）
        transform.DOScale(targetScale, duration);
    }
}

