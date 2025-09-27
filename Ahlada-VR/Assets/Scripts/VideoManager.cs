using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
public class VideoManager : MonoBehaviour
{
    [Header("All Video Parents (with VideoPlayers inside)")]
    public GameObject[] videoParents;   
    [Header("UI Buttons for each video")]
    public Button[] videoButtons;       
    private VideoPlayer[] videoPlayers;
    private void Start()
    {
        videoPlayers = new VideoPlayer[videoParents.Length];
        for (int i = 0; i < videoParents.Length; i++)
        {
            videoPlayers[i] = videoParents[i].GetComponentInChildren<VideoPlayer>();
            videoParents[i].SetActive(false); 
        }
        for (int i = 0; i < videoButtons.Length; i++)
        {
            int index = i; 
            videoButtons[i].onClick.AddListener(() => PlayVideo(index));
        }
    }
    public void PlayVideo(int index)
    {
        for (int i = 0; i < videoParents.Length; i++)
        {
            videoParents[i].SetActive(false);
        }
        videoParents[index].SetActive(true);
        videoPlayers[index].Stop();  
        videoPlayers[index].Play();
    }
}
