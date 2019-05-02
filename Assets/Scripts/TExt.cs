using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class TExt : MonoBehaviour
{

    public static string NewWord2;
    public List<string> Alpha = new List<string>
    
    {
        "a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p","q","r","s","t","u","v","w","x","y","z","a"
    };
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(GetComponent<TextMesh>().text);
        List<string> NewWord = new List<string>();
        string word = GetComponent<TextMesh>().text;
        int i;
        for (i = 0; i < word.Length; i++)
        {
            if (Alpha.Contains((word[i]).ToString())){
                NewWord.Add((Alpha[Alpha.IndexOf(word[i].ToString())+1]).ToString());
            }
            else
            { 
                NewWord.Add((word[i]).ToString());
            }
            
        }
        for (int n = 0; n<NewWord.Count(); n++)
        {
            NewWord2 += NewWord[n];
        }

        GetComponent<TextMesh>().text = NewWord2;

    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<TextMesh>().text = NewWord2;
    }
}
