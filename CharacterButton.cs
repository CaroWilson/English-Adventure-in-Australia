using UnityEngine;

public class CharacterButton : MonoBehaviour
{
    public CharacterSelection characterSelection;
    public bool isMia;

    private void OnMouseDown()
    {
        if (isMia)
        {
            characterSelection.SelectMia();
        }
        else
        {
            characterSelection.SelectLeo();
        }
    }
}