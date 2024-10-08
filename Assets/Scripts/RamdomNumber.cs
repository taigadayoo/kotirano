using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RamdomNumber : MonoBehaviour
{
    public float spinDuration = 3f; // スロットがスピンし続ける時間
    public GameObject[] images; // スロットの画像の配列
    public GameObject[] powerNamber;
    private int targetNumber; // スロットが止まるターゲットの番号
    public bool spinning = false; // スロットがスピン中かどうかを示すフラグ
    [SerializeField] private string sceneName;
    [SerializeField] private Color fadeColor;
    [SerializeField] private float fadeSpeed;

    BoolManager boolManager;

    public bool OneGrass = false;

    // Start is called before the first frame update
   
    private void Start()
    {

        boolManager = FindObjectOfType<BoolManager>();

        spinning = false;
            OneGrass = false;
        
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
        if (!OneGrass)
        {
            if (Input.GetKeyDown(KeyCode.Space) && !spinning)
            {
                SampleSoundManager.Instance.PlaySe(SeType.SE1);
                spinning = true;
               boolManager.ramdomNumber = Random.Range(0, images.Length);
                OneGrass = true;
                boolManager.randomPower = Random.Range(0, 3);
                Debug.Log(boolManager.ramdomNumber);
                Debug.Log(boolManager.randomPower);
                StartCoroutine(SpinSlot());
                StartCoroutine(SceneChange());
            }
        }
    }
    IEnumerator SpinSlot()
    {
        float spinTimer = 0f;
        while (spinTimer < spinDuration)
        {
            // ランダムに画像を表示
            foreach (GameObject image in images)
            {
                image.SetActive(false);
            }
            int randomIndex = Random.Range(0, images.Length);
            images[randomIndex].SetActive(true);

            spinTimer += Time.deltaTime;
            yield return null;
        }

        // ターゲット番号に到達したら止まる
        foreach (GameObject image in images)
        {
            image.SetActive(false);
        }
        images[boolManager.ramdomNumber].SetActive(true);

        yield return new WaitForSeconds(0.5f);
        RandomPower();
       
        spinning = false;
    }
    private IEnumerator SceneChange()
    {
        yield return new WaitForSeconds(6.5f);

        Initiate.Fade(sceneName, fadeColor, fadeSpeed);
    }
    private void RandomPower()
    {
        if(boolManager.randomPower == 0)
        {
            powerNamber[0].SetActive(true);
        }
        if (boolManager.randomPower == 1)
        {
            powerNamber[1].SetActive(true);
        }
        if (boolManager.randomPower == 2)
        {
            powerNamber[2].SetActive(true);
        }
    }
}
