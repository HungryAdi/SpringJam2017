using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelection : MonoBehaviour {
    
    enum Target { cheerleader, nerd, guard, player, size }
    Vector2[] targetList;
    GameObject[] highlightList;
    int targetSelection = 3;
    Animator anim;
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
        highlightList[(int)Target.player] = GameObject.Find("ExitHighlight");

        anim = GameObject.Find("PlayerSprite").GetComponent<Animator>();

        for (int i=0; i<=3; i++)
        {
            highlightList[i].SetActive(false);
        }
    }
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.Return) )
        {
            if(targetSelection == (int)Target.nerd)
            { Navigator.Instance.LoadScene("Brett"); }
            else if(targetSelection == (int)Target.cheerleader)
            {
                Navigator.Instance.LoadScene("Kaitlyn");
            }
            else if (targetSelection == (int)Target.player)
            {
                Navigator.Instance.LoadScene("MainMenu");
            }
        }
        if (targetSelection < ((int)Target.size))
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
        
        if(targetSelection< ((int)Target.size))
        {
            highlightList[targetSelection].SetActive(true);
        }
            
        transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), targetList[targetSelection], 5 * Time.deltaTime);

        
        if (transform.position.x - targetList[targetSelection].x > 0)
        {
            //Debug.Log("Left");
            anim.SetInteger("Direction", -1);
        }
        else if(transform.position.x - targetList[targetSelection].x < 0)
        {
            //Debug.Log("Right");
            anim.SetInteger("Direction", 1);
        }
        else
        {
            //Debug.Log("OK");
            anim.SetInteger("Direction", 0);
        }
    }
    
}
