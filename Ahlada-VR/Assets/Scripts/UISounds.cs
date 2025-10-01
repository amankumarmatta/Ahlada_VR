using UnityEngine;
using UnityEngine.EventSystems;
public class UISounds : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    public AudioClip highlightSound;
    public AudioClip clickSound;
    private AudioSource _audioSource;
    void Start()
    {
        _audioSource = FindFirstObjectByType<AudioSource>();
        if (_audioSource == null)
        {
            GameObject audioObj = new GameObject("UIAudioSource");
            _audioSource = audioObj.AddComponent<AudioSource>();
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (highlightSound != null)
            _audioSource.PlayOneShot(highlightSound);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (clickSound != null)
            _audioSource.PlayOneShot(clickSound);
    }
}
