using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerIt : MonoBehaviour
{
  public Button openBtn;
  public string triggerParameter = "Open";
  public Animator animator;

  void Start()
  {
    openBtn.onClick.AddListener(OnOpenButtonClick);
  }

  private void OnOpenButtonClick()
  {
    Debug.Log("Open button clicked!");
    animator.SetTrigger(triggerParameter);
  }
}
