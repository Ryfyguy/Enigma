using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Vector3 Desination;
    // Desination(x,y,z) preset
    void OnTriggerEnter2D(Collider2D other)
        //On trigger(when 2 ridgid body over laps)
    {
        other.attachedRigidbody.transform.position = Desination;
        // other object that touches this ridgid body changes postion to new Desination(x,y,z)
    }
    // Start is called before the first frame update 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
