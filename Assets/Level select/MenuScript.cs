﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void ChangeScence(int sceneNum)
    {
        SceneManager.LoadScene(sceneNum);
    }
}