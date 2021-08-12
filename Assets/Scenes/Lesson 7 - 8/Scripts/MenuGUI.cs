using UnityEngine;
using UnityEngine.Rendering.PostProcessing;


public class MenuGUI : MonoBehaviour
{
    [SerializeField] PostProcessProfile _normal;
    [SerializeField] PostProcessProfile _awful;
    [SerializeField] PostProcessVolume _volume;
    private ColorGrading _grading;
    private bool _isNormal = true;
    void Update()
    {
        
    }
    
    void OnGUI()
   {
       GUI.Box(new Rect(10,10,200,140), "Menu Panel");
       if(GUI.Button(new Rect(20, 40, 180, 30), "Change Profile"))
       {
           if(_isNormal){
               _volume.profile = _awful;
           }
           else _volume.profile = _normal;

           _isNormal=!_isNormal;
       }
       if(GUI.Button(new Rect(20, 80, 180, 30), "Change Color"))
       {

           _grading = ScriptableObject.CreateInstance<ColorGrading>();
           _grading.enabled.Override(true);

       }
    }
}
