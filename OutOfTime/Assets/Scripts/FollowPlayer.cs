using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private Vector3 offset = new Vector3(-3, -3, -1);
    public GameObject barbarian;
    public Transform target;
    public Camera cam;
    private Vector3 previousPosition;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive)
        {
            if (Input.GetMouseButtonDown(0))
            {
                previousPosition = cam.ScreenToViewportPoint(Input.mousePosition);
            }

            if (Input.GetMouseButton(0))
            {
                Vector3 direction = previousPosition - cam.ScreenToViewportPoint(Input.mousePosition);

                cam.transform.position = target.position;

                cam.transform.Rotate(new Vector3(1, 0, 0), direction.y * 180);
                cam.transform.Rotate(new Vector3(0, 1, 0), -direction.x * 180, Space.World);
                cam.transform.Translate(new Vector3(0, 0, -10));

                previousPosition = cam.ScreenToViewportPoint(Input.mousePosition);

                offset = target.position - cam.transform.position;
            }
            
            transform.position = barbarian.transform.position - offset;
        }
        

        
    }
}
