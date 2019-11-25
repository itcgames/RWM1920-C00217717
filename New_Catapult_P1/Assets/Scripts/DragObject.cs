using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    private float StartX;
    private float StartY;

    private bool isHeld = false;

    private void Update()
    {
        if (isHeld)
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            gameObject.transform.localPosition = new Vector3(mousePos.x - StartX, mousePos.y - StartY, 0);
        }


    }

    void OnMouseDown()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            StartX = mousePos.x - transform.localPosition.x;
            StartY = mousePos.y - transform.localPosition.y;


            isHeld = true;

        }

    }

    void OnMouseUp()
    {
        isHeld = false;
    }

}




