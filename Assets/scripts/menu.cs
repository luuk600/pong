using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public void PlayGame ()
    {
        SceneManager.LoadScene("normal");
    }
    public void Menu ()
    {
        SceneManager.LoadScene("menu");
    }
}
