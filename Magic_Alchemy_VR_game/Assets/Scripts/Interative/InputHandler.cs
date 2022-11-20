using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    public static InputHandler Instance;
    
    public UnityEvent OnTeleportButton_Down;
    public UnityEvent OnTeleportButton_Pressed;
    public UnityEvent OnTeleportButton_Up;
    
    [SerializeField] private InputActionAsset actionAssets;

    private InputAction rightTeleportAction;
    private InputAction leftTeleportAction;

    private void Awake()
    {
        if (!Instance)
            Instance = this;
    }

    private void Start()
    {
        if (OnTeleportButton_Down == null) OnTeleportButton_Down = new UnityEvent();
        if (OnTeleportButton_Pressed == null) OnTeleportButton_Pressed = new UnityEvent();
        if (OnTeleportButton_Up == null) OnTeleportButton_Up = new UnityEvent();
        
        var rightHandActionMap = actionAssets.FindActionMap("XRI RightHand Interaction");
        rightTeleportAction = rightHandActionMap.FindAction("Activate");
        
        var leftHandActionMap = actionAssets.FindActionMap("XRI LeftHand Interaction");
        leftTeleportAction = leftHandActionMap.FindAction("Activate");
    }

    private void Update()
    {
        if (IsTeleportButton_Down()) OnTeleportButton_Down.Invoke();
        if (IsTeleportButton_Pressed()) OnTeleportButton_Pressed.Invoke();
        if (IsTeleportButton_Up()) OnTeleportButton_Up.Invoke();
    }

    private bool IsTeleportButton_Down()
    {
        return rightTeleportAction.triggered || leftTeleportAction.triggered;
    }
    
    private bool IsTeleportButton_Pressed()
    {
        return rightTeleportAction.IsPressed() || leftTeleportAction.IsPressed();
    }
    
    private bool IsTeleportButton_Up()
    {
        return !(rightTeleportAction.IsPressed() && rightTeleportAction.triggered) 
               || !(leftTeleportAction.IsPressed() && leftTeleportAction.triggered);
    }
}
