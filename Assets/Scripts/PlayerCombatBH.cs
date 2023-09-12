using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatBH : MonoBehaviour
{
    public Transform attackPoint;
    public LayerMask O_DestructibleLayer;
    public LayerMask B_DestructibleLayer;
    public LayerMask C_DestructibleLayer;
    public float attackRange = 2f;

    public ParticleSystem oSlash;
    public ParticleSystem bSlash;

    public bool isActive1;
    public bool isActive2;
    public bool isActive3;
    public GameObject Ennemy1;
    public GameObject Ennemy2;
    public GameObject Ennemy3;







    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            oSlash.Play();

            AttackO();
            AttackC();
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            oSlash.Stop();

        }



        if (Input.GetKeyDown(KeyCode.E))
        {
            bSlash.Play();

            AttackB();
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            bSlash.Stop();

        }

        if (isActive1 == false)
        {
            Ennemy1.SetActive(false);
            Ennemy2.SetActive(true);
        }

        if (isActive2 == false)
        {
            Ennemy2.SetActive(false);
        }

        if (isActive2 == false & isActive1 == false)
        {
            Ennemy3.SetActive(true);
        }

        



    }

    void AttackO()
    {
        Collider[] hitO_Destructibles = Physics.OverlapSphere(attackPoint.position, attackRange, O_DestructibleLayer);
        isActive1 = true;

        foreach (Collider O_Destructible in hitO_Destructibles)
        {
            isActive1 = false;
            isActive2 = true;
            Debug.Log("We hit " + O_Destructible.name);

        }

    }

    void AttackB()
    {
        Collider[] hitB_Destructibles = Physics.OverlapSphere(attackPoint.position, attackRange, B_DestructibleLayer);


        foreach (Collider B_Destructible in hitB_Destructibles)
        {
            isActive2 = false;
            isActive3 = true;
            Debug.Log("We hit " + B_Destructible.name);

        }

    }

    void AttackC()
    {
        Collider[] hitC_Destructibles = Physics.OverlapSphere(attackPoint.position, attackRange, C_DestructibleLayer);


        foreach (Collider C_Destructible in hitC_Destructibles)
        {
            isActive3 = false;
            Debug.Log("We hit " + C_Destructible.name);

        }

    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }


}
