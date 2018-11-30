using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterBar : MonoBehaviour {


    float BarValue;
    float MaxBarValue;
    float currentbarValue;
    public enum Bartype {Health, Mana, Exp }
    public Bartype BarType;
    public GameObject player;
    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (BarType == Bartype.Exp)
        {
        BarValue = player.GetComponentInParent<PlayerScript>().myStats.Experience;
        MaxBarValue = player.GetComponentInParent<PlayerScript>().myStats.Level * 100;
        }
       else if (BarType == Bartype.Mana)
        {
            BarValue = player.GetComponentInParent<CharacterScript>().myStats.Mana;
            MaxBarValue = player.GetComponentInParent<CharacterScript>().myStats.MaxMana;
        }
        else if (BarType == Bartype.Health)
        {
            BarValue = player.GetComponentInParent<CharacterScript>().myStats.Health;
            MaxBarValue = player.GetComponentInParent<CharacterScript>().myStats.MaxHealth;
            
        }
        currentbarValue = BarValue / MaxBarValue;
        gameObject.transform.localScale = new Vector3(currentbarValue, 1, 1);
    }
}