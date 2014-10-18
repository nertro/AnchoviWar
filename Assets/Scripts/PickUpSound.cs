using UnityEngine;
using System.Collections;

public class PickUpSound : MonoBehaviour {
	private AudioSource source;
	
	void Start () {
		source = GetComponent<AudioSource>();
		source.Play();
	}
	
	// Update is called once per frame
	void Update () {
		if (!source.isPlaying)
		{
			Destroy(this.gameObject);
		}
	}
}
