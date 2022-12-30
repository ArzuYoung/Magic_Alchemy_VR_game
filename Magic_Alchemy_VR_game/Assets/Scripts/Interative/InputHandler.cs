using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using Unity.VisualScripting.Dependencies.NCalc;
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
    
    [HideInInspector] public UnityEvent OnLeftGripButton_Down;
    [HideInInspector] public UnityEvent OnLeftGripButton_Up;

    private InputAction leftTeleportAction;
    private InputAction leftGripAction;
    
    private bool isLeftTeleportButton = false;
    private bool isLeftGripButton = false;
    
    [HideInInspector] public UnityEvent OnRightTeleportButton_Down;
    [HideInInspector] public UnityEvent OnRightTeleportButton_Up;
    
    [HideInInspector] public UnityEvent OnRightGripButton_Down;
    [HideInInspector] public UnityEvent OnRightGripButton_Up;
    
    private InputAction rightTeleportAction;
    private InputAction rightGripAction;
    
    private bool isRightTeleportButton = false;
    private bool isRightGripButton = false;
    
    [HideInInspector] public UnityEvent OnRightUiPressedButton_Down;
    [HideInInspector] public UnityEvent OnRightUiPressedButton_Up;
    
    private InputAction rightUiPressedAction;
    
    [HideInInspector] public UnityEvent OnLeftUiPressedButton_Down;
    [HideInInspector] public UnityEvent OnLeftUiPressedButton_Up;
    
    private InputAction leftUiPressedAction;
    
    private bool isRightUiPressedButton = false;
    private bool isLeftUiPressedButton = false;
    
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Start()
    {
        if (OnLeftTeleportButton_Down == null) OnLeftTeleportButton_Down = new UnityEvent();
        if (OnLeftTeleportButton_Up == null) OnLeftTeleportButton_Up = new UnityEvent();
        if (OnLeftGripButton_Down == null) OnLeftGripButton_Down = new UnityEvent();
        if (OnLeftGripButton_Up == null) OnLeftGripButton_Up = new UnityEvent();
        
        if (OnRightTeleportButton_Down == null) OnRightTeleportButton_Down = new UnityEvent();
        if (OnRightTeleportButton_Up == null) OnRightTeleportButton_Up = new UnityEvent();
        if (OnRightGripButton_Down == null) OnRightGripButton_Down = new UnityEvent();
        if (OnRightGripButton_Up == null) OnRightGripButton_Up = new UnityEvent();
        
        if (OnRightUiPressedButton_Down == null) OnRightUiPressedButton_Down = new UnityEvent();
        if (OnRightUiPressedButton_Up == null) OnRightUiPressedButton_Up = new UnityEvent();
        
        var rightHandActionMap = actionAssets.FindActionMap("XRI RightHand Interaction");
        rightTeleportAction = rightHandActionMap.FindAction("Activate");
        rightGripAction = rightHandActionMap.FindAction("Select");
        rightUiPressedAction = rightHandActionMap.FindAction("UI Press");
        
        var leftHandActionMap = actionAssets.FindActionMap("XRI LeftHand Interaction");
        leftTeleportAction = leftHandActionMap.FindAction("Activate");
        leftGripAction = leftHandActionMap.FindAction("Select");
        leftUiPressedAction = leftHandActionMap.FindAction("UI Press");
    }

    private void Update()
    {
        if (IsLeftTeleportButton_Down()) OnLeftTeleportButton_Down.Invoke();
        if (IsLeftTeleportButton_Up()) OnLeftTeleportButton_Up.Invoke();
        if (IsLeftGripButton_Down()) OnLeftGripButton_Down.Invoke();
        if (IsLeftGripButton_Up()) OnLeftGripButton_Up.Invoke();
        
        if (IsRightTeleportButton_Down()) OnRightTeleportButton_Down.Invoke();
        if (IsRightTeleportButton_Up()) OnRightTeleportButton_Up.Invoke();
        if (IsRightGripButton_Down()) OnRightGripButton_Down.Invoke();
        if (IsRightGripButton_Up()) OnRightGripButton_Up.Invoke();
        
        if (IsRightUiPressedButton_Down()) OnRightUiPressedButton_Down.Invoke();
        if (IsRightUiPressedButton_Up()) OnRightUiPressedButton_Up.Invoke();
        if (IsLeftUiPressedButton_Down()) OnLeftUiPressedButton_Down.Invoke();
        if (IsLeftUiPressedButton_Up()) OnLeftUiPressedButton_Up.Invoke();
        
        isLeftTeleportButton = IsLeftTeleportButton_Pressed();
        isRightTeleportButton = IsRightTeleportButton_Pressed();
        
        isLeftGripButton = IsLeftGripButton_Pressed();
        isRightGripButton = IsRightGripButton_Pressed();
        
        isRightUiPressedButton = IsRightUiPressedButton_Pressed();
        isLeftUiPressedButton = IsLeftUiPressedButton_Pressed();
    }

    private bool IsLeftTeleportButton_Pressed() => leftTeleportAction.IsPressed();
    
    private bool IsLeftTeleportButton_Down() => !isLeftTeleportButton && IsLeftTeleportButton_Pressed();
    
    private bool IsLeftTeleportButton_Up() => isLeftTeleportButton && !IsLeftTeleportButton_Pressed();
    
    
    private bool IsLeftGripButton_Pressed() => leftGripAction.IsPressed();
    
    private bool IsLeftGripButton_Down() => !isLeftGripButton && IsLeftGripButton_Pressed();
    
    private bool IsLeftGripButton_Up() => isLeftGripButton && !IsLeftGripButton_Pressed();
    
    
    private bool IsRightTeleportButton_Pressed() => rightTeleportAction.IsPressed();
    
    private bool IsRightTeleportButton_Down() => !isRightTeleportButton && IsRightTeleportButton_Pressed();
    
    private bool IsRightTeleportButton_Up() => isRightTeleportButton && !IsRightTeleportButton_Pressed();
    
    
    private bool IsRightGripButton_Pressed() => rightGripAction.IsPressed();
    
    private bool IsRightGripButton_Down() => !isRightGripButton && IsRightGripButton_Pressed();
    
    private bool IsRightGripButton_Up() => isRightGripButton && !IsRightGripButton_Pressed();
    
    
    private bool IsRightUiPressedButton_Pressed() => rightUiPressedAction.IsPressed();
    
    private bool IsRightUiPressedButton_Down() => !isRightUiPressedButton && IsRightUiPressedButton_Pressed();
    
    private bool IsRightUiPressedButton_Up() => isRightUiPressedButton && !IsRightUiPressedButton_Pressed();
    
    
    private bool IsLeftUiPressedButton_Pressed() => leftUiPressedAction.IsPressed();
    
    private bool IsLeftUiPressedButton_Down() => !isLeftUiPressedButton && IsLeftUiPressedButton_Pressed();
    
    private bool IsLeftUiPressedButton_Up() => isLeftUiPressedButton && !IsLeftUiPressedButton_Pressed();
}