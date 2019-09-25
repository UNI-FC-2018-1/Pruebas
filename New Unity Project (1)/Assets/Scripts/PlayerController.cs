using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
  
    public GameObject Player;
    public GameObject Ball;
    public GameObject Detroit_Smash;
    public bool LaunchCond=true;
    public bool detroitCond= true;
    public float maxSpeed = 5f;
    public float speed = 2f;
    public bool grounded;
    public Vector3 velocidad;
    public Vector3 BallPos;
    public Vector3 DetroitPos;
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
    public float Dash=20f;
    public bool dash=false;
    public float Wait;
    private bool detroit;
    private bool detroitD;

    /* public IEnumerator Wait()
     {
         yield return new WaitForSeconds(0.2f);
         Launch = false;
         Debug.Log("retrasos");
     }*/
    ///Rutina de espera para el lanzamiento de bola
    ///

    public IEnumerator WaitDash()
    {
        yield return new WaitForSeconds(Wait);
        dash = false;
        rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;
        Debug.Log("retraso");
    }
    public IEnumerator WaitBall()
    {
        LaunchCond = false;
        yield return new WaitForSeconds(0.4f);
        Launch = false;
        Ball.gameObject.SetActive(true);
        Ball.transform.position = BallPos;
        Ball.GetComponent<Rigidbody2D>().velocity = velocidad;
    }

    public IEnumerator WaitDetroit()
    {
        detroitCond=false;
        yield return new WaitForSeconds(0.4f);
        detroit = false;
        Detroit_Smash.gameObject.SetActive(true);
        Detroit_Smash.transform.position = DetroitPos;
        Detroit_Smash.GetComponent<Rigidbody2D>().velocity = velocidad;
    }





    // Start is called before the first frame update    
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
    }
    void Update()
    {
        //////animaciones 
        anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));
        anim.SetBool("Grounded", grounded);
        anim.SetBool("Jump", Jump);
        anim.SetBool("InAir", InAir);
        anim.SetBool("Launch", Launch);
        anim.SetBool("ShiftDash", dash);
        anim.SetBool("Detroit", detroit);

        ///Salto detectando el piso con condición
        ///
        if (Input.GetKeyDown(KeyCode.UpArrow) && grounded)
        {
            JumpD = true;

        }
        ///////////////////////////////////////////////7
        //////////////Dash
        if (Input.GetKeyDown(KeyCode.Z) && Input.GetKey(KeyCode.RightArrow) && Mathf.Abs(rb2d.velocity.x)>=maxSpeed)
        {
            
            rb2d.AddRelativeForce(Vector2.right * Dash, ForceMode2D.Force);
            rb2d.constraints = RigidbodyConstraints2D.FreezePositionY| RigidbodyConstraints2D.FreezeRotation;
            Debug.Log("dash derecho");
            dash = true;
            StartCoroutine(WaitDash());
            
        }

        else if (Input.GetKeyDown(KeyCode.Z) && Input.GetKey(KeyCode.LeftArrow) && Mathf.Abs(rb2d.velocity.x)>=maxSpeed)
        {
            rb2d.AddForce(Vector2.left * Dash, ForceMode2D.Force);
            rb2d.constraints= RigidbodyConstraints2D.FreezePositionY| RigidbodyConstraints2D.FreezeRotation;
            Debug.Log("dash izquierdo");
            dash = true;
            StartCoroutine(WaitDash());
        }
        
        }



    // Update is called once per frame
    void FixedUpdate()
    {

        ////////////////////////////////////////////////////
        ///DETROIT SMASH
        ///

        if (Input.GetKeyDown(KeyCode.C) && detroitCond)
        {
            detroit = true;
            detroitD = true;
            if (transform.localScale == new Vector3(2.5f, 2.5f, 1f))
            {
                Detroit_Smash.transform.localScale = new Vector3(1f, 1f, 1f);
                //velocidad = new Vector3(ballSpeed, 0f, 0f);
                //BallPos = Player.transform.position + new Vector3(0.87f, 0.27f, 0f);
            }
            else if (transform.localScale == new Vector3(-2.5f, 2.5f, 1f))
            {
                Detroit_Smash.transform.localScale = new Vector3(-1f, 1f, 1f);
                //velocidad = new Vector3(-ballSpeed, 0f, 0f);
                //BallPos = Player.transform.position + new Vector3(-0.87f, 0.27f, 0f);
            }



        }





            /////////////////////////////////////////////////////




            /////////////Lanzamiento de bola inicial

            if (Input.GetKeyDown(KeyCode.X) && LaunchCond && grounded)
        {
            Launch = true;
            LaunchD = true;

            if (transform.localScale == new Vector3(2.5f, 2.5f, 1f))
            {
                Ball.transform.localScale = new Vector3(2f, 2f, 1f);
                //velocidad = new Vector3(ballSpeed, 0f, 0f);
                //BallPos = Player.transform.position + new Vector3(0.87f, 0.27f, 0f);
            }
            else if (transform.localScale == new Vector3(-2.5f, 2.5f, 1f))
            {
                Ball.transform.localScale = new Vector3(-2f, 2f, 1f);
                //velocidad = new Vector3(-ballSpeed, 0f, 0f);
                //BallPos = Player.transform.position + new Vector3(-0.87f, 0.27f, 0f);
            }

        }


            ///////////////MOVIMIENTO DE BALL
        if (transform.localScale == new Vector3(2.5f, 2.5f, 1f))
        {
            //Ball.transform.localScale = new Vector3(2f, 2f, 1f);
            velocidad = new Vector3(ballSpeed, 0f, 0f);
            BallPos = Player.transform.position + new Vector3(0.87f, 0.27f, 0f);
        }
        else if (transform.localScale == new Vector3(-2.5f, 2.5f, 1f))
        {
            //Ball.transform.localScale = new Vector3(-2f, 2f, 1f);
            velocidad = new Vector3(-ballSpeed, 0f, 0f);
            BallPos = Player.transform.position + new Vector3(-0.87f, 0.27f, 0f);
        }



        ////////////////MOVIMIENTO DE DETROIT SMASH
        if (transform.localScale == new Vector3(2.5f, 2.5f, 1f))
        {
            //Ball.transform.localScale = new Vector3(2f, 2f, 1f);
            velocidad = new Vector3(ballSpeed, 0f, 0f);
            DetroitPos = Player.transform.position + new Vector3(0.87f, 0f, 0f);
        }
        else if (transform.localScale == new Vector3(-2.5f, 2.5f, 1f))
        {
            //Ball.transform.localScale = new Vector3(-2f, 2f, 1f);
            velocidad = new Vector3(-ballSpeed, 0f, 0f);
            DetroitPos = Player.transform.position + new Vector3(-0.87f, 0f, 0f);
        }


        ////////////Movimiento en X
        ///
        float h = Input.GetAxis("Horizontal");

        rb2d.AddForce(Vector2.right * speed * h);

        float limitedspeed = Mathf.Clamp(rb2d.velocity.x, -maxSpeed, maxSpeed);
        rb2d.velocity = new Vector2(limitedspeed, rb2d.velocity.y);

        if (h > 0.1f)
        {
            transform.localScale = new Vector3(2.5f, 2.5f, 1f);


        }
        if (h < -0.1f)
        {
            transform.localScale = new Vector3(-2.5f, 2.5f, 1f);


        }
        /*if (Mathf.Abs(rb2d.velocity.x) <= maxSpeed * 0.9)
        {
            rb2d.velocity = new Vector2(0f, rb2d.velocity.y);
        }*/

        /////////SALTO
        if (JumpD)
        {
            rb2d.AddForce(Vector2.up * JumpSonic, ForceMode2D.Impulse);
            Jump = true;

            Debug.Log("Impulso");
            JumpD = false;

        }
        ////////////////////////////////////7
        

////////////Lanzamiento de bola
        if (LaunchD)
        {
             //Player.transform.position + new Vector3(0.87f, 0.27f, 0f);
            StartCoroutine(WaitBall());

            //StartCoroutine(Wait());
            
            LaunchD = false;
            Debug.Log("Lanzamiento");
        }

        if(detroitD)
        {
            StartCoroutine(WaitDetroit());
            detroitD = false;
            Debug.Log("Detroit Smash!!!");
        }

        ///////Condición de Air
        if (rb2d.velocity.y < 0)
        {
            Jump = false;

            InAir = true;

        }

        else InAir = false;
        ////////////////////////////////
        ///

        ////////Movimiento del Dash
        
    }
    ////////////////////////////




}

    
