using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DistanceDisplay : MonoBehaviour
{
    public GameObject object1; // �I�u�W�F�N�g1
    public GameObject object2; // �I�u�W�F�N�g2
    public Text distanceText; // ������\������e�L�X�g

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
        // �I�u�W�F�N�g�Ԃ̋������v�Z
        if (object2 != null)
        {
            float distance = Mathf.Abs((obj1Pos* 8) -( obj2Pos * 8) + 30);

            //Debug.Log(distance);
           

            // ��������ɕ\������
            distanceText.text = "���̐l�Ƃ̋����F" + distance.ToString("F2") + "cm"; // �����_�ȉ�2���܂ŕ\��
        }
    }
}
