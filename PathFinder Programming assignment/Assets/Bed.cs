using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed : Device {

    // Update is called once per frame
    public override void FixedUpdate()
    {

        if (contact == true)
        {

            pieter.UpdateNeeds(hygene, energy, hunger);
        }

    }
//Wanneer de player het bed raakt doet hij iets.
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
