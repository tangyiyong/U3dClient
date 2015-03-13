using UnityEngine;
using System; 
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ClientEngine: MonoBehaviour {

    public static ClientConnector s_ClientConnector = null;
    
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        s_ClientConnector = new ClientConnector();
        s_ClientConnector.InitConnector();
    }

    void OnDestroy()
    {
        if (s_ClientConnector != null)
        {
            s_ClientConnector.CloseConnector();
        }
    }

    void Update()
    {
        if (s_ClientConnector != null)
        {
            s_ClientConnector.Render();
        }
    }
}
