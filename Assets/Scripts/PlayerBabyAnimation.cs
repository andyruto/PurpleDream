using UnityEngine;
using System.Collections;

public class PlayerBabyAnimation : MonoBehaviour {

    private Animator anim;
    private Rigidbody2D rb2d;

	void Start ()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
	}
	
	void Update ()
    {
	    // Immediately start rolling as soon as player presses anything
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Jump") != 0)
        {
            anim.SetBool("IsMoving", true);
        }
        if (Input.GetAxis("Crouch") != 0)
        {
            anim.SetBool("IsMoving", false);
        }
	}

    void FixedUpdate()
    {
        if (rb2d.velocity.sqrMagnitude < .01f)
        {
            anim.SetBool("IsMoving", false);
        }
    }
}
