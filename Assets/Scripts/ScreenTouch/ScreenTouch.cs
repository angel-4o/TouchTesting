using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenTouch : MonoBehaviour {

    //[SerializeField]
    public enum Direction // a simple bool can do the job but I wanted to test how enumerations work
    {
        Left,
        Righ
    }
    public float speed = 3f;
    public Direction direction = Direction.Left;
    public float movingSpeed = 8f;
    public float thrust = 10f;


    private Touch prevTouch;
    private Direction prevDirection;
    private bool shouldMove = false;
    private Rigidbody2D playerRB;


    private void Awake()
    {
        print("Awake");
        playerRB = GetComponent<Rigidbody2D>();
        //playerRB.velocity = new Vector2(0f, 1f);
        //Invoke("AutoJump", 3f);
    }

    private void OnEnable()
    {
        print("OnEnable");
        Vector2 force = new Vector2(0f, 10f);
        playerRB.AddForce(force, ForceMode2D.Impulse);
    }

    private void Start()
    {
        print("OnStart");
    }

    private void OnDisable()
    {
        print("OnDisable");
    }

    private void OnDestroy()
    {
        print("OnDestroy");
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        print("OnTriggerEnter2D");
        playerRB.velocity = Vector2.zero;
        playerRB.AddForce(Vector2.up * thrust, ForceMode2D.Impulse);
    }

    private void FixedUpdate()
    {
        int h = (int)Input.GetAxisRaw("Horizontal1");

        if(h != 0f)
        {
            if(h > 0f)
            {
                direction = Direction.Righ;
            }
            else
            {
                direction = Direction.Left;
            }
            Move();
        }
        else
        {
            EndMove();
        }
        if(Input.touches.Length > 0)
        {
            Touch touch = Input.touches[0];
            if(touch.phase == TouchPhase.Began)
            {
                prevTouch = touch;
            }
            else if(touch.phase == TouchPhase.Moved)
            {
                shouldMove = true;
                prevDirection = direction;
                direction = prevTouch.position.x < touch.position.x ? Direction.Righ : Direction.Left;
                //Rotate(prevDirection != direction);
                prevTouch = touch;
                // when you move the touch for second time
            }
            else if(touch.phase == TouchPhase.Ended)
            {
                shouldMove = false;
                EndMove();
            }

            if (shouldMove)
            {
                Move();
            }
        }
        
    }
  

    private void Move()
    {
        /*
        float newX = transform.position.x; // get the old value of x
        newX += direction == Direction.Left ?  -movingSpeed * Time.deltaTime : movingSpeed * Time.deltaTime; // depending on the direction increase / decrease the value of x by speed * Time*deltaTime. This way the object will move speed units per second
        Vector2 newPosition = new Vector2(newX, playerRB.velocity.y); // create vector with the old y and z values and the new x

        playerRB.MovePosition(newPosition);
        */
        playerRB.velocity = new Vector2(direction == Direction.Left ? -movingSpeed : movingSpeed, playerRB.velocity.y);
        print("move");
    }

    private void EndMove()
    {
        playerRB.velocity = new Vector2(0f, playerRB.velocity.y);
    }

}
