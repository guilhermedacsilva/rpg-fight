using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesController : MonoBehaviour {
    
	void Start () {
		
	}
	
	void Update () {
		
	}

    public static void CreateEnemy()
    {
        GameObject prefab = Resources.Load<GameObject>("Prefabs/Enemy/Enemy");
        Instantiate(prefab, new Vector3(30, 0, 32), Quaternion.identity);
    }
}
