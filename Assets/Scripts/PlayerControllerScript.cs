using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerControllerScript : MonoBehaviour
{
    
    public float force;
    private Rigidbody2D playerbody;
    private SpriteRenderer playersprite;
    private SpriteRenderer spr;

    public Animator playerAnim;
    private float movementX;

     private bool Landed;
     public float health;
     public float score;
     
     public UnityEngine.UI.Image healthline;
     public  ShootingController shootingController;

    private EnemyController enemyController;

    public GameObject GOP;
    //  public bool knife;
    //  float kniftimer =0;
    //  float knifetimegap = 0.15f;
    
    // Start is called before the first frame update
    void Start()
    {
        playerbody = gameObject.GetComponent<Rigidbody2D>();
        playerAnim = gameObject.GetComponent<Animator>();
        playersprite = gameObject.GetComponent<SpriteRenderer>();
        spr = GameObject.FindWithTag("rotationpoint").GetComponent<SpriteRenderer>();
        enemyController = GameObject.FindWithTag("Enemy").GetComponent<EnemyController>();

        // knife = false;

      //  StartCoroutine(footsteps());
    
    }

    void Update(){
        PlayerJump();

        // if(knife == false){
        //     kniftimer+= Time.deltaTime;
        //     if(kniftimer >= knifetimegap){
        //         knife = true;
        //         kniftimer = 0;
        //     }
        //     playerAnim.SetBool("knife", false);
        // }
        PlayerKnife();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Playermovement();
        playerWalk();
        playerJump();
    }

    void Playermovement(){
        movementX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movementX,0f,0f)*Time.deltaTime*8f;
    }

    void PlayerJump(){
        if((Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && Landed == true){
            playerbody.AddForce(new Vector2(0f,force),ForceMode2D.Impulse);
            Landed = false;
            
        }
    }

    void PlayerKnife(){
        // if(Input.GetKeyDown(KeyCode.Mouse1) && knife == true){
        //     knife = false;
        //     playerAnim.SetBool("knife", true);

            // health = Mathf.Clamp(health,0,195);
            // health+=5;
            // healthline.fillAmount = health/200;
            // shootingController.bulletcount = Mathf.Clamp(shootingController.bulletcount, 0,19);
            // shootingController.bulletcount+=5;
            
     //   }
        
    }

   
    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("jump")){
            Landed = true;
        }

        if(collision.gameObject.CompareTag("Enemy")){
            health = health - 10;
            healthline.fillAmount = health/200;
            if(health <= 0){
                Destroy(gameObject);
                GOP.SetActive(true);
                SceneManager.LoadScene(0);
            }
        }
   }

   private void playerWalk(){
       if(movementX > 0 && Landed == true){
         playerAnim.SetBool("walk", true);
      //   FindAnyObjectByType<AudioManager>().playsound("PlayerWalk");
     //    playersprite.flipX = false;
      //   spr.flipX = false;
        
        }
       else if(movementX <0 && Landed == true){
        playerAnim.SetBool("walk", true);
    //    FindAnyObjectByType<AudioManager>().playsound("PlayerWalk");
    //    playersprite.flipX = true;
     //   spr.flipX = true;
       }
        else{
         playerAnim.SetBool("walk", false);
        }

        if(shootingController.mousepos.x > transform.position.x){
            playersprite.flipX = false;
        }else{
            playersprite.flipX = true;
        }

    }

    private void playerJump(){

         if(Landed == false){
            playerAnim.SetBool("jump", true);
        }
        else{
            playerAnim.SetBool("jump", false);
        }
    }

    // private IEnumerator footsteps(){
        
    //     while(true){

    //         if(movementX != 0) {
    //         yield return new WaitForSeconds(2f);
            
    //         FindAnyObjectByType<AudioManager>().playsound("PlayerWalk");
    //         }else{
    //             break;
    //         }

    //         yield return new WaitForSeconds(0.5f);
    //     }
    // }

   
 }
