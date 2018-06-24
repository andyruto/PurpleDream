//Using namespaces
using UnityEngine;
using System.Collections;

class CameraMovement : MonoBehaviour {
	// -- Properties and fields -- //
	//Public
	public float cameraDistOffset = 10f;
	public float movingSpeed = 5f;

	//Private
	private Camera mainCamera;
	private GameObject player;

	// Use this for initialization
	void Start () {
		mainCamera = GetComponent<Camera>();
		player = GameObject.Find("Player");

		//First initial position setting for mainCamera
		Vector3 playerInfo = player.transform.transform.position;
		mainCamera.transform.position = new Vector3(playerInfo.x, playerInfo.y, playerInfo.z - cameraDistOffset);
	}

	// Update is called once per frame
	void Update () {
		//Set camera position to player position (only y axe)
		//Vector3 playerInfo = player.transform.transform.position;
		//mainCamera.transform.position = new Vector3(mainCamera.transform.position.x, playerInfo.y, playerInfo.z - cameraDistOffset);
	
		//Set camera position temporary to player position
		Vector3 playerInfo = player.transform.transform.position;
        mainCamera.transform.position = new Vector3(playerInfo.x, playerInfo.y, playerInfo.z - cameraDistOffset);

		//ToDo: Smooth CameraMovement if player moves to moving area of camera
		//      Don't let camera move out of level range
        //if(playerInfo.x > (mainCamera.transform.position.x + (0.5f * (Screen. / 3f))))
		//{
		//	mainCamera.transform.position = new Vector3(mainCamera.transform.position.x + movingSpeed, playerInfo.y, playerInfo.z - cameraDistOffset);
		//}
	}
}