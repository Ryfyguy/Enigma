using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class text : MonoBehaviour
{
    public Text TimerText;
    public float Timer;
    public int TimerInt;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        TimerInt = (int)Timer + 1;
        TimerText.text = "Timer: " + TimerInt.ToString();
        Timer -= Time.deltaTime;

        if (Timer < 0)
        {
            Time.timeScale = 0;
        }

    }
}
