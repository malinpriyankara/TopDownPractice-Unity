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
    void Start()
    {
        _audio001.enabled = true;
    }//Start

    
    void Update()
    {
        PlayerChase();
        
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
       if(collision.gameObject.CompareTag("Bullet")) _audio001.Play(0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet")) Destroy(this.gameObject, 0);
       
    }//On trigger enter
   
}//Class
