using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public int enemyHealth;
    public int damage = 1;

    public PlayerScript ps;

    public ParticleSystem bloodFX;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnBlood()
    {
        bloodFX.Play();
        ps.playerHealth -= damage;
        Debug.Log(ps.playerHealth);
    }
}
