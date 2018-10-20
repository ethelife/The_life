using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicUIController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GoToCutscenes()
    {
        Messenger.Broadcast(GameEvent.Go_To_Cutscenes);
    }
}
