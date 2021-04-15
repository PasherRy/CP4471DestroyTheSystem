﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPlayer : MonoBehaviour
{
    public float moveSpeed = 10.0f;
    public float verticalInput;
    public float horizontalInput;
    public float turnSpeed = 5.0f;
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
            verticalInput = Input.GetAxis("Vertical");
            transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * moveSpeed);
            horizontalInput = Input.GetAxis("Horizontal");
            transform.Rotate(Vector3.up * horizontalInput * turnSpeed);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectable"))
        {
            Destroy(other.gameObject);
            gameManager.CollectGem();

        }

        if (gameManager.collectablesCollected == 5 && other.CompareTag("WinGate"))
        {
            gameManager.WinGame();
        }

        if (other.CompareTag("Trap"))
        {
            Destroy(other.gameObject);
            gameManager.TakeDamage();
        }
    }
}
