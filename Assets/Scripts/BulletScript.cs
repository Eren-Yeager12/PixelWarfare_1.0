using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Camera cam;
    private Vector3 mousepos;
    private Rigidbody2D bulletbody;
    private float speed  = 30;
    
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.GetComponent<Camera>();
        mousepos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousepos - transform.position;
        Vector3 rotation = transform.position - mousepos;
        bulletbody = gameObject.GetComponent<Rigidbody2D>();

        bulletbody.velocity = new Vector2(direction.x,direction.y).normalized*speed;
        float rot = Mathf.Atan2(rotation.y,rotation.x)*Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0,rot + 90);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Enemy"){
            Debug.Log("collision detected");
            Destroy(gameObject);
        }
    }
}
