using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yeniOlan : MonoBehaviour
{
    public float speed;

    public Transform[] movePoints;

    private int randompos;


    void Start()
    {

        randompos = Random.Range(0, movePoints.Length);

    }

    
    void Update()
    {

        transform.position= Vector2.MoveTowards(
            transform.position,
            movePoints[randompos].position,
            speed*Time.deltaTime);

        if(Vector2.Distance(transform.position, movePoints[randompos].position)<0.1f)
        {
            randompos = Random.Range(0, movePoints.Length);
        }
        
    }
}
