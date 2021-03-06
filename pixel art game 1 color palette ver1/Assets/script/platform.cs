﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform : MonoBehaviour
{
    private Rigidbody2D rb;



    [Header("Platform Object")]
    public GameObject activePlatform, nonActivePlatform;

    [Header("moving Attribute")]
    public Vector2 PlatformSpeed;
    private Vector2 StartPositionMoving;
    private Vector2 facingDirection;
    public float DistanceMove = 10f;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        activePlatform.SetActive(true);
        nonActivePlatform.SetActive(false);
        facingDirection = new Vector2(1,1);
        StartPositionMoving = transform.position;
    }

    public void FixedUpdate() {
        movingPlatform();
    }

    private void OnCollisionEnter2D(Collision2D player) {
        if (player.gameObject.tag == "Player")
        {
            activePlatform.SetActive(false);
            nonActivePlatform.SetActive(true);
            player.collider.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D player) {
        if (player.gameObject.tag == "Player"){
            activePlatform.SetActive(true);
            nonActivePlatform.SetActive(false);
            player.collider.transform.SetParent(null);
        }
    }

    private void movingPlatform(){
    transform.position += new Vector3(PlatformSpeed.x*facingDirection.x, PlatformSpeed.y*facingDirection.y,0);

        if (Mathf.Abs(transform.position.x - StartPositionMoving.x) > DistanceMove){
            facingDirection *= -1;
            StartPositionMoving.x = transform.position.x;
        }
        
        if (Mathf.Abs(transform.position.y - StartPositionMoving.y) > DistanceMove){
            facingDirection *= -1;
            StartPositionMoving.y = transform.position.y;
        }
        
    }


}   
