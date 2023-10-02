using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterScript : MonoBehaviour
{
    [Header("General")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifetime = 5f;
    [SerializeField] float baseFiringRate = 0.2f;

    [Header("AI")]
    [SerializeField] bool useAi;
    [SerializeField] float firingRateVariance = 0;
    [SerializeField] float minimumFiringRate = 0.1f;

    [HideInInspector]
    public bool isFiring;

    Coroutine firingCoroutine;
    AudioPlayerScript audioPlayerScript;

    private void Awake()
    {
        audioPlayerScript = FindObjectOfType<AudioPlayerScript>();
    }

    void Start()
    {
        if (useAi)
        {
            isFiring = true;
        }
    }

    void Update()
    {
        Fire();
    }

    void Fire()
    {
        if (isFiring && firingCoroutine == null)
        {
            firingCoroutine = StartCoroutine(FireCotinously());

        }
        else if (!isFiring && firingCoroutine !=null)
        {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
    }

    IEnumerator FireCotinously()
    {
        while (true)
        {
            GameObject instance = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

            Rigidbody2D myRigidbody2D = instance.GetComponent<Rigidbody2D>();
            if (myRigidbody2D != null)
            {
                myRigidbody2D.velocity = transform.up * projectileSpeed;
            }
            Destroy(instance, projectileLifetime);

            float timeToNextProjectile = Random.Range(baseFiringRate - firingRateVariance, baseFiringRate + firingRateVariance);
            timeToNextProjectile = Mathf.Clamp(timeToNextProjectile, minimumFiringRate, float.MaxValue);

            audioPlayerScript.PlayShootingClip();

            yield return new WaitForSeconds(timeToNextProjectile);
        }
    }
}
