//Using namespaces
using UnityEngine;
using System.Collections;

public class PlayerBabyMovement : MonoBehaviour {
	//Properties and fields
	//public
    public float jumpForce = 1000f;
    public float moveForce = 10f;
	public float sqrMaxSpeed = Mathf.Pow(10f, 2);//Mathf.Pow(x,y) executes x upper y
    public float stoppingForce = 5f;
    public bool isInAir;

	//private
    private Rigidbody2D rb2d;

	//Executed on startup. Initial implementations in here.
    void Start()
    {
		//Getting components of given asset
        rb2d = GetComponent<Rigidbody2D>();
    }

	//Executed if a collision appears and stays
    void OnCollisionStay2D(Collision2D coll)
    {
        // Groundcheck
        //if (coll.gameObject.layer == LayerMask.NameToLayer("Ground"))
        //{
            // Ground hit
        //}

		//Local variables
        float tolerance = .2f;
        Vector2 center = coll.collider.bounds.center;
        Vector2 collision = coll.contacts[0].point;
        Bounds bounds = coll.collider.bounds;

		//If collision point is somewhere on top and in the
		//middle of any sprite with collider2D
        if (collision.y > (center.y + bounds.size.y / 2) - tolerance && // is on top
            collision.x > center.x - bounds.size.x / 2 + tolerance && collision.x < center.x + bounds.size.x / 2 - tolerance) // is not on side
        {
            isInAir = false;
        }
    }

	//Executed on every physics update step
	void FixedUpdate()
    {
        // --- Controls --- //

        // Jumping
        if (Input.GetAxis("Jump") != 0 && !isInAir)
        {
            rb2d.AddForce(Vector2.up * jumpForce);
            isInAir = true;
        }

        // Moving
        // Accelerating
        float movementInput = Input.GetAxis("Horizontal");
        if (rb2d.velocity.sqrMagnitude < sqrMaxSpeed)
        {
            rb2d.AddForce(Vector2.right * movementInput * moveForce);
        }
        // Slowing down
        if ((movementInput == 0 || movementInput * rb2d.velocity.x < 0) && rb2d.velocity.sqrMagnitude > 0f)
        {
            rb2d.AddForce(rb2d.velocity.normalized * -stoppingForce);//Normalized returns the vector with a magnitude of 1
        }
        // Stopping
        if (Input.GetAxis("Crouch") != 0)
        {
            rb2d.rotation = 0;
			//set rotation position to root position
			this.transform.rotation.Set(0f, 0f, 0f, 0f);
            rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        else
        {
            rb2d.constraints = RigidbodyConstraints2D.None;
        }
    }
}
