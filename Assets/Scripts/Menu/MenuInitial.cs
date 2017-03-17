using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuInitial : MonoBehaviour {
    private MenuCaracterSheet menuChar;

    public void Start()
    {
        GameObject obj = GameObject.Find("/Canvas/MenuCharacter");
        menuChar = obj.GetComponent<MenuCaracterSheet>();
    }

	public void InitGame()
    {
        gameObject.SetActive(false);
        menuChar.Init();
    }
}
