﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hardmode : MonoBehaviour {

    static bool hard;

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void setHardMode()
    {
        hard = true;
    }

    public void setEasyMode()
    {
        hard = false;
    }

    public bool getHardMode()
    {
        return hard;
    }
}
