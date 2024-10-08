using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class NumberAnim : MonoBehaviour
{
    public float FadeDuration = 0.5f; // �t�F�[�h�C���̎���

    public float duration = 1.0f; // ���k�̎���
    public Vector3 targetScale = new Vector3(1f, 1f, 1f);

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        // SpriteRenderer�R���|�[�l���g���擾
        spriteRenderer = GetComponent<SpriteRenderer>();

        // �����̃A���t�@�l��0�ɐݒ�i���S�ɓ����j
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
        // �t�F�[�h�C���i�A���t�@�l��1�ɕύX�j
        spriteRenderer.DOFade(1, FadeDuration);
    }
    void ShrinkObject()
    {
        // ���k�i�X�P�[����targetScale�ɕύX�j
        transform.DOScale(targetScale, duration);
    }
}

