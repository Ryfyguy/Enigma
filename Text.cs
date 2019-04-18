using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text : MonoBehaviour
{
	
    
    // Start is called before the first frame update
    void Start()
    {
       	List<string> alphabet = new List<string>()
	{
		"a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p","q","r","s","t","u","v","w","x","y","z","A"
	};

	string normalString = GetComponent<TextMesh>().text;
	string newString;
	int i;
	for (i=0;i<(normalString.Length);i++)
	{
		string apples = "m";
		//apples += string(normalString[i]);
		//Debug.Log(alphabet.IndexOf(apples.ToString()));
		if alphabet.Contains("m")
		{
			Debug.Log(apples);
		//	newString+=alphabet[(alphabet.IndexOf(apples))];
		}
		//else
		//{
		//	newstring+=normalString[i];
		//}
	}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
