using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    [SerializeField] private GameObject _player;
<<<<<<< HEAD
    [SerializeField] private GameObject _spawnPoint;
    [SerializeField] private float _bulletSpeed;
    private float _minDistance = 1f;
    private Rigidbody2D _rbd2;
=======
    [SerializeField] private float _enemyBulletSpeed=200;
    private Rigidbody2D _rd2;
>>>>>>> origin/Bugs-Fixes-001
    private Vector2 _direction;
    private Vector2 _playerPos;
    void Start()
    {
<<<<<<< HEAD
        _rbd2 = this.gameObject.GetComponent<Rigidbody2D>();
    }//Start

    
    void Update()
    {
        
    }//Update

    private void OnCollisionEnter2D(Collision2D collision)
    {
       if(collision.gameObject.CompareTag("Player")) Destroy(this.gameObject);
       if(collision.gameObject.CompareTag("Wall")) Destroy(this.gameObject);
        print(collision.gameObject.tag);
=======
        _rd2 = this.gameObject.GetComponent<Rigidbody2D>();
    }//Start

    
    void FixedUpdate()
    {
        BulletMove();
    }//Update
    private void BulletMove()
    {
        _playerPos = Camera.main.ScreenToWorldPoint(_player.transform.position);
        _direction = (_playerPos - (Vector2)transform.position).normalized;
        _rd2.velocity = _direction * _enemyBulletSpeed*Time.deltaTime;
    }//Bullet move
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player")|| collision.gameObject.CompareTag("Wall"))  Destroy(this.gameObject);
>>>>>>> origin/Bugs-Fixes-001
    }
}//Class
