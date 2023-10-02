using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShakeScript : MonoBehaviour
{
    [SerializeField] float shakeDuration = 1.0f;
    [SerializeField] float shakeMagnitude = 0.5f;

    Vector3 initalPosition;

    void Start()
    {
        initalPosition = transform.position;
    }

    public void Play()
    {
        StartCoroutine(Shake());
    }

    IEnumerator Shake()
    {
        float elapsedTime = 0;
        while (elapsedTime < shakeDuration)
        {
            elapsedTime += Time.deltaTime;
            transform.position = initalPosition + (Vector3)Random.insideUnitCircle * shakeMagnitude;
            yield return new WaitForEndOfFrame();
        }
        transform.position = initalPosition;
    }
}
