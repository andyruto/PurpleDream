using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float jumpForce = 1000f;
    public float moveForce = 10f;
    public float sqrMaxSpeed = Mathf.Pow(10f, 2);

    private Rigidbody2D rb2d;
    public bool isInAir;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void OnCollisionStay2D(Collision2D coll)
    {
        // Groundcheck
        if (coll.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            // Ground hit
            isInAir = false;
        }
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
            // Stopping
        if(Input.GetButtonUp("Horizontal")) // (vtll rüber in update)
        {
            rb2d.rotation = 0f;
            rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        if(Input.GetButtonDown("Horizontal"))
        {
            rb2d.constraints = RigidbodyConstraints2D.None;
        }
    }
}
