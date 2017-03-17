using Assets.Scripts.Sheet;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character
{
    public int st;
    public int dx;
    public int iq;
    public int ht;

    public int stCombat;
    public int stWeight;
    public int dxActual;
    public int dxAttackClosePlus;
    public int dxAttackFarPlus;
    public int iqActual;

    public int weightMax; // st * st
    public int weightBase; // weigthMax / 10
    public int weight;
    public float weightMult;

    /* examples
     * st == 12 >>> 1d + 2
     * st == 13 >>> 2d - 1
     * ---------------------
     * base = 3.5
     * ceil(st / 4) - 2
     * ---------------------
     * <= 12: 1 mult
     * <= 16: 2 mult
     * <= 20: 3 mult
     * min mult is 1
     * ---------------------
     * plus damage: ((st-1) % 4) - 1
     * if st < 9: 1d - 2 >>>> 3.5 - 2 >>>> 1.5
     * ---------------------
     * damage variation: 10%
     */
    public int damageSt;
    public int lifeExtra;
    public int lifeMax; // st
    public float life;
    public float lifeRegen;
    public int staminaExtra;
    public int staminaMax; // ht
    public float stamina;
    public float staminaRegen;
    public float staminaRegenPlus;
    public float staminaRegenMult;
    public float movement; // (dx + ht) / 4
                            /* 1.0*: weight <= 1x wb (weightBase)
                             * 0.8*: weight <= 2x wb
                             * 0.6*: weight > 2x wb
                             */
    public float movementPlus;
    public int dodge; // moveSpeed + 3
                      /* -0: weight <= 1x wb (weightBase)
                       * -1: weight <= 2x wb
                       * -2: weight > 2x wb
                       */
    public int dodgePlus;
    public int block;
    public int blockPlus;
    public int parry;
    public int parryPlus;

    public int sight;
    public int sightPlus;

    public int damageReduction;
    public int damageReductionPlus;

    public int hardToTarget;
    public int resistanceStun;
    public int resistanceDie;

    public Advantages advantages;
    public Disadvantages disadvantages;

    public void Init()
    {
        st = 10;
        dx = 10;
        iq = 10;
        ht = 10;
        advantages = new Advantages(this);
        disadvantages = new Disadvantages(this);
    }

    public void ResetCurrents()
    {
        life = lifeMax;
        stamina = staminaMax;
    }

    public void CalcStats()
    {
        ZeroStats();
        advantages.ApplyAll();
        disadvantages.ApplyAll();
        CalcWeight();
        CalcDamage();
        CalcMovement();
        CalcDodge();
        CalcLife();
        CalcStamina();
    }

    private void ZeroStats()
    {
        stCombat = st;
        stWeight = st;
        dxActual = dx;
        dxAttackClosePlus = 0;
        dxAttackFarPlus = 0;
        iqActual = iq;
        weightMult = 1;
        movementPlus = 0;
        dodgePlus = 0;
        blockPlus = 0;
        parryPlus = 0;
        lifeRegen = 1;
        staminaRegenPlus = 0;
        staminaRegenMult = 1;
        sightPlus = 0;
        damageReductionPlus = 0;
        hardToTarget = 0;
        resistanceStun = 0;
        resistanceDie = 0;
    }

    private void CalcLife()
    {
        lifeMax = st + lifeExtra;
    }

    private void CalcStamina()
    {
        staminaMax = ht + staminaExtra;
        staminaRegen = (1 + staminaRegenPlus) * staminaRegenMult;
        if (staminaRegen < 0) staminaRegen = 0;
    }

    private void CalcWeight()
    {
        weightMax = (int)(stWeight * stWeight * weightMult);
        weightBase = weightMax / 10;
    }

    private void CalcDamage()
    {
        float damageMult = Mathf.Max(1, Mathf.Ceil((stCombat / 4.0f) - 2));
        int damagePlus = -2;
        if (stCombat >= 9)
        {
            damagePlus = ((stCombat - 1) % 4) - 1;
        }
        damageSt = (int)(3.5 * damageMult + damagePlus);
    }

    private void CalcMovement()
    {
        movement = (dxActual + ht) / 4.0f + movementPlus;
    }

    private void CalcDodge()
    {
        dodge = (int)((dxActual + ht) / 4.0) + 3 + dodgePlus;
    }

}
