using UnityEngine;

public class ButtonClickSound : MonoBehaviour
{
    public AudioSource clickSound;

    void OnMouseDown()
    {
        clickSound.Play();
    }
}