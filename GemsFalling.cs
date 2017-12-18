using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemsFalling : MonoBehaviour {

    Vector2 startpos;
	// Use this for initialization
	void Start ()
    {
        byte r = (byte)Random.Range(0,256);
        byte g = (byte)Random.Range(0, 256);
        byte b = (byte)Random.Range(0, 256);
        byte a = (byte)Random.Range(0, 256);
        GetComponent<SpriteRenderer>().color = new Color32(r, g, b, a);
        startpos = this.transform.position;
    }
	
	// Update is called once per frame
	void Update ()
    {
		if(this.transform.position.y < -40)
        {
            this.transform.position = startpos;
            byte r = (byte)Random.Range(0, 256);
            byte g = (byte)Random.Range(0, 256);
            byte b = (byte)Random.Range(0, 256);
            byte a = (byte)Random.Range(0, 256);
            GetComponent<SpriteRenderer>().color = new Color32(r, g, b, a);
        }
	}
}
