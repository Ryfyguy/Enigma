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
        {
            float WalkTranslation = Input.GetAxis("Horizontal") * Time.deltaTime * WalkSpeed;
            transform.Translate(WalkTranslation, 0, 0);
        }
        if (Input.GetButton("Vertical"))
        {
            float WalkTranslation = Input.GetAxis("Vertical") * WalkSpeed;
            WalkTranslation *= Time.deltaTime;
            transform.Translate(0, WalkTranslation, 0);
        }
    }
}
