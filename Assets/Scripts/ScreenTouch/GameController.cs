using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public static GameController instance = null;

    public GameObject player;
    public GameObject[] interrupts;
    public int interruptsCount;
    public float interruptsRange;

    private Transform interruptsParent;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
        interruptsParent = new GameObject("Interrupts").transform;

        Instantiate(player);

        for(int i = 0; i < interruptsCount; i++)
        {
            float xPos = Random.Range(-interruptsRange, interruptsRange);
            Vector2 position = new Vector2(xPos, (i+1)*4);
            Instantiate(interrupts[0], position, Quaternion.identity).transform.parent = interruptsParent;
        }
    }

}
