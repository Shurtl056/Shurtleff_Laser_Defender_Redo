using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] AudioClip shootingClip;
    [SerializeField] [Range(0f, 1f)] float flShootingVolume = 1f;

    [Header("Damage")]
    [SerializeField] AudioClip damageClip;
    [SerializeField] [Range(0f, 1f)] float flDamageVolume = 1f;

    public void PlayShootingClip()
    {
        PlayClip(shootingClip,flShootingVolume);
    }
     public void PlayDamageClip()
     {
         PlayClip(damageClip, flDamageVolume);
     }
void PlayClip(AudioClip clip, float volume)
{
    if(clip != null)
    {
        Vector3 cameraPos = Camera.main.transform.position;
        AudioSource.PlayClipAtPoint(clip, cameraPos, volume);
    }
}
}
