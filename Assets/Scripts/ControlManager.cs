using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ControlType
{
    Keyboard,
    Mouse,
    None
}

public class ControlManager : MonoBehaviour
{
    public ControlType ControlType = ControlType.None;
    private Component controlComponent;

    public void SetControlType(int type)
    {
        SetControlType((ControlType)type);
    }

    public void SetControlType(ControlType type)
    {
        if (type != ControlType && controlComponent != null)
            DestroyImmediate(controlComponent);

        ControlType = type;

        switch (type)
        {
            case ControlType.Keyboard:
                controlComponent = gameObject.AddComponent<KeyboardMove>();
                break;
            case ControlType.Mouse:
                controlComponent = gameObject.AddComponent<MouseMove>();
                break;
            default:
                break;
        }
    }
    
    // Use this for initialization
    void Start ()
    {
        SetControlType(ControlType);
	}
}
