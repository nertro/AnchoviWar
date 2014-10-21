using UnityEngine;
using System.Collections;

public class WinScreen : MonoBehaviour {

	public MovieTexture Movie;

	void Start () {
		Movie.Play ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!Movie.isPlaying) {
			Application.LoadLevel("Start");
		}
	}
}
