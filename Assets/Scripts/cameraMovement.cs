using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;
    // Vector3 offset = new Vector3(0.0f, 0.0f, 0.0f);
    // Use this for initialization
    void Start()
    {
        offset = transform.position - player.transform.position;
    }
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;

    }
    // Update is called once per frame
    void Update()
    {

    }

}
