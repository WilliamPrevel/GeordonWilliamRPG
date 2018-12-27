using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialogueBoxScript : MonoBehaviour
{
    public GameObject dialoguer;
    public GameObject dialoguerMini;
    public GameObject Player;
    public Text dialogueText;
    public Text dialogueTextMini;
    // Use this for initialization
    void Start()
    {
        //dialoguer = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.CurrentState == GameManager.GameState.Dialogue)
        {
            dialoguer.SetActive(true);
        }
        else
        {
            dialoguer.SetActive(false);
        }
        //this._alpha = 100;
        //remove from update later, for now lets get it working.
        dialogueText.text = GameManager.CurrentMessage;
        ///
        if(Player.GetComponent<PlayerScript>().currentWeapon.GetComponent<Weapon>().myStats.weaponName != null)
        dialogueTextMini.text = Player.GetComponent<PlayerScript>().currentWeapon.GetComponent<Weapon>().myStats.weaponName;
    }
}
    
