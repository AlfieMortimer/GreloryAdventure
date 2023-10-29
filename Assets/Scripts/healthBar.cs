using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Sprite Six = Resources.Load<Sprite>("meter-06");
        Sprite Five = Resources.Load<Sprite>("meter-05");
        Sprite Four = Resources.Load<Sprite>("meter-04");
        Sprite Three = Resources.Load<Sprite>("meter-03");
        Sprite Two = Resources.Load<Sprite>("meter-02");
        Sprite One = Resources.Load<Sprite>("meter-01");

        if (Input.GetKeyDown("r"))
        {
            gameObject.GetComponent<Image>().sprite = Five;
        }
        if (Input.GetKeyDown("t"))
        {
            gameObject.GetComponent<Image>().sprite = Six;
        }
    }
}
