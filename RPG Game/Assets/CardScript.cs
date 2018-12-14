using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayingCard
{
    enum CardType {Creature, Event, Item, Generator, Upgrade, Virus};
    enum ItemType {Equipment, Consumable};
    enum GeneratorType {Basic, Gate};
    enum CreatureType {Animal, Plant, Machine, Spirit, Elemental, Nightmare, Fungus, Outerling};
    enum ElementalType {Dust, Fire, Water};
}

public class CardScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void CardPlayed(){

    }
    void takeDamage()
    {

    }
}
