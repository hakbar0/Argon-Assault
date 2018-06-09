﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

    [Tooltip("In ms^-1")][SerializeField] float speed = 15f;
    [Tooltip("In m")] [SerializeField] float xRange = 3f;
    [Tooltip("In m")] [SerializeField] float yRange = 2f;

    [SerializeField] float positionPitchFactor = -2f;
    [SerializeField] float controlPitchFactor = -30f;
    [SerializeField] float positionYawFactor = -10f;
    [SerializeField] float controlRollFactor = -20f;

    float xThrow, yThrow;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        HorizontalMovement();
        VerticalMovement();
        ProcessRotation();
    }

    private void HorizontalMovement()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffsetThisFrame = speed * xThrow * Time.deltaTime;
        float rawNewXPostion = transform.localPosition.x + xOffsetThisFrame;
        float clampedXPos = Mathf.Clamp(rawNewXPostion, -xRange, xRange);
        transform.localPosition = new Vector3(clampedXPos, transform.localPosition.y, transform.localPosition.z);
    }

    private void VerticalMovement()
    {
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffsetThisFrame = speed * yThrow * Time.deltaTime;
        float rawNewYPostion = transform.localPosition.y + yOffsetThisFrame;
        float clampedYPos = Mathf.Clamp(rawNewYPostion, -yRange, yRange);
        transform.localPosition = new Vector3(transform.localPosition.x, clampedYPos, transform.localPosition.z);
    }

    private void ProcessRotation()
    {
        float pitchDueToPostion = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;
        float pitch = pitchDueToPostion + pitchDueToControlThrow;

        float yaw = transform.localPosition.x * positionYawFactor;

        float roll = xThrow * controlRollFactor;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll); 
    }

	private void OnCollisionEnter(Collision collision)
	{
        print("I collided with something");
	}

	private void OnTriggerEnter(Collider other)
	{
        print("Player triggered with something");	
	}
}
