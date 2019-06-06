using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    public TextMesh Winner;
    public string levelName;
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
            SceneManager.LoadScene(levelName);
        }
    }
}
