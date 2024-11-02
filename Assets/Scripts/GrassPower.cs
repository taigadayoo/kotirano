using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassPower : MonoBehaviour
{
    // �O���X�̎�ނ��`����񋓌^
    public enum GrassName
    {
        rock, // ���b�N�^�C�v
        wine, // ���C���^�C�v
        cocktail // �J�N�e���^�C�v
    }

    // �p���[���x�����`����񋓌^
    public enum Power
    {
        one, // ���x��1�̃p���[
        two, // ���x��2�̃p���[
        max // �ő�p���[���x��
    }

    public float oneSpeed = 2.0f; // ���x��1�̑��x
    public float twoSpeed = 4.0f; // ���x��2�̑��x
    public float maxSpeed = 6.0f; // �ő�p���[�̑��x

    public bool Finish = false; // �����������������ǂ����������t���O

    [SerializeField]
    public Power power; // ���݂̃p���[���x��
    [SerializeField]
    public GrassName grassName; // ���݂̃O���X�̎��

    private float pulsPower = 0; // �Փː��Ɋ�Â��p���X�p���[
    BoolManager boolManager; // BoolManager�̃C���X�^���X
    CountCollider countCollider; // CountCollider�̃C���X�^���X

    private void Awake()
    {
        // BoolManager�̃C���X�^���X���擾
        boolManager = FindObjectOfType<BoolManager>();
    }

    void Start()
    {
        Finish = false; // Finish�t���O�����Z�b�g
        countCollider = FindObjectOfType<CountCollider>(); // CountCollider�̃C���X�^���X���擾

        // BoolManager�̃����_���l�Ɋ�Â��ăp���[������
        if (boolManager.randomPower == 0)
        {
            power = Power.one;
        }
        else if (boolManager.randomPower == 1)
        {
            power = Power.two;
        }
        else if (boolManager.randomPower == 2)
        {
            power = Power.max;
        }
    }

    // Update�̓t���[�����ƂɌĂяo�����
    void Update()
    {
        StartCoroutine(DireySlide()); // �X���C�h�R���[�`�����J�n

        // �X���C�h���J�n����邩�`�F�b�N
        if (countCollider.StartSlide == true)
        {
            // �O���X�̎�ނɉ����Ĉړ�
            if (grassName == GrassName.rock)
            {
                GrassRoockMove();
            }
            if (grassName == GrassName.wine)
            {
                WineGrassMove();
            }
            if (grassName == GrassName.cocktail)
            {
                CaktailGrassMove();
            }
            pulsPower = countCollider.collisionCount * 0.45f; // �Փː��Ɋ�Â��ăp���X�p���[���X�V
        }
    }

    // ���b�N�O���X�̈ړ�
    public void GrassRoockMove()
    {
        // �p���[���x���ɉ����Ĉړ�
        if (power == Power.one)
        {
            transform.Translate(Vector3.right * (oneSpeed - 1 + pulsPower) * Time.deltaTime);
        }
        if (power == Power.two)
        {
            transform.Translate(Vector3.right * (twoSpeed - 1 + pulsPower) * Time.deltaTime);
        }
        if (power == Power.max)
        {
            transform.Translate(Vector3.right * (maxSpeed - 1 + pulsPower) * Time.deltaTime);
        }
    }

    // ���C���O���X�̈ړ�
    public void WineGrassMove()
    {
        // �p���[���x���ɉ����Ĉړ�
        if (power == Power.one)
        {
            transform.Translate(Vector3.right * (oneSpeed + 1 + pulsPower) * Time.deltaTime);
        }
        if (power == Power.two)
        {
            transform.Translate(Vector3.right * (twoSpeed + 1 + pulsPower) * Time.deltaTime);
        }
        if (power == Power.max)
        {
            transform.Translate(Vector3.right * (maxSpeed + 1 + pulsPower) * Time.deltaTime);
        }
    }

    // �J�N�e���O���X�̈ړ�
    public void CaktailGrassMove()
    {
        // �p���[���x���ɉ����Ĉړ�
        if (power == Power.one)
        {
            transform.Translate(Vector3.right * (oneSpeed + 4 + pulsPower) * Time.deltaTime);
        }
        if (power == Power.two)
        {
            transform.Translate(Vector3.right * (twoSpeed + 4 + pulsPower) * Time.deltaTime);
        }
        if (power == Power.max)
        {
            transform.Translate(Vector3.right * (maxSpeed + 4 + pulsPower) * Time.deltaTime);
        }
    }

    // RedLine����̏Փˉ������̏���
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "RedLine")
        {
            Finish = true; // RedLine����o������Finish��true�ɐݒ�
        }
    }

    // �X���C�h�������s���R���[�`��
    IEnumerator DireySlide()
    {
        yield return new WaitForSeconds(4f); // 4�b�ҋ@
        countCollider.StartSlide = true; // �X���C�h�J�n������
    }
}
