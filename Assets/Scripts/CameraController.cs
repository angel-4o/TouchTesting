using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    private GameObject player;
    private Vector3 diff;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        diff = transform.position - player.transform.position;
    }

    private void Update()
    {
        transform.localPosition = diff + player.transform.position - new Vector3(player.transform.position.x, 0f, 0f);
    }
}
