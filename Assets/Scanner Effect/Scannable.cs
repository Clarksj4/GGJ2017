using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scannable : MonoBehaviour
{
    public MonoBehaviour target;
    public string method;

	public void Ping()
    {
        target.Invoke(method, 0);
    }
}
