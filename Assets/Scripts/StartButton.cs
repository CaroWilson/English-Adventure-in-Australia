using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    void OnMouseDown()
    {
        Debug.Log("Start Adventure clicked!");

        if (PlayerPrefs.HasKey("SelectedCharacter"))
        {
            SceneManager.LoadScene("Breakfast");
        }
    }
}