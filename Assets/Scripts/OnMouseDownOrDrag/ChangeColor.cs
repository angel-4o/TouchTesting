using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour {

    public Renderer objectToColor;

    private void OnMouseDown()
    {
        objectToColor.material.color = GetComponent<Renderer>().material.color;
    }

}
