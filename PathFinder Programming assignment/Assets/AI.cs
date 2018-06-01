using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour {
    /*
     *      MAAK "INHERITENCE SCRIPT" (PAPA SCRIPT)
     *      GEEF ELK SCRIPT WAT PAPA SCRIPT NODIG HEEFT ZIJN EIGEN MANIER OM ORIGINEEL TE ZIEN (ABSTRACT OF VIRTUAL)
     *      ZORG VOOR INTERACTION(OVERGANG VAN DIT SCRIPT NAAR EEN ANDER SCRIPT)MET HET OBJECT WAT JE NODIG HEBT
     * 
     * 
     * 
     * 
    */
    public float energy;
    public float hunger;
    public float hygene;


    public float energyLoss;
    public float hungerLoss;
    public float hygeneLoss;
    public Transform shower, bed, food;
    public bool bereikt;

    public NavMeshAgent agent;

    public enum Picker
    {
        Idle,
        Sleep,
        Eat,
        Shower
    }

    public Picker _Picker;

    private void Start()
    {
        energy = 100f;
        hunger = 100f;
        hygene = 100f;
    }

    public void LimitValue()
    {
        if (energy > 100f)
        {
            energy = 100f;
        }
        if (hunger > 100f)
        {
            hunger = 100f;
        }
        if (hygene > 100f)
        {
            hygene = 100f;
        }


    }

    private void Update()
    {
        LimitValue();
        Needs();
    }

    //Hier gaat er naar een bepaalde tijd de value van hunger en energy en hygene steeds naar beneden. Hij pakt hij ook de anim state als hij onder een bepaalde value is.
    void Needs()
    {
        hunger -= hungerLoss * Time.deltaTime;
        energy -= energyLoss * Time.deltaTime;
        hygene -= hygeneLoss * Time.deltaTime;

        if (energy < 20f)
        {
            _Picker = Picker.Sleep;
            CheckState();
        }
        if (hunger < 45f)
        {
            _Picker = Picker.Eat;
            CheckState();
        }
        if (hygene < 30f)
        {
            _Picker = Picker.Shower;
            CheckState();
        }
        else if(energy > 20f && hunger > 45f && hygene > 30f)
        {
            _Picker = Picker.Idle;
            CheckState();
        }
        
    }
    void CheckState ()
    {
        AIState();
    }
    // Dit zorgt ervoor dat de AI bepaalde dingen kan uitvoeren.
    void AIState()
    {

        switch (_Picker)
        {
            case Picker.Idle:

                //agent.isStopped = true;
                //Bij Idle gebruikt hij de Walk op random momenten, hij stopt met niks doen als een bepaalde variable onder een bepaalde value is. 

                print("Idle");
                break;

            case Picker.Eat:

                Action(food);
                //Hij loopt naar destination en als hij er dan is gaat hij eten en wordt zijn variable weer naar 100 gezet.
                print("Lekker eten");
                break;

            case Picker.Shower:
                Action(shower);
                //Hij loopt naar destination en als hij er dan is gaat hij douchen en wordt zijn variable weer naar 100 gezet.
                print("Douchen is goed!");
                break;

            case Picker.Sleep:
                Action(bed);
                //als zijn energy onder een bepaald value is gaat hij naar bedje toe en wordt zijn value INSTANT 100
                print("sLAPEN?");
                break;

        }
    }
    //Hierdoor loopt hij naar zijn destination
    void Action(Transform needs)
    {
        print("action");
        agent.destination = needs.position;
    }
    public void UpdateNeeds(float shower, float bed, float eat)
    {
        hygene += shower;
        hunger += eat;
        energy += bed;
    }
}
