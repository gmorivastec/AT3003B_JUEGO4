using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GUIManager : MonoBehaviour
{

    [SerializeField]
    private TMP_Text _texto;

    public void VidaCambio(float nuevaVida)
    {
        _texto.text = "Vida: " + nuevaVida;

        if(nuevaVida < 80)
        {
            _texto.color = Color.red;
        }
    }

    public void VidaCero()
    {
        SceneManager.LoadScene(1);
    }
}
