using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    public Text hungerText;
    public Text friendshipText;
    public Text sickText;

    public GameObject rock;

    // Start is called before the first frame update
    void Start()
    {
        //hungerText.text = "I'm Hungry";
        //friendhsipText.text = "I'm Unhappy";
        //sickText.text = "Healthy";

    }

    // Update is called once per frame
    void Update()
    {
        StatusTextUpdate();
    }

    void StatusTextUpdate()
    {
        if(rock != null)
        {
            hungerText.text = "Hunger: " + Math.Ceiling(rock.GetComponent<RockController>().hunger).ToString();

            friendshipText.text = "Friendship: " + Math.Ceiling(rock.GetComponent<RockController>().friendship).ToString();

            bool isSick = rock.GetComponent<RockController>().isSick;
            if (isSick)
                sickText.text = "Sick";
            else
                sickText.text = "";
        }
  
    }

    public void FeedRock()
    {
        if (rock.GetComponent<RockController>().hunger <= 95 && !rock.GetComponent<RockController>().isDead)
            rock.GetComponent<RockController>().hunger += 5;
    }

    public void PlayWithRock()
    {
        if (rock.GetComponent<RockController>().friendship <= 95 && !rock.GetComponent<RockController>().isDead)
            rock.GetComponent<RockController>().friendship += 5;
    }

    public void GoToVet()
    {
        if(rock.GetComponent<RockController>().isSick && !rock.GetComponent<RockController>().isDead)
            rock.GetComponent<RockController>().isSick = false;
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.LogError("Game Quit");
    }
}
