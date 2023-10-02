using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    [SerializeField] int health = 50;
    [SerializeField] bool isPlayer;
    [SerializeField] int score = 100;
    [SerializeField] ParticleSystem hitEffectParticleSystem;

    [SerializeField] bool applyCameraShake;
    CameraShakeScript cameraShakeScript;

    AudioPlayerScript audioPlayerScript;

    ScoreKeeperScript scoreKeeperScript;
    LevelManagerScript levelManagerScript;

    void Awake()
    {
        cameraShakeScript = Camera.main.GetComponent<CameraShakeScript>();
        audioPlayerScript = FindObjectOfType<AudioPlayerScript>();
        scoreKeeperScript = FindObjectOfType<ScoreKeeperScript>();
        levelManagerScript = FindObjectOfType<LevelManagerScript>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealerScript damageDealerScript = collision.GetComponent<DamageDealerScript>();
        if (damageDealerScript != null)
        {
            TakeDamage(damageDealerScript.GetDamage());
            PlayHitEffect();
            audioPlayerScript.PlayDamageClip();
            ShakeCamera();
            damageDealerScript.Hit();
        }
    }

    void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (!isPlayer)
        {
            scoreKeeperScript.ModifyScore(score);
        }
        else
        {
            levelManagerScript.LoadGameOver();
        }
        Destroy(gameObject);
    }

    void PlayHitEffect()
    {
        if (hitEffectParticleSystem != null)
        {
            ParticleSystem instance = Instantiate(hitEffectParticleSystem, transform.position, Quaternion.identity);
            Destroy(instance, instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }

    void ShakeCamera()
    {
        if (cameraShakeScript != null && applyCameraShake)
        {
            cameraShakeScript.Play();
        }
    }

    public int GetHealth()
    {
        return health;
    }
}
