using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FireManager : MonoBehaviour
{
    public static FireManager instance;
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void UpdateFire(int fireCount)
    {
        text.text = "x " + fireCount.ToString();
    }

}
