using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountCollider : MonoBehaviour
{
    private bool collidedWithCollider1 = false;
    private bool collidedWithCollider2 = false;
   public int collisionCount = 0;

    public bool StartSlide = false;
    GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameManager.OnCount)
        {
            if (collision.gameObject.tag == "Collider1")
            {
                SampleSoundManager.Instance.PlaySe(SeType.SE2);
                if (!collidedWithCollider1 && StartSlide)
                {
                    collidedWithCollider1 = true;
                    collidedWithCollider2 = false; // Collider1に当たった時にCollider2の状態をリセット
                    collisionCount++; // カウントを増やす
                    Debug.Log("Collision Count: " + collisionCount);
                }
            }
            else if (collision.gameObject.tag == "Collider2")
            {
                SampleSoundManager.Instance.PlaySe(SeType.SE2);
                if (!collidedWithCollider2 && StartSlide)
                {
                    collidedWithCollider2 = true;
                    collidedWithCollider1 = false; // Collider2に当たった時にCollider1の状態をリセット
                }
            }
        }
    }
}
