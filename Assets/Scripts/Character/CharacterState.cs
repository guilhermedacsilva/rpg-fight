using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterState : MonoBehaviour {
    public Character character;
    private float attackNextTime = 0;

    public bool TryAttack()
    {
        if (Time.time >= attackNextTime)
        {
            attackNextTime = Time.time + character.attackDelay;
            return true;
        }
        return false;
    }

    public void ApplyDamage(int damage)
    {
        int finalDamage = damage - character.damageReduction;
        finalDamage += (int) (Random.value * 10 % 3) - 1;
        character.life -= finalDamage;
    }

    public void ApplyRegen()
    {
        character.life += character.lifeRegen * Time.deltaTime;
        character.life = Mathf.Min(character.life, character.lifeMax);
    }

    void Update()
    {
        ApplyRegen();
    }
}
