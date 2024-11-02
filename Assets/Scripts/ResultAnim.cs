using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ResultAnim : MonoBehaviour
{
    BoolManager boolManager; // BoolManager�̃C���X�^���X
    Scenemanager scenemanager; // SceneManager�̃C���X�^���X
    private bool OneMove = false; // �A�j���[�V��������x�������s�����悤�ɂ���t���O

    [SerializeField]
    SpriteRenderer spriteRenderer; // �X�v���C�g��`�悷�邽�߂�SpriteRenderer

    [SerializeField]
    Sprite rock; // ��̃X�v���C�g
    [SerializeField]
    Sprite wine; // ���C���̃X�v���C�g
    [SerializeField]
    Sprite caktail; // �J�N�e���̃X�v���C�g

    // Start is called before the first frame update
    void Start()
    {
        // BoolManager��SceneManager��������
        boolManager = FindObjectOfType<BoolManager>();
        scenemanager = FindObjectOfType<Scenemanager>();
    }

    // Update is called once per frame
    void Update()
    {
        // BoolManager�����݂��A�A�j���[�V�������܂����s����Ă��Ȃ��ꍇ
        if (boolManager != null && OneMove == false)
        {
            // ��~��Ԃ̏���
            if (boolManager.isStop)
            {
                // �X�v���C�g����ɐݒ�
                if (boolManager.isRock)
                {
                    spriteRenderer.sprite = rock;
                }
                // �X�v���C�g�����C���ɐݒ�
                if (boolManager.isWine)
                {
                    spriteRenderer.sprite = wine;
                }
                // �X�v���C�g���J�N�e���ɐݒ�
                if (boolManager.isCaktail)
                {
                    spriteRenderer.sprite = caktail;
                }
                // �ʒu���ړ�������
                this.transform.DOMove(new Vector3(3.83f, -0.8f, 0f), 2f);
                OneMove = true; // �A�j���[�V���������s���ꂽ���Ƃ��L�^
                StartCoroutine(GameOver()); // �Q�[���I�[�o�[�̏������J�n
                StartCoroutine(isStopAnim()); // ��~�A�j���[�V�����̃T�E���h���J�n
            }
            // �m�F��Ԃ̏���
            if (boolManager.isJust)
            {
                if (boolManager.isRock)
                {
                    spriteRenderer.sprite = rock;
                }
                if (boolManager.isWine)
                {
                    spriteRenderer.sprite = wine;
                }
                if (boolManager.isCaktail)
                {
                    spriteRenderer.sprite = caktail;
                }
                this.transform.DOMove(new Vector3(6.54f, -0.8f, 0f), 2.5f);
                OneMove = true;
                StartCoroutine(Clear()); // �Q�[���N���A�̏������J�n
                StartCoroutine(isJustAnim()); // �m�F�A�j���[�V�����̃T�E���h���J�n
            }
            // �I����Ԃ̏���
            if (boolManager.isOver)
            {
                if (boolManager.isRock)
                {
                    spriteRenderer.sprite = rock;
                }
                if (boolManager.isWine)
                {
                    spriteRenderer.sprite = wine;
                }
                if (boolManager.isCaktail)
                {
                    spriteRenderer.sprite = caktail;
                }
                this.transform.DOMove(new Vector3(13f, -0.8f, 0f), 2.5f);
                OneMove = true;
                StartCoroutine(GameOver()); // �Q�[���I�[�o�[�̏������J�n
                StartCoroutine(IsOverAnim()); // �I���A�j���[�V�����̃T�E���h���J�n
            }
        }
    }

    // �m�F��Ԃ̃A�j���[�V����
    IEnumerator isJustAnim()
    {
        yield return new WaitForSeconds(1.5f); // 1.5�b�҂�
        SampleSoundManager.Instance.PlaySe(SeType.SE5); // �T�E���h���Đ�
    }

    // �I����Ԃ̃A�j���[�V����
    IEnumerator IsOverAnim()
    {
        yield return new WaitForSeconds(1f); // 1�b�҂�
        SampleSoundManager.Instance.PlaySe(SeType.SE3); // �T�E���h���Đ�
        yield return new WaitForSeconds(1f); // 1�b�҂�
        SampleSoundManager.Instance.PlaySe(SeType.SE4); // �T�E���h���Đ�
    }

    // ��~��Ԃ̃A�j���[�V����
    IEnumerator isStopAnim()
    {
        yield return new WaitForSeconds(1f); // 1�b�҂�
        SampleSoundManager.Instance.PlaySe(SeType.SE6); // �T�E���h���Đ�
    }

    // �Q�[���I�[�o�[�̏���
    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(3.5f); // 3.5�b�҂�
        scenemanager.GameOver(); // �Q�[���I�[�o�[���Ăяo��
    }

    // �Q�[���N���A�̏���
    IEnumerator Clear()
    {
        yield return new WaitForSeconds(3f); // 3�b�҂�
        scenemanager.GameClear(); // �Q�[���N���A���Ăяo��
    }
}
