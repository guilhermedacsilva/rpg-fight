using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour
{
    private static GameObject obj;

    private PlayerController player;
    private EnemyController enemy;
    private Vector3 point;
    private int terrainMask = 1 << 8;
    private int enemyMask = 1 << 9;
    private Ray ray;
    private RaycastHit hitInfo;
    private bool hit;
    private float selectTimeOK;
    private float selectDelayTime = 0.15f;

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
        else if (Input.GetKey(KeyCode.Mouse1))
        {
            if (Time.time > selectTimeOK)
            {
                TrySetTargetEnemy();
                selectTimeOK = Time.time + selectDelayTime;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Q)) { Debug.Log("Q"); }
        /*
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
            point = hitInfo.point;
            return true;
        }
        return false;
    }

    private void TrySetTargetEnemy()
    {
        EnemyController newEnemy;
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.SphereCast(ray, 0.25f, out hitInfo, 100, enemyMask, QueryTriggerInteraction.Ignore))
        {
            newEnemy = hitInfo.transform.GetComponentInParent<EnemyController>();
            if (enemy != newEnemy)
            {
                UpdateEnemySelection(newEnemy);
                enemy = newEnemy;
            }
        }
        else
        {
            UpdateEnemySelection(null);
            enemy = null;
        }
    }

    private void UpdateEnemySelection(EnemyController newEnemy)
    {
        if (enemy != null)
        {
            Destroy(enemy.gameObject.transform.Find("Selection").gameObject);
        }

        if (newEnemy != null)
        {
            GameObject obj = (GameObject)Instantiate(
                        Resources.Load<GameObject>("Prefabs/CharStates/Selection"),
                        newEnemy.gameObject.transform.position + new Vector3(0, 0.02f, 0),
                        Quaternion.Euler(90, 0, 0),
                        newEnemy.gameObject.transform);
            obj.name = "Selection";
        }
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
    */
}
