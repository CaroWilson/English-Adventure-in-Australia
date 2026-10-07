using UnityEngine;

public class BushwalkCharacter : MonoBehaviour
{
    public GameObject mia;
    public GameObject leo;

    void Start()
    {
        string selectedCharacter = PlayerPrefs.GetString("SelectedCharacter");

        if (selectedCharacter == "Mia")
        {
            mia.SetActive(true);
            leo.SetActive(false);
        }
        else if (selectedCharacter == "Leo")
        {
            mia.SetActive(false);
            leo.SetActive(true);
        }
    }
}