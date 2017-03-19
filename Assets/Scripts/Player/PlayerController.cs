using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private static GameObject playerObj;
    private Vector3 destination;
    private CharacterState charState;
    private HpTextController hpUI;
    private bool isAttacking;
    private EnemyController enemy;

    public static GameObject GetObject()
    {
        return playerObj;
    }

    public static PlayerController GetController()
    {
        return playerObj.GetComponent<PlayerController>();
    }
    
    void Start () {
        playerObj = gameObject;
        charState = gameObject.GetComponent<CharacterState>();
        destination = transform.position;
        hpUI = HpTextController.Create(gameObject);
        hpUI.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }

    public static void Activate()
    {
        playerObj.SetActive(true);
        GetController().isAttacking = false;
        GetController().hpUI.gameObject.SetActive(true);
        GetController().charState.character.ResetCurrents();
    }

    void Update () {
        if (destination != transform.position)
        {
            GoToDestination();
        }
        
        if (isAttacking 
            && enemy != null 
            && Vector3.Distance(transform.position, enemy.transform.position) <= 2f
            && charState.TryAttack()
            )
        {
            enemy.TakeDamage(charState.character.damageSt);
        }
    }

    private void LateUpdate()
    {
        hpUI.SetHp(charState.character.life);
    }

    private void GoToDestination()
    {
        transform.LookAt(destination);
        DoMove(destination);
    }

    private void DoMove(Vector3 dest)
    {
        Vector3 newPosition = Vector3.MoveTowards(transform.position, dest, charState.character.movement * Time.deltaTime);
        
        if (Physics.OverlapSphere(newPosition + new Vector3(0, 0.5f, 0), 0.4f).Length == 1)
        {
            transform.position = newPosition;
        }
    }

    public void MoveTo(Vector3 point)
    {
        destination = point;
        destination.y = transform.position.y;
    }

    public void SetEnemy(EnemyController enemy)
    {
        this.enemy = enemy;
    }

    public void Cast(int index)
    {
        // only attack, index == 0
        isAttacking = !isAttacking;
        RawImage buttonUI = GameObject.Find("/Canvas/Game2D/Button Attack").GetComponent<RawImage>();
        buttonUI.color = isAttacking ? new Color(1, 143f/255, 143f/255) : Color.white;        
    }
}
