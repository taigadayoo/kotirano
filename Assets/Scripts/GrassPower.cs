using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassPower : MonoBehaviour
{
    // Start is called before the first frame update]
   public enum GrassName
    {
        rock,
        wine,
        cocktail
    }
   public enum Power
    {
        one,
        two,
        max
    }
    public float oneSpeed = 2.0f;

    public float twoSpeed = 4.0f;

    public float maxSpeed = 6.0f;

    public bool Finish = false;

   
    [SerializeField]
   public Power power;
    [SerializeField]
  public  GrassName grassName;

    private float pulsPower = 0;
    BoolManager boolManager;
    CountCollider countCollider;
    private void Awake()
    {
        boolManager = FindObjectOfType<BoolManager>();
    }
    void Start()
    {
       
        Finish = false;
        countCollider = FindObjectOfType<CountCollider>();
      if( boolManager.randomPower == 0)
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

    // Update is called once per frame
    void Update()
    {

        StartCoroutine(DireySlide());
        if (countCollider.StartSlide == true)
        {
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
            pulsPower = countCollider.collisionCount * 0.45f;
        }

        
    }

    public void GrassRoockMove()
    {
        if (power == Power.one)
        {
            transform.Translate(Vector3.right * (oneSpeed -1 + pulsPower ) * Time.deltaTime);
        }
        if (power == Power.two)
        {
            transform.Translate(Vector3.right * (twoSpeed -1 + pulsPower ) * Time.deltaTime);
        }
        if (power == Power.max)
        {
            transform.Translate(Vector3.right * (maxSpeed -1 + pulsPower )* Time.deltaTime);
        }
    }
    public void WineGrassMove()
    {
        if (power == Power.one)
        {
            transform.Translate(Vector3.right * (oneSpeed +1 + pulsPower) * Time.deltaTime);
        }
        if (power == Power.two)
        {
            transform.Translate(Vector3.right * (twoSpeed + 1 + pulsPower) * Time.deltaTime);
        }
        if (power == Power.max)
        {
            transform.Translate(Vector3.right * (maxSpeed + 1  + pulsPower) * Time.deltaTime);
        }
    }
    public void CaktailGrassMove()
    {
        if (power == Power.one)
        {
            transform.Translate(Vector3.right * (oneSpeed + 4 + pulsPower) * Time.deltaTime) ;
        }
        if (power == Power.two)
        {
            transform.Translate(Vector3.right * (twoSpeed + 4  + pulsPower) * Time.deltaTime);
        }
        if (power == Power.max)
        {
            transform.Translate(Vector3.right * (maxSpeed + 4 + pulsPower) * Time.deltaTime);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "RedLine")
        {
            Finish = true;
        }
    }
    IEnumerator DireySlide()
    {
        yield return new WaitForSeconds(4f);

       countCollider.StartSlide = true;
    }
}
