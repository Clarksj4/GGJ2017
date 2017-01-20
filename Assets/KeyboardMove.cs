using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Bat))]
public class KeyboardMove : MonoBehaviour
{
    public KeyCode[] Forward = new KeyCode[] { KeyCode.W, KeyCode.UpArrow };
    public KeyCode[] Left = new KeyCode[] { KeyCode.A, KeyCode.LeftArrow };
    public KeyCode[] Right = new KeyCode[] { KeyCode.D, KeyCode.RightArrow };

    private Bat bat;

    void Awake()
    {
        bat = GetComponent<Bat>();
    }

	// Update is called once per frame
	void Update ()
    {
        if (AnyKeyPressed(Forward))
            bat.Move(1);

        if (AnyKeyPressed(Left))
            bat.Turn(-1);

        if (AnyKeyPressed(Right))
            bat.Turn(1);
    }

    bool AnyKeyPressed(KeyCode[] keys)
    {
        foreach (KeyCode key in keys)
        {
            if (Input.GetKey(key))
                return true;
        }

        return false;
    }
}
