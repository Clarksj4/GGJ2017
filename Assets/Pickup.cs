using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {

    public float RotateSpeed = 100;

	// Use this for initialization
	void Start ()
    {
        StartCoroutine(Rotate());	
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    IEnumerator Rotate()
    {
        while (true)
        {
            transform.Rotate(Vector3.up, Time.deltaTime * RotateSpeed);

            yield return null;
        }
    }

    IEnumerator MoveToAndShrink(Vector3 destination, float time)
    {
        // Shrink power up over time
        // Move to destination
        // Delete powerup when complete

        yield return null;
    }
}
