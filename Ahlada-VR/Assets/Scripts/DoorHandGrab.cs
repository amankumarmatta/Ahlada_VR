using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class DoorHandleGrab : UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable
{
    [SerializeField] private Transform door;   
    [SerializeField] private float minY = -90f; 
    [SerializeField] private float maxY = 90f;  
    private Quaternion initialGrabRotation;
    private Quaternion initialDoorRotation;
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        initialGrabRotation = args.interactorObject.transform.rotation;
        initialDoorRotation = door.rotation;
    }
    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {
        base.ProcessInteractable(updatePhase);
        if (isSelected && firstInteractorSelecting != null)
        {
            Quaternion currentGrabRotation = firstInteractorSelecting.transform.rotation;
            Quaternion delta = currentGrabRotation * Quaternion.Inverse(initialGrabRotation);
            Quaternion targetRotation = delta * initialDoorRotation;
            float rawY = targetRotation.eulerAngles.y;
            float y = Mathf.DeltaAngle(0f, rawY);
            y = Mathf.Clamp(y, minY, maxY);
            door.rotation = Quaternion.Euler(0f, y, 0f);
        }
    }
}
