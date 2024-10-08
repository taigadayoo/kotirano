using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupidMove : MonoBehaviour
{
    private bool isDragging = false; // オブジェクトがドラッグされているかどうかを示すフラグ
    private Vector3 offset; // ドラッグ開始時のマウスカーソルとオブジェクトの相対位置

    void Update()
    {
        // クリックした瞬間にドラッグを開始する
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                isDragging = true;
                offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
        }

        // クリックを離すとドラッグを停止する
        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

        // ドラッグ中はオブジェクトをマウスカーソルの位置に追従させる
        if (isDragging)
        {
            Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
            transform.position = cursorPosition;
        }
    }
}
