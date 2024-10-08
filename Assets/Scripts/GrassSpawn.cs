using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassSpawn : MonoBehaviour
{
    public GameObject rockGrass;
    public GameObject wineGrass;
    public GameObject cakGrass;
    public Transform spawnPoint;
    public bool OneFinish = false;
    RamdomNumber ramdomNumber;
    BoolManager boolManager;
    private bool OneSpawn = false;
    public GameObject SpawnGrass;
    GameManager gameManager;
    void Start()
    {
        boolManager = FindObjectOfType<BoolManager>();
        gameManager = FindObjectOfType<GameManager>();
      ramdomNumber =   GameObject.FindObjectOfType<RamdomNumber>();
        StartCoroutine(RamdomSpawn());
      
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    IEnumerator RamdomSpawn()
    {
        if(boolManager.ramdomNumber == 0)
        {
           SpawnGrass =  Instantiate(rockGrass, spawnPoint.position, Quaternion.identity);
            

            yield return new WaitUntil(() => SpawnGrass != null);

            gameManager.grass = SpawnGrass;

            yield return new WaitUntil(() => gameManager.grass != null);
            gameManager.grassPower =gameManager.grass.GetComponent<GrassPower>();
        }
        if (boolManager.ramdomNumber == 1)
        {
            SpawnGrass =  Instantiate(wineGrass, spawnPoint.position, Quaternion.identity);
           

            yield return new WaitUntil(() => SpawnGrass != null);

            gameManager.grass = SpawnGrass;

            yield return new WaitUntil(() => gameManager.grass != null);
            gameManager.grassPower = gameManager.grass.GetComponent<GrassPower>();
        }
        if (boolManager.ramdomNumber == 2)
        {
            SpawnGrass = Instantiate(cakGrass, spawnPoint.position, Quaternion.identity);
           

            yield return new WaitUntil(() => SpawnGrass != null);

            gameManager.grass = SpawnGrass;

            yield return new WaitUntil(() => gameManager.grass != null);
            gameManager.grassPower = gameManager.grass.GetComponent<GrassPower>();
        }
    }
}
