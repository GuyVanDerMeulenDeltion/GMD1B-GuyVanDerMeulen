using UnityEngine;
using System.Collections;

public class ChangeMaterial : MonoBehaviour {

    // Dit is een tekst
    public string hitbanana;
    
    // Zodra de object met dit script collision vind met een GameObject met de naam: Banana, dan verandert de kleur (Material) naar geel
    void OnCollisionEnter(Collision c)

    {
        if (c.gameObject.name == "Banana")
        {
 
            // De get componement is de pad die het volgt om bij de plek te komen waar de materials worden geregistreert, in dit geval is *Render* de component waar de info over materials in staat
            // Nadat hij bij material.color is aangekomen kan je uit een selectie van preset colors kiezen, de blauwe *Color* geeft aan dat je niet echt de material verandert, maar gewoon de kleur
            gameObject.GetComponent<Renderer>().material.color = Color.yellow;

            // Hierdoor print het de string *hitbanana* in de console
            print(hitbanana);

        }
    }
}