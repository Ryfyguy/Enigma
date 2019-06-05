using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float WalkSpeed;
   
    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Horizontal"))
            //Check if input is 'a'/'d' or arrow left/right
        {
            float WalkTranslation = Input.GetAxis("Horizontal") * Time.deltaTime * WalkSpeed;
            // new postion = GetAxis(-1 or +1 for left/right) * walkspeed(preset value) * deltatime(per second)
            transform.Translate(WalkTranslation, 0, 0);
            //update x's position to new postion
        }
        if (Input.GetButton("Vertical"))
            //Check if input is 'w',/'d' or arrow up/down
        {
            float WalkTranslation = Input.GetAxis("Vertical") * Time.deltaTime * WalkSpeed;
            // new postion = GetAxis(-1 or +1 for up/down) * walkspeed(preset value) * deltatime(per second)
            transform.Translate(0, WalkTranslation, 0);
            //update y's position to new postion
        }
    }
}
