using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimalsNextButton : MonoBehaviour
{
    public bool canContinue = false;

    void OnMouseDown()
    {
        if (canContinue)
        {
            Debug.Log("Animals Next clicked!");
            SceneManager.LoadScene("Bushwalk");
        }
    }
}