using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keuken : Device
{

    //Als de value tussen 0 en 2 is en hij heeft de value 1 gaat hij pieter needs updaten.
    public override void FixedUpdate()
    {

        if (contact == true)
        {
            int value = Random.Range(0, 2);
            if (value == 1)
            {
                pieter.UpdateNeeds(hygene, energy, hunger);
            }
        }

    }
    //Wanneer de player de keuken raakt doet hij iets.
    public override void OnCollisionEnter(Collision collision)
    {
        print("collision");
        if (collision.collider.tag == "Player")
        {
            pieter = collision.collider.GetComponent<AI>();
            contact = true;
        }
    }
    public override void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            pieter = null;
            contact = false;
        }
    }
}
