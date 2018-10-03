using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    /*static Dictionary<string, List<TacticsMove>> units = new Dictionary<string, List<TacticsMove>>();
    static Queue<string> turnKey = new Queue<string>();
    static Queue<TacticsMove> turnTeam = new Queue<TacticsMove>();*/
    static Dictionary<string, List<TacticsActions>> units = new Dictionary<string, List<TacticsActions>>();
    static Queue<string> turnKey = new Queue<string>();
    static Queue<TacticsActions> turnTeam = new Queue<TacticsActions>();









    // Use this for initialization
    void Start ()
    {
		
	}
	
	/*// Update is called once per frame
	void Update ()
    {
        

        if (turnUnit.Count==0)
        {
            InitUnitTurnQueue();
        }
	}

    static void InitUnitTurnQueue()
    {
        


        foreach (TacticsCombat unit in list)
        {
            turnUnit.Enqueue(unit);
        }
        StartTurn();
    }

    public static void StartTurn()
    {
        if(turnUnit.Count>0)
        {
            turnUnit.Peek().BeginTurn();
        }
    }

    public static void EndTurn()
    {
        TacticsCombat unit = turnUnit.Dequeue();
        turnUnit.Enqueue(unit);
        unit.EndTurn();

        if(turnUnit.Count>0)
        {
            StartTurn();
        }
       
    }

    public static void  AddUnit(TacticsCombat unit)
    {
        List<TacticsCombat> list;
        

        
        if(!units.ContainsKey(unit.tag))
        {
            list = new List<TacticsCombat>();
            units[unit.tag] = list;

           
        }
        else
        {
            list = units[unit.tag];
        }

        list.Add(unit);
        
    }*/
    
     	void Update ()
    {
       
		if(turnTeam.Count==0)
        {
            InitUnitTurnQueue();
        }
	}

    static void InitUnitTurnQueue()
    {
        List<TacticsActions> unitList = units[turnKey.Peek()];

        foreach(TacticsActions unit in unitList)
        {
            turnTeam.Enqueue(unit);
        }
        StartTurn();
    }

    public static void StartTurn()
    {
        if(turnTeam.Count>0)
        {
            turnTeam.Peek().BeginTurn();
        }
    }

    public static void EndTurn()
    {
        TacticsActions unit = turnTeam.Dequeue();
        unit.EndTurn();
        
        


        if(turnTeam.Count>0)
        {
            StartTurn();
        }
        else
        {
            string team = turnKey.Dequeue();
            turnKey.Enqueue(team);
            InitUnitTurnQueue();
        }
    }

    public static void  AddUnit(TacticsActions unit)
    {
        List<TacticsActions> list;
        if(!units.ContainsKey(unit.tag))
        {
            list = new List<TacticsActions>();
            units[unit.tag] = list;

            if(!turnKey.Contains(unit.tag))
            {
                turnKey.Enqueue(unit.tag);
            }
        }
        else
        {
            list = units[unit.tag];
        }

        list.Add(unit);
    }


    
   
}
