using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockController : MonoBehaviour
{
    public string rockName = "The Boulder";
    public float hunger = 100f;
    public float friendship = 100f;
    public bool isSick = false;

    public float hungerScale = 2f;
    public GameObject brokenRocks;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        StatusUpdate();
        CheckHealth();
    }

    void StatusUpdate()
    {
        // Updates Hunger and Friendship over time
        if(isSick)
        {
            if (hunger > 0)
                hunger -= Time.deltaTime * hungerScale * 3;
            if (hunger < 90)
                if (friendship > 0)
                    friendship -= (90 - hunger) / 10 * Time.deltaTime * 5;
        }
        else
        {
            if (hunger > 0)
                hunger -= Time.deltaTime * hungerScale;
            if (hunger < 90)
                if (friendship > 0)
                    friendship -= (90-hunger)/10 * Time.deltaTime;
        }
        

        // Generates a random chance for your pet rock to get sick
        int sickChance = Random.Range(0, (int)(hunger * friendship/5));
        if (sickChance == 667)
            isSick = true;
    }

    void CheckHealth()
    {
        if (hunger <= 0)
        {
            Destroy(gameObject);
            brokenRocks.SetActive(true);
            
        }
        if (friendship <= 0)
        {
            Destroy(gameObject);
        }
    }
}
