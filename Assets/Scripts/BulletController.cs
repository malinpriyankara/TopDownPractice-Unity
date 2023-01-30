using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed = 5f;
    private Rigidbody2D _rb;
    void Start()
    {
        _rb = this.gameObject.GetComponent<Rigidbody2D>();
    }//Start

    
    void Update()
    {
        BulletMove();
    }//Update
    private void BulletMove()
    {
        //transform.Translate(new Vector3(Input.mousePosition.x,Input.mousePosition.y,0) * _bulletSpeed * Time.deltaTime);
        _rb.AddForce(Input.mousePosition * _bulletSpeed*Time.deltaTime);
        //transform.Rotate(new Vector3(0, -90, 0), Space.Self);
    }//Bullet move
}//Class
