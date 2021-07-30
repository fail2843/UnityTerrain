using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]
public class IKTest : MonoBehaviour
{
    [SerializeField] private bool _isActiveIK;
     private Transform _lookObj;
    [SerializeField] private float _weightIK;
    private Animator _animator;
    
    void Start()
    {
        _animator = GetComponent<Animator>();
    }
    void Update()
    {
        if(Physics.SphereCast(Vector3.up, 2f, Vector3.forward, out RaycastHit hitInfo, 3f))
        {
            _isActiveIK = true;
            _lookObj = hitInfo.transform;

        }
        else _isActiveIK = false;
        
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
