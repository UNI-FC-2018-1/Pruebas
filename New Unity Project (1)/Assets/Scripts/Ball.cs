using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public PlayerController player;
    // Start is called before the first frame update
    void Start()
    {

    }




    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Wall"))
        {
            gameObject.SetActive(false);
            transform.position = new Vector2(-4.58f, 4.8f);
            GetComponent<Rigidbody2D>().velocity = new Vector2(0f,0f);
            player.LaunchCond = true;

        }
    }

}

