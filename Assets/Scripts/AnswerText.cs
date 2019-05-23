using UnityEngine;

public class AnswerText : MonoBehaviour
{
    public TextMesh Answer;

    void Start()
    {

    }

    void Update()
    {
      if (Answer.text.ToLower() == InitalText.Puzzles[0].ToString())
        {
            GM.Win = true;
        }
    }
}
