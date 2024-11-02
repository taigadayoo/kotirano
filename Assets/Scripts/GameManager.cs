using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance; // �V���O���g���p�^�[���p�̃C���X�^���X
    public GameObject grass; // �O���X�I�u�W�F�N�g
    [SerializeField]
    GameObject qupid; // �L���[�s�b�h�I�u�W�F�N�g

    public GameObject push; // �v�b�V���{�^���I�u�W�F�N�g
    GrassSpawn grassSpawn; // GrassSpawn�C���X�^���X
    public GrassPower grassPower; // GrassPower�C���X�^���X
    CountCollider countCollider; // CountCollider�C���X�^���X
    Scenemanager scenemanager; // SceneManager�C���X�^���X
    BoolManager boolManager; // BoolManager�C���X�^���X
    public bool OnCount = false; // �J�E���g��Ԃ��Ǘ�

    RamdomNumber ramdomNumber; // �����_���ԍ����Ǘ�����I�u�W�F�N�g

    // Start���\�b�h�̓Q�[���I�u�W�F�N�g���L���ɂȂ����Ƃ��ɌĂяo�����
    void Start()
    {
        StartCoroutine(TimeStop()); // ���Ԃ��~����R���[�`�����J�n
        // �e��R���|�[�l���g���擾
        grassSpawn = FindObjectOfType<GrassSpawn>();
        boolManager = FindObjectOfType<BoolManager>();
        countCollider = FindObjectOfType<CountCollider>();
        scenemanager = FindObjectOfType<Scenemanager>();

        // BoolManager�̃t���O��������
        boolManager.isJust = false;
        boolManager.isOver = false;
        boolManager.isStop = false;
        boolManager.isRock = false;
        boolManager.isWine = false;
        boolManager.isCaktail = false;

        // SceneManager�̃t���O��������
        scenemanager.OneClear = false;
        scenemanager.OneFade = false;
    }

    // Update���\�b�h�̓t���[�����ƂɌĂяo�����
    void Update()
    {
        // �X�y�[�X�L�[�������ꂽ���Ɏ��Ԃ��ĊJ
        if (Input.GetKeyDown(KeyCode.Space) && Time.timeScale == 0)
        {
            Time.timeScale = 1f; // ���Ԃ�ʏ�ɖ߂�
            push.SetActive(false); // �v�b�V���{�^�����\���ɂ���
        }

        // GrassPower���擾
        grassPower = FindFirstObjectByType<GrassPower>();

        // �O���X�����݂���ꍇ
        if (grass != null)
        {
            // �O���X���L���[�s�b�h���E�ɂ��邩�𔻒�
            if (grass.transform.position.x < qupid.transform.position.x)
            {
                OnCount = true; // �J�E���g��L���ɂ���
            }
            else
            {
                OnCount = false; // �J�E���g�𖳌��ɂ���
            }

            // GrassPower���I�������画�f���s��
            if (grassPower.Finish)
            {
                Judge(); // ���胁�\�b�h���Ăяo��
            }
        }
    }

    // ���Ԃ��~����R���[�`��
    IEnumerator TimeStop()
    {
        yield return new WaitForSeconds(1f); // 1�b�ҋ@
        Time.timeScale = 0; // ���Ԃ��~
    }

