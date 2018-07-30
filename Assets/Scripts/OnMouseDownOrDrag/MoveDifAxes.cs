using UnityEngine;

public class MoveDifAxes : MonoBehaviour {

    public int objectId;

    private string hAxis;
    private string vAxis;

	void Start () {
        hAxis = "Horizontal" + objectId;
        vAxis = "Vertical" + objectId;
	}
	
	void Update () {
        float h = Input.GetAxis(hAxis);
        float v = Input.GetAxis(vAxis);

        Move(h, v);
	}

    void Move(float h, float v)
    {
        float newX = transform.position.x + h;
        float newY = transform.position.y + v;

        Vector2 newPosition = new Vector2(newX, newY);
        transform.position = newPosition;
    }
}
