using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public GameObject portal;
	public int notes;
	
	public AudioClip pickup;
	public AudioClip[] footstep;
	public AudioClip[] bgm;
	
	bool collecting, footstepPlaying, bgmPlaying;

	// Use this for initialization
	void Start () {}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(new Vector3(0, Input.GetAxis("Look X") * 3, 0));
		
		//DiveFPSController con = GetComponent<DiveFPSController>();
		
		if ((Mathf.Abs(Input.GetAxis("Horizontal")) > 0.1f || Mathf.Abs(Input.GetAxis("Vertical")) > 0.1f) && !footstepPlaying){
			StartCoroutine(playFootstep());
		}
		
		if (!bgmPlaying){
			StartCoroutine(playBGM());
		}
	}
	
	void OnControllerColliderHit (ControllerColliderHit hit) {
		if(hit.gameObject.tag=="PickUps" && !collecting){
			collecting = true;
			Debug.Log("hit something");
			Destroy(hit.gameObject);
			notes++;
			
			audio.PlayOneShot(pickup);
			
			if (notes == 3){
				Debug.Log("all notes collected");
				portal.active = true;
			}
			
			StartCoroutine(stopCollecting());
		}
	}
	
	void OnGUI () {
		for (int offset = 0; offset <= Screen.width / 2; offset += Screen.width / 2){
			GUI.Label(new Rect(10 + offset, 10, 400, 40), "<size=32>Notes Collected " + notes + "</size>");
		}
	}
	
	IEnumerator playFootstep(){
		System.Random rand = new System.Random();
		
		AudioClip clip = footstep[rand.Next(footstep.Length)];
		footstepPlaying = true;
		audio.PlayOneShot(clip);
		yield return new WaitForSeconds(clip.length);
		footstepPlaying = false;
	}
	
	IEnumerator playBGM(){
		System.Random rand = new System.Random();
		
		AudioClip clip = bgm[rand.Next(bgm.Length)];
		bgmPlaying = true;
		audio.PlayOneShot(clip);
		yield return new WaitForSeconds(clip.length);
		bgmPlaying = false;
	}
	
	IEnumerator stopCollecting(){
		yield return new WaitForEndOfFrame();
		collecting = false;
	}
}