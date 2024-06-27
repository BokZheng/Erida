using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextScene : MonoBehaviour
{
    public int Scenes = 1;
    public void LoadScene()
    {
        SceneManager.LoadScene(Scenes);
    }
}
