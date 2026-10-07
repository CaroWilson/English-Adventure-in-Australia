using UnityEngine;

public class ReadAloud : MonoBehaviour
{
    public AudioSource voiceAudio;

    void OnMouseDown()
    {
        voiceAudio.Play();
    }
}