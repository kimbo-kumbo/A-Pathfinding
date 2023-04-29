using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Controller : MonoBehaviour
{    
    [SerializeField] private float _speed;
    private Rigidbody _rb;


    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        Vector3 m_Input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        _rb.MovePosition(transform.position + m_Input * Time.deltaTime * _speed);
        //if (Input.GetKey(KeyCode.W)) transform.Translate(Vector3.forward * Time.deltaTime * _speed);
        //if (Input.GetKey(KeyCode.S)) transform.Translate(-Vector3.forward * Time.deltaTime * _speed);
        //if (Input.GetKey(KeyCode.A)) transform.Translate(-Vector3.right * Time.deltaTime * _speed);
        //if (Input.GetKey(KeyCode.D)) transform.Translate(Vector3.right * Time.deltaTime * _speed);
    }  
}
