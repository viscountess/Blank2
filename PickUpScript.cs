using UnityEngine;
using System.Collections;

public class PickUpScript : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		transform.Rotate(new Vector3 (0, 1, 0), Space.Self);
	}
}