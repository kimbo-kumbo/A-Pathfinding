using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Controller : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private float _speed;

    private void Update()
    {
        if (Input.GetKey(KeyCode.W)) _playerTransform.Translate(Vector3.forward*Time.deltaTime*_speed);
        if (Input.GetKey(KeyCode.S)) _playerTransform.Translate(-Vector3.forward * Time.deltaTime * _speed);
        if (Input.GetKey(KeyCode.A)) _playerTransform.Translate(-Vector3.right * Time.deltaTime * _speed);
        if (Input.GetKey(KeyCode.D)) _playerTransform.Translate(Vector3.right * Time.deltaTime * _speed);
    }  
}
