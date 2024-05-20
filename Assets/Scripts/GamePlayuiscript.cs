using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePlayuiscript : MonoBehaviour
{
    public Text scoretext;
   
    PlayerControllerScript playerControllerScript;
    public static float sc;

  
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.FindWithTag("Player").GetComponent<PlayerControllerScript>();
   
        
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        sc = playerControllerScript.score;
        scoretext.text = "Score : " + sc;

        
    }

    public void home(){
        FindAnyObjectByType<AudioManager>().playsound("ButtonClick");
        SceneManager.LoadScene(0);
    }
    public void pause(){
        FindAnyObjectByType<AudioManager>().playsound("ButtonClick");
        if(Time.timeScale == 1){
            Time.timeScale = 0;
        }else{
            Time.timeScale = 1;
        }
    }

}
