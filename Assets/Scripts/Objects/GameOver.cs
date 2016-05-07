using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Game Over");

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<Rigidbody2D>().MovePosition(transform.GetChild(0).position);
    }
}
