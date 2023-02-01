using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private float _enemySpeed = 2f;
    [SerializeField] private float _range = 1f;
    [SerializeField] private float _minDistance = 1f;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private GameObject _gun;
    [SerializeField] private AudioSource _audio001;

    [SerializeField] private GameObject _bulletSpawnPoint;
    [SerializeField] private GameObject _enemyBullet;
    [SerializeField] private float _enemyBulletSpeed = 50f;
    public float enemyHealth = 3;
    private float _intervals = 0;
    private float _shootTimmer = 1;
    private Vector2 _shootDirection;

    //[SerializeField] private GameObject _enemyBullet;
    [SerializeField] private GameObject _enemyGun;
    [SerializeField] private float _bulletSpawnTimer = 10;

    void Start()
    {
        _audio001.enabled = true;
        InvokeRepeating("EnemyShoot", 2f, 1f);
    }//Start

    
    void Update()
    {
        PlayerChase();

        EnemyDie();

        InvokeRepeating("EnemyShoot", _bulletSpawnTimer,2);

    }//Update

    public void PlayerChase()
    {
        transform.LookAt(_player.transform.position);
        transform.Rotate(new Vector3(0, -90, 0), Space.Self);
        if (Vector3.Distance(transform.position, _player.transform.position) > _minDistance)
        {
            transform.Translate(new Vector3(_enemySpeed * Time.deltaTime, 0, 0));
        }
    }//Player chase
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            _audio001.Play(0);
            enemyHealth--;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet")) Destroy(this.gameObject, 0);
       
    }//On trigger enter


    private void EnemyShoot()
    {
        if (Vector2.Distance(transform.position, _player.transform.position) <= _minDistance)
        {
            _shootDirection= ((Vector2)_player.transform.position - (Vector2)transform.position).normalized;
            GameObject gobj=   Instantiate(_enemyBullet, _bulletSpawnPoint.transform.position, Quaternion.identity);
            Rigidbody2D gRbd2 = gobj.GetComponent<Rigidbody2D>();
            //gRbd2.AddForce(_player.transform.position, ForceMode2D.Impulse);
            gRbd2.velocity = _shootDirection*_enemyBulletSpeed;
            print("Shoot");
        }
    }//Enemy shoot

   

   
    private void EnemyDie()
    {
        if (enemyHealth <= 0) Destroy(this.gameObject);
    }
}//Class
