using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInterface : MonoBehaviour
{
   void OnGUI()
   {
       GUI.Box(new Rect(10,10,200,140), "Menu Panel");
       GUI.Button(new Rect(20, 40, 180, 30), "Test");

   }
}
