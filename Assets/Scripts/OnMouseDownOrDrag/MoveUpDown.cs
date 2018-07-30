using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUpDown : MonoBehaviour {

    public float moveBy = 0;
    public Transform objectToMove;
    public float yLimit = 4;

    private Color objectToMoveStartingColor;

    private void Awake()
    {
        Renderer objectToMoveRenderer = transform.GetComponent<Renderer>();

        if (objectToMoveRenderer != null)
        {
            objectToMoveStartingColor = objectToMoveRenderer.material.color;
        }
    }

    // OnMouseDown doesn't work on objects w/o colliders
    private void OnMouseDown()
    {
        //return the color to the starting one
        //objectToMoveRenderer.material.color = objectToMoveStartingColor;
        objectToMove.GetComponent<Renderer>().material.color = objectToMoveStartingColor;


        //move the object up or down
        float newY = objectToMove.position.y + moveBy; 
        newY = Mathf.Clamp(newY, -yLimit, yLimit);
        Vector2 newPosition = new Vector2(objectToMove.position.x, newY);
        
        objectToMove.position = newPosition;
    }
}
