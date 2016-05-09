//Using namespaces
using UnityEngine;
using System.Collections;

class CameraMovement : MonoBehaviour {
	// -- Properties and fields -- //
	//Public
	public float cameraDistOffset = 10f;

	//Private
	private Camera mainCamera;
	private GameObject player;

	// Use this for initialization
	void Start () {
		mainCamera = GetComponent<Camera>();
		player = GameObject.Find("Player");
	}

	// Update is called once per frame
	void Update () {
		//Set camera position to player position
		Vector3 playerInfo = player.transform.transform.position;
		mainCamera.transform.position = new Vector3(playerInfo.x, playerInfo.y, playerInfo.z - cameraDistOffset);
	}
}