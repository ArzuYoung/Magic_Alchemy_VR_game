using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class TeleportationManager : MonoBehaviour
{
    [SerializeField] private XRRayInteractor rayInteractor;
    [SerializeField] private TeleportationProvider teleportationProvider;

    // Start is called before the first frame update
    void Start()
    {
        InputHandler.Instance.OnTeleportButton_Down.AddListener(ActivateRayInteractor);
        InputHandler.Instance.OnTeleportButton_Up.AddListener(TeleportToPointContactOfBeam);
        InputHandler.Instance.OnTeleportButton_Up.AddListener(DeactivateRayInteractor);
    }

    private void ActivateRayInteractor()
    {
        rayInteractor.enabled = true;
    }
    
    private void DeactivateRayInteractor()
    {
        rayInteractor.enabled = false;
    }

    private void TeleportToPointContactOfBeam()
    {
        if (!rayInteractor.TryGetCurrent3DRaycastHit(out RaycastHit hit))
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
