using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] bool blIsPlayer;
    [SerializeField] int intHealth = 50;
    [SerializeField] int intScore = 50;
    [SerializeField] ParticleSystem hitEffect;

    [SerializeField] bool blApplyCameraShake;
    CameraShake cameraShake;

    AudioPlayer audioPlayer;
    ScoreKeeper scoreKeeper;
    LevelManager levelManager;

    void Awake() 
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        levelManager = FindObjectOfType<LevelManager>();
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();

        if(damageDealer != null)
        {
            //take damage
            TakeDamage(damageDealer.GetDamage());
            PlayHitEffect();
            audioPlayer.PlayDamageClip();
            ShakeCamera();
            //tell damage dealer that it hit something 
            damageDealer.Hit(); 
        }

    }

    public int GetHealth()
    {
        return intHealth;
    }

    void TakeDamage(int intDamage)
    {
        intHealth -= intDamage;
        if(intHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if(!blIsPlayer)
        {
            scoreKeeper.ModifyScore(intScore);
        }
        else
        {
            levelManager.LoadGameOver();
        }
        Destroy(gameObject);
    }

    void PlayHitEffect()
    {
        if(hitEffect != null)
        {
            ParticleSystem instance = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }

    void ShakeCamera()
    {
        if(cameraShake != null && blApplyCameraShake)
        {
            cameraShake.Play();
        }
    }
}
