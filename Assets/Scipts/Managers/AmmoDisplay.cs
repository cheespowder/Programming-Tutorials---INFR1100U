using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoDisplay : MonoBehaviour
{
    public int ammo;
    public bool isFiring;
    public Text ammodDisplay;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ammodDisplay.text = ammo.ToString();
        
        if (Input.GetMouseButton(0) && !isFiring && ammo > 0)
        {
            isFiring = true;
            ammo--;
            isFiring = false;
        }
    }
}
