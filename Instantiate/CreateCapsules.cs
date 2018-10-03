using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateCapsules : MonoBehaviour
{
    public GameObject Mercenary;
    public GameObject Bandit;
    public GameObject Infantryman;
    public GameObject Necromancer;
    public GameObject Wizard;
    public GameObject Priest;

    public Button moveButt;
    public Button attackButt;
    public Button passButt;

    private GameObject unit;
    private PlayerActions unitScript;





    public void CreateMercenary1()
    {
        Vector3 SpawnPos = new Vector3(0.5f, 1f, -5f);
        unit=Instantiate(Mercenary,SpawnPos,Quaternion.identity);
        unit.name = "mercenary1";
        unit.tag = "Player1";
        unit.AddComponent<PlayerActions>();
        unitScript = unit.GetComponent<PlayerActions>();
        unitScript.unitclass = TacticsActions.Classes.Mercenary;

        moveButt.onClick.AddListener(unitScript.PresetMove);
        attackButt.onClick.AddListener(unitScript.PresetAttack);
        passButt.onClick.AddListener(unitScript.PresetPass);
    }

    public void CreateBandit1()
    {
        Vector3 SpawnPos = new Vector3(0.5f, 1f, -5f);
        unit = Instantiate(Bandit, SpawnPos, Quaternion.identity);
        unit.name = "bandit1";
        unit.tag = "Player1";
        unit.AddComponent<PlayerActions>();
        unitScript = unit.GetComponent<PlayerActions>();
        unitScript.unitclass = TacticsActions.Classes.Bandit;

        moveButt.onClick.AddListener(unitScript.PresetMove);
        attackButt.onClick.AddListener(unitScript.PresetAttack);
        passButt.onClick.AddListener(unitScript.PresetPass);
    }

    public void CreateInfantryman1()
    {
        Vector3 SpawnPos = new Vector3(0.5f, 1f, -5f);
        unit = Instantiate(Infantryman, SpawnPos, Quaternion.identity);
        unit.name = "Infantry1";
        unit.tag = "Player1";
        unit.AddComponent<PlayerActions>();
        unitScript = unit.GetComponent<PlayerActions>();
        unitScript.unitclass = TacticsActions.Classes.Infantryman;

        moveButt.onClick.AddListener(unitScript.PresetMove);
        attackButt.onClick.AddListener(unitScript.PresetAttack);
        passButt.onClick.AddListener(unitScript.PresetPass);
    }

    public void CreateNecromancer1()
    {
        Vector3 SpawnPos = new Vector3(0.5f, 1f, -5f);
        unit = Instantiate(Necromancer, SpawnPos, Quaternion.identity);
        unit.name = "necromancer1";
        unit.tag = "Player1";
        unit.AddComponent<PlayerActions>();
        unitScript = unit.GetComponent<PlayerActions>();
        unitScript.unitclass = TacticsActions.Classes.Necromancer;

        moveButt.onClick.AddListener(unitScript.PresetMove);
        attackButt.onClick.AddListener(unitScript.PresetAttack);
        passButt.onClick.AddListener(unitScript.PresetPass);
    }

    public void CreateWizard1()
    {
        Vector3 SpawnPos = new Vector3(0.5f, 1f, -5f);
        unit = Instantiate(Mercenary, SpawnPos, Quaternion.identity);
        unit.name = "wizard1";
        unit.tag = "Player1";
        unit.AddComponent<PlayerActions>();
        unitScript = unit.GetComponent<PlayerActions>();
        unitScript.unitclass = TacticsActions.Classes.Wizard;

        moveButt.onClick.AddListener(unitScript.PresetMove);
        attackButt.onClick.AddListener(unitScript.PresetAttack);
        passButt.onClick.AddListener(unitScript.PresetPass);
    }

    public void CreatePriest1()
    {
        Vector3 SpawnPos = new Vector3(0.5f, 1f, -5f);
        unit = Instantiate(Priest, SpawnPos, Quaternion.identity);
        unit.name = "priest1";
        unit.tag = "Player1";
        unit.AddComponent<PlayerActions>();
        unitScript = unit.GetComponent<PlayerActions>();
        unitScript.unitclass = TacticsActions.Classes.Priest;

        moveButt.onClick.AddListener(unitScript.PresetMove);
        attackButt.onClick.AddListener(unitScript.PresetAttack);
        passButt.onClick.AddListener(unitScript.PresetPass);
    }







    public void CreateMercenary2()
    {
        Vector3 SpawnPos = new Vector3(0.7f, 1f, 4f);
        unit = Instantiate(Mercenary, SpawnPos, Quaternion.identity);
        unit.name = "mercenary2";
        unit.tag = "Player2";
        unit.AddComponent<PlayerActions>();
        unitScript = unit.GetComponent<PlayerActions>();
        unitScript.unitclass = TacticsActions.Classes.Necromancer;

        moveButt.onClick.AddListener(unitScript.PresetMove);
        attackButt.onClick.AddListener(unitScript.PresetAttack);
        passButt.onClick.AddListener(unitScript.PresetPass);


    }

    public void CreateBandit2()
    {
        Vector3 SpawnPos = new Vector3(0.7f, 1f, 4f);
        unit = Instantiate(Bandit, SpawnPos, Quaternion.identity);
        unit.name = "bandit2";
        unit.tag = "Player2";
        unit.AddComponent<PlayerActions>();
        unitScript = unit.GetComponent<PlayerActions>();
        unitScript.unitclass = TacticsActions.Classes.Bandit;

        moveButt.onClick.AddListener(unitScript.PresetMove);
        attackButt.onClick.AddListener(unitScript.PresetAttack);
        passButt.onClick.AddListener(unitScript.PresetPass);
    }

    public void CreateInfantryman2()
    {
        Vector3 SpawnPos = new Vector3(0.7f, 1f, 4f);
        unit = Instantiate(Infantryman, SpawnPos, Quaternion.identity);
        unit.name = "Infantry2";
        unit.tag = "Player2";
        unit.AddComponent<PlayerActions>();
        unitScript = unit.GetComponent<PlayerActions>();
        unitScript.unitclass = TacticsActions.Classes.Infantryman;

        moveButt.onClick.AddListener(unitScript.PresetMove);
        attackButt.onClick.AddListener(unitScript.PresetAttack);
        passButt.onClick.AddListener(unitScript.PresetPass);
    }

    public void CreateNecromancer2()
    {
        Vector3 SpawnPos = new Vector3(0.7f, 1f, 4f);
        unit = Instantiate(Necromancer, SpawnPos, Quaternion.identity);
        unit.name = "necromancer2";
        unit.tag = "Player2";
        unit.AddComponent<PlayerActions>();
        unitScript = unit.GetComponent<PlayerActions>();
        unitScript.unitclass = TacticsActions.Classes.Necromancer;

        moveButt.onClick.AddListener(unitScript.PresetMove);
        attackButt.onClick.AddListener(unitScript.PresetAttack);
        passButt.onClick.AddListener(unitScript.PresetPass);
    }

    public void CreateWizard2()
    {
        Vector3 SpawnPos = new Vector3(0.7f, 1f, 4f);
        unit = Instantiate(Mercenary, SpawnPos, Quaternion.identity);
        unit.name = "wizard2";
        unit.tag = "Player2";
        unit.AddComponent<PlayerActions>();
        unitScript = unit.GetComponent<PlayerActions>();
        unitScript.unitclass = TacticsActions.Classes.Wizard;

        moveButt.onClick.AddListener(unitScript.PresetMove);
        attackButt.onClick.AddListener(unitScript.PresetAttack);
        passButt.onClick.AddListener(unitScript.PresetPass);
    }

    public void CreatePriest2()
    {
        Vector3 SpawnPos = new Vector3(0.7f, 1f, 4f);
        unit = Instantiate(Priest, SpawnPos, Quaternion.identity);
        unit.name = "priest2";
        unit.tag = "Player2";
        unit.AddComponent<PlayerActions>();
        unitScript = unit.GetComponent<PlayerActions>();
        unitScript.unitclass = TacticsActions.Classes.Priest;

        moveButt.onClick.AddListener(unitScript.PresetMove);
        attackButt.onClick.AddListener(unitScript.PresetAttack);
        passButt.onClick.AddListener(unitScript.PresetPass);
    }











}
