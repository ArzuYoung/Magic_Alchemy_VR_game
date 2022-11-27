using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit.Inputs.Composites;

public class InputHandler : MonoBehaviour
{
    public static InputHandler Instance;
 
    [SerializeField] private InputActionAsset actionAssets;
    
    [HideInInspector] public UnityEvent OnLeftTeleportButton_Down;
    [HideInInspector] public UnityEvent OnLeftTeleportButton_Up;

    private InputAction leftTeleportAction;
    
    private bool isLeftTeleportButton = false;
    
    [HideInInspector] public UnityEvent OnRightTeleportButton_Down;
    [HideInInspector] public UnityEvent OnRightTeleportButton_Up;
    
    private InputAction rightTeleportAction;
    
    private bool isRightTeleportButton = false;

    private InputAction select;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Start()
    {
        if (OnLeftTeleportButton_Down == null) OnLeftTeleportButton_Down = new UnityEvent();
        if (OnLeftTeleportButton_Up == null) OnLeftTeleportButton_Up = new UnityEvent();
        
        if (OnLeftTeleportButton_Down == null) OnRightTeleportButton_Down = new UnityEvent();
        if (OnLeftTeleportButton_Up == null) OnRightTeleportButton_Up = new UnityEvent();
        
        var rightHandActionMap = actionAssets.FindActionMap("XRI RightHand Interaction");
        rightTeleportAction = rightHandActionMap.FindAction("Activate");
        
        var leftHandActionMap = actionAssets.FindActionMap("XRI LeftHand Interaction");
        leftTeleportAction = leftHandActionMap.FindAction("Activate");

        select = rightHandActionMap.FindAction("Select");
    }

    private void Update()
    {
        if (IsLeftTeleportButton_Down()) OnLeftTeleportButton_Down.Invoke();
        if (IsLeftTeleportButton_Up()) OnLeftTeleportButton_Up.Invoke();
        
        if (IsRightTeleportButton_Down()) OnRightTeleportButton_Down.Invoke();
        if (IsRightTeleportButton_Up()) OnRightTeleportButton_Up.Invoke();
        
        isLeftTeleportButton = IsLeftTeleportButton_Pressed();
        isRightTeleportButton = IsRightTeleportButton_Pressed();
        
        if (select.IsPressed()) Debug.Log("Grip Is Pressed!");
    }

    private bool IsLeftTeleportButton_Pressed() => leftTeleportAction.IsPressed();
    
    private bool IsLeftTeleportButton_Down() => !isLeftTeleportButton && IsLeftTeleportButton_Pressed();
    
    private bool IsLeftTeleportButton_Up() => isLeftTeleportButton && !IsLeftTeleportButton_Pressed();
    
    private bool IsRightTeleportButton_Pressed() => rightTeleportAction.IsPressed();
    
    private bool IsRightTeleportButton_Down() => !isRightTeleportButton && IsRightTeleportButton_Pressed();
    
    private bool IsRightTeleportButton_Up() => isRightTeleportButton && !IsRightTeleportButton_Pressed();
}