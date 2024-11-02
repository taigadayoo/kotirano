using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountCollider : MonoBehaviour
{
    // �R���C�_�[1�ɏՓ˂������ǂ����̃t���O
    private bool collidedWithCollider1 = false;
    // �R���C�_�[2�ɏՓ˂������ǂ����̃t���O
    private bool collidedWithCollider2 = false;
    // �Փˉ񐔂��J�E���g����ϐ�
    public int collisionCount = 0;

    // �X���C�h���J�n���邩�ǂ����̃t���O
    public bool StartSlide = false;
    // GameManager�̃C���X�^���X��ێ����邽�߂̃t�B�[���h
    GameManager gameManager;

    // Start���\�b�h�̓Q�[���I�u�W�F�N�g���L���ɂȂ����Ƃ��ɌĂяo�����
    private void Start()
    {
        // GameManager�̃C���X�^���X���擾
        gameManager = FindObjectOfType<GameManager>();
    }

    // �g���K�[�R���C�_�[�ɓ������Ƃ��ɌĂяo�����
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �Q�[���}�l�[�W���[���J�E���g��L���ɂ��Ă���ꍇ
        if (gameManager.OnCount)
        {
            // Collider1�ɏՓ˂����ꍇ
            if (collision.gameObject.tag == "Collider1")
            {
                // ���ʉ����Đ�
                SampleSoundManager.Instance.PlaySe(SeType.SE2);
                // Collider1�ɏ��߂ē��������ꍇ
                if (!collidedWithCollider1 && StartSlide)
                {
                    // �t���O��ݒ�
                    collidedWithCollider1 = true;
                    collidedWithCollider2 = false; // Collider1�ɓ��������Ƃ���Collider2�̏�Ԃ����Z�b�g
                    collisionCount++; // �J�E���g�𑝂₷
                    // ���݂̃J�E���g���f�o�b�O�o��
                    Debug.Log("Collision Count: " + collisionCount);
                }
            }
            // Collider2�ɏՓ˂����ꍇ
            else if (collision.gameObject.tag == "Collider2")
            {
                // ���ʉ����Đ�
                SampleSoundManager.Instance.PlaySe(SeType.SE2);
                // Collider2�ɏ��߂ē��������ꍇ
                if (!collidedWithCollider2 && StartSlide)
                {
                    // �t���O��ݒ�
                    collidedWithCollider2 = true;
                    collidedWithCollider1 = false; // Collider2�ɓ��������Ƃ���Collider1�̏�Ԃ����Z�b�g
                }
            }
        }
    }
}
