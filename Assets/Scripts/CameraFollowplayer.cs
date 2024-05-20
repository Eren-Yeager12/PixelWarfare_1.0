using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraFollowplayer : MonoBehaviour
{
    private Transform player;
    private Vector3 tempos;
    public float minX,maxX,maxY,minY;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        tempos = transform.position;
        tempos.x = player.position.x;
        tempos.y = player.position.y;

        if(tempos.x <minX){
            tempos.x = minX;
        }
        if(tempos.x > maxX){
            tempos.x = maxX;
        }

        if(tempos.y > maxY){
            tempos.y = maxY;
        }

        if(tempos.y < minY){
            tempos.y = minY;
        }

        transform.position = tempos;
    }
}
