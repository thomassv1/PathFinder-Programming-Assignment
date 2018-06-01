using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shower : Device
{
    float timer;
    bool set;

    private void Start()
    {
        timer = 3f;
    }
    // Update is called once per frame
    public override void FixedUpdate()
    {

        if (contact == true)
        {
            
        }

    }
    //Wanneer de player de shower raakt doet hij iets.
    public override void OnCollisionEnter(Collision collision)
    {
        print("collision");
        if (collision.collider.tag == "Player")
        {
            pieter = collision.collider.GetComponent<AI>();
            contact = true;
            StartCoroutine(TakeShower());
        }
    }
    //Wanneer de player het bed verlaat doet hij iets.
    public override void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            pieter = null;
            contact = false;
        }
    }
    //Wanneer de player de shower aanraakt krijgt hij een timer voordat hij hygene erbij kan krijgen.
    public IEnumerator TakeShower()
    {
        while(contact == true)
        {
           
            pieter.UpdateNeeds(hygene * 2, energy, hunger);
            yield return new WaitForSeconds(timer);

        }
    }
}
