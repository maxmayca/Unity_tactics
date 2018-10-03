using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : TacticsActions
{

    // Use this for initialization
    void Start()
    {
        Init();
        if (unitclass==Classes.Mercenary)
        {
        SetMercenary();
         }
        else if(unitclass==Classes.Bandit)
        {
            SetBandit();
        }
        else if (unitclass == Classes.Infantryman)
        {
            SetInfantryman();
        }
        else if (unitclass == Classes.Necromancer)
        {
            SetNecromancer();
        }
        else if (unitclass == Classes.Wizard)
        {
            SetWizard();
        }
        else if (unitclass == Classes.Priest)
        {
            SetPriest();
        }
        InitStats();
       
    }
	
	// Update is called once per frame
	void Update ()
    {
        Debug.DrawRay(transform.position, transform.forward);

        if (!dead)
        {
            if (!turn)
            {
                return;
            }
            else
            {
               
                    if (action1)
                    {
                        if (!walking && !running)
                        {
                        if (!findwtile)
                        {
                            FindWalkableTiles();
                            findwtile = true;
                        }
                        else if (findwtile && !findrtile)
                        {
                            FindRunnableTiles();
                            findrtile = true;
                        }
                        else
                        {
                            FixTile();
                            CheckMouseM();
                        }
                        


                        

                            if (Input.GetKeyDown(KeyCode.Escape))
                            {
                                ReturnToMove();
                            
                            }



                        }
                        else if (walking)
                        {
                            Walk();
                        }
                        else if(running)
                         {
                        Run();
                          }
                    }
                    else if (action2)
                    {
                        if (!attacking)
                        {

                            FindAttackableTiles();

                            CheckMouseA();

                            if (Input.GetKeyDown(KeyCode.Escape))
                            {
                                ReturnToAttack();
                            }



                        }
                        else
                        {
                            Attack();
                        }
                    }

                    else if (action3)
                    {

                        FindOrientationTiles();

                        CheckMouseP();

                        if (Input.GetKeyDown(KeyCode.Escape))
                        {
                            ReturnToPass();
                        }


                    }
                
               
            }
        }
        else
        {
            Destroy(gameObject);
        }


    }
    void CheckMouseM()
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

                    if (t.walkable)
                    {
                        //todo move target
                        WalkToTile(t);
                    }
                    if(t.runnable)
                    {
                        RunToTile(t);
                    }
                }
            }
        }
    }



   

    void CheckMouseA()
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
    }

    void CheckMouseP()
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

                    if (t.orientation)
                    {
                        //todo move target
                        Pass(t);
                    }
                }
            }
        }
    }
}



