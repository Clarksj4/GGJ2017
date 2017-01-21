using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Pickup : MonoBehaviour
{
    public event EventHandler Vanishing;

    public Transform model;
    public float RotateSpeed = 100;
    public float VanishDuration = 0.5f;

    private Coroutine vanishing;
    private new ParticleSystem particleSystem;
    private PickupManager manager;

    void Awake()
    {
        manager = GetComponentInParent<PickupManager>();
        particleSystem = GetComponentInChildren<ParticleSystem>();

        StartCoroutine(Rotate());
    }

    public void Vanish(Vector3 destination)
    {
        if (vanishing == null)
        {
            if (Vanishing != null)
                Vanishing(this, new EventArgs());

            StopAllCoroutines();
            particleSystem.Play();
            vanishing = StartCoroutine(MoveToAndShrink(destination, VanishDuration));
        }
    }

    IEnumerator Rotate()
    {
        while (true)
        {
            model.Rotate(Vector3.up, Time.deltaTime * RotateSpeed);
            yield return null;
        }
    }

    IEnumerator MoveToAndShrink(Vector3 destination, float duration)
    {
        Vector3 initialPosition = model.position;
        Vector3 initialScale = model.localScale;
        float time = 0;

        while (time < duration)
        {
            time += Time.deltaTime;
            float t = time / duration;

            model.position = Vector3.Lerp(initialPosition, destination, t);
            model.localScale = Vector3.Lerp(initialScale, Vector3.zero, t);

            yield return null;
        }

        Destroy(gameObject);
    }
}
