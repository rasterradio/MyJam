using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlatformerController : PhysicsObject
{

    //public float maxSpeed = 7;
    //public float jumpTakeOffSpeed = 7;

    public float moveSpeed = 150f;
    public float gravity = 600f;
    public bool locked = false;
    public float dashCharge = 100f;
    //public velocity = Vector2(0,0);

    public float maxSpeed = 3f;
    public float decel = 0.3f;

    public float jumpStrength = 5f;
    public float dashStrength = 6f;

    public double dx = 0f;
    public double dy = 0f;



    public string playerState;

    public GameObject bulletPrefab;
    public Transform bulletSpawn;

    AudioSource audioData;

    private SpriteRenderer spriteRenderer;

    void awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioData = GetComponent<AudioSource>();

    }

    void update()
    {
        /*if (grounded)
            playerState = "grounded";
        else
            playerState = "jumping";*/

        dashCharge = dashCharge + 40; //dash recharge
        if (dashCharge > 100)
            dashCharge = 100;

        if (!locked)
        {
            //keypress
        }
    }

    void stopKick()
    {
        if (locked)
        {
            locked = false;
            gravity = 600f;
            //self.hitbox:rotate(math.rad(-90))
		    //self.hitbox:scale(0.5)
        }
        else
            return;
    }

    void kickRecoil()
    {
        if (locked)
        {
		    dy = -200;
		    dx = dx * -0.2;
		    gravity = 600f;
        }
        //self.bounceSound:rewind()
	    //self.bounceSound:play()
    }

    /*void onHitBy()
    {
        if (hp < 0)
        {
            hp = 0;
            locked = true;
            if (facingLeft)
            {
                currAnim = hurtLeftAnim;
                dx = 100;
            }
            if (facingRight)
            {
                currAnim = hurtRightAnim;
                dx = -100;
            }
            audio.stop();
            deadsound.play();
            gameState = death();
            //still need to do breakpoint

        }
    }*/

    protected override void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;

        move.x = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            //velocity.y = jumpTakeOffSpeed;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            if (velocity.y > 0)
            {
                velocity.y = velocity.y * 0.5f;
            }
        }

        if (Input.GetButtonDown("Fire1"))
        {
            //shoot();
        }

        bool flipSprite = (spriteRenderer.flipX ? (move.x > 0.01f) : (move.x < 0.01f));
        if (flipSprite)
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }

        targetVelocity = move * maxSpeed;
    }

    /*void shoot()
    {
        var bullet = (GameObject)Instantiate(
            bulletPrefab,
            bulletSpawn.position,
            bulletSpawn.rotation);

        //audioData = GetComponent<AudioSource>();
        audioData.Play(0);

        bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.forward * 6;
        Destroy(bullet, 2.0f);
	}*/
}
