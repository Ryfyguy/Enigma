using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextIn : MonoBehaviour
{
    // Start is called before the first frame update
    public Text TimerText;
    public float Timer;
    public static int TimerInt;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        TimerInt = -((int)Timer) + 1;
        TimerText.text = "Timer: " + TimerInt.ToString();
        Timer -= Time.deltaTime;

        //if (Timer >= 20)
        {
          //Time.timeScale = 0;
        }

    }
}
