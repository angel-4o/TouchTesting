using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour {

    //Important things to remember from this scene:
    // 1. Input.mousePosition is the current position of the mouse in screen pixels
    // 2. You can convert pixel coordinates in world coordinates by using the function Camera.main.ScreenToWorldPoint(posInPixels)
    // 3. OnMouse event functions work on 2018.1.1.f1 version of Unity
    // 4. All OnMouse event functions work only on GUI or Colliders
    // 5. All event functions: OnMouseDown, OnMouseEnter, OnMouseExit, OnMouseExit, OnMouseOver, OnMouseUp, OnMouseUpAsButton.

        
    private void OnMouseDrag()
    {
        // what is current position of the mouse in pixels
        Vector2 posInPixels = Input.mousePosition;
        // conversion to the vector 2 game position
        Vector2 posInWorld = Camera.main.ScreenToWorldPoint(posInPixels);
        //set the new position the current mouse position
        transform.position = posInWorld;
    }

}
