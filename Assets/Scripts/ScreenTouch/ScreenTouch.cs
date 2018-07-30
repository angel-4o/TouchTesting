using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DeltaDNA;

public class ScreenTouch : MonoBehaviour {

    //[SerializeField]
    public enum Direction // a simple bool can do the job but I wanted to test how enumerations work
    {
        Left,
        Righ
    }

    public float speed = 3f;
    public Direction direction = Direction.Left;


    private Touch prevTouch;
    private Direction prevDirection;
    private bool shouldMove = false;
    private Rigidbody2D playerRB;


    private void Awake()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        Vector2 force = new Vector2(0f, 10f);
        playerRB.AddForce(force, ForceMode2D.Impulse);
    }

    private void Update()
    {
        if(Input.touches.Length > 0)
        {
            Touch touch = Input.touches[0];
            if(touch.phase == TouchPhase.Began)
            {
                prevTouch = touch;
            }
            else if(touch.phase == TouchPhase.Moved)
            {
                // touch is the new one in the first move
                // prevTouch is the previous touch
                // you can keep your direction if prevTouch.x < touch.x
                
                //if(prevTouch.position.x < touch.position.x)//go right
                //{
                   // direction = Direction.Righ;
                //}
                //else
                //{
                  //  direction = Direction.Left;
                //}
                
                shouldMove = true;
                prevDirection = direction;
                direction = prevTouch.position.x < touch.position.x ? Direction.Righ : Direction.Left;
                Rotate(prevDirection != direction);
                prevTouch = touch;
                // when you move the touch for second time
            }
            else if(touch.phase == TouchPhase.Ended)
            {
                shouldMove = false;
            }

            if (shouldMove)
            {
                Move();
            }
        }
    }
  

    private void Move()
    {
        float newX = transform.position.x; // get the old value of x
        newX += direction == Direction.Left ? -1f * Time.deltaTime : 1f * Time.deltaTime; // depending on the direction increase / decrease the value of x by speed * Time*deltaTime. This way the object will move speed units per second
        Vector2 newPosition = new Vector2(newX, transform.position.y); // create vector with the old y and z values and the new x

        transform.position = newPosition; // set the new position to the transform component i.e. move the object
        /*
        if(direction == Direction.Left)
        {
            float moveBy = -2f * Time.deltaTime;
            transform.Translate(moveBy, 0f, 0f);
            print("left");
            print(moveBy);
        }
        else
        {
            float moveBy = 2f * Time.deltaTime;
            transform.Translate(moveBy, 0f, 0f);
            print("right");
            print(moveBy);
        }*/
    }

    private void Rotate(bool changeDirection) // whenever we turn the direction the object should be inverted
    {
        if (changeDirection) // The boolean variable changeDirection tells us should we change the direction
        {
            Vector3 currentRotation = transform.rotation.eulerAngles; // get the current rotation part of the transform component of this game object. This problem can be solved w/o using this but this way is way more sleaker.
            Vector3 newRotation = new Vector3(currentRotation.x, currentRotation.y + 180f, currentRotation.z); // calculate the new rotation by adding 180 degrees to the y rotation and keeping the other axis the same
            transform.rotation = Quaternion.Euler(newRotation); // assign the new rotation to the rotation part of the transform component of this game object
        }
    }

}
