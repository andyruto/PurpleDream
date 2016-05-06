﻿using UnityEngine;
using System.Collections;

class CameraMovement : MonoBehaviour
{
	public float cameraDistOffset = 10f;
	private Camera mainCamera;
	private GameObject player;

	// Use this for initialization
	void Start () {
		mainCamera = GetComponent<Camera>();
		player = GameObject.Find("Player");
	}

	// Update is called once per frame
	void Update () {
		Vector3 playerInfo = player.transform.transform.position;
		mainCamera.transform.position = new Vector3(playerInfo.x, playerInfo.y, playerInfo.z - cameraDistOffset);
	}
}