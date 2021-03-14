using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject barbarian;
    private Vector3 offset = new Vector3(3, 3, 1);
    public float horizontalInput;
    public float turnSpeed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = barbarian.transform.position + offset;
        horizontalInput = Input.GetAxis("Horizontal");
        transform.RotateAround(barbarian.transform.position,
            Vector3.up, horizontalInput * turnSpeed);

    }
}
