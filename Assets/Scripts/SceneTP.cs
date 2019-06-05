using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTP : MonoBehaviour
{
    //public int index;
    public string levelName;
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {
        //SceneManager.LoadScene(index);
        //Loading Level with build index

        SceneManager.LoadScene(levelName);
        //loading level with scene name
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
