using UnityEngine;
using System.Collections;

public class StartScreen : MonoBehaviour {

	void Update () {
		if (Input.GetAxis("Fire3") >= 1) {
			Application.LoadLevel("game");	
		}
	}
}
