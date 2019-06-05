using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void ChangeScence(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        // changes scene to new scene(sceneName)
    }
}
