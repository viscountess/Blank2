using UnityEngine;
using System.Collections;

public class PortalScript : MonoBehaviour {

	public string LevelName;
	public GameObject player;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt(player.transform.position);
		Vector3 rot = transform.rotation.eulerAngles;
		rot.x = 90;
		transform.rotation = Quaternion.Euler(rot);
	}
	
	void OnTriggerEnter(Collider c){
		if (c.gameObject.tag == "Player"){
			Application.LoadLevel(LevelName);
		}
	}
}