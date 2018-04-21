﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CircleCollider2D))]
public class FlashLight : MonoBehaviour
{
    private CircleCollider2D cc2d;
    [SerializeField] private Light flashlight;

    // Use this for initialization
    void Start()
    {
        cc2d = GetComponent<CircleCollider2D>();
    }

    public void On()
    {
        cc2d.enabled = true;
        flashlight.intensity = 5;
    }

    public void Off()
    {
        cc2d.enabled = false;
        flashlight.intensity = 0;
    }
}