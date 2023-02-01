using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _spawnPoint;
    [SerializeField] private float _bulletSpeed;
    private float _minDistance = 1f;
    private Rigidbody2D _rbd2;
    private Vector2 _direction;
    private Vector2 _playerPos;
    void Start()
    {
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
    }
}//Class
