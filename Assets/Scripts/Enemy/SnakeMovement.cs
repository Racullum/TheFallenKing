using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    Animator anim;
    bool stopped = true;
    float initial_x_pos;
    private int right_counter = 0;
    private int left_counter = 0;
    private bool walking_right = true;
    public float sprite_speed;
    Transform trans;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        trans = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        initial_x_pos = rb.position.x;
    }

    private void flip()
    {
        trans.Rotate(trans.rotation.x, 180f, trans.rotation.z);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       
        if (!walking_right)
        {
          
            rb.velocity = new Vector2(-sprite_speed * Time.deltaTime, rb.velocity.y);


            right_counter = right_counter + 1;
      
            if (right_counter == 80)
            {

                walking_right = true;
                rb.velocity = new Vector2(0, rb.velocity.y);
                flip();
               
                right_counter = 0;
            }



        }



    
        else if (walking_right)
        {

           
            rb.velocity = new Vector2(sprite_speed * Time.deltaTime, rb.velocity.y);
            left_counter++;

            if (left_counter == 80)
            {

                walking_right = false;
                rb.velocity = new Vector2(0, rb.velocity.y);
                flip();
                left_counter = 0;
            }



        }

    }
}
