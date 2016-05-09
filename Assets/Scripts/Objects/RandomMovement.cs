//Using namespaces
using UnityEngine;
using System.Collections;

public class RandomMovement : MonoBehaviour {

    // --- public vars --- //
    public float minRadius = .5f;
    public float maxRadius = 3.5f;

    public float minSpeed = 0.0003f;
    public float maxSpeed = 0.01f;

    // --- private vars --- //
    private float radius;
    private float speed;
    private float rotation;

    // Object rotates around this point
    private Vector2 origin;
    
    //Executed on startup. Use this method for initialization.
	void Start ()
    {
        radius = Random.Range(minRadius, maxRadius);
        speed = Random.Range(minSpeed, maxSpeed);
        origin = transform.position;
        rotation = 0f;
	}

	//Executed on every frame update.
	void Update ()
    {
        rotation += speed;
        transform.position = new Vector3(origin.x + Mathf.Cos(rotation) * radius, origin.y + Mathf.Sin(rotation) * radius, transform.position.z);
	}
}
