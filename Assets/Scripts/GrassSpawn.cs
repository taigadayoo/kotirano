using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassSpawn : MonoBehaviour
{
    public GameObject rockGrass; // ���b�N�O���X�̃v���n�u
    public GameObject wineGrass; // ���C���O���X�̃v���n�u
    public GameObject cakGrass; // �J�N�e���O���X�̃v���n�u
    public Transform spawnPoint; // �X�|�[���ʒu
    public bool OneFinish = false; // 1�ڂ̃X�p�E�������t���O

    RamdomNumber ramdomNumber; // �����_���ԍ��Ǘ��N���X
    BoolManager boolManager; // BoolManager�̃C���X�^���X
    private bool OneSpawn = false; // ��x�����X�p�E�����邽�߂̃t���O
    public GameObject SpawnGrass; // �X�|�[�����ꂽ�O���X�̃C���X�^���X
    GameManager gameManager; // �Q�[���Ǘ��N���X

    void Start()
    {
        // BoolManager��GameManager�̃C���X�^���X���擾
        boolManager = FindObjectOfType<BoolManager>();
        gameManager = FindObjectOfType<GameManager>();
        ramdomNumber = GameObject.FindObjectOfType<RamdomNumber>();

        // �����_���X�|�[���̃R���[�`�����J�n
        StartCoroutine(RamdomSpawn());
    }



    IEnumerator RamdomSpawn()
    {
        // BoolManager�̃����_���ԍ��ɉ����ăX�|�[������O���X������
        if (boolManager.ramdomNumber == 0)
        {
            SpawnGrass = Instantiate(rockGrass, spawnPoint.position, Quaternion.identity); // ���b�N�O���X���X�|�[��

            yield return new WaitUntil(() => SpawnGrass != null); // �X�|�[������������܂őҋ@

            gameManager.grass = SpawnGrass; // GameManager�ɃX�|�[�����ꂽ�O���X��ݒ�

            yield return new WaitUntil(() => gameManager.grass != null); // GameManager���O���X���擾����܂őҋ@
            gameManager.grassPower = gameManager.grass.GetComponent<GrassPower>(); // GrassPower���擾
        }
        else if (boolManager.ramdomNumber == 1)
        {
            SpawnGrass = Instantiate(wineGrass, spawnPoint.position, Quaternion.identity); // ���C���O���X���X�|�[��

            yield return new WaitUntil(() => SpawnGrass != null); // �X�|�[������������܂őҋ@

            gameManager.grass = SpawnGrass; // GameManager�ɃX�|�[�����ꂽ�O���X��ݒ�

            yield return new WaitUntil(() => gameManager.grass != null); // GameManager���O���X���擾����܂őҋ@
            gameManager.grassPower = gameManager.grass.GetComponent<GrassPower>(); // GrassPower���擾
        }
        else if (boolManager.ramdomNumber == 2)
        {
            SpawnGrass = Instantiate(cakGrass, spawnPoint.position, Quaternion.identity); // �J�N�e���O���X���X�|�[��

            yield return new WaitUntil(() => SpawnGrass != null); // �X�|�[������������܂őҋ@

            gameManager.grass = SpawnGrass; // GameManager�ɃX�|�[�����ꂽ�O���X��ݒ�

            yield return new WaitUntil(() => gameManager.grass != null); // GameManager���O���X���擾����܂őҋ@
            gameManager.grassPower = gameManager.grass.GetComponent<GrassPower>(); // GrassPower���擾
        }
    }
}
