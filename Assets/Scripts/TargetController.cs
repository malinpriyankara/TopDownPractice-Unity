using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
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
    }//Target move

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet")) Instantiate(_enemy, this.gameObject.transform.position, Quaternion.identity);
    }
}//Class
