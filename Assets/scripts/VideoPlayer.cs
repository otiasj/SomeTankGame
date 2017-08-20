using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoPlayer : MonoBehaviour {

	private MovieTexture texture; 

	// Use this for initialization
	void Start () {
		if (GetComponent<Renderer>() != null) {
			texture = (MovieTexture)GetComponent<Renderer>().material.mainTexture;
		}
	}
	
	public void Play() {
		if (texture != null) {
			texture.Play();
		}
	}

	public void Stop() {
		if (texture != null) {
			texture.Stop();
		}
	}
}
