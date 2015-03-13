using UnityEngine;
using System; 
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class LoginUI : MonoBehaviour
{
    private LoginUI_Logic loginLogic = new LoginUI_Logic();

    void Start()
    {
        loginLogic.Start();
    }

    void OnDestroy()
    {
        loginLogic.OnDestroy();
    }

    // Update is called once per frame
    void Update()
    {

    }
 
    void OnGUI()
    {
        loginLogic.OnGUI();
    }

    
}
