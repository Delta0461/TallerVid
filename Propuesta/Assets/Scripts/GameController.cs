using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public TextMeshProUGUI HP;
    public Player player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HP.text = "HP: " + player.hp;
    }
}
