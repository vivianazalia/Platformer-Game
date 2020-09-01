using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPlayer : MonoBehaviour
{
    Rigidbody2D playerRb;

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            //Player jalan ke kanan
        } 
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //Player jalan ke kiri
        }
        else
        {
            //Animasi Idle
        }
        
    }
}
