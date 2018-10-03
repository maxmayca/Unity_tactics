using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : TacticsCombat
{
    /*

    // Use this for initialization
    void Start()
    {
        Init();

    }

    // Update is called once per frame
    void Update()
    {
         Debug.DrawRay(transform.position, transform.forward);

        if (!dead)
        {
            if (!turn)
            {
                return;
            }

            if (!attacking)
            {
                // FindTargetableTiles();
                FindAttackableTiles();

                CheckMouse();



            }
            else
            {
                Attack();
            }
        }
        else
        {
            Destroy(gameObject);
        }
       

           
        
        


    } 
    void CheckMouse()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "Tile")
                {
                    Tile t = hit.collider.GetComponent<Tile>();

                    if (t.targetable)
                    {
                        //todo move target
                       
                        AttackTile(t);
                       
                        
                    }
                }
            }
        }
    } */
}
