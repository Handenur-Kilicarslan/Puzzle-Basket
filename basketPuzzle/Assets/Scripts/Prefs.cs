using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prefs : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetString("WhichFruit", string.Empty);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
