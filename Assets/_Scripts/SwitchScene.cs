using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    public void switchScene(string scene)
    {
        if (scene != null)
        {
            SceneManager.LoadScene(scene);
        }
    }
}
