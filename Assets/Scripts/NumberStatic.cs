using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberStatic : MonoBehaviour
{
    private static NumberStatic instance;

    public int ramdomNumber;
    // Start is called before the first frame update
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
    public static NumberStatic GetInstance()
    {
        return instance;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
