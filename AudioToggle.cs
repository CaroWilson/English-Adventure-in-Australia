using UnityEngine;

public class AudioToggle : MonoBehaviour
{
    private static bool isMuted = false;

    void Start()
    {
        AudioListener.pause = isMuted;
    }

    void OnMouseDown()
    {
        isMuted = !isMuted;
        AudioListener.pause = isMuted;

        Debug.Log("Audio muted: " + isMuted);
    }
}