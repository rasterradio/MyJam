using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public enum ButtonName {Horizontal,Vertical, Fire1 , Fire2, Fire3 , Fire4}

    public float GetAxis( string axisName)
    {
        return Input.GetAxis(axisName);
    }
 
    public bool GetButton( ButtonName buttonName)
    {    
            return Input.GetButton(buttonName.ToString());
    }

    public bool GetButtonDown( ButtonName buttonName)
    { 
            return Input.GetButtonDown(buttonName.ToString());
    }
   
    public  bool GetButtonUp(ButtonName buttonName)
    {
            return Input.GetButtonUp(buttonName.ToString());  
    }
}
