using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class TeleportationManager : MonoBehaviour
{
    [Space]
    [SerializeField] private XRRayInteractor rayInteractorLeft;
    [SerializeField] private XRRayInteractor rayInteractorRight;
    [Space]
    [SerializeField] private GameObject controllerRightGrab;
    [SerializeField] private GameObject controllerRightTeleport;
    [SerializeField] private GameObject controllerLeftGrab;
    [SerializeField] private GameObject controllerLeftTeleport;
    [Space]
    [SerializeField] private TeleportationProvider teleportationProvider;

    void Start()
    {
        controllerRightGrab.SetActive(true);
        controllerRightTeleport.SetActive(false);
        
        controllerLeftGrab.SetActive(true);
        controllerLeftTeleport.SetActive(false);
        
        rayInteractorLeft.enabled = false;
        rayInteractorRight.enabled = false;
    
        InputHandler.Instance.OnLeftTeleportButton_Down.AddListener(ActivateRayInteractorLeft);
        InputHandler.Instance.OnLeftTeleportButton_Up.AddListener(TeleportToPointContactOfLeftBeam);
        InputHandler.Instance.OnLeftTeleportButton_Up.AddListener(DeactivateRayInteractorLeft);
        
        InputHandler.Instance.OnRightTeleportButton_Down.AddListener(ActivateRayInteractorRight);
        InputHandler.Instance.OnRightTeleportButton_Up.AddListener(TeleportToPointContactOfRightBeam);
        InputHandler.Instance.OnRightTeleportButton_Up.AddListener(DeactivateRayInteractorRight);
    }

    private void ActivateRayInteractorLeft()
    {
        if (rayInteractorRight.enabled) return;
        
        rayInteractorLeft.enabled = true;
        
        controllerLeftGrab.SetActive(false);
        controllerLeftTeleport.SetActive(true);
    }
    
    private void DeactivateRayInteractorLeft()
    {
        rayInteractorLeft.enabled = false;
        
        controllerLeftGrab.SetActive(true);
        controllerLeftTeleport.SetActive(false);
    }
    
    private void ActivateRayInteractorRight()
    {
        if (rayInteractorLeft.enabled) return;
        
        rayInteractorRight.enabled = true;
        
        controllerRightGrab.SetActive(false);
        controllerRightTeleport.SetActive(true);
    }
    
    private void DeactivateRayInteractorRight()
    {
        rayInteractorRight.enabled = false;
        
        controllerRightGrab.SetActive(true);
        controllerRightTeleport.SetActive(false);
    }

    private void TeleportToPointContactOfLeftBeam()
    {
        if (rayInteractorRight.enabled) return;

        if (!rayInteractorLeft.TryGetCurrent3DRaycastHit(out RaycastHit hit))
        {
            return;
        }

        if (hit.rigidbody.gameObject.layer != 7) return;
        
        var teleportRequest = new TeleportRequest()
        {
            destinationPosition = hit.point,
        };
        
        teleportationProvider.QueueTeleportRequest(teleportRequest);
    }
    
    private void TeleportToPointContactOfRightBeam()
    {
        if (rayInteractorLeft.enabled) return;
        
        if (!rayInteractorRight.TryGetCurrent3DRaycastHit(out RaycastHit hit))
        {
            return;
        }
        
        var teleportRequest = new TeleportRequest()
        {
            destinationPosition = hit.point,
        };
        
        teleportationProvider.QueueTeleportRequest(teleportRequest);
    }
}