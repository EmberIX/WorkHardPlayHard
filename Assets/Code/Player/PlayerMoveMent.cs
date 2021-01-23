using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class PlayerMoveMent : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float CurrentSpeed = 5f;
    public Rigidbody2D rb;
    public Vector2 movement;
    public bool SideWalk;

    public float stamina;
    public float maxStamina;

    public float dashSpeed = 6;
    public float dashSpeed2 = 6;
    public float dashing;
    public float dashStoping = 0.1f;
    public float startDashing = 1.0f;
    public float dashDistance = 10;
    public bool isDash;
    public Animator animator;
    public Collider2D pColl;

    PlayerScript Ps;
    public ParticleSystem paSys;
    public Vector2 currentPosition;
    public Transform player;
    
    void Start()
    {
        Ps = GameObject.FindObjectOfType<PlayerScript>();
        CurrentSpeed = moveSpeed;
        dashing = startDashing;
    }

    // Update is called once per frame
    void Update()
    {
        if(Ps.isInteracted)
        {
            return;
        }



        currentPosition = new Vector2(player.position.x, player.position.y);

        if (isDash == false && Ps.isDamaged == false)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
        }

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if ((movement.x == 1 && movement.y == 1) || (movement.x == -1 && movement.y == -1) || (movement.x == 1 && movement.y == -1) || (movement.x == -1 && movement.y == 1))
        {
            SideWalk = true;
        }
        else
        {
            SideWalk = false;
        }

        if (Input.GetKeyDown("space") && (dashing >= startDashing) && (movement.x != 0 || movement.y != 0) && Ps.isDamaged == false)
        {
            isDash = true;
            animator.SetTrigger("Dash");
            Instantiate(paSys, transform.position, Quaternion.identity);
            SoundManagerScript.PlaySound(SoundManagerScript.roll);
        }
        
        if(dashing < startDashing && isDash==false)
        {
            
            dashing += Time.deltaTime;
            if(dashing >= startDashing)
            {
                dashing = startDashing;
            }
        }
        

    }

    void FixedUpdate()
    {
        if (Ps.isInteracted)
        {
            return;
        }

        if (SideWalk)
        {
            rb.MovePosition(rb.position + movement * (CurrentSpeed - 0.6f ) * Time.fixedDeltaTime);
        }

        if (SideWalk == false)
        {
            rb.MovePosition(rb.position + movement * CurrentSpeed * Time.fixedDeltaTime);
        }

        if (isDash)
        {
            Ps.isdashing = true;
            if (SideWalk)
            {

                //transform.position = Vector2.MoveTowards(transform.position, currentPosition + (movement * dashSpeed2) , dashDistance);
                if (Input.GetKey("w") || Input.GetKey("a"))
                {
                    rb.AddForce((transform.up + (-transform.right)) * (dashSpeed2 / 2));
                }

                if (Input.GetKey("w") || Input.GetKey("d"))
                {
                    rb.AddForce((transform.up + (transform.right)) * (dashSpeed2 / 2));
                }

                if (Input.GetKey("s") || Input.GetKey("d"))
                {
                    rb.AddForce(((-transform.up) + (transform.right)) * (dashSpeed2 / 2));
                }

                if (Input.GetKey("s") || Input.GetKey("a"))
                {
                    rb.AddForce(((-transform.up) + ((-transform.right))) * (dashSpeed2 / 2));
                }
            }
            if (!SideWalk)
            {
                //transform.position = Vector2.MoveTowards(transform.position, currentPosition + (movement * dashSpeed), dashDistance);

                if (Input.GetKey("w"))
                {
                    //print("Dashhhhh");
                    rb.AddForce(transform.up * dashSpeed);
                }
                if (Input.GetKey("s"))
                {
                    rb.AddForce(-transform.up * dashSpeed);
                }
                if (Input.GetKey("d"))
                {
                    rb.AddForce(transform.right * dashSpeed);
                }
                if (Input.GetKey("a"))
                {
                    rb.AddForce(-transform.right * dashSpeed);
                }
            }
            dashing -= Time.deltaTime;
            if (dashing <= 0)
            {
                isDash = false;
                Ps.isdashing = false;
                pColl.enabled = (true);
            }
        }

    }

    public void SideWayWalk()
    {
        if (SideWalk == true)
        {
            CurrentSpeed -= 0.5f;
        }
        if (SideWalk == false)
        {
            CurrentSpeed = moveSpeed;
        }
    }

    
}
