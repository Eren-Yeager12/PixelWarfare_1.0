using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootingController : MonoBehaviour
{
    private Camera cam;
    public Vector3 mousepos;
    public GameObject bullet;
    public Transform bullettransform;
    public bool canfire;
    private float timer =0f;
    public float maxtimegap;
    
    public int bulletcount;

    public Text reloadline;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.GetComponent<Camera>();
        bulletcount = 50;
    }

    // Update is called once per frame
    void Update()
    {
        mousepos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mousepos - transform.position;

        float rotz = Mathf.Atan2(rotation.y,rotation.x)*Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f,0f,rotz);


        if(canfire == false){
            timer+= Time.deltaTime;
            if(timer >= maxtimegap){
                canfire = true;
                timer =0f;
            }
        }

        if(Input.GetMouseButton(0) && canfire == true){
            canfire = false;
            if(bulletcount != 0){
            Instantiate(bullet,bullettransform.position,Quaternion.identity); 
            bulletcount--;

            FindAnyObjectByType<AudioManager>().playsound("PlayerWalk");
            }
           
        }
        reloadline.text = bulletcount.ToString() + "/50";
    }

}