using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimalsBackButton : MonoBehaviour
{
    void OnMouseDown()
    {
        SceneManager.LoadScene("Beach");
    }
}
