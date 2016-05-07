using UnityEngine;
using System.Collections;

public class CrumblingPlatforms : MonoBehaviour {
    // --- Properties and fields --- //
    // Public
    public float timer = 1f;
    public float platformTimer = 5f;
    public float vanishingSpeed = .95f;
    

    // Private
    // Components
    private BoxCollider2D boxColl;
    private SpriteRenderer spr;
    // Vars
	private bool playerOnPlatform = false;
	private bool platformBroken = false;

	// --- Methods --- //
	void Start ()
    {
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

	// Executed when collision stops
	void OnCollisionExit2D(Collision2D coll)
	{
		// Player not colliding any more
		/*if (coll.gameObject == GameObject.Find("Player"))
		{
			timer = 1f;
            playerOnPlatform = false;

        }*/
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (playerOnPlatform)
        {
            spr.color = new Color(spr.color.r, spr.color.g, spr.color.b, spr.color.a * vanishingSpeed);
        }
	}

	// Executed on fixed physics update steps
	void FixedUpdate()
	{
		// player on platform // platform not bricked
		if (playerOnPlatform) {
			// platform timer for hiding
			timer -= Time.deltaTime;

			// platform timer over
			if (timer < 0f) {
				timer = 1f;
                
                Color color = spr.color;
                //color.a = ;
                spr.color = new Color(spr.color.r, spr.color.g, spr.color.b, 0f);
                platformBroken = true;
                playerOnPlatform = false;

            }
		}

		// platform bricked // player not on platform any more
		if (platformBroken) {
			//disabling platform collider
			boxColl.enabled = false;

			//platform timer for platform appearance
			platformTimer -= Time.deltaTime;

			//platform timer is over
			if (platformTimer < 1f)
			{
				platformTimer = 5f;

				boxColl.enabled = true;
                platformBroken = false;
                spr.color = new Color(spr.color.r, spr.color.g, spr.color.b, 255f); ;
            }
		}

	}
}
