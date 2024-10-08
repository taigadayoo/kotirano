using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupidMove : MonoBehaviour
{
    private bool isDragging = false; // �I�u�W�F�N�g���h���b�O����Ă��邩�ǂ����������t���O
    private Vector3 offset; // �h���b�O�J�n���̃}�E�X�J�[�\���ƃI�u�W�F�N�g�̑��Έʒu

    void Update()
    {
        // �N���b�N�����u�ԂɃh���b�O���J�n����
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                isDragging = true;
                offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
        }

        // �N���b�N�𗣂��ƃh���b�O���~����
        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

        // �h���b�O���̓I�u�W�F�N�g���}�E�X�J�[�\���̈ʒu�ɒǏ]������
        if (isDragging)
        {
            Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
            transform.position = cursorPosition;
        }
    }
}
