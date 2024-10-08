using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scenemanager : MonoBehaviour
{
    [SerializeField] private string sceneNameClear;
    [SerializeField] private string sceneNameGameOver;
    [SerializeField] private string sceneNameResult;
    [SerializeField] private Color fadeColor;
    [SerializeField] private float fadeSpeed;
    private static Scenemanager instance;
    public bool OneFade = false;
    public bool OneClear = false;

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
    public static Scenemanager GetInstance()
    {
        return instance;
    }
    public void GameClear()
    {
        if (!OneClear)
        {
            Initiate.Fade(sceneNameClear, fadeColor, fadeSpeed);
            OneClear = true;
        }
    }
    public void GameOver()
    {
        if (!OneClear)
        {
            Initiate.Fade(sceneNameGameOver, fadeColor, fadeSpeed);
            OneClear = true;
        }
    }
    public void GameResult()
    {
        if (!OneFade)
        {
          
            Initiate.Fade(sceneNameResult, fadeColor, fadeSpeed);
            OneFade = true;
        }
    }
}
