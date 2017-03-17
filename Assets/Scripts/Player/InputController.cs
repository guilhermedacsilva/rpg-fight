﻿using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour
{
    private static GameObject obj;

    private PlayerController player;
    // private EnemyController enemy;
    private Vector3 point;
    private int terrainMask = 1 << 8;
    // private int enemyMask = 1 << 9;
    private Ray ray;
    private RaycastHit hitInfo;
    private bool hit;
    private float selectTimeOK;
    private float selectDelayTime = 0.25f;

    public static void Activate()
    {
        obj.SetActive(true);
    }

    private void Start()
    {
        obj = gameObject;
        obj.SetActive(false);
        selectTimeOK = Time.time;
    }

    private void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (TrySetTargetPoint())
            {
                PlayerController.GetController().MoveTo(point);
            }
        }
        /*
        else if (Input.GetKey(KeyCode.Mouse1))
        {
            if (Time.time > selectTimeOK)
            {
                TrySetTargetEnemy();
                player.ChaseAttack(enemy);
                selectTimeOK = Time.time + selectDelayTime;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Q)) { Cast("Q"); }
        else if (Input.GetKeyDown(KeyCode.W)) { Cast("W"); }
        else if (Input.GetKeyDown(KeyCode.E)) { Cast("E"); }
        else if (Input.GetKeyDown(KeyCode.R)) { Cast("R"); }
        */
    }

    private bool TrySetTargetPoint()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(ray, out hitInfo, 100, terrainMask, QueryTriggerInteraction.Ignore))
        {
            //enemy = null;
            point = hitInfo.point;
            return true;
        }
        return false;
    }

    /*
    private void Cast(string hotkey)
    {
        TrySetTargetEnemyOrPoint();
        player.Cast(
            Hotkey.ConvertKeyToIndex(hotkey),
            point,
            enemy);
    }

    private void TrySetTargetEnemyOrPoint()
    {
        if (!TrySetTargetEnemy())
        {
            TrySetTargetPoint();
        }
    }

    private bool TrySetTargetEnemy()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.SphereCast(ray, 0.5f, out hitInfo, 100, enemyMask, QueryTriggerInteraction.Ignore))
        {
            enemy = hitInfo.transform.GetComponent<EnemyController>();
            point = enemy.transform.position;
        }
        else
        {
            enemy = null;
        }
        return enemy != null;
    }
    */
}
