using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu: MonoBehaviour
{
    public int _sceneIndex = 0;
    public KeyCode _moveKey = KeyCode.Escape;

    void Update()
    {
        if (Input.GetKeyDown(_moveKey))
        {
            SceneManager.LoadScene(_sceneIndex);
        }
    }
}
