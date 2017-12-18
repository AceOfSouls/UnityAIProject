using UnityEngine;
using System.Collections;

public class SetGems : MonoBehaviour {

    int RNG;
    GameObject[] Gems;
    int allset = 0;
    bool hm;

    // Use this for initialization
    void Start ()
    {
        Gems = GameObject.FindGameObjectsWithTag("PickUp");
        hm = GameObject.FindGameObjectWithTag("HardModeScript").GetComponent<Hardmode>().getHardMode();
        if (hm == false)
        {
            while (allset < 2)
            {
                RNG = Random.Range(0, Gems.Length);
                if (Gems[RNG].activeSelf == true)
                {
                    Gems[RNG].SetActive(false);
                    allset++;
                }
            }
        }
        else
        {
            foreach(GameObject g in Gems)
            {
                g.SetActive(true);
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
