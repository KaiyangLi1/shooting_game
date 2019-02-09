using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scroller : MonoBehaviour {

    public Renderer rend;
    float offset;
    public float speed;

	// Use this for initialization
	void Start () {
        rend = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
        offset = Time.time * speed;
        rend.material.mainTextureOffset = new Vector2(0, offset);
		
	}
}
