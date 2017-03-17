using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private static GameObject playerObj;
    private Vector3 destination;
    private PlayerStats stats;
    private HpTextController hpUI;

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
        stats = gameObject.GetComponent<PlayerStats>();
        destination = transform.position;
        hpUI = HpTextController.Create(gameObject);
        hpUI.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }

    public static void Activate()
    {
        playerObj.SetActive(true);
        GetController().hpUI.gameObject.SetActive(true);
        GetController().stats.character.ResetCurrents();
    }

    void Update () {
        if (destination != transform.position)
        {
            GoToDestination();
        }
    }

    private void LateUpdate()
    {
        hpUI.SetHp(stats.character.life, stats.character.lifeMax);
    }

    private void GoToDestination()
    {
        transform.LookAt(destination);
        DoMove(destination);
    }

    private void DoMove(Vector3 dest)
    {
        Vector3 newPosition = Vector3.MoveTowards(transform.position, dest, stats.character.movement * Time.deltaTime);
        
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
}
