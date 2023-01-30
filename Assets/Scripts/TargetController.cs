using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
   
    void Start()
    {
        
    }//Start

   
    void Update()
    {
        TragetMove();
    }//Update
    private void TragetMove()
    {
        Vector2 _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position=Vector2.Lerp(transform.position,_mousePosition,50*Time.deltaTime);
    }
}//Class
