using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    public GameObject mainmenu;
    public GameObject Actions;
    public GameObject map;
    public GameObject CreateCharacter1;
    public GameObject CreateCharacter2;
    public GameObject ClassDescription1;
    public GameObject ClassDescription2;
    public GameObject ClassDescription3;
    public GameObject ClassDescription4;
    public GameObject ClassDescription5;
    public GameObject ClassDescription6;
    public GameObject ClassDescription21;
    public GameObject ClassDescription22;
    public GameObject ClassDescription23;
    public GameObject ClassDescription24;
    public GameObject ClassDescription25;
    public GameObject ClassDescription26;


    public void GoToTest()
    {
        mainmenu.SetActive(false);
        Actions.SetActive(true);
    }

    public void NewGame()
    {
        mainmenu.SetActive(false);
        CreateCharacter1.SetActive(true);
        ClassDescription1.SetActive(false);
        ClassDescription2.SetActive(false);
        ClassDescription3.SetActive(false);
        ClassDescription4.SetActive(false);
        ClassDescription5.SetActive(false);
        ClassDescription6.SetActive(false);

    }

    public void ClickMercenary()
    {
        ClassDescription1.SetActive(true);
        ClassDescription2.SetActive(false);
        ClassDescription3.SetActive(false);
        ClassDescription4.SetActive(false);
        ClassDescription5.SetActive(false);
        ClassDescription6.SetActive(false);
    }

    public void ClickBandit()
    {
        ClassDescription1.SetActive(false);
        ClassDescription2.SetActive(true);
        ClassDescription3.SetActive(false);
        ClassDescription4.SetActive(false);
        ClassDescription5.SetActive(false);
        ClassDescription6.SetActive(false);
    }

    public void ClickInfantry()
    {
        ClassDescription1.SetActive(false);
        ClassDescription2.SetActive(false);
        ClassDescription3.SetActive(true);
        ClassDescription4.SetActive(false);
        ClassDescription5.SetActive(false);
        ClassDescription6.SetActive(false);
    }

    public void ClickNecromancer()
    {
        ClassDescription1.SetActive(false);
        ClassDescription2.SetActive(false);
        ClassDescription3.SetActive(false);
        ClassDescription4.SetActive(true);
        ClassDescription5.SetActive(false);
        ClassDescription6.SetActive(false);
    }

    public void ClickWizard()
    {
        ClassDescription1.SetActive(false);
        ClassDescription2.SetActive(false);
        ClassDescription3.SetActive(false);
        ClassDescription4.SetActive(false);
        ClassDescription5.SetActive(true);
        ClassDescription6.SetActive(false);
    }

    public void ClickPriest()
    {
        ClassDescription1.SetActive(false);
        ClassDescription2.SetActive(false);
        ClassDescription3.SetActive(false);
        ClassDescription4.SetActive(false);
        ClassDescription5.SetActive(false);
        ClassDescription6.SetActive(true);
    }

    public void ReturnToMain()
    {
        mainmenu.SetActive(true);
        CreateCharacter1.SetActive(false);
        ClassDescription1.SetActive(false);
        ClassDescription2.SetActive(false);
        ClassDescription3.SetActive(false);
        ClassDescription4.SetActive(false);
        ClassDescription5.SetActive(false);
        ClassDescription6.SetActive(false);
    }

    public void NextCharacter()
    {
        CreateCharacter1.SetActive(false);
        CreateCharacter2.SetActive(true);
        ClassDescription21.SetActive(false);
        ClassDescription22.SetActive(false);
        ClassDescription23.SetActive(false);
        ClassDescription24.SetActive(false);
        ClassDescription25.SetActive(false);
        ClassDescription26.SetActive(false);
    }

    public void ReturnToChar1()
    {
        
        CreateCharacter1.SetActive(true);
        CreateCharacter2.SetActive(false);
        ClassDescription1.SetActive(false);
        ClassDescription2.SetActive(false);
        ClassDescription3.SetActive(false);
        ClassDescription4.SetActive(false);
        ClassDescription5.SetActive(false);
        ClassDescription6.SetActive(false);
    }

    public void ClickMercenary2()
    {
        ClassDescription21.SetActive(true);
        ClassDescription22.SetActive(false);
        ClassDescription23.SetActive(false);
        ClassDescription24.SetActive(false);
        ClassDescription25.SetActive(false);
        ClassDescription26.SetActive(false);
    }

    public void ClickBandit2()
    {
        ClassDescription21.SetActive(false);
        ClassDescription22.SetActive(true);
        ClassDescription23.SetActive(false);
        ClassDescription24.SetActive(false);
        ClassDescription25.SetActive(false);
        ClassDescription26.SetActive(false);
    }

    public void ClickInfantry2()
    {
        ClassDescription21.SetActive(false);
        ClassDescription22.SetActive(false);
        ClassDescription23.SetActive(true);
        ClassDescription24.SetActive(false);
        ClassDescription25.SetActive(false);
        ClassDescription26.SetActive(false);
    }

    public void ClickNecromancer2()
    {
        ClassDescription21.SetActive(false);
        ClassDescription22.SetActive(false);
        ClassDescription23.SetActive(false);
        ClassDescription24.SetActive(true);
        ClassDescription25.SetActive(false);
        ClassDescription26.SetActive(false);
    }

    public void ClickWizard2()
    {
        ClassDescription21.SetActive(false);
        ClassDescription22.SetActive(false);
        ClassDescription23.SetActive(false);
        ClassDescription24.SetActive(false);
        ClassDescription25.SetActive(true);
        ClassDescription26.SetActive(false);
    }

    public void ClickPriest2()
    {
        ClassDescription21.SetActive(false);
        ClassDescription22.SetActive(false);
        ClassDescription23.SetActive(false);
        ClassDescription24.SetActive(false);
        ClassDescription25.SetActive(false);
        ClassDescription26.SetActive(true);
    }

    public void EndCharacterSelection()
    {
        
        CreateCharacter2.SetActive(false);
        Actions.SetActive(true);
        map.AddComponent(typeof(TurnManager));

    }

}



