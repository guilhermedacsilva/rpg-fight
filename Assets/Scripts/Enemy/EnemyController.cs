using Assets.Scripts.Sheet;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    private HpTextController hpTextController;
    private CharacterState charState;

	void Start () {
        Character character = new Character();
        character.Init();
        character.CalcStats();
        character.ResetCurrents();

        charState = GetComponent<CharacterState>();
        charState.character = character;

        hpTextController = HpTextController.Create(gameObject);
    }
	
	void Update()
    {
        hpTextController.SetHp(charState.character.life);
    }

    public void TakeDamage(int damage)
    {
        charState.ApplyDamage(damage);
    }
}
