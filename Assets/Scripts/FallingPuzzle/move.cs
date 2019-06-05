using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public float Speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name == "object")
        {
            Time.timeScale = 0;
        }
    }

    void Update()
    {
        var playerObject = GameObject.Find("Player");
        var playerPos = playerObject.transform.position;

        if (Input.GetButton("Horizontal"))
        {
            float WalkTranslation = Input.GetAxis("Horizontal") * Time.deltaTime * Speed;
            transform.Translate(WalkTranslation, 0, 0);
        }

        if (playerPos[1] <= -24)
        {
            playerPos[1] = 23;
            playerObject.transform.position = playerPos;
        }
    }
}
