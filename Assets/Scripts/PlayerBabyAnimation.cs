using UnityEngine;
using System.Collections;

public class PlayerBabyAnimation : MonoBehaviour {

	//Properties and fields
    private Animator anim;
    private Rigidbody2D rb2d;

	//Executed on startup. Initial implementations in here.
	void Start ()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
	}

	//Executed on every frame
	void Update ()
    {
	    // Immediately start rolling as soon as player presses anything
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Jump") != 0)
        {
            anim.SetBool("IsMoving", true);
        }
	}

	//Executed on fixed physics update steps
    void FixedUpdate()
    {
        if (rb2d.velocity.sqrMagnitude < .01f)
        {
            anim.SetBool("IsMoving", false);
        }
    }
}
