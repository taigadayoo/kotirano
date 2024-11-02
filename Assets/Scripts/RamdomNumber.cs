using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RamdomNumber : MonoBehaviour
{
    public float spinDuration = 3f; // �X���b�g���X�s���������鎞��
    public GameObject[] images; // �X���b�g�̉摜�̔z��
    public GameObject[] powerNamber; // ���ʂ̉摜�̔z��
    private int targetNumber; // �X���b�g���~�܂�^�[�Q�b�g�̔ԍ�
    public bool spinning = false; // �X���b�g���X�s�������ǂ����������t���O
    [SerializeField] private string sceneName; // ���̃V�[����
    [SerializeField] private Color fadeColor; // �t�F�[�h���̐F
    [SerializeField] private float fadeSpeed; // �t�F�[�h���x

    BoolManager boolManager; // BoolManager�̃C���X�^���X

    public bool OneGrass = false; // 1�񂾂��O���X���������邽�߂̃t���O

    // Start is called before the first frame update
    private void Start()
    {
        boolManager = FindObjectOfType<BoolManager>(); // BoolManager�̃C���X�^���X���擾
        spinning = false; // �X�s����Ԃ�������
        OneGrass = false; // 1��̏����t���O��������

        // �S�Ẳ摜���\���ɂ���
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
        if (!OneGrass) // �܂��O���X�̏������s���Ă��Ȃ��ꍇ
        {
            if (Input.GetKeyDown(KeyCode.Space) && !spinning) // �X�y�[�X�L�[��������A�X�s�����łȂ��ꍇ
            {
                SampleSoundManager.Instance.PlaySe(SeType.SE1); // ���ʉ����Đ�
                spinning = true; // �X�s���J�n�t���O�𗧂Ă�
                boolManager.ramdomNumber = Random.Range(0, images.Length); // �����_���ȉ摜�ԍ����擾
                OneGrass = true; // �O���X�����t���O�𗧂Ă�
                boolManager.randomPower = Random.Range(0, 3); // �����_���ȃp���[�ԍ����擾
                Debug.Log(boolManager.ramdomNumber); // �����_���ԍ����f�o�b�O�o��
                Debug.Log(boolManager.randomPower); // �����_���p���[���f�o�b�O�o��
                StartCoroutine(SpinSlot()); // �X���b�g�X�s���̃R���[�`�����J�n
                StartCoroutine(SceneChange()); // �V�[���ύX�̃R���[�`�����J�n
            }
        }
    }

    IEnumerator SpinSlot()
    {
        float spinTimer = 0f; // �X�s���^�C�}�[�̏�����
        while (spinTimer < spinDuration) // �X�s�����Ԃ��o�߂���܂Ń��[�v
        {
            // �����_���ɉ摜��\��
            foreach (GameObject image in images)
            {
                image.SetActive(false); // �摜���\���ɂ���
            }
            int randomIndex = Random.Range(0, images.Length); // �����_���ȃC���f�b�N�X���擾
            images[randomIndex].SetActive(true); // �����_���ɑI�񂾉摜��\��

            spinTimer += Time.deltaTime; // �X�s���^�C�}�[���X�V
            yield return null; // ���̃t���[���܂őҋ@
        }

        // �^�[�Q�b�g�ԍ��ɓ��B������~�܂�
        foreach (GameObject image in images)
        {
            image.SetActive(false); // �摜���\���ɂ���
        }
        images[boolManager.ramdomNumber].SetActive(true); // �^�[�Q�b�g�摜��\��

        yield return new WaitForSeconds(0.5f); // 0.5�b�ҋ@
        RandomPower(); // �����_���ȃp���[������

        spinning = false; // �X�s����Ԃ����Z�b�g
    }

    private IEnumerator SceneChange()
    {
        yield return new WaitForSeconds(6.5f); // 6.5�b�ҋ@
        Initiate.Fade(sceneName, fadeColor, fadeSpeed); // �V�[���J�ڂ����s
    }

    private void RandomPower()
    {
        // �����_���p���[�Ɋ�Â��ĉ摜��\��
        if (boolManager.randomPower == 0)
        {
            powerNamber[0].SetActive(true); // �p���[1��\��
        }
        else if (boolManager.randomPower == 1)
        {
            powerNamber[1].SetActive(true); // �p���[2��\��
        }
        else if (boolManager.randomPower == 2)
        {
            powerNamber[2].SetActive(true); // �p���[3��\��
        }
    }
}
