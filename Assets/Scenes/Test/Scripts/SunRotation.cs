using UnityEngine;
public class SunRotation : MonoBehaviour
{  
    [SerializeField] private float _sunStep;  
    void Update()=>transform.Rotate(Vector3.left, _sunStep); 
}