using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    public Text highscoretext;
   
  
     float scr;
    // Start is called before the first frame update
    void Start()
    {
     //   playerControllerScript  = GameObject.FindWithTag("Player").GetComponent<PlayerControllerScript>();
      highscoretext.text = "HighScore : " + PlayerPrefs.GetInt("Highscore",0).ToString();
     
    
    }


    // Update is called once per frame
    void LateUpdate()
    {
      scr =  GamePlayuiscript.sc ;
      
      if(scr > PlayerPrefs.GetInt("Highscore",0)){
          PlayerPrefs.SetInt("Highscore",(int)scr);
          highscoretext.text = "Highscore : " + scr.ToString();
      }   
        
    }

    public void playgame(){
       FindAnyObjectByType<AudioManager>().playsound("ButtonClick");
        SceneManager.LoadScene("GamePlay");
    }

    public void resethighscore(){
      FindAnyObjectByType<AudioManager>().playsound("ButtonClick");
      PlayerPrefs.DeleteKey("Highscore");
      highscoretext.text = "Highscore : " + 0.ToString();
    }

    public void Quitgame(){
        UnityEngine.Application.Quit();
        FindAnyObjectByType<AudioManager>().playsound("ButtonClick");
        
    }
    public void buttonsound(){
      FindAnyObjectByType<AudioManager>().playsound("ButtonClick");
    }
}
