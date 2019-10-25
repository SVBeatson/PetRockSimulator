using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockController : MonoBehaviour
{
    public string rockName = "The Boulder";
    public float hunger = 100f;
    public float friendship = 100f;
    public bool isSick = false;
    public bool isDead = false;
    public float hungerScale = 2f;
    public GameObject brokenRocks;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            Application.Quit();
        }

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
        if (!isDead)
        {
            if (hunger <= 0)
            {
                isDead = true;
                Destroy(gameObject);
                brokenRocks.SetActive(true);

            }
            if (friendship <= 0)
            {
                isDead = true;
                rb.AddForce(new Vector3(0f, 100f, 50f));
            }
        }
    }
}
