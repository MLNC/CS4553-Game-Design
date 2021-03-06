﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeTransparency : MonoBehaviour {
	private SpriteRenderer sr;
	private float time; //timer variable for tweening colors
    private bool rise;

    public float startTime;
	public Gradient colorGradient;
	public float changeTime = 100f;
	// Use this for initialization
	void Start () {
		sr = GetComponent<SpriteRenderer>();
		time = startTime;
		rise = false;
		sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0.5f);
	}


	// Update is called once per frame
	void FixedUpdate () {
		sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, (time / changeTime));
		//sr.color = colorGradient.Evaluate (time / changeTime); //as time increases, we move along the gradient
		if (rise) {
			time += Time.deltaTime;
			if (time >= changeTime) {
				rise = false;
			}
		} else {
			time -= Time.deltaTime;
			if (time <= 0) {
				rise = true;
			}
		}
		//Debug.Log(Time.deltaTime);
	}
}
