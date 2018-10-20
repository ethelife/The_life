using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameSceneManager))]
public class Managers : MonoBehaviour {

    public static GameSceneManager MyGameScene { get; private set; }

    private List<IGameManager> _startSequence;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        MyGameScene = GetComponent<GameSceneManager>();

        _startSequence = new List<IGameManager>();
        _startSequence.Add(MyGameScene);
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
