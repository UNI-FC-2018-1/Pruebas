using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prueba : MonoBehaviour
{
    public GameObject PlayerPos;
    public GameObject Target;
    private Transform target;
    private Vector3 targetPos;
    private Vector3 thisPos;
    private float angle;
    private Rigidbody2D rb2d;
    public float Fuerza;
    private bool Cond2;



    void Start()
    {
        target = Target.GetComponent<Transform>();
        rb2d = GetComponent<Rigidbody2D>();

    }

    void Rotation()
    {

        targetPos = PlayerPos.GetComponent<Transform>().position;

        thisPos = transform.position;
        targetPos.x = targetPos.x - thisPos.x;
        targetPos.y = targetPos.y - thisPos.y;
        angle = Mathf.Atan2(targetPos.y, targetPos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

    }



    void TargetImpulse()
    {
        rb2d.AddForce(new Vector2(targetPos.x, targetPos.y).normalized * Fuerza);

    }





    void FixedUpdate()
    {

        rb2d.bodyType = RigidbodyType2D.Static;
        bool Cond;

        if (Mathf.Abs(target.GetComponent<Rigidbody2D>().velocity.x) == 0 && Mathf.Abs(target.GetComponent<Rigidbody2D>().velocity.y) == 0)
        {
            Cond = true;
        }
        else Cond = false;




        ///////////////////////////////////////////////////
        if (Cond2 == true && Cond == true)
        {
            PlayerPos.GetComponent<Transform>().position = target.position;
            
            
        }
        Rotation();
        rb2d.bodyType = RigidbodyType2D.Dynamic;
        TargetImpulse();


        //////////////////////////////////////////////////////////7
    }




        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("PosRef"))
            {
                Cond2 = true;
                rb2d.bodyType = RigidbodyType2D.Static;
                Debug.Log("Trigger active");
            }
            else
            {
                Cond2 = false;
                Debug.Log("Trigger off");
            }

        }

    
}