using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerText : MonoBehaviour
{
    public Text Answer;

    void Start()
    {

    }

    void Update()
    {
      if (Answer.text.ToLower() == InitalText.Puzzles[GM.indexer].ToString())
        {
            GM.Win = true;
        }
    }
}
