using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    public Text countdownText;
    public float totalTime = 3f; // �J�E���g�_�E���̍��v����
    public float goTextDuration = 1f; // "GO!" �e�L�X�g�̕\������
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
            yield return new WaitForSeconds(1f); // 1�b�҂�
            currentTime -= 1f; // ���Ԃ����炷
            SampleSoundManager.Instance.PlaySe(SeType.SE7);
            UpdateCountdownText();
        }

        countdownText.text = "�C��!"; // �J�E���g�_�E���I�����̃e�L�X�g

        yield return new WaitForSeconds(goTextDuration); // GO! ��\��������A�w�肵�����ԑ҂�

        // GO! �e�L�X�g���\���ɂ���
        countdownText.enabled = false;
    }

    void UpdateCountdownText()
    {
        countdownText.text = Mathf.CeilToInt(currentTime).ToString(); // �c�莞�Ԃ�\��
    }
}
