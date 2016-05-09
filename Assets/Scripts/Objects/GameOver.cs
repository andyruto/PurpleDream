//Using namespaces
using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour
{
	//Executed if an collider2D trigger started
    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("Game Over");

        GameObject player = GameObject.FindGameObjectWithTag("Player");
		//Reset player position
        player.GetComponent<Rigidbody2D>().MovePosition(transform.GetChild(0).position);

		//ToDo: Let Player only fall straight down and delete
		//      all forces.
    }
}
