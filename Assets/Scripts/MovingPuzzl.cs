using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPuzzl : MonoBehaviour
{
    bool move;
    Vector2 mousePos;
    float startPosX;
    float startPosY;
    public GameObject form;
    bool finish;
    public bool isOnPlace;

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            move = true;
            startPosX = mousePos.x - this.transform.position.x;
            startPosY = mousePos.y - this.transform.position.y;

        }
    }

    void OnMouseUp()
    {
        move = false;
		print(Vector3.Distance(transform.position, form.transform.position));
		if (Vector3.Distance(transform.position, form.transform.position)<2f)  
        {

            this.transform.position = form.transform.position;
            finish = true;

		}
    }

    void Start()
    {
        isOnPlace = false;

	}

    void Update()
    {
        isOnPlace = finish;
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (move == true && finish == false)
        {
            transform.position = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, transform.position.z);
        }
    }
}
