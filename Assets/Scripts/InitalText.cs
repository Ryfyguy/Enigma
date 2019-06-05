using System.Collections.Generic;
using UnityEngine;

public class InitalText : MonoBehaviour
{

    private static string NewWord2;
    public static string word;
    //we initialize a generic alphabet for reference, and a seperate alphabet to be manipulated
    public static List<string> Alpha = new List<string>
    {
        "a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p","q","r","s","t","u","v","w","x","y","z","a"
    };
    public static List<string> AlphaCreate = new List<string>
    {
        "a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p","q","r","s","t","u","v","w","x","y","z"
    };
    public static List<string> Cipher = new List<string> { };
    public TextMesh BaseText;

    void Start()
    {
        //creates a randomized alphabet to cipher from for the puzzle
        for (int i = 0; i < 26; i++)
        {
            int temp = Random.Range(0, 26 - i);
            Cipher.Add("");
            Cipher[i] = AlphaCreate[temp];
            AlphaCreate.RemoveAt(temp);
        }
        GM.Key = Cipher[19] + " = t";
        string word = "this sentence is false";
        for (int i = 0; i < word.Length; i++)
        {
            if (Alpha.Contains((word[i]).ToString()))
            {
                NewWord2 += Cipher[Alpha.IndexOf(word[i].ToString())].ToString();
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
