using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    public Transform player;
    public Animator enemyAnim;

    public ParticleSystem melee;
    public ParticleSystem heavy;
    public ParticleSystem range;
    public ParticleSystem spell;

    public GameObject tornadoPrefab;

    public int meleeAttackCount;
    public int rangeAttackCount;

    public Image hpBar;
    public float maxHP;
    public float curHP;

    public bool isTornadoSpawned;
    public bool isDefeated;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        isTornadoSpawned = false;
        isDefeated = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform.position);
        hpBar.fillAmount = curHP / maxHP;

        if (curHP <= 30 && !isTornadoSpawned)
        {
            SummonTornado();
        }
        else if (curHP == 0 && isTornadoSpawned)
        {
            enemyAnim.SetBool("isDead", true);
        }
    }

    public void meleeFX()
    {
        melee.Play();
    }

    public void heavyFX()
    {
        heavy.Play();
    }

    public void rangeFX()
    {
        range.Play();
    }

    public void spellFX()
    {
        spell.Play();
    }

    public void meleeAttackCounter()
    {

        meleeAttackCount++;
        Debug.Log("Melee: " + meleeAttackCount);

    }

    public void rangeAttackCounter()
    {

        rangeAttackCount++;
        Debug.Log("Range: " + rangeAttackCount);

    }

    private void SummonTornado()
    {
        isTornadoSpawned = true;
        Instantiate(tornadoPrefab, transform.position, Quaternion.identity);
    }
}
