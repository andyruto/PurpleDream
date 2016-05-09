//Using namespaces
using UnityEngine;
using System.Collections;

public class PlayerBabyAnimation : MonoBehaviour {
	//Properties and fields
	//private
    private Animator anim;
    private Rigidbody2D rb2d;

	//Executed on startup. Initial implementations in here.
	void Start ()
    {
		//Get components of given asset
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
        if (Input.GetAxis("Crouch") != 0)
        {
            anim.SetBool("IsMoving", false);
        }
	}

	//Executed on fixed physics update steps
    void FixedUpdate()
    {
		//Stop rolling animaton if the velocity magnitute
		//gets lower then a specific value
        if (rb2d.velocity.sqrMagnitude < .01f)
        {
            anim.SetBool("IsMoving", false);
			rb2d.rotation = 0;
			this.transform.rotation.Set(0f, 0f, 0f, 0f);
        }
    }
}
