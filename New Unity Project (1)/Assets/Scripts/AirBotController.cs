using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AirBotController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Animator anim;
    public GameObject player;
    public float velocidad_bot=1f;
    public float maxSpeed=1f;

    private void velocidad_horizontal()
    {
        rb2d.AddRelativeForce(Vector2.left * velocidad_bot);
        float limitedspeed = Mathf.Clamp(rb2d.velocity.x, -maxSpeed, maxSpeed);
        rb2d.velocity = new Vector2(limitedspeed,rb2d.velocity.y);
    }
    private void velocidad_vertical()
    {
        rb2d.AddRelativeForce(Vector2.up * velocidad_bot);
        float limitedspeed = Mathf.Clamp(rb2d.velocity.y, -maxSpeed, maxSpeed);
        rb2d.velocity = new Vector2(rb2d.velocity.x, limitedspeed);
    }
    
    private void Detenerse()
    {
        rb2d.bodyType= RigidbodyType2D.Static;
       
        
    }

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            velocidad_horizontal();
            if (Mathf.Abs(rb2d.velocity.x) >= maxSpeed)
            {
                Detenerse();
                rb2d.bodyType = RigidbodyType2D.Dynamic;
                Debug.Log("Detenerse");
            }
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            velocidad_vertical();
            if (Mathf.Abs(rb2d.velocity.y) >= maxSpeed)
            {
                Detenerse();
                rb2d.bodyType = RigidbodyType2D.Dynamic;
                Debug.Log("Detenerse");
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }




}
