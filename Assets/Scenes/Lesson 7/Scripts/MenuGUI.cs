using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;


public class MenuGUI : MonoBehaviour
{
    [SerializeField] PostProcessProfile _normal;
    [SerializeField] PostProcessProfile _awful;
    [SerializeField] PostProcessVolume _volume;
    private bool _isNormal = true;
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
       if(GUI.Button(new Rect(20, 40, 180, 30), "Color Temperature"))
       {
           _volume.profile.
       }
   }
}
