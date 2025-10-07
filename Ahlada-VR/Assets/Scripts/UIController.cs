using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
  [Header("Scene References")]
  public string skipSceneName;
  public string exploreSceneName;

  public void OnSkipClicked()
  {
    if (!string.IsNullOrEmpty(skipSceneName))
      SceneManager.LoadScene(skipSceneName);
    else
      Debug.LogWarning("Skip scene not assigned in UIController.");
  }

  public void OnExploreClicked()
  {
    if (!string.IsNullOrEmpty(exploreSceneName))
      SceneManager.LoadScene(exploreSceneName);
    else
      Debug.LogWarning("Explore scene not assigned in UIController.");
  }

  public void OnExitClicked()
  {
    Application.Quit();
  }

  public void backButtonClicked()
  {
    SceneManager.LoadScene("Shiva-Intro");
  }
}
