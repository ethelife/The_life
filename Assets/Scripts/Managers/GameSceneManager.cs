using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;

public class GameSceneManager : MonoBehaviour, IGameManager {

    public ManagerStatus status { get; private set; }

    public List<int> path;

    public Hashtable CutscenesIntroduction;

    public Hashtable SceneName;

    public int currentSceneType;

    public int currentSceneNum;
    //目前先把最大的场景的数值定位10（11）——包括“死亡”在内。
    private const int maxSceneNum = 10;

    
    void Awake()
    {
        //这个能不能放在这里？？
        path = new List<int>();
        CutscenesIntroduction = new Hashtable();
        SceneName = new Hashtable();
        InitHashTable();

        currentSceneType = -1;
        currentSceneNum = -1;
        GenerateNewPath();

        Messenger.AddListener(GameEvent.Go_To_Info, OnGoToInfo);
        Messenger.AddListener(GameEvent.Quit, OnQuit);
        Messenger.AddListener(GameEvent.Go_To_Cutscenes, OnGoToCutscenes);
        Messenger.AddListener(GameEvent.Go_To_Next_Scene, OnGoToNextScene);
    }
    void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.Go_To_Info, OnGoToInfo);
        Messenger.RemoveListener(GameEvent.Quit, OnQuit);
        Messenger.RemoveListener(GameEvent.Go_To_Cutscenes, OnGoToCutscenes);
        Messenger.RemoveListener(GameEvent.Go_To_Next_Scene, OnGoToNextScene);
    }

    private void undateCurrentSceneNum()
    {
        currentSceneNum++;
    }

    private void InitHashTable()
    {
        CutscenesIntroduction.Add(1, "你将面对新的敌人！");
        CutscenesIntroduction.Add(10, "你将面对新的敌人！");
        CutscenesIntroduction.Add(2, "你将面对一个事件！");
        CutscenesIntroduction.Add(3, "你将获得休息的机会！");
        CutscenesIntroduction.Add(4, "你将面对一个强大的敌人！");
        CutscenesIntroduction.Add(5, "你将面对一个不可战胜的敌人！（？）");

        SceneName.Add(1, "BattleScene");
        SceneName.Add(10, "BattleScene");
        SceneName.Add(2, "EventScene");
        SceneName.Add(3, "BreakScene");
        SceneName.Add(4, "BossScene");
        SceneName.Add(5, "DeadScene");
    }

    private void GenerateNewPath()
    {
        //目前这里先姑且写死了
        path.Add(10);//固定的教学战斗
        path.Add(2);//固定的事件
        path.Add(1);//战斗
        path.Add(2);//事件
        path.Add(2);
        path.Add(1);
        path.Add(2);
        path.Add(1);
        path.Add(3);//补血事件
        path.Add(4);//Boss
        path.Add(5);//死亡   
    }

    //click the button "图鉴" on the start UI 
    private void OnGoToInfo()
    {
        throw new NotImplementedException();
    }

    //click the button "退出" on the start UI 
    private void OnQuit()
    {
        Debug.Log("退出游戏！！");
    }

    //when complete a battle or click the "下一步" button on the EventScene
    //wait several seconds and show player what he/she will meet in next scene
    private void OnGoToCutscenes()
    {
        undateCurrentSceneNum();
        currentSceneType = path[currentSceneNum];
        SceneManager.LoadScene("CutScenes");
    }

    

    //after cutscenes
    private void OnGoToNextScene()
    {
        string SceneNameStr = (string)SceneName[currentSceneType];
        SceneManager.LoadScene(SceneNameStr);
    }




    public void Startup()
    {
        Debug.Log("Mission manager starting...");
    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


}
