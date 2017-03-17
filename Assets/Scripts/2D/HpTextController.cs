using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpTextController : MonoBehaviour
{
    private Transform targetUnit;
    private Vector3 offset;
    private int total;
    private int current;

    public static HpTextController Create(GameObject targetObj)
    {
        GameObject textPrefab = Resources.Load<GameObject>("Prefabs/UI/Hp Text");
        GameObject gameObject = (GameObject)Instantiate(textPrefab,
                                                    Camera.main.WorldToScreenPoint(targetObj.transform.position),
                                                    Quaternion.identity,
                                                    GameObject.Find("/Canvas/Game2D").transform);
        HpTextController textController = gameObject.GetComponent<HpTextController>();
        textController.targetUnit = targetObj.transform;
        return textController;
    }

    private void Start()
    {
        offset = new Vector3(0, 0.08f * Screen.height, 0);
    }

    public void SetHp(float current, float total)
    {
        this.current = (int)current;
        this.total = (int)total;
    }

    private void Update()
    {
        transform.position = Camera.main.WorldToScreenPoint(targetUnit.position) + offset;
        GetComponentInChildren<Text>().text = current + "/" + total;
    }
}
