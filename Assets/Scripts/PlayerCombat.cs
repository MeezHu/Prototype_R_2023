using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Transform attackPoint;
    public LayerMask O_DestructibleLayer;
    public LayerMask B_DestructibleLayer;
    public float attackRange = 2f;

    public ParticleSystem oSlash;
    public ParticleSystem bSlash;





    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            oSlash.Play();

            AttackO();
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

    }

    void AttackO()
    {
        Collider[] hitO_Destructibles = Physics.OverlapSphere(attackPoint.position, attackRange, O_DestructibleLayer);


        foreach(Collider O_Destructible in hitO_Destructibles)
        {
            Destroy(O_Destructible.gameObject);
            Debug.Log("We hit " + O_Destructible.name);

        }

    }

    void AttackB()
    {
        Collider[] hitB_Destructibles = Physics.OverlapSphere(attackPoint.position, attackRange, B_DestructibleLayer);


        foreach (Collider B_Destructible in hitB_Destructibles)
        {
            Destroy(B_Destructible.gameObject);
            Debug.Log("We hit " + B_Destructible.name);

        }

    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }


}
