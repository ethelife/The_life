using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaitTimeController : MonoBehaviour {


	// Use this for initialization
	void Start () {
        GameSceneManager MyGameSceneManager = GameObject.Find("GameManagers").GetComponent<GameSceneManager>();
        string IntroductionString = (string)MyGameSceneManager.
            CutscenesIntroduction[MyGameSceneManager.currentSceneType];
        Text target = GameObject.Find("IntroductionText").GetComponent<Text>();
        target.text = IntroductionString;

        Debug.Log("说明文字是：" + IntroductionString);

        StartCoroutine(WaitTime());

    }

    // Update is called once per frame
    void Update () {
		
	}

    public IEnumerator WaitTime()
    {
        Debug.Log("我在这里！！等待4秒！！");

        yield return new WaitForSeconds(2);

        Messenger.Broadcast(GameEvent.Go_To_Next_Scene);
    }
}
