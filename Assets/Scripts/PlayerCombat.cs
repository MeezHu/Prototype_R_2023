using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Transform attackPoint;
    public LayerMask O_DestructibleLayer;
    public LayerMask B_DestructibleLayer;
    public float attackRange = 2f;





    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            AttackO();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            AttackB();
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
