using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKHandTest : MonoBehaviour
{
    
    [SerializeField] private Transform _leftHandObj;
    [SerializeField] private Transform _rightHandObj;
    [SerializeField] private float _changeSpeed = 0.01f;
    [SerializeField] private float _minDistance = 1f;
    private bool _isActiveIK;
    private Transform _targetObj;
    private float _weightIK;
    private Animator _animator;
    void Start()
    {
        _animator = GetComponent<Animator>();
        _targetObj = _rightHandObj.root.transform;
    }
    private void Update()
    {
        if(Vector3.Distance(transform.position,_targetObj.position)<_minDistance)
            _isActiveIK = true;
            else _isActiveIK = false;
    }
    private void OnAnimatorIK()
    {
        PositionIK();
        RotationIK();
        if(_isActiveIK) StartCoroutine(WeightUp());
        else StartCoroutine(WeightDown()); 
    }
    private void PositionIK()
    {
        _animator.SetIKPosition(AvatarIKGoal.RightHand, _rightHandObj.position);
        _animator.SetIKPositionWeight(AvatarIKGoal.RightHand, _weightIK);

        _animator.SetIKPosition(AvatarIKGoal.LeftHand, _leftHandObj.position);
        _animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, _weightIK);
    }
    private void RotationIK()
    {
        _animator.SetIKRotation(AvatarIKGoal.LeftHand, _leftHandObj.rotation);
        _animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, _weightIK);

        _animator.SetIKRotation(AvatarIKGoal.RightHand, _rightHandObj.rotation);
        _animator.SetIKRotationWeight(AvatarIKGoal.RightHand, _weightIK);
    }
    IEnumerator WeightUp()
    {
        if(_weightIK <= 1)
            _weightIK+= _changeSpeed;
        yield return null;
    }
    IEnumerator WeightDown()
    {
        if(_weightIK > 0)
            _weightIK-= _changeSpeed;
        yield return null;
    }
}