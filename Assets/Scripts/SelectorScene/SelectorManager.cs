using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectorManager : MonoBehaviour
{
    public static SelectorManager instance;
    private void Start() //tempo
    {
        instance = this;
    }
    public void LoadLevel() //This function loads a level
    {
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
