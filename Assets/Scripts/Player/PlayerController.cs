using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    Transform trans;
    private Rigidbody2D rb;
    bool in_air = false;
    int times_jumped = 0;

    public bool onLadder = false;
    private bool moving_left, moving_right, moving_up, moving_down = false;

    //ANIMATION
    private Animator anim;

    //HEALTH 
    private HealthSystem hs;
    private bool can_take_damage = true;
    private int health = 3;

    //KEY/CHEST SYSTEM
    private KeySystem keySystem;
    public bool can_open_chest = false;
    private int key_count = 0;
    public GameObject chest;
    public Sprite chest_opened;
    
    


	// Use this for initialization
	void Start () {
        keySystem = FindObjectOfType<KeySystem>();
        hs = FindObjectOfType<HealthSystem>();
        trans = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
       

	}

    public void moveUp()
    {
        moving_up = true;
    }

    public void moveDown()
    {
        moving_down = true;
    }

    public void moveLeft()
    {
        flip();
        anim.SetBool("isWalking", true);
        moving_left = true;
        
    }

    public void moveRight()
    {
        anim.SetBool("isWalking", true);
        moving_right = true;

    }

    public void openChest()
    {
        
        if (can_open_chest)
        {
            // chestAnim.SetBool("isOpened", true);
            chest.GetComponent<ChestController>().decrementKeys();
            key_count++;
            chest.GetComponentInChildren<SpriteRenderer>().sprite = chest_opened;
            keySystem.incrementKeys(key_count);
            
            
        }
    }

    public void jump()
    {
        if (rb.velocity.y == 0)
        {
            times_jumped = 0;
            in_air = true;
            rb.AddForce(Vector2.up * 200f);
            times_jumped++;
        }
        else
        {
            
            if(times_jumped < 2)
            {
                rb.AddForce(Vector2.up * 100f);
                times_jumped++;
            }
           
        }
      
    }

  

   

    public void stopMovement()
    {
        if(moving_left)
        {
            flip();
        }
        moving_right = false;
        moving_left = false;
        moving_down = false;
        moving_up = false;
        rb.velocity = new Vector2(0, 0);
        anim.SetBool("isWalking", false);
    }

    public int getHealth()
    {
        return health;
    }

    IEnumerator turnDamageOff()
    {
        Color temp = gameObject.GetComponentInChildren<SpriteRenderer>().color;
        temp.a = .3f;
        gameObject.GetComponentInChildren<SpriteRenderer>().color = temp;
        yield return new WaitForSeconds(1.3f);
        temp.a = 1;
        gameObject.GetComponentInChildren<SpriteRenderer>().color = Color.white;
        can_take_damage = true;
    }

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag.Equals("Enemy"))
        {
            if (can_take_damage)
            {
                Color temp;
                health--;
                temp = gameObject.GetComponentInChildren<SpriteRenderer>().color;
                gameObject.GetComponentInChildren<SpriteRenderer>().color = Color.red;

                gameObject.GetComponent<AudioSource>().Play();
                hs.decreaseHearts(health);
                can_take_damage = false;
                StartCoroutine(turnDamageOff());



            }

        }

 
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.collider.tag.Equals("Enemy"))
        {
            //gameObject.GetComponentInChildren<SpriteRenderer>().color = Color.white;
        }
    }

    //HELPER METHODS
    private void flip()
    {
        trans.Rotate(trans.rotation.x, 180f, trans.rotation.z);
    }

    public int getNumKeys()
    {
        return key_count;
    }

  

    // Update is called once per frame
    void Update () {

        
         if (onLadder)
         {
            rb.gravityScale = 0;
            if (moving_up)
            {
                Debug.Log("We are moving up");
                
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y + .15f);

            }
         }
        

        if(onLadder)
        {
            if(moving_down)
            {
                
                Debug.Log("We are moving down");
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y - .15f);
            }
        }

        
       
        if(moving_left)
        {
            rb.velocity = new Vector2(rb.velocity.x - .20f, rb.velocity.y); 
        }
		
        if(moving_right)
        {
            rb.velocity = new Vector2(rb.velocity.x + .20f, rb.velocity.y);
        }

        if((health == 0) || (trans.position.y <= -4.5))
        {
            trans.position = new Vector3(-18.09f, -2.89f, 0);

            health = 3;

            hs.decreaseHearts(health);
        }
	}
}
