using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityUI : MonoBehaviour
{
    public GameObject TerrainGenerator;
    public GameObject CreateStructure;


    public bool isSelectingTrees = false; //PUBLIC BOOLEAN GRABBED BY CAMERAOPERATOR


    // MAIN MENU GAMEOBJECTS & BOOLEANS
    public GameObject MainMenuGroup;
    public GameObject NewGameLoadGameGroup;
    public GameObject NewGameGroup;
    bool isInMainMenu = true;
    bool isInNewGameLoadGameGroup = false;
    bool isInNewGameGroup = false;


    //GAME UI GAMEOBJECTS & BOOLEANS
    public GameObject LowerBarGroup;
    public GameObject TopPanel;
    public GameObject OrdersMenuGroup;
    public GameObject ConstructionMenuGroup;
    public GameObject StructuresMenuGroup;
    bool isInOrdersMenu = false;
    bool isInConstructionMenu = false;
    bool isInStructuresMenu = false;


    bool isGameUIActive = false;


    void Start()
    {
        
    }

    void Update()
    {
        if(isInMainMenu)              { MainMenuGroup.active = true;  }
        else                          { MainMenuGroup.active = false; }

        if (isInNewGameLoadGameGroup) { NewGameLoadGameGroup.active = true;  }
        else                          { NewGameLoadGameGroup.active = false; }

        if (isInNewGameGroup)         { NewGameGroup.active = true;  }
        else                          { NewGameGroup.active = false; }

        if (isGameUIActive) {
            TopPanel.active = true;
            if(isInOrdersMenu) {
                LowerBarGroup.active = false;
                OrdersMenuGroup.active = true;
            }
            else if(isInConstructionMenu) {
                LowerBarGroup.active = false;
                ConstructionMenuGroup.active = true;
            }
            else if(isInStructuresMenu) {
                LowerBarGroup.active = false;
                StructuresMenuGroup.active = true;
            }
            else {
                OrdersMenuGroup.active = false;
                ConstructionMenuGroup.active = false;
                StructuresMenuGroup.active = false;
                LowerBarGroup.active = true;
            }
        }
        else {
            LowerBarGroup.active = false;
            TopPanel.active = false;
        }

    }


    // MAIN MENU FUNCTIONS
    public void onSinglePlayerButtonPressed() {
        isInMainMenu = false;
        isInNewGameLoadGameGroup = true;
    }
    public void onMultiplayerButtonPressed() {
        Debug.Log("Multiplayer Not Yet Implemented :(");
    }
    public void onOptionsButtonPressed() {
        Debug.Log("Options Menu Not Yet Implemented :(");
    }
    public void onQuitButtonPressed() {
        // WOULD LIKE TO HAVE AN "ARE YOU SURE?" MENU HERE
        Application.Quit();
    }

    // NEW GAME / LOAD GAME MENU FUNCTIONS
    public void onNewGameButtonPressed() {
        isInNewGameLoadGameGroup = false;
        isInNewGameGroup = true;
    }
    public void onLoadGameButtonPressed() {
        Debug.Log("Loading Games Is Coded But Not Yet Fully Integrated :(");
    }

    //NEW GAME MENU FUNCTIONS
    public void onTerrainGeneratorButtonPressed() {
        isInNewGameGroup = false;
        isGameUIActive = true;
        TerrainGenerator.GetComponent<terrainGenerator>().renderLevel();
    }
    public void onAlphaWorldButtonPressed(){
        Debug.Log("Alpha World Disabled At This Time");
    }
    public void onDevelopmentMapButtonPressed(){
        Debug.Log("Development Map Disabled At This Time");
    }

    //LOWER BAR MENU FUNCTIONS
    public void onOrdersButtonPressed() {
        isInOrdersMenu = true;
    }
    public void onConstructionButtonPressed() {
        isInConstructionMenu = true;
    }
    public void onStructuresButtonPressed() {
        isInStructuresMenu = true;
    }


    //ORDERS MENU FUCTIONS
    public void onFellTreesButtonPressed() {
        isSelectingTrees = true;
    }
    public void onOrdersMenuBackButtonPressed() {
        isSelectingTrees = false;
        isInOrdersMenu = false;
    }

    //CONSTRUCTION MENU FUCTIONS
    public void onStockpileButtonPressed() {
        CreateStructure.GetComponent<createStructure>().generateStructure("stockpile");
        //REGENERATE A* GRID @ A LATER DATE 
    }
    public void onConstructionMenuBackButtonPressed() {
        isInConstructionMenu = false;
    }

    //STRUCTURES MENU GROUP
    public void onMineButtonPressed() {
        CreateStructure.GetComponent<createStructure>().generateStructure("mine");
        //NEEDS WORK
    }

    public void onPrimitveHomeButtonPressed() {
        CreateStructure.GetComponent<createStructure>().generateStructure("tribalshack");
    }
    public void onShrineButtonPressed(){
        Debug.Log("Shrine Not Yet Implemented :(");
    }
    public void onBarracksButtonPressed() {
        CreateStructure.GetComponent<createStructure>().generateStructure("barracks");
    }

    public void onStructuresBackButtonPressed() {
        isInStructuresMenu = false;
    }




}
