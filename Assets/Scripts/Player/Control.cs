using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    private Vector3 _direction = new Vector3(0,0,0);
    private float _xRotation, _yRotation;
    [SerializeField] private float _speed = 100;
    [SerializeField] private float _senstivity = 50;
    void Update()
    {
        //Вычисление вращния камеры
        _xRotation += Input.GetAxis("Mouse X") *_senstivity * Time.deltaTime;
        _yRotation += Input.GetAxis("Mouse Y") *_senstivity * Time.deltaTime;
        _yRotation = Mathf.Clamp(_yRotation, -60f, 60f);

        //Вычисление перемещения
        _direction = transform.position;
        _direction.y = 0f;
        _direction.x = Input.GetAxis("Horizontal") * Time.deltaTime;
        _direction.z = Input.GetAxis("Vertical") * Time.deltaTime;
        
    }
    void FixedUpdate()
    {
        //Движение и вращение
        transform.Translate(_direction* _speed);
        transform.localEulerAngles = Vector3.left * _yRotation + Vector3.up * _xRotation;
    }
}