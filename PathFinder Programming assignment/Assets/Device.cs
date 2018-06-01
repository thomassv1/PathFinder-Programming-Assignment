using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 *      MAAK "INHERITENCE SCRIPT" (PAPA SCRIPT)
 *      GEEF ELK SCRIPT WAT PAPA SCRIPT NODIG HEEFT ZIJN EIGEN MANIER OM ORIGINEEL TE ZIEN (ABSTRACT OF VIRTUAL)
 *      ZORG VOOR INTERACTION(OVERGANG VAN DIT SCRIPT NAAR EEN ANDER SCRIPT)MET HET OBJECT WAT JE NODIG HEBT
 * 
 * 
 * 
*/
public class Device : MonoBehaviour {
    public AI pieter;
    public float energy;
    public float hunger;
    public float hygene;
    public bool contact;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	virtual public void FixedUpdate () {

        if(contact == true)
        {
            pieter.UpdateNeeds(hygene, energy, hunger);
        }

	}
    //Wanneer de player het raakt doet hij iets.
    virtual public void OnCollisionEnter(Collision collision)
    {
        print("collision");
        if (collision.collider.tag == "Player")
        {
            pieter = collision.collider.GetComponent<AI>();
            contact = true;
        }
    }
    //Wanneer de player het verlaat doet hij iets.
    virtual public void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            pieter = null;
            contact = false;
        }
    }

}
