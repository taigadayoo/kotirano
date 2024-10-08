using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    private static GameManager instance;
    public GameObject grass;
    [SerializeField]
    GameObject qupid;

    public GameObject push;
    GrassSpawn grassSpawn;
   public GrassPower grassPower;
    CountCollider countCollider;
    Scenemanager scenemanager;
    BoolManager boolManager;
    public bool OnCount = false;

    RamdomNumber ramdomNumber;

   
    void Start()
    {
        StartCoroutine(TimeStop());
        grassSpawn = FindObjectOfType<GrassSpawn>();
        boolManager = FindObjectOfType<BoolManager>();
        countCollider = FindObjectOfType<CountCollider>();
        scenemanager = FindObjectOfType<Scenemanager>();
        boolManager.isJust = false;
        boolManager.isOver = false;
        boolManager.isStop = false;
        
        boolManager.isRock = false;
        boolManager.isWine = false;
        boolManager.isCaktail = false;

        scenemanager.OneClear = false;
        scenemanager.OneFade = false;
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.Space) && Time.timeScale == 0)
        {
            Time.timeScale = 1f;
            push.SetActive(false);
        }
        grassPower = FindFirstObjectByType<GrassPower>();
        if (grass != null)
        {
           
            if (grass.transform.position.x < qupid.transform.position.x)
            {
                OnCount = true; //グラスがキューピッドより右にあるかを判定
            }
            else
            {
                OnCount = false;
            }
            if (grassPower.Finish)
            {
               
                Judge();
            }
        }
    }
    IEnumerator TimeStop()
    {
        yield return new WaitForSeconds(1f);
      
        Time.timeScale = 0;
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
