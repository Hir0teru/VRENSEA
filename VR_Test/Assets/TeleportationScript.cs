using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportationScript : MonoBehaviour {

	public Transform destination;
	void OnTriggerEnter (Collider other){
		if (other.tag == "Player") {
			var startPosition = other.transform.position;
			other.transform.position = destination.position;
			var moveDelta = other.transform.position - startPosition;
			Camera.main.transform.position += moveDelta;
		}
	}
}
