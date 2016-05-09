//Using namespaces
using UnityEngine;
using System.Collections;

//ToDo: Cloud does not slowly disappear at second step on cloud of player
public class CrumblingPlatforms : MonoBehaviour {
    // --- Properties and fields --- //
    // Public
    public float timer = 1f;
    public float platformTimer = 5f;
    public float vanishingSpeed = .50f;

    // Private
    // Components
    private BoxCollider2D boxColl;
    private SpriteRenderer spr;
    // Vars
	private bool playerOnPlatform = false;
	private bool platformBroken = false;

	// --- Methods --- //
	//Executed on startup. Use this method for initialization.
	void Start ()
    {
		//Get components of given game object
		boxColl = gameObject.GetComponent<BoxCollider2D>();
        spr = gameObject.GetComponent<SpriteRenderer>();
	}

	// Executed if a collision appears and stays
	void OnCollisionStay2D(Collision2D coll)
	{
		// Player collision check
		if (coll.gameObject == GameObject.Find("Player"))
		{
            // Player collided
            playerOnPlatform = true;

        }
	}

	// Executed on fixed physics update steps
	void FixedUpdate()
	{
		// player on platform // platform not disappeared
		if (playerOnPlatform) {
			//Let the cloud slowly disappear
			spr.color = new Color(spr.color.r, spr.color.g, spr.color.b, spr.color.a * vanishingSpeed);

			// platform timer for hiding
			timer -= Time.deltaTime;

			// platform timer over
			if (timer < 0f) {
				timer = 1f;
                
				// Cloud disapeard
                spr.color = new Color(spr.color.r, spr.color.g, spr.color.b, 0f);

                platformBroken = true;
                playerOnPlatform = false;

            }
		}

		// cloud disappeard // player not on platform any more
		if (platformBroken) {
			//disabling platform collider
			boxColl.enabled = false;

			// platform timer for platform appearance
			platformTimer -= Time.deltaTime;

			// platform timer is over
			if (platformTimer < 1f)
			{
				platformTimer = 5f;

				boxColl.enabled = true;
                platformBroken = false;

				// Cloud apeard
                spr.color = new Color(spr.color.r, spr.color.g, spr.color.b, 255f);
            }
		}
	}
}
