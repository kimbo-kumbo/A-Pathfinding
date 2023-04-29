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
    }   
}