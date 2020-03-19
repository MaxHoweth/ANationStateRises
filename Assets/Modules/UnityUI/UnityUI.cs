using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityUI : MonoBehaviour
{
    public GameObject TerrainGenerator;
    public GameObject CreateStructure;



    public GameObject JobsRowPrefab;
    public List<GameObject> listOfAis;
    public GameObject JobsMenu;

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

    bool isInJobsMenu = false;
    bool hasGeneratedJobsMenu = false;


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


            if (isInJobsMenu) {
                if (hasGeneratedJobsMenu == false) { 
                    generateJobsMenu();
                    hasGeneratedJobsMenu = true;
                
                }
            }
            else {
                destroyJobsMenu();

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
    public void onJobsMenuButtonPressed() {
        isInJobsMenu = !isInJobsMenu;
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






    void generateJobsMenu() {
        int index = 0;
        foreach (GameObject gameObj in GameObject.FindGameObjectsWithTag("Player")){
            listOfAis.Add(gameObj);
            string nameParsed = gameObj.name.Substring(7).Replace("_", " ");
            createJobRow(nameParsed, gameObj.GetComponent<Ai>().job, index);
            index += 1;
        }
        Debug.Log(listOfAis[0]);
    }
    void destroyJobsMenu() {
        foreach (Transform child in JobsMenu.transform) {
            GameObject.Destroy(child.gameObject);
        }
        listOfAis.Clear();
        hasGeneratedJobsMenu = false;
    }

    void createJobRow(string _name, int _job, int _index) {
        GameObject inst = Instantiate(JobsRowPrefab, new Vector3(0,0,0), new Quaternion(0, 0, 0, 0));
        inst.transform.SetParent(JobsMenu.transform, false);
        inst.name = "JobsRow" + _index;

        GameObject nameLabelInstance = GameObject.Find("Canvas/JobsMenu/JobsRow" + _index + "/NameLabel");
            nameLabelInstance.GetComponent<UnityEngine.UI.Text>().text = _name;

        GameObject jobLabelInstance = GameObject.Find("Canvas/JobsMenu/JobsRow" + _index + "/JobLabel");
            jobLabelInstance.GetComponent<UnityEngine.UI.Text>().text = convertJobIntToString(_job);

        GameObject builderButtonInstance = GameObject.Find("Canvas/JobsMenu/JobsRow" + _index + "/BuilderButton");
            builderButtonInstance.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(delegate { changeJob(_index, 4); });

        GameObject loggerButtonInstance = GameObject.Find("Canvas/JobsMenu/JobsRow" + _index + "/LoggerButton");
            loggerButtonInstance.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(delegate { changeJob(_index, 2); });

        GameObject haulerButtonInstance = GameObject.Find("Canvas/JobsMenu/JobsRow" + _index + "/HaulerButton");
            haulerButtonInstance.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(delegate { changeJob(_index, 3); });
    }



    string convertJobIntToString(int input)
    {
        if (input == 0) { return "Unemployed"; }
        else if (input == 2) { return "Logger"; }
        else if (input == 3) { return "Hauler"; }
        else if (input == 4) { return "Builder"; }

        else { return "UNDEFINED"; }
    }

    public void changeJob(int _aiIndex, int _job) {
        listOfAis[_aiIndex].GetComponent<Ai>().job = _job;
        listOfAis[_aiIndex].GetComponent<Ai>().selected = false;
        listOfAis[_aiIndex].GetComponent<Ai>().mouseOverrideSelected = false;

    }

    /*
             if (!listOfAis.Contains(gameObj)) { listOfAis.Add(gameObj); }

            GUI.Box(new Rect(30, ((numberOfAis + 1) * 25) + 6, Screen.width - 100, 20), "");   //Background Box
                            string nameParsed = gameObj.name.Substring(7).Replace("_", " ");
            GUI.Label(new Rect(30, ((numberOfAis + 1) * 25) + 6, 200, 20), " " + nameParsed + " "); // Labels the row with the Ais Name

                GUI.Label(new Rect(180, ((numberOfAis + 1) * 25) + 6, 200, 20), convertJobIntToString(listOfAis[numberOfAis].GetComponent<Ai>().job)); // Display The AIs Current Job

                if (GUI.Button(new Rect(300, ((numberOfAis + 1) * 25) + 6, 75, 20), "Logger"))
                {
                    listOfAis[numberOfAis].GetComponent<Ai>().job = 2;
                    listOfAis[numberOfAis].GetComponent<Ai>().selected = false;
                    listOfAis[numberOfAis].GetComponent<Ai>().mouseOverrideSelected = false;
                }
                if (GUI.Button(new Rect(390, ((numberOfAis + 1) * 25) + 6, 75, 20), "Hauler"))
                {
                    listOfAis[numberOfAis].GetComponent<Ai>().job = 3;
                    listOfAis[numberOfAis].GetComponent<Ai>().selected = false;
                    listOfAis[numberOfAis].GetComponent<Ai>().mouseOverrideSelected = false;

                }
                if (GUI.Button(new Rect(480, ((numberOfAis + 1) * 25) + 6, 75, 20), "Builder"))
                {
                    listOfAis[numberOfAis].GetComponent<Ai>().job = 4;
                    listOfAis[numberOfAis].GetComponent<Ai>().selected = false;
                    listOfAis[numberOfAis].GetComponent<Ai>().mouseOverrideSelected = false;
                }


                //gameObj.GetComponent<Ai>().job = jobMenuState;
                //Debug.Log(gameObj.GetComponent<Ai>().job);
                //Debug.Log(numberOfAis);
                numberOfAis += 1;

        */

}
