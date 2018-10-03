using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TacticsActions : MonoBehaviour
{

    public bool turn = false;

    List<Tile> walkableTiles = new List<Tile>();
    List<Tile> runnableTiles = new List<Tile>();
    List<Tile> attackableTiles = new List<Tile>();
    List<Tile> targetableTiles = new List<Tile>();
    List<Tile> orientationTiles = new List<Tile>();
    GameObject[] tiles;

    Stack<Tile> path = new Stack<Tile>();
    Tile currentTile;
    TacticsActions Target;

    public enum Classes { Mercenary,Bandit,Infantryman,Necromancer, Wizard, Priest};
    public Classes unitclass;

    public bool action1 = false;
    public bool action2 = false;
    public bool action3 = false;
    public bool moved = false;

    public bool findwtile = false;
    public bool findrtile = false;

    public bool walking = false;
    public bool running = false;
   // public int walk = 2;
    //public int run = 4;
    public bool attacking = false;
   // public int power = 3;
    //public int maxHP = 9;
   // public int HP;
    public int range = 1;
   // public float jumpHeight = 2;
    public float moveSpeed = 2;
    public float jumpVelocity = 4.5f;

    public bool dead = false;

    Vector3 velocity = new Vector3();
    Vector3 heading = new Vector3();

    float halfHeight = 0;

    bool FallingDown = false;
    bool JumpingUp = false;
    bool movingEdge = false;
    bool center = false;
    bool edge = false;
    Vector3 jumpTarget;

    public Tile actualTargetTile;

    public int constitution=new int();
    public int strengh = new int();
    public int dexterity = new int();
    public int resolve = new int();
    public int intelligence = new int();
    public int wisdom = new int();
    public int perception = new int();
    public int walk = new int();
    public int strictrun = new int();
    public int jumpheight = new int();

    public int maxHP = new int();
    public int HP = new int();
    public int power = new int();
    public double critics = new double();
    public double accuracy = new double();
    public int maxEP = new int();
    public int EP = new int();
    public int magicpower = new int();
    public double magiccritics = new double();
    public double magicaccuracy = new double();
    public int celerity = new int();
    public int run = new int();

    protected void Init()
    {
        tiles = GameObject.FindGameObjectsWithTag("Tile");

        halfHeight = GetComponent<Collider>().bounds.extents.y;

        

        TurnManager.AddUnit(this);


    }
    protected void SetMercenary()
    {
        constitution = 2;
        strengh = 3;
        dexterity = 2;
        resolve = 1;
        intelligence = 1;
        wisdom = 1;
        perception = 2;
        walk = 2;
        strictrun = 2;
        jumpheight = 1;
    }

    protected void SetBandit()
    {
        constitution = 1;
        strengh = 1;
        dexterity = 3;
        resolve = 2;
        intelligence = 1;
        wisdom = 1;
        perception = 3;
        walk = 3;
        strictrun = 2;
        jumpheight = 1;
    }

    protected void SetInfantryman()
    {
        constitution = 3;
        strengh = 3;
        dexterity = 2;
        resolve = 2;
        intelligence = 1;
        wisdom = 1;
        perception = 1;
        walk = 2;
        strictrun = 1;
        jumpheight = 1;
    }

    protected void SetNecromancer()
    {
        constitution = 2;
        strengh = 1;
        dexterity = 1;
        resolve = 2;
        intelligence = 2;
        wisdom = 3;
        perception = 1;
        walk = 2;
        strictrun = 1;
        jumpheight = 1;
    }

    protected void SetWizard()
    {
        constitution = 1;
        strengh = 1;
        dexterity = 1;
        resolve = 2;
        intelligence = 3;
        wisdom = 2;
        perception = 1;
        walk = 2;
        strictrun = 1;
        jumpheight = 1;
    }

    protected void SetPriest()
    {
        constitution = 1;
        strengh = 1;
        dexterity = 1;
        resolve = 3;
        intelligence = 2;
        wisdom = 3;
        perception = 1;
        walk = 2;
        strictrun = 1;
        jumpheight = 1;
    }


    protected void InitStats()
    {
        maxHP = constitution * 10;
        HP = maxHP;
        power = strengh;
        critics = dexterity / 100;
        accuracy = 1 - (45 - 5 * dexterity) / (100 * dexterity);
        maxEP = resolve * 10;
        EP = maxEP;
        magicpower = intelligence;
        magiccritics = wisdom / 100;
        magicaccuracy = 1 - (45 - 5 * wisdom) / (100 * wisdom);
        celerity = strengh + dexterity;
        run = strictrun + walk;
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

    public void ComputeAdjacencyLists(float jumpHeight, Tile target)
    {
        foreach (GameObject tile in tiles)
        {
            Tile t = tile.GetComponent<Tile>();
            t.FindNeighbors(jumpHeight, target);
        }

    }

    public void ComputeAdjacencyListsPartial(float jumpHeight, Tile target)
    {
        foreach (GameObject tile in tiles)
        {
            Tile t = tile.GetComponent<Tile>();
            t.FindNeighbors2(jumpHeight, target);
        }

    }

   

    public void FindWalkableTiles()
    {
        ComputeAdjacencyLists(jumpheight, null);
        GetCurrentTile();

        Queue<Tile> process = new Queue<Tile>();
        

        process.Enqueue(currentTile);
       
        currentTile.visited = true;


        while (process.Count > 0)
        {
            Tile t = process.Dequeue();
            walkableTiles.Add(t);
            t.walkable = true;


            if (t.distance < walk)
            {

                foreach (Tile tile in t.adjacencyList)
                {
                    if (!tile.visited)
                    {
                        tile.parent = t;
                        tile.visited = true;
                        tile.distance = 1 + t.distance;
                        process.Enqueue(tile);

                    }
                }
            }
        }
        
       
        
        
    }

    public void FindRunnableTiles()
    {

        ComputeAdjacencyListsPartial(jumpheight, null);
        GetCurrentTile();

        Queue<Tile> process = new Queue<Tile>();


        process.Enqueue(currentTile);

        currentTile.visited = true;

        
            while (process.Count > 0)
            {
                Tile t = process.Dequeue();
                runnableTiles.Add(t);
                t.runnable = true;

                if (t.distance < run)
                {

                    foreach (Tile tile in t.adjacencyList)
                    {
                        if (!tile.visited)
                        {
                            tile.parent = t;
                            tile.visited = true;
                            tile.distance = 1 + t.distance;
                            process.Enqueue(tile);

                        }
                    }
                }
            }
        
       
          
           
        
        
    }

    public void FixTile()
    {
        foreach (Tile tile in walkableTiles)
        {

            tile.runnable = false;
            runnableTiles.Remove(tile);

        }
    }



    public void WalkToTile(Tile tile)
    {
        path.Clear();
        tile.target = true;
        walking = true;

        Tile next = tile;
        while (next != null)
        {
            path.Push(next);
            next = next.parent;
        }
    }

    public void RunToTile(Tile tile)
    {
        path.Clear();
        tile.target = true;
        running = true;

        Tile next = tile;
        while (next != null)
        {
            path.Push(next);
            next = next.parent;
        }
    }

    public void Walk()
    {
        if (path.Count > 0)
        {
            Tile t = path.Peek();
            Vector3 target = t.transform.position;

            //calculate the unit postion on top of the target tile
            target.y += halfHeight + t.GetComponent<Collider>().bounds.extents.y;

            if (Vector3.Distance(transform.position, target) >= 0.05f)
            {
                /*bool jump = transform.position.y != target.y;

                if (jump)
                {
                    Jump(target);
                }
                else
                {*/
                CalculateHeading(target);
                SetHorizontalVelocity();
                // }


                // Locomotion
                transform.forward = heading;
                transform.position += velocity * Time.deltaTime;
            }
            else
            {
                //tile center reached
                transform.position = target;
                path.Pop();
            }


        }
        else
        {
            RemoveWalkableTiles();
            RemoveRunnableTiles();
            walking = false;

            action1 = false;
            action2 = false;
            action3 = false;

            moved = true;


        }
    }

    public void Run()
    {
        if (path.Count > 0)
        {
            Tile t = path.Peek();
            Vector3 target = t.transform.position;

            //calculate the unit postion on top of the target tile
            target.y += halfHeight + t.GetComponent<Collider>().bounds.extents.y;

            if (Vector3.Distance(transform.position, target) >= 0.05f)
            {
                /*bool jump = transform.position.y != target.y;

                if (jump)
                {
                    Jump(target);
                }
                else
                {*/
                CalculateHeading(target);
                SetHorizontalVelocity();
                velocity *= 2.0f;
                // }


                // Locomotion
                transform.forward = heading;
                transform.position += velocity * Time.deltaTime;
            }
            else
            {
                //tile center reached
                transform.position = target;
                path.Pop();
            }


        }
        else
        {
            RemoveWalkableTiles();
            RemoveRunnableTiles();
            running = false;

            action1 = false;
            action2 = false;
            action3 = false;

            TurnManager.EndTurn();


        }
    }

    protected void RemoveWalkableTiles()
    {
        if (currentTile != null)
        {
            currentTile.current = false;
            currentTile = null;

        }

        foreach (Tile tile in walkableTiles)
        {
            tile.Reset();
        }

        walkableTiles.Clear();
    }

    protected void RemoveRunnableTiles()
    {
        if (currentTile != null)
        {
            currentTile.current = false;
            currentTile = null;

        }

        foreach (Tile tile in runnableTiles)
        {
            tile.Reset();
        }

        runnableTiles.Clear();
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

    void Jump(Vector3 target)
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

    /* protected Tile FindLowestF(List<Tile> list)
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



     } */

    public void BeginTurn()
    {
        turn = true;

        findwtile = false;
        findrtile = false;
        
        action1 = false;
        action2 = false;
        action3 = false;
        moved = false;
    }

    public void EndTurn()
    {
        turn = false;
        
    }





    // ***************************Attack*******************************************  

    public TacticsActions FindTargetUnit(Tile tile)
    {


        RaycastHit hit;
        TacticsActions TargetUnit = null;

        if (Physics.Raycast(tile.transform.position, Vector3.up, out hit, 1))
        {
            TargetUnit = hit.collider.GetComponent<TacticsActions>();
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
        ComputeAdjacencyLists2(jumpheight, null);
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

            if (Target.HP - this.power > 0)
            {
                Target.HP -= this.power;
            }
            else
            {
                Target.dead = true;

                //DestroyGameObject();
                Target.HP = 0;
            }

            action1 = false;
            action2 = false;
            action3 = false;

            TurnManager.EndTurn();

            Debug.Log(Target.HP);
        }
    }



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


        Vector3 target = targetTile.transform.position;
        target.y += halfHeight + targetTile.GetComponent<Collider>().bounds.extents.y;




        if (Vector3.Distance(transform.position, target) <= 1f)
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

    public void PresetMove()
    {
        if (!moved)
        {
           action1 = true;
           action2 = false;
           action3 = false;
        }
    }

    public void PresetAttack()
    {
        action1 = false;
        action2 = true;
        action3 = false;
    }

    public void PresetPass()
    {
        action1 = false;
        action2 = false;
        action3 = true;
    }

    public void ReturnToMove()
    {
        action1 = false;
       
        
        RemoveWalkableTiles();
        RemoveRunnableTiles();
    }
    public void ReturnToAttack()
    {
        action2 = false;
        RemoveTargetableTiles();
        RemoveAttackableTiles();
    }

    public void ReturnToPass()
    {
        action3 = false;
        RemoveOrientationTiles();
       
    }

    //*************************************************Pass*****************************************

    public void FindOrientationTiles()
    {
        ComputeAdjacencyLists2(jumpheight, null);
        GetCurrentTile();

        Queue<Tile> process = new Queue<Tile>();

        process.Enqueue(currentTile);
        currentTile.visited = true;

        while (process.Count > 0)
        {
            Tile t = process.Dequeue();
            orientationTiles.Add(t);
            t.orientation = true;

            if (t.distance < 1)
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
            }

        }
    }

   


    public void Pass(Tile tile)
    {
        Vector3 target = tile.transform.position;
        CalculateHeading(target);


        



        

            RemoveOrientationTiles();
            
            

          

            action1 = false;
            action2 = false;
        action3 = false;

            TurnManager.EndTurn();

            
        
    }

protected void RemoveOrientationTiles()
{
    if (currentTile != null)
    {
        currentTile.current = false;
        currentTile = null;

    }

    foreach (Tile tile in orientationTiles)
    {
        tile.Reset();
    }

    orientationTiles.Clear();
}







}
