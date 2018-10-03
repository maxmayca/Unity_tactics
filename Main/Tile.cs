using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public bool available = true;
    public bool current = false;
    public bool target = false;
    public bool walkable = false;
    public bool runnable = false;
    public bool attackable = false;
    public bool targetable = false;
    public bool orientation = false;

    


    public List<Tile> adjacencyList = new List<Tile>();
    public List<Tile> adjacencyList2 = new List<Tile>();
    public List<Tile> adjacencyListEnnemies = new List<Tile>();

    public bool visited = false;
    public Tile parent = null;
    public int distance = 0;

    //for A*

    public float f = 0;
    public float g = 0;
    public float h = 0;

    // Use this for initialization
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if (current)
        {
            GetComponent<Renderer>().material.color = Color.grey;
        }
        else if (orientation)
        {
            GetComponent<Renderer>().material.color = Color.green;
        }
        else if (target)
        {
            GetComponent<Renderer>().material.color = Color.black;

        }
        else if (targetable)
        {
            GetComponent<Renderer>().material.color = Color.red;
        }
        else if (attackable)
        {
            GetComponent<Renderer>().material.color = Color.yellow;
        }
        else if (walkable)
        {
            GetComponent<Renderer>().material.color = Color.cyan;

        }
        else if (runnable)
        {
            GetComponent<Renderer>().material.color = Color.blue;
        }
        else
        {
            GetComponent<Renderer>().material.color = Color.white;

        }

    }
    public void Reset()
    {
        adjacencyList.Clear();
        adjacencyList2.Clear();
        adjacencyListEnnemies.Clear();
        

        current = false;
        target = false;
        walkable = false;
        runnable = false;
        attackable = false;
        targetable = false;
        orientation = false;
    


        visited = false;
        parent = null;
        distance = 0;

        f = g = h = 0;
    }
    public void PartialReset()
    {
        adjacencyList.Clear();
        adjacencyList2.Clear();
        adjacencyListEnnemies.Clear();

        current = false;
        target = false;
        
        
       


        visited = false;
        parent = null;
        distance = 0;

        f = g = h = 0;
    }
    public void FindNeighbors(float jumpHeight, Tile target)
    {
        Reset();


        CheckTile(Vector3.forward, jumpHeight,target);
        CheckTile(-Vector3.forward, jumpHeight,target);
        CheckTile(Vector3.right, jumpHeight,target);
        CheckTile(-Vector3.right, jumpHeight,target);
    }

    public void FindNeighbors2(float jumpHeight, Tile target)
    {
        PartialReset();


        CheckTile(Vector3.forward, jumpHeight, target);
        CheckTile(-Vector3.forward, jumpHeight, target);
        CheckTile(Vector3.right, jumpHeight, target);
        CheckTile(-Vector3.right, jumpHeight, target);
    }


    public void FindNeighborsEnnemies(float jumpHeight, Tile target)
 {
     Reset();


     CheckTileForEnnemies(Vector3.forward, jumpHeight, target);
     CheckTileForEnnemies(-Vector3.forward, jumpHeight, target);
     CheckTileForEnnemies(Vector3.right, jumpHeight, target);
     CheckTileForEnnemies(-Vector3.right, jumpHeight, target);
 }
    public void CheckTileForEnnemies(Vector3 direction, float jumpHeight,Tile target)
    {
        Vector3 halfExtents = new Vector3(0.25f, (1 + jumpHeight) / 2.0f, 0.25f);
        Collider[] colliders = Physics.OverlapBox(transform.position + direction, halfExtents);

        foreach (Collider item in colliders)
        {
            
            Tile tile = item.GetComponent<Tile>();
            if (tile != null && tile.available)
            {
                RaycastHit hit;

               // if (!Physics.Raycast(tile.transform.position, Vector3.up, out hit, 1)|| (tile==target))
                //{



                    adjacencyList2.Add(tile);
                //  }
                //else
                if (Physics.Raycast(tile.transform.position, Vector3.up, out hit, 1) || (tile == target))
                {
                  adjacencyListEnnemies.Add(tile);
                }

            }

        }
    }
    public void CheckTile(Vector3 direction, float jumpHeight, Tile target)
    {
        Vector3 halfExtents = new Vector3(0.25f, (1 + jumpHeight) / 2.0f, 0.25f);
        Collider[] colliders = Physics.OverlapBox(transform.position + direction, halfExtents);

        foreach (Collider item in colliders)
        {

            Tile tile = item.GetComponent<Tile>();
            if (tile != null && tile.available)
            {
                RaycastHit hit;

                 if (!Physics.Raycast(tile.transform.position, Vector3.up, out hit, 1)|| (tile==target))
                {



                adjacencyList.Add(tile);
                  }
              

            }

        }
    }



}
