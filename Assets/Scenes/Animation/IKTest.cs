using UnityEngine;
[RequireComponent(typeof(Animator))]
public class IKTest : MonoBehaviour
{
    [SerializeField] private Transform _lookObj;
    [SerializeField] private float _lookDistance = 3f;
    private float _weightLookIK;

    private Animator _animator;
    private bool _isActiveIK;
    void Start()
    {
        _animator = GetComponent<Animator>();
    }
    void Update()
    {
        if(Vector3.Distance(transform.position, _lookObj.position) <= _lookDistance)
            _isActiveIK = true;
        else _isActiveIK = false;
    } 
    private void OnAnimatorIK() => LookAtObj();
    private void LookAtObj()
    {
        if(!_isActiveIK)
        {
            _weightLookIK = 0;
            _animator.SetLookAtWeight(_weightLookIK);
            return;
        }
        _weightLookIK = 1;
        _animator.SetLookAtWeight(_weightLookIK);
        _animator.SetLookAtPosition(_lookObj.position);
    }
}