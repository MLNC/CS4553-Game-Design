﻿using UnityEngine;
using System.Collections;

/*
This script change the color of object along a gradient and not just transparency
Can experiment if desired
*/

public class ControlEnemyTransparency : MonoBehaviour
{
    private SpriteMask hitSpriteMask;

    private SpriteRenderer sr;

    private float time; //timer variable for tweening colors

    [Range(0, 4)]
    public float changeTime = 1.0f;

    public Gradient colorGradient;

    private bool startChanging;

    // Use this for initialization
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        time = changeTime;
        startChanging = false;
    }

    private void Update()
    {
        if (startChanging)
        {
            if (time < changeTime)
            {
                sr.color = colorGradient.Evaluate(time / changeTime); //as time increases, we move along the gradient
                time += Time.deltaTime;
            }
            else
            {
                hitSpriteMask.enabled = false;
                //sr.maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
                sr.color = colorGradient.Evaluate(0); //get the color from the far right of the gradient
                startChanging = false;
            }
        }
    }

    //When enter the range of flashlight apply the color on the left most of gradient
    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*if (collision.gameObject.tag == "FlashLight")
        {
            Debug.Log("Enter");
            sr.color = colorGradient.Evaluate(0);
            time = changeTime;
        }*/
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            hitSpriteMask = collision.gameObject.transform.GetChild(3).GetComponent<SpriteMask>();
            hitSpriteMask.enabled = true;
            //sr.maskInteraction = SpriteMaskInteraction.None;
            sr.color = colorGradient.Evaluate(0);
            startChanging = true;
            time = 0;
        }
    }

    //When out of range start changing the color along the gradient
    private void OnTriggerExit2D(Collider2D collision)
    {
        /*if(collision.gameObject.tag == "FlashLight")
        {
            Debug.Log("Exit");
            startChanging = true;
            time = 0;
        }*/
    }
}