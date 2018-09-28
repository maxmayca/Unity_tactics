using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TacticsCombat : MonoBehaviour
{

    //public bool turn = false;

    List<Tile> attackableTiles = new List<Tile>();
    List<Tile> targetableTiles = new List<Tile>();
   
    GameObject[] tiles;
    


    Stack<Tile> path = new Stack<Tile>();
    Tile currentTile;
    test Target;


    public bool attacking = false;
    public int power = 3;
    public  int maxHP = 9;
    public int HP;
    public int range = 1;
    public float jumpHeight = 2;
    public float moveSpeed = 2;
    public float jumpVelocity = 4.5f;
    public bool dead = false;

    Vector3 velocity = new Vector3();
    Vector3 heading = new Vector3();

   

    float halfHeight = 0;

    bool center = false;
    bool edge = false;
    

    /* bool FallingDown = false;
     bool JumpingUp = false;
    bool movingEdge = false;
    bool movingBack = false; */

     
    
   

    // public Tile actualTargetTile;

    protected void Init()
    {
        tiles = GameObject.FindGameObjectsWithTag("Tile");

        halfHeight = GetComponent<Collider>().bounds.extents.y;

        HP = maxHP;






        //TurnManager.AddUnit(this);

    }

    public void GetCurrentTile()
    {
        currentTile = GetTargetTile(gameObject);
        currentTile.current = true;

    }
    public Tile GetTargetTile(GameObject target)
    {
        RaycastHit hit;
        Tile tile = null;

        if (Physics.Raycast(target.transform.position, -Vector3.up, out hit, 1))
        {
            tile = hit.collider.GetComponent<Tile>();
        }
        return tile;
    }

    public test FindTargetUnit(Tile tile)
    {
        /*Vector3 halfExtents = new Vector3(0.25f, (1 + jumpHeight) / 2.0f, 0.25f);
        Vector3 t = tile.transform.position;
        Collider[] targetcollider = Physics.OverlapBox(t+Vector3.up, halfExtents);*/

        RaycastHit hit;
        test TargetUnit = null;

        if (Physics.Raycast(tile.transform.position, Vector3.up, out hit, 1))
        {
            TargetUnit = hit.collider.GetComponent<test>();
        }
        return TargetUnit;

    }

   

    public void ComputeAdjacencyLists2(float jumpHeight, Tile target)
    {
        foreach (GameObject tile in tiles)
        {
            Tile t = tile.GetComponent<Tile>();
            t.FindNeighborsEnnemies(jumpHeight, target);
        }

    }
   





    public void FindAttackableTiles()
    {
        ComputeAdjacencyLists2(jumpHeight, null);
        GetCurrentTile();

        Queue<Tile> process = new Queue<Tile>();
       

        process.Enqueue(currentTile);
        currentTile.visited = true;

        while (process.Count > 0)
        {
            Tile t = process.Dequeue();
            attackableTiles.Add(t);
            t.attackable = true;

            if (t.distance < range)
            { 

                foreach (Tile tile in t.adjacencyList2)
                {
                    if (!tile.visited)
                    {
                        tile.parent = t;
                        tile.visited = true;
                        tile.distance = 1 + t.distance;
                        process.Enqueue(tile);

                    }
                }
                foreach (Tile tile in t.adjacencyListEnnemies)
                {
                    targetableTiles.Add(tile);
                    tile.targetable = true;
                    
                }

            }
           

        }

    }
   
   


    public void AttackTile(Tile tile)
    {
        path.Clear();
        tile.target = true;
        attacking = true;
        center = true;
        edge = false;
         Target = FindTargetUnit(tile);
        
       
        

        Tile next = tile;
        while (next != null)
        {
            path.Push(next);
            next = next.parent;
        }
        path.Pop();


        
     
    }
    

    public void Attack()
    {            
           
            Tile t1 = path.Peek();
        


        if (center)
             {
                 MoveToEdge(t1);

             }
             else if (edge)
             {
                 MoveToCenter(t1);
             }
            
        
        else
        {
            RemoveTargetableTiles();
            RemoveAttackableTiles();
            attacking = false;

            if(Target.HP-this.power>0)
            {
                Target.HP -= this.power;
            }
            else
            {
                Target.dead = true;
               
                //DestroyGameObject();
                Target.HP = 0;
            }
           

            
            Debug.Log(Target.HP);
        }
    }

  /*  void DestroyGameObject()
    {
       
    }*/

    void MoveToEdge(Tile targetTile)
    {
       
        Vector3 target = targetTile.transform.position;
        target.y += halfHeight + targetTile.GetComponent<Collider>().bounds.extents.y;





        if (Vector3.Distance(transform.position, target) >= 0.75f)
        {
            CalculateHeading(target);
            SetHorizontalVelocity();
            velocity *= 2f;

            transform.forward = heading;
            transform.position += velocity * Time.deltaTime;
            
        }
        else
        {
            center = false;
            edge = true;
       

        }
    }

    void MoveToCenter(Tile targetTile)
    {

      
        Vector3 target= targetTile.transform.position;
        target.y += halfHeight + targetTile.GetComponent<Collider>().bounds.extents.y;




        if (Vector3.Distance(transform.position, target)<=1f)
        {
            CalculateHeading(target);
            SetHorizontalVelocity();
            velocity *= 2f;

            transform.forward = heading;
            transform.position += -velocity * Time.deltaTime;


        }
        else
        {
            center = false;
            edge = false;
           
        }
    }

    


  












    //else



    //TurnManager.EndTurn();



    protected void RemoveAttackableTiles()
    {
        if (currentTile != null)
        {
            currentTile.current = false;
            currentTile = null;

        }

        foreach (Tile tile in attackableTiles)
        {
            tile.Reset();
        }

        attackableTiles.Clear();
    }
    protected void RemoveTargetableTiles()
    {
        if (currentTile != null)
        {
            currentTile.current = false;
            currentTile = null;

        }

        foreach (Tile tile in targetableTiles)
        {
            tile.Reset();
        }

        targetableTiles.Clear();
    }

    void CalculateHeading(Vector3 target)
    {
        heading = target - transform.position;
        heading.Normalize();
    }

    void SetHorizontalVelocity()
    {
        velocity = heading * moveSpeed;
    }

    /* void AttackForward()
     {
        Tile t = path.Peek();
        Vector3 target = t.transform.position;

        if (Vector3.Distance(transform.position, target) >= 0.5f )
         {
             CalculateHeading(target);
                    SetHorizontalVelocity();
                velocity /= 3.0f;
                


                // Locomotion
                transform.forward = heading;
                transform.position += velocity * Time.deltaTime;
         }
         else
         {
             center=false;
             edge=true;
         }
     }*/

   /* void AttackBackward()
    {
        Tile t = path.Peek();
        Vector3 target = t.transform.position;

        if (Vector3.Distance(transform.position, target) <= 1f)
        {
             CalculateHeading(target);
                SetHorizontalVelocity();
                velocity /= 3.0f;

                transform.forward = heading;
                transform.position -= velocity * Time.deltaTime;
        }
        else
        {
            center = false;
            edge= false;

            velocity /= 3.0f;
            velocity.y = 1.5f;
        }
    }*/


    /*void Jump(Vector3 target)
    {
        if (FallingDown)
        {

        }
        else if (JumpingUp)
        {

        }
        else if (movingEdge)
        {

        }
        else
        {
            PrepareJump(target);
        }
    }

    void PrepareJump(Vector3 target)
    {
        float targetY = target.y;

        target.y = transform.position.y;

        CalculateHeading(target);

        if (transform.position.y > targetY)
        {
            FallingDown = false;
            JumpingUp = false;
            movingEdge = true;

            jumpTarget = transform.position + (target - transform.position) / 2.0f;


        }
        else
        {
            FallingDown = false;
            JumpingUp = true;
            movingEdge = false;

            velocity = heading * moveSpeed / 3.0f;

            float difference = targetY - transform.position.y;

            velocity.y = jumpVelocity * (0.5f + difference / 2.0f);
        }
    } 

    void FallDownward(Vector3 target)
    {
        velocity += Physics.gravity * Time.deltaTime;

        if (transform.position.y <= target.y)
        {
            FallingDown = false;

            Vector3 p = transform.position;
            p.y = target.y;
            transform.position = p;

            velocity = new Vector3();
        }
    }

    void JumpUpward(Vector3 target)
    {
        velocity += Physics.gravity * Time.deltaTime;

        if (transform.position.y > target.y)
        {
            JumpingUp = false;
            FallingDown = true;

        }

    }

    void MoveToEdge()
    {
        if (Vector3.Distance(transform.position, jumpTarget) >= 0.05f)
        {
            SetHorizontalVelocity();
        }
        else
        {
            movingEdge = false;
            FallingDown = true;

            velocity /= 3.0f;
            velocity.y = 1.5f;
        }
    }

    protected Tile FindLowestF(List<Tile> list)
    {
        Tile lowest = list[0];

        foreach (Tile t in list)
        {
            if (t.f < lowest.f)
            {
                lowest = t;
            }
        }
        list.Remove(lowest);

        return lowest;
    }

    protected Tile FindEndTile(Tile t)
    {
        Stack<Tile> tempPath = new Stack<Tile>();

        Tile next = t.parent;
        while (next != null)
        {
            tempPath.Push(next);
            next = next.parent;
        }

        if (tempPath.Count <= move)
        {
            return t.parent;
        }

        Tile endTile = null;
        for (int i = 0; i <= move; i++)
        {
            endTile = tempPath.Pop();
        }

        return endTile;
    }

    protected void FindPath(Tile target)
    {
        ComputeAdjacencyLists(jumpHeight, target);
        GetCurrentTile();

        List<Tile> openList = new List<Tile>();
        List<Tile> closedList = new List<Tile>();

        openList.Add(currentTile);
        //currentTile.parent=??
        currentTile.h = Vector3.Distance(currentTile.transform.position, target.transform.position);
        currentTile.f = currentTile.h;

        while (openList.Count > 0)
        {
            Tile t = FindLowestF(openList);

            closedList.Add(t);

            if (t == target)
            {
                actualTargetTile = FindEndTile(t);
                MoveToTile(actualTargetTile);
                return;
            }

            foreach (Tile tile in t.adjacencyList)
            {
                if (closedList.Contains(tile))
                {
                    //do nothing
                }
                else if (openList.Contains(tile))
                {
                    float tempG = t.g + Vector3.Distance(tile.transform.position, t.transform.position);

                    if (tempG < tile.g)
                    {
                        tile.parent = t;

                        tile.g = tempG;
                        tile.f = tile.g + tile.h;
                    }

                }
                else
                {
                    tile.parent = t;

                    tile.g = t.g + Vector3.Distance(tile.transform.position, t.transform.position);
                    tile.h = Vector3.Distance(tile.transform.position, target.transform.position);
                    tile.f = tile.g + tile.h;

                    openList.Add(tile);
                }
            }
        }

        //What do you do if no path?
        Debug.Log("Path not found");



    }

    public void BeginTurn()
    {
        turn = true;
    }

    public void EndTurn()
    {
        turn = false;
    }*/
}
