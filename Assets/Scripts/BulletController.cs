using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed = 5f;
    private Rigidbody2D _rb;
    private Vector2 _mousePosition;
    public Vector2 _direction;

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
        _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
         _direction = (_mousePosition - (Vector2)transform.position).normalized;
        _rb.velocity = _direction * _bulletSpeed;
      //print(_direction);
        //print(transform.position);
    }//Bullet move
    private void FixedUpdate()
    {
       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(this.gameObject);
    }
}//Class
