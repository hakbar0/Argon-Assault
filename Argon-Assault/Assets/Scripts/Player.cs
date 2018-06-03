using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

    [Tooltip("In ms^-1")][SerializeField] float speed = 15f;
    [Tooltip("In m")] [SerializeField] float xRange = 3f;
    [Tooltip("In m")] [SerializeField] float yRange = 2f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        horizontalMovement();
        verticalMovement();
    }

    private void horizontalMovement()
    {
        float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffsetThisFrame = speed * xThrow * Time.deltaTime;
        float rawNewXPostion = transform.localPosition.x + xOffsetThisFrame;
        float clampedXPos = Mathf.Clamp(rawNewXPostion, -xRange, xRange);
        transform.localPosition = new Vector3(clampedXPos, transform.localPosition.y, transform.localPosition.z);
    }

    private void verticalMovement()
    {
        float yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffsetThisFrame = speed * yThrow * Time.deltaTime;
        float rawNewYPostion = transform.localPosition.y + yOffsetThisFrame;
        float clampedYPos = Mathf.Clamp(rawNewYPostion, -yRange, yRange);
        transform.localPosition = new Vector3(transform.localPosition.x, clampedYPos, transform.localPosition.z);
    }

}
