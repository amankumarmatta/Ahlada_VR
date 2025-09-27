using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DoorHandleGrab : UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable
{
    [SerializeField] private Transform door;   // The actual door object

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

            // 🔒 Lock X and Z, allow only Y
            Vector3 euler = targetRotation.eulerAngles;
            door.rotation = Quaternion.Euler(0f, euler.y, 0f);
        }
    }
}
