using System.Collections.Generic;
using UnityEngine;

public class InitalText : MonoBehaviour
{

    private static string NewWord2;
    public static string word;
    public static List<string> Puzzles = new List<string>
    {
        "this sentence is false"
    };
    public static List<string> Alpha = new List<string>
    {
        "a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p","q","r","s","t","u","v","w","x","y","z","a"
    };
    public TextMesh BaseText;

    void Start()
    {
        GM.Key = "u = t";
        string word = Puzzles[0].ToString();
        for (int i = 0; i < word.Length; i++)
        {
            if (Alpha.Contains((word[i]).ToString()))
            {
                NewWord2 += Alpha[Alpha.IndexOf(word[i].ToString()) + 1].ToString();
            }
            else
            {
                NewWord2 += word[i];
            }

        }

        BaseText.text = NewWord2;

    }

    void Update()
    {

    }


}
