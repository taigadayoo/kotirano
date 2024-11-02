using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceDisplay : MonoBehaviour
{
    public GameObject object1; // �I�u�W�F�N�g1
    public GameObject object2; // �I�u�W�F�N�g2
    public Text distanceText; // ������\������e�L�X�g

    private float obj2Pos = 0; // �I�u�W�F�N�g2�̈ʒu
    private float obj1Pos = 0; // �I�u�W�F�N�g1�̈ʒu
    GameManager gameManager; // GameManager�̃C���X�^���X��ێ�

    // Start���\�b�h�̓Q�[���I�u�W�F�N�g���L���ɂȂ����Ƃ��ɌĂяo�����
    private void Start()
    {
        // GameManager�̃C���X�^���X���擾
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update���\�b�h�̓t���[�����ƂɌĂяo�����
    void Update()
    {
        // object1��object2���������݂���ꍇ
        if (object1 != null && object2 != null)
        {
            // �I�u�W�F�N�g��X�ʒu���擾
            obj2Pos = object2.transform.position.x;
            obj1Pos = object1.transform.position.x;
        }

        // object2��null�̏ꍇ�AgameManager����grass���擾
        if (object2 == null)
        {
            object2 = gameManager.grass;
        }

        // �I�u�W�F�N�g�Ԃ̋������v�Z
        if (object2 != null)
        {
            // �������v�Z�i�X�P�[���ƃI�t�Z�b�g���l���j
            float distance = Mathf.Abs((obj1Pos * 8) - (obj2Pos * 8) + 30);

            // �������e�L�X�g�ɕ\���i�����_�ȉ�2���܂ŕ\���j
            distanceText.text = "���̐l�Ƃ̋����F" + distance.ToString("F2") + "cm";
        }
    }
}
