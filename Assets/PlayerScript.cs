using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float playerHealth = 200;
    public int playerDamage = 1;
    public float playerSpeed = 5f;

    public float XMove;
    public float YMove;

    public Animator anim;

    public EnemyScript es;
    public EnemyManager em;
    public GameObject enemyObject;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        walk();
        run();
        attack();
        roll();
        enemyHPControl();
    }
    void FixedUpdate()
    {

    }

    void enemyHPControl()
    {
        if(Input.GetKey(KeyCode.Q))
        {
            em.curHP = 30;
        }
        if (Input.GetKey(KeyCode.E))
        {
            em.curHP = 0;
        }

    }

    public void OnDamage(float dmgDealt)
    {
        playerHealth = playerHealth - dmgDealt;
        Debug.Log(playerHealth);
    }
    void walk()
    {
        XMove = Input.GetAxis("Horizontal");
        YMove = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(XMove, 0.0f, YMove);
        transform.position += movement * playerSpeed * Time.deltaTime;

        anim.SetBool("isAttacking", false);
        anim.SetBool("isRolling", false);
        anim.SetBool("isRunning", false);

        if (Mathf.Abs(XMove) > 0 || Mathf.Abs(YMove) > 0)
        {
            transform.rotation = Quaternion.LookRotation(movement);
            anim.SetBool("isIdle", false);
            anim.SetBool("isWalking", true);


        }
        else
        {
            anim.SetBool("isWalking", false);
            anim.SetBool("isIdle", true);
        }


    }

    void run()
    {
        if ((Mathf.Abs(XMove) > 0 || Mathf.Abs(YMove) > 0) && Input.GetKey(KeyCode.LeftShift))
        {
            playerSpeed = 10f;
            anim.SetBool("isIdle", false);
            anim.SetBool("isAttacking", false);
            anim.SetBool("isRolling", false);
            anim.SetBool("isRunning", true);
            anim.SetBool("isWalking", false);
        }
        else if ((Mathf.Abs(XMove) > 0 || Mathf.Abs(YMove) > 0) && Input.GetKeyUp(KeyCode.LeftShift))
        {
            playerSpeed = 5f;  // set the player's speed back to the default value
            anim.SetBool("isIdle", false);
            anim.SetBool("isAttacking", false);
            anim.SetBool("isRolling", false);
            anim.SetBool("isRunning", false);
            anim.SetBool("isWalking", true);
        }   
    }

    void attack()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            anim.SetBool("isIdle", false);
            anim.SetBool("isAttacking", true);
            anim.SetBool("isRolling", false);
            anim.SetBool("isRunning", false);
            anim.SetBool("isWalking", false);
        }
        else if(Input.GetKeyUp(KeyCode.Mouse0))
        {
            anim.SetBool("isIdle", true);
            anim.SetBool("isAttacking", false); ;
            anim.SetBool("isRolling", false);
            anim.SetBool("isRunning", false);
            anim.SetBool("isWalking", false);
        }
        else if ((Mathf.Abs(XMove) > 0 || Mathf.Abs(YMove) > 0) && Input.GetKeyUp(KeyCode.Mouse0))
        {
            anim.SetBool("isIdle", false);
            anim.SetBool("isAttacking", true); ;
            anim.SetBool("isRolling", false);
            anim.SetBool("isRunning", true);
            anim.SetBool("isWalking", false);
        }
    }

    void roll()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            anim.SetBool("isIdle", false);
            anim.SetBool("isAttacking", false); ;
            anim.SetBool("isRolling", true);
            anim.SetBool("isRunning", false);
            anim.SetBool("isWalking", false);
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            anim.SetBool("isIdle", false);
            anim.SetBool("isAttacking", false); ;
            anim.SetBool("isRolling", false);
            anim.SetBool("isRunning", false);
            anim.SetBool("isWalking", true);
        }
    }

}



