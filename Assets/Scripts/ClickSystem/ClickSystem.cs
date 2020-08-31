using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickSystem : MonoBehaviour
{
    static readonly Dictionary<string,IClickable> Handlers = new Dictionary<string, IClickable>()
    {
        { "Untagged", new InstantiationBehavior()},
        { "Object", new ClickBehavior()},
    };
    
    Camera m_MainCamera;
    

    void Start() => m_MainCamera = Camera.main;

    void Update()
    {
        if(!Input.GetMouseButtonDown(0)) return;
        var mousePosition = Input.mousePosition;
        if (!Physics.Raycast(m_MainCamera.ScreenPointToRay(mousePosition), out var hit)) return;
        
        
        Handlers[hit.collider.tag].OnClickCallbackReceived(in hit);
    }
}