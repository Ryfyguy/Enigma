using UnityEngine;

public class Win : MonoBehaviour
{
    //Checks to see if the player input matches the final text, then displays "Correct" if it does
    public TextMesh Winner;
    // Start is called before the first frame update
    void Start()
    {
        Winner.text = "Key: " + GM.Key;
    }

    // Update is called once per frame
    void Update()
    {
        if (GM.AnswerCheck == "this sentence is false")
        {
            GM.Win = true;
        }
        if (GM.Win){
            Winner.text = "Correct!";
        }
    }
}
