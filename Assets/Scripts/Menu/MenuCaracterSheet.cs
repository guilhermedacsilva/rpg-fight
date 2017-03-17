using Assets.Scripts.Sheet;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuCaracterSheet : MonoBehaviour {
    private const int MAX_ATTRIBUTE = 20;
    private const int MIN_ATTRIBUTE = 7;
    private Character character;
    private Advantages advantages;
    private Disadvantages disadvantages;
    private Costs costs;

    public void Start()
    {
        gameObject.SetActive(false);
    }

    public void Init()
    {
        gameObject.SetActive(true);
        character = new Character();
        advantages = new Advantages();
        advantages.Init(character, new List<int>());
        disadvantages = new Disadvantages();
        disadvantages.Init(character, new List<int>());
        character.Init();
        character.CalcStats();
        costs = new Costs(character);
        costs.CalcAll();
    }

    public void Play()
    {
        if (costs.total > 100)
        {
            return;
        }
        gameObject.SetActive(false);
        GameObject player = PlayerController.GetObject();
        PlayerStats stats = player.GetComponent<PlayerStats>();
        stats.character = character;
        PlayerController.Activate();
        InputController.Activate();
        EnemiesController.CreateEnemy();
    }

    public void Refresh()
    {
        costs.CalcAll();
        character.CalcStats();
        GameObject.Find("Texts/ST").GetComponent<Text>().text = character.st.ToString();
        GameObject.Find("Texts/ST Cost/Cost").GetComponent<Text>().text = costs.st.ToString();
        GameObject.Find("Texts/DX").GetComponent<Text>().text = character.dx.ToString();
        GameObject.Find("Texts/DX Cost/Cost").GetComponent<Text>().text = costs.dx.ToString();
        GameObject.Find("Texts/IQ").GetComponent<Text>().text = character.iq.ToString();
        GameObject.Find("Texts/IQ Cost/Cost").GetComponent<Text>().text = costs.iq.ToString();
        GameObject.Find("Texts/HT").GetComponent<Text>().text = character.ht.ToString();
        GameObject.Find("Texts/HT Cost/Cost").GetComponent<Text>().text = costs.ht.ToString();
        Text total = GameObject.Find("Texts/Total").GetComponent<Text>();
        total.text = "Total: " + costs.total + " points";
        if (costs.total > 100)
        {
            total.color = Color.red;
        } else {
            total.color = Color.black;
        }
    }

    public void AddSt()
    {
        if (character.st < MAX_ATTRIBUTE) character.st++;
        Refresh();
    }

    public void SubSt()
    {
        if (character.st > MIN_ATTRIBUTE) character.st--;
        Refresh();
    }

    public void AddDx()
    {
        if (character.dx < MAX_ATTRIBUTE) character.dx++;
        Refresh();
    }

    public void SubDx()
    {
        if (character.dx > MIN_ATTRIBUTE) character.dx--;
        Refresh();
    }

    public void AddIq()
    {
        if (character.iq < MAX_ATTRIBUTE) character.iq++;
        Refresh();
    }

    public void SubIq()
    {
        if (character.iq > MIN_ATTRIBUTE) character.iq--;
        Refresh();
    }

    public void AddHt()
    {
        if (character.ht < MAX_ATTRIBUTE) character.ht++;
        Refresh();
    }

    public void SubHt()
    {
        if (character.ht > MIN_ATTRIBUTE) character.ht--;
        Refresh();
    }
}
