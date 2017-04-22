using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelection : MonoBehaviour {
    enum Target { cheerleader, nerd, guard, player, size }
    Vector2[] targetList;
    GameObject[] highlightList;
    int targetSelection = 3;
	// Use this for initialization
	void Awake () {
        targetList = new Vector2[(int)Target.size];
        targetList[(int)Target.player] = GameObject.Find("PlayerTargetGO").transform.position;
        targetList[(int)Target.cheerleader] = GameObject.Find("CheerleaderTargetGO").transform.position;
        targetList[(int)Target.nerd] = GameObject.Find("NerdTargetGO").transform.position;
        targetList[(int)Target.guard] = GameObject.Find("GuardTargetGO").transform.position;

        highlightList = new GameObject[(int)Target.size];
        highlightList[(int)Target.cheerleader] = GameObject.Find("CheerleaderHighlight");
        highlightList[(int)Target.nerd] = GameObject.Find("NerdHighlight");
        highlightList[(int)Target.guard] = GameObject.Find("GuardHighlight");

        for(int i=0; i<=2; i++)
        {
            highlightList[i].SetActive(false);
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (targetSelection < ((int)Target.size - 1))
            highlightList[targetSelection].SetActive(false);
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {

            targetSelection = (int)Target.guard;
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            targetSelection = (int)Target.nerd;
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            targetSelection = (int)Target.player;
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            targetSelection = (int)Target.cheerleader;
        }
        
        if(targetSelection< ((int)Target.size - 1))
        {
            highlightList[targetSelection].SetActive(true);
        }
            
        transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), targetList[targetSelection], 5 * Time.deltaTime);
    }
    
}
