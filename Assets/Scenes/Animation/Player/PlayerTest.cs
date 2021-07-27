using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTest : MonoBehaviour
{
    [SerializeField] private GameObject _camera;
    private Animator _animator;
    private float _mouseY, _mouseX;
    void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    void Update()
    {
        _mouseY += Input.GetAxis("Mouse Y");
        _mouseX += Input.GetAxis("Mouse X");
        _mouseY = Mathf.Clamp(_mouseY, -60, 60);

        float _vertical = Input.GetAxis("Vertical");
        float _horizontal = Input.GetAxis("Mouse X");

        PlayerAnimation(_vertical, _horizontal);
    }
    void FixedUpdate()
    {
        gameObject.transform.eulerAngles = new Vector3(0,_mouseX,0);
        _camera.transform.eulerAngles = new Vector3(-_mouseY, _mouseX, 0);
    }
    void PlayerAnimation(float _vertical, float _horizontal)
    {
        _animator.SetFloat("Vertical", _vertical);
        _animator.SetFloat("Horizontal", _horizontal);
    }
}
