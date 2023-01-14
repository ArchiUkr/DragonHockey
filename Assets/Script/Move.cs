using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private Vector2 mousePos;
    public float dashSpeed =2f;

    Rigidbody2D rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (mousePos.y <= 2 && mousePos.y >= -3.6 && mousePos.x <= -0.1 && mousePos.x >= -7.5)
            {
                rb.MovePosition(mousePos);
            }
        }
    }
}
