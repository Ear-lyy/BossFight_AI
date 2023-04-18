using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    public ParticleSystem melee;

    public int meleeAttackCount;

    public Image hpBar;
    public float maxHP;
    public float curHP;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hpBar.fillAmount = curHP / maxHP;
    }

    public void meleeFX()
    {
        melee.Play();
    }

    public void meleeAttackCounter()
    {

        meleeAttackCount++;
        Debug.Log(meleeAttackCount);

    }    
}
