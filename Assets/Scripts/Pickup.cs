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
    public float HighlightDuration = 1;
    [Range(0, 8)]
    public float HighlightIntensity = 5;
    [Range(0, 20)]
    public float HighlightRange = 4;
    public ParticleSystem PickupParticles;
    public Light Highlight;
    public AudioSource sound;

    private Coroutine highlighting;
    private Coroutine vanishing;
    private PickupManager manager;

    void Awake()
    {
        manager = GetComponentInParent<PickupManager>();

        StartCoroutine(DoRotate());
    }

    public void Vanish(Vector3 destination)
    {
        if (vanishing == null)
        {
            if (Vanishing != null)
                Vanishing(this, new EventArgs());

            StopAllCoroutines();
            vanishing = StartCoroutine(DoVanish(destination, VanishDuration));
        }
    }

    public void Ping()
    {
        if (highlighting == null)
            highlighting = StartCoroutine(DoHighlight());
    }

    IEnumerator DoRotate()
    {
        while (true)
        {
            model.Rotate(Vector3.up, Time.deltaTime * RotateSpeed);
            yield return null;
        }
    }

    IEnumerator DoVanish(Vector3 destination, float duration)
    {
        PickupParticles.Play();
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
        vanishing = null;
    }

    IEnumerator DoHighlight()
    {
        Highlight.enabled = true;
        Highlight.intensity = 0;
        Highlight.range = HighlightRange;
        sound.Stop();
        sound.Play();

        float time = 0;
        while (time < HighlightDuration)
        {
            float t = (time / HighlightDuration);

            // First half of highlight
            if (time < (HighlightDuration / 2))
                t /= 0.5f;
            else
                t = 1 - t;

            float intensity = Mathf.Lerp(0, HighlightIntensity, t);
            Highlight.intensity = intensity;

            time += Time.deltaTime;
            yield return null;
        }

        Highlight.enabled = false;
        Highlight.intensity = 0;
        highlighting = null;
    }
}
