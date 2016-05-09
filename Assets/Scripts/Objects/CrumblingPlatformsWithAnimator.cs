//Using namespaces
using UnityEngine;
using System.Collections;

public class CrumblingPlatformsWithAnimator : MonoBehaviour {
	// --- Properties and fields --- //
	//Public
	public float timer = 1f;
	public float platformTimer = 5f;

	//Private
	private Animator anim;
	private BoxCollider2D boxColl;

	// --- Methods --- //
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		boxColl = gameObject.GetComponent<BoxCollider2D>();
	}

	// Executed if a collision appears and stays
	void OnCollisionStay2D(Collision2D coll)
	{
		// Player collision check
		if (coll.gameObject == GameObject.Find("Player"))
		{
			// Player collided
			anim.SetBool("playerOnPlatform", true);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Executed on fixed physics update steps
	void FixedUpdate()
	{
		// player on platform // platform not bricked
		if (anim.GetBool("playerOnPlatform")) {
			// platform timer for hiding
			timer -= Time.deltaTime;

			// platform timer over
			if (timer < 0f) {
				timer = 1f;

				anim.SetBool("platformBroken", true);
				anim.SetBool ("playerOnPlatform", false);
			}
		}

		// platform bricked // player not on platform any more
		if (anim.GetBool("platformBroken")) {
			//disabling platform collider
			boxColl.enabled = false;

			//platform timer for platform appearance
			platformTimer -= Time.deltaTime;

			//platform timer is over
			if (platformTimer < 1f)
			{
				platformTimer = 5f;

				boxColl.enabled = true;
				anim.SetBool("platformBroken", false);
			}
		}

	}
}
