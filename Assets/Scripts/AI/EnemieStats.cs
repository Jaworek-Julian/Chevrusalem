using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieStats : CharacterStats
{

    //récupération de l'animator
    
    //définition de la vie max au start
    
    //Fonctino de prise de dommage
    
    void Update()
    {
        if (this.hp <= 0)
        {
            Destroy(gameObject);
        }
    }
    
}