public void Judge()
    {
        if(grassPower.grassName == GrassPower.GrassName.rock && grassPower.power == GrassPower.Power.one)
        {
            if(countCollider.collisionCount < 13)
            {
                scenemanager.GameResult();
               boolManager.isStop = true;
                boolManager.isRock = true;
            }
            if (countCollider.collisionCount >= 13 && countCollider.collisionCount <= 15)
            {
                scenemanager.GameResult();
               boolManager.isJust = true;
                boolManager.isRock = true;
            }
            if (countCollider.collisionCount > 15)
            {
                scenemanager.GameResult();
              boolManager.isOver = true;
                boolManager.isRock = true;
            }
        }
        if (grassPower.grassName == GrassPower.GrassName.rock && grassPower.power == GrassPower.Power.two)
        {
            if (countCollider.collisionCount < 11)
            {
                scenemanager.GameResult();
                boolManager.isStop = true;
                boolManager.isRock = true;
            }
            if (countCollider.collisionCount >= 11 && countCollider.collisionCount <= 13)
            {
                scenemanager.GameResult();
                boolManager.isJust = true;
                boolManager.isRock = true;
            }
            if (countCollider.collisionCount > 13)
            {
                scenemanager.GameResult();
                boolManager.isOver = true;
                boolManager.isRock = true;
            }
        }
        if (grassPower.grassName == GrassPower.GrassName.rock && grassPower.power == GrassPower.Power.max)
        {
            if (countCollider.collisionCount < 7)
            {
                scenemanager.GameResult();
                boolManager.isStop = true;
                boolManager.isRock = true;
            }
            if (countCollider.collisionCount >= 7 && countCollider.collisionCount <= 9)
            {
                scenemanager.GameResult();
                boolManager.isJust = true;
                boolManager.isRock = true;
            }
            if (countCollider.collisionCount > 9)
            {
                scenemanager.GameResult();
                boolManager.isOver = true;
                boolManager.isRock = true;
            }
        }
        if (grassPower.grassName == GrassPower.GrassName.wine && grassPower.power == GrassPower.Power.one)
        {
            if (countCollider.collisionCount < 9)
            {
                scenemanager.GameResult();
                boolManager.isStop = true;
                boolManager.isWine = true;
            }
            if (countCollider.collisionCount >= 9 && countCollider.collisionCount <= 11)
            {
                scenemanager.GameResult();
                boolManager.isJust = true;
                boolManager.isWine = true;
            }
            if (countCollider.collisionCount > 11)
            {
                scenemanager.GameResult();
                boolManager.isOver = true;
                boolManager.isWine = true;
            }
        }
        if (grassPower.grassName == GrassPower.GrassName.wine && grassPower.power == GrassPower.Power.two)
        {
            if (countCollider.collisionCount < 7)
            {
                scenemanager.GameResult();
                boolManager.isStop = true;
                boolManager.isWine = true;
            }
            if (countCollider.collisionCount >= 7 && countCollider.collisionCount <= 9)
            {
                scenemanager.GameResult();
                boolManager.isJust = true;
                boolManager.isWine = true;
            }
            if (countCollider.collisionCount > 9)
            {
                scenemanager.GameResult();
                boolManager.isOver = true;
                boolManager.isWine = true;
            }
        }
        if (grassPower.grassName == GrassPower.GrassName.wine && grassPower.power == GrassPower.Power.max)
        {
            if (countCollider.collisionCount < 5)
            {
                scenemanager.GameResult();
                boolManager.isStop = true;
                boolManager.isWine = true;
            }
            if (countCollider.collisionCount >= 5 && countCollider.collisionCount <= 7)
            {
                scenemanager.GameResult();
                boolManager.isJust = true;
                boolManager.isWine = true;
            }
            if (countCollider.collisionCount > 7)
            {
                scenemanager.GameResult();
                boolManager.isOver = true;
                boolManager.isWine = true;
            }
        }
        if (grassPower.grassName == GrassPower.GrassName.cocktail && grassPower.power == GrassPower.Power.one)
        {
            if (countCollider.collisionCount < 4)
            {
                scenemanager.GameResult();
                boolManager.isStop = true;
                boolManager.isCaktail = true;
            }
            if (countCollider.collisionCount >= 4 && countCollider.collisionCount <= 6)
            {
                scenemanager.GameResult();
                boolManager.isJust = true;
                boolManager.isCaktail = true;
            }
            if (countCollider.collisionCount > 6)
            {
               
                scenemanager.GameResult();
                boolManager.isOver = true;
                boolManager.isCaktail = true;
            }
        }
        if (grassPower.grassName == GrassPower.GrassName.cocktail && grassPower.power == GrassPower.Power.two)
        {
            if (countCollider.collisionCount < 3)
            {
                scenemanager.GameResult();
                boolManager.isStop = true;
                boolManager.isCaktail = true;
            }
            if (countCollider.collisionCount >= 3 && countCollider.collisionCount <= 5)
            {
                scenemanager.GameResult();
                boolManager.isJust = true;
                boolManager.isCaktail = true;
            }
            if (countCollider.collisionCount > 5)
            {

                scenemanager.GameResult();
                boolManager.isOver = true;
                boolManager.isCaktail = true;
            }
        }
        if (grassPower.grassName == GrassPower.GrassName.cocktail && grassPower.power == GrassPower.Power.max)
        {
            if (countCollider.collisionCount < 2)
            {
                scenemanager.GameResult();
                boolManager.isStop = true;
                boolManager.isCaktail = true;
            }
            if (countCollider.collisionCount >= 2 && countCollider.collisionCount <= 4)
            {
                scenemanager.GameResult();
                boolManager.isJust = true;
                boolManager.isCaktail = true;
            }
            if (countCollider.collisionCount > 4)
            {

                scenemanager.GameResult();
                boolManager.isOver = true;
                boolManager.isCaktail = true;
            }
        }
    }
}
