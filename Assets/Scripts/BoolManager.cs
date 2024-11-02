using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoolManager : MonoBehaviour
{
    public bool isOver = false;
    public bool isJust = false;
    public bool isStop = false;

    public bool isRock = false;
    public bool isWine = false;
    public bool isCaktail = false;
    public int ramdomNumber;
    public int randomPower;
    private static BoolManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public static BoolManager GetInstance()
    {
        return instance;
    }

}
