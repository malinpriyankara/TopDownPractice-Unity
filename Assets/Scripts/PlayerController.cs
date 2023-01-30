using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _playerSpeed = 2f;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private GameObject _gun;
    private Vector3 _mousePosition;
    private Vector2 _2DMousePosition;
    
   // private static EnemyController _enemyController;
    void Start()
    {
        
    }//Start

   
    void Update()
    {
        PlayerMove();
        PlayerLookingAt();
        PlayerShoot();
       // _enemyController.PlayerChase();
    }//Update

    private void PlayerMove()
    {
        transform.Translate(Vector2.right * _playerSpeed * Time.deltaTime * Input.GetAxis("Horizontal"));
        transform.Translate(Vector2.up * _playerSpeed * Time.deltaTime * Input.GetAxis("Vertical"));
        
    }//Player move
    private void PlayerLookingAt()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
       // _mousePosition = Input.mousePosition;
           // _2DMousePosition = new Vector2(_mousePosition.x, _mousePosition.y);
            transform.LookAt(mousePosition);
            transform.Rotate(new Vector3(0, -90, 0), Space.Self);
       
        //print("Mouse Position is"+_bc._direction);
    }
    private void PlayerShoot()
    {
       if(Input.GetMouseButtonDown(0)) Instantiate(_bullet, _gun.transform.position, Quaternion.identity);
    }//Shoot
}//Class
