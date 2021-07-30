using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]
public class IKTest : MonoBehaviour
{
    [SerializeField] private bool _isActiveIK;
    [SerializeField] private float _weightIK;
    private Animator _animator;
    private Transform _lookObj;
    void Start()
    {
        _animator = GetComponent<Animator>();
    }
    void Update()
    {
        if(Physics.SphereCast(transform.position, 2f ,transform.forward ,out RaycastHit _info, 2f))
        {
            _isActiveIK = true;
            _lookObj = _info.transform;
            _weightIK = 1f;
        }
        else 
        {
            _isActiveIK = false;
            _weightIK = 0;
        }
    }
    private void OnAnimatorIK()
    {
        if(!_isActiveIK)
        {
            _animator.SetLookAtWeight(0);
            return;
        }

        _animator.SetLookAtWeight(_weightIK);
        _animator.SetLookAtPosition(_lookObj.position);

    }
}