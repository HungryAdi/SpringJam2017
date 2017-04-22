using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameMenuSelect : MonoBehaviour
{
    //The text objects relating to the menu choices
    public GameObject[] menuOptions;
    //The strings of scenes the option will lead to
    public string[] scenes;

    private int menuOptionDex;

	// Use this for initialization
	void Start ()
    {
        menuOptionDex = 0;
        //Highlight first option
        menuOptions[0].GetComponent<Text>().color = Color.green;
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.D))
        {
            if (menuOptionDex < menuOptions.Length - 1)
            {
                menuOptions[menuOptionDex].GetComponent<Text>().color = Color.white;
                menuOptionDex++;
                menuOptions[menuOptionDex].GetComponent<Text>().color = Color.green;
            }
            else
            {
                menuOptions[menuOptionDex].GetComponent<Text>().color = Color.white;
                menuOptionDex = 0;
                menuOptions[menuOptionDex].GetComponent<Text>().color = Color.green;
            }
            //unhighlight previous option, highlight new one
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            if (menuOptionDex > 0)
            {
                menuOptions[menuOptionDex].GetComponent<Text>().color = Color.white;
                menuOptionDex--;
                menuOptions[menuOptionDex].GetComponent<Text>().color = Color.green;
            }
            else
            {
                menuOptions[menuOptionDex].GetComponent<Text>().color = Color.white;
                menuOptionDex = menuOptions.Length - 1;
                menuOptions[menuOptionDex].GetComponent<Text>().color = Color.green;
            }
        }
        else if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(scenes[menuOptionDex]);
            //Need the navigator?
            Navigator.Instance.LoadScene(scenes[menuOptionDex]);
        }
	}
}
