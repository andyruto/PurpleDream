using UnityEngine;
using System.Collections;

public class PlayerBabyMovement : MonoBehaviour
{
    public float jumpForce = 1000f;
    public float moveForce = 10f;
    public float sqrMaxSpeed = Mathf.Pow(10f, 2);
    public float stoppingForce = 5f;
    public bool isInAir;

    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void OnCollisionStay2D(Collision2D coll)
    {
        // Groundcheck
        //if (coll.gameObject.layer == LayerMask.NameToLayer("Ground"))
        //{
            // Ground hit
            isInAir = false;
        //}
    }

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
            rb2d.AddForce(rb2d.velocity.normalized * -stoppingForce);
        }
            // Stopping
        if (Input.GetAxis("Crouch") != 0)
        {
            rb2d.rotation = 0;
            rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        else
        {
            rb2d.constraints = RigidbodyConstraints2D.None;
        }
    }
}
