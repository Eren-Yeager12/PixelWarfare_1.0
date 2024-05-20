using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class EnemyController : MonoBehaviour
{

    // Start is called before the first frame update
    private PlayerControllerScript playerControllerScript;
    private ShootingController shootingController;
    public GameObject player;
    public float speed;
    public float distancediffer;
    public float health;

    private Rigidbody2D rb;
    private Animator anim;

    private SpriteRenderer spr;
    public float distance;

     public bool knife;
     float kniftimer =0;
     float knifetimegap = 0.15f;
 
    void Awake(){
        playerControllerScript = GameObject.FindWithTag("Player").GetComponent<PlayerControllerScript>();
        shootingController = GameObject.FindWithTag("rotationpoint").GetComponent<ShootingController>();
        anim = gameObject.GetComponent<Animator>();
        spr = gameObject.GetComponent<SpriteRenderer>();
        
    }
    

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    
        rb = GetComponent<Rigidbody2D>();
        
        FindAnyObjectByType<AudioManager>().playsound("MonsterRoar");

       
    

           knife = true;
    }

    // Update is called once per frame
    void FixedUpdate(){
         distance =  Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position -  transform.position;
        direction.Normalize();

       if(distance < distancediffer) {
        transform.position =  Vector2.MoveTowards(transform.position, player.transform.position , speed*Time.deltaTime);
        anim.SetBool("chase",true);
       }else{
        anim.SetBool("chase", false);
       }

       if(distance > 2){
         anim.SetBool("attack", false);
       }

       if(player.transform.position.x < transform.position.x){
            spr.flipX = true;
       }else{
        spr.flipX = false;
       }

       if(SceneManager.GetActiveScene().name == "MainMenu"){
          Destroy(gameObject);
       }



    }
    

    void Update(){

       if(knife == false){
            kniftimer+= Time.deltaTime;
            if(kniftimer >= knifetimegap){
                knife = true;
                kniftimer = 0;
            }
            playerControllerScript.playerAnim.SetBool("knife", false);
        }

        if(Input.GetKeyDown(KeyCode.Mouse1) &&  knife == true ){
              knife =false;
            if(distance <2){
                health = health - 50f;
                 health = Mathf.Clamp(health,-10,199);
               playerControllerScript.health+=1;
            playerControllerScript.healthline.fillAmount = playerControllerScript.health/200;
            playerControllerScript.shootingController.bulletcount = Mathf.Clamp(shootingController.bulletcount, 0,30);
            playerControllerScript.shootingController.bulletcount+=20;
            }
             playerControllerScript.playerAnim.SetBool("knife", true);
        }


         if(health <= 0){
                    playerControllerScript.score++;
              //     playerControllerScript.health += 15;
               //    playerControllerScript.healthline.fillAmount = health/200;
               //    shootingController.bulletcount += 8;
                     Destroy(gameObject);
                     
                }
    }

    void OnCollisionEnter2D(Collision2D col){

            if(col.gameObject.CompareTag("jump")){
                rb.AddForce(Vector2.up * 400f);
             //    FindAnyObjectByType<AudioManager>().playsound("MonsterRoar");
            }

            if(col.gameObject.CompareTag("Bullet")){
                health = health - 10;
           //      FindAnyObjectByType<AudioManager>().playsound("MonsterRoar");
               
            }

            if(col.gameObject.CompareTag("Player")){
                anim.SetBool("attack",true);
            //    FindAnyObjectByType<AudioManager>().playsound("MonsterRoar");
    
                
            }

    
    }

  
    
}
