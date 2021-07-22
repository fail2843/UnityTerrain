using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class View : MonoBehaviour
{
    [SerializeField] private float _speed = 100;
    private Vector3 _direction = new Vector3(0,0,0);
    private Vector3 _rotation = new Vector3 (0,0,0);
    private float _sensetivity = 100;
    private float _rotX, _rotY;
    
    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Update()
    {
        
        _direction.x = Input.GetAxis("Horizontal") * Time.deltaTime;
        _direction.z = Input.GetAxis("Vertical") * Time.deltaTime;
        Vector3.ClampMagnitude(_direction, 1);

        _rotX += Input.GetAxis("Mouse X")*Time.deltaTime;
        _rotY += Input.GetAxis("Mouse Y")*Time.deltaTime;
        _rotation = (Vector3.up*_rotX + Vector3.left* _rotY )* _sensetivity;
        
    }
    void FixedUpdate()
    {
        transform.Translate(_direction * _speed);
        transform.eulerAngles = _rotation;
    }
}
