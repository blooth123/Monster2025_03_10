using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    public Text textS;
    public GameObject ga;
    public GameObject uI;
    public GameObject Over;
    bool Buttoncheck = false;

    int number = 0;
    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        if(Buttoncheck == false) Buttoncheck = ButtonTest.buttonClick;
        if (Buttoncheck == true)
        {
            ga.SetActive(true);
            uI.SetActive(false);
        }
        number = ZombieSpawn.list_count;
        textS.text = "Enemy : " + number;
        if (number > 30)
        {
            Over.SetActive(true);
            Time.timeScale = 0;
        }

    }
}
