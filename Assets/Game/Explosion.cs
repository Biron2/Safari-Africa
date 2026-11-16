using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public ParticleSystem m_ExplosionParticles;
    public AudioSource m_ExplosionAudio;
    private Transform explosionParent;

    void Start()
    {
        explosionParent = GameObject.Find("Canvas/GameController/explosion_parent").transform;
        m_ExplosionParticles.transform.parent = explosionParent;
        m_ExplosionParticles.Play();
        m_ExplosionAudio.Play();
        Destroy(m_ExplosionParticles.gameObject, m_ExplosionParticles.main.duration);
    }
}