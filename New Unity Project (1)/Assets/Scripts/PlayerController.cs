using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject Player;
    public GameObject Ball;
    
    public float maxSpeed = 5f;
    public float speed = 2f;
    public bool grounded;
    public Vector3 velocidad;
    public Vector3 BallPos;
    private Rigidbody2D rb2d;
    private Animator anim;
    public float JumpSonic = 6.5f;
    public float ballSpeed = 6.5f;
    public float Posy;
    private bool JumpD;
    public bool Jump;
    private bool InAir;
    private bool LaunchD;
    private bool Launch;
    


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
        anim.SetBool("Launch", Launch);
        


        if (Input.GetKeyDown(KeyCode.UpArrow) && grounded)
        {
            JumpD = true;
            
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            Launch = true;
            LaunchD = true;
            
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
            Jump = true;
            
            Debug.Log("Impulso");
            JumpD = false;
           
        }

        if (transform.localScale == new Vector3(2.5f, 2.5f, 1f))
        {
            Ball.transform.localScale = new Vector3(2f, 2f, 1f);
            velocidad = new Vector3(ballSpeed, 0f,0f);
            BallPos = Player.transform.position + new Vector3(0.87f, 0.27f, 0f);
        }
        else if (transform.localScale == new Vector3(-2.5f, 2.5f, 1f))
        {
            Ball.transform.localScale = new Vector3(-2f, 2f, 1f);
            velocidad = new Vector3(-ballSpeed,0f,0f);
            BallPos = Player.transform.position + new Vector3(-0.87f, 0.27f, 0f);
        }


        if (LaunchD)
        {
            Ball.gameObject.SetActive(true);
            Ball.transform.position = BallPos; //Player.transform.position + new Vector3(0.87f, 0.27f, 0f);
            Ball.GetComponent<Rigidbody2D>().velocity = velocidad;
           
            LaunchD = false;
            
            Debug.Log("Lanzamiento");
        }

        
            if (rb2d.velocity.y < 0)
        {
            Jump = false;

            InAir = true;
           
        }

        else InAir = false;
    }

    






}
