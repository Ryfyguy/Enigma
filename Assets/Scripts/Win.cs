using UnityEngine;

public class Win : MonoBehaviour
{
    public TextMesh Winner;
    // Start is called before the first frame update
    void Start()
    {
        Winner.text = "Key: " + GM.Key;
    }

    // Update is called once per frame
    void Update()
    {
        if (GM.Win){
            Winner.text = "Correct!";
        }
    }
}
