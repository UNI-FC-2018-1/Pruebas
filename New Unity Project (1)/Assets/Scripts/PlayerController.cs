using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float maxSpeed = 5f;
    public float speed = 2f;
    public bool grounded;
    private Rigidbody2D rb2d;
    private Animator anim;
    public float JumpSonic = 6.5f;
    private bool JumpD;
    public bool Jump;
    private bool InAir;
    private bool Fall;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }
    void Update()
    {
        anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));
        anim.SetBool("Grounded", grounded);
        anim.SetBool("Jump", Jump);
        anim.SetBool("InAir", InAir);
        anim.SetBool("Fall", Fall);
        if (Input.GetKeyDown(KeyCode.UpArrow) && grounded)
        {
            JumpD = true;
            
        }

        
        
  
       

    }   
    // Update is called once per frame
    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");

        rb2d.AddForce(Vector2.right * speed * h);

        float limitedspeed = Mathf.Clamp(rb2d.velocity.x,-maxSpeed,maxSpeed);
        rb2d.velocity = new Vector2(limitedspeed, rb2d.velocity.y);

        if (h > 0.1f)
        {
            transform.localScale = new Vector3(2.5f, 2.5f, 1f);
        }
        if (h < -0.1f)
        {
            transform.localScale = new Vector3(-2.5f, 2.5f, 1f);
        }
        if (Mathf.Abs(rb2d.velocity.x) <=maxSpeed*0.9)
        {
            rb2d.velocity = new Vector2(0f, rb2d.velocity.y);
        }
        if (JumpD)
        {
            rb2d.AddForce(Vector2.up * JumpSonic, ForceMode2D.Impulse);
            
            JumpD = false;
           
        }
        Debug.Log(rb2d.velocity.x);

        


    }

   

    /*void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("LimitCol"))
        {
            Jump = false;
            InAir = true;
            Debug.Log("Salió del triger");
        }
    }*/

    /*private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("LimitCol"))
        {
            InAir = false;
        }
    }*/



}
