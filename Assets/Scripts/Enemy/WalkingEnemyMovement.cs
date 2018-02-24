using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingEnemyMovement : MonoBehaviour {

    private Rigidbody2D rb;
    Animator anim;
    bool stopped = true;
    float initial_x_pos;
    private int right_counter = 0;
    private int left_counter = 0;
    private bool walking_right = false;
    public float sprite_speed;
    Transform trans;

    private void flip()
    {
        trans.Rotate(trans.rotation.x, 180f, trans.rotation.z);
    }


    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        trans = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        initial_x_pos = rb.position.x;
	}

    void Awake()
    {
        //QualitySettings.vSyncCount = 0;
        //Application.targetFrameRate = 60;

    }



    // Update is called once per frame
    void FixedUpdate () {
        //if we are at initial_x_pos + .5f then we need to turn around and go back to the initial_x_pos
        //if we are at the initial_x_pos then we need to go to initial_x_pos + .5f
        
        //if((rb.position.x > (initial_x_pos + .3f)))
        //{
        if (!walking_right)
        {
            //rb.velocity = new Vector2(rb.velocity.x - (sprite_speed * Time.deltaTime), rb.velocity.y);
            rb.velocity = new Vector2(-sprite_speed * Time.deltaTime, rb.velocity.y);
          
            
            right_counter = right_counter + 1;
       
            if (right_counter == 80)
            {
               
                walking_right = true;
                rb.velocity = new Vector2(0, rb.velocity.y);
                anim.SetBool("ZWalkingRight", true);
                flip();
                right_counter = 0;
            }

            

        }



        else if(walking_right)
        {

            //rb.velocity = new Vector2(rb.velocity.x + (sprite_speed * Time.deltaTime), rb.velocity.y);
            rb.velocity = new Vector2(sprite_speed * Time.deltaTime, rb.velocity.y);
            left_counter++;
           
            if (left_counter == 80)
            {
                flip();
                walking_right = false;
                rb.velocity = new Vector2(0, rb.velocity.y);
                anim.SetBool("ZWalkingRight", false);
                left_counter = 0;
            }

           

        }
   
	}
}
