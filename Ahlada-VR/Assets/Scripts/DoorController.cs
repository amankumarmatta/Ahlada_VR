using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public void ToggleDoor()
    {
        animator.Play("DoorAnim", 0, 0f);
    }
}
