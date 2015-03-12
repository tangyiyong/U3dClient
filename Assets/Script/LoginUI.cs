using UnityEngine;
using System; 
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class LoginUI : MonoBehaviour {

    public string ui_state = "login";
 
    private string labelMsg = "";
    private Color labelColor = Color.green;

    private string stringAccount = "";
    private string stringPasswd = "";

    void Start()
    {

    }

    void OnDestroy()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    /*
    void onSelAvatarUI()
    {
        if (startCreateAvatar == false && GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height - 40, 200, 30), "CreateAvatar(创建角色)"))    
        {
            startCreateAvatar = !startCreateAvatar;
        }

        if (startCreateAvatar == false && GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height - 75, 200, 30), "EnterGame(进入游戏)"))    
        {
            if(selAvatarDBID == 0)
            {
                err("Please select a Avatar!(请选择角色!)");
            }
            else
            {
                info("Please wait...(请稍后...)");
                Account account = (Account)KBEngineApp.app.player();
                if(account != null)
                    account.selectAvatarGame(selAvatarDBID);
				
                Application.LoadLevel("world");
            }
        }
		
        if(startCreateAvatar)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height - 40, 200, 30), "CreateAvatar-OK(创建完成)"))    
            {
                if(stringAvatarName.Length > 1)
                {
                    startCreateAvatar = !startCreateAvatar;
                    Account account = (Account)KBEngineApp.app.player();
                    account.reqCreateAvatar(1, stringAvatarName);
                }
                else
                {
                    err("avatar name is null(角色名称为空)!");
                }
            }
	        
            stringAvatarName = GUI.TextField(new Rect(Screen.width / 2 - 100, Screen.height - 75, 200, 30), stringAvatarName, 20);
        }
		
        if(ui_avatarList != null && ui_avatarList.Count > 0)
        {
            int idx = 0;
            foreach(UInt64 dbid in ui_avatarList.Keys)
            {
                Dictionary<string, object> info = ui_avatarList[dbid];
                Byte roleType = (Byte)info["roleType"];
                string name = (string)info["name"];
                UInt16 level = (UInt16)info["level"];
                UInt64 idbid = (UInt64)info["dbid"];

                idx++;
				
                Color color = GUI.contentColor;
                if(selAvatarDBID == idbid)
                {
                    GUI.contentColor = Color.red;
                }
				
                if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 120 - 35 * idx, 200, 30), name))    
                {
                    Debug.Log("selAvatar:" + name);
                    selAvatarDBID = idbid;
                }
				
                GUI.contentColor = color;
            }
        }
        else
        {
            if(KBEngineApp.app.entity_type == "Account")
            {
                KBEngine.Account account = (KBEngine.Account)KBEngineApp.app.player();
                if(account != null)
                    ui_avatarList = new Dictionary<ulong, Dictionary<string, object>>(account.avatars);
            }
        }
    }
    */
    void ShowLoginUI()
    {
        if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 30, 200, 30), "Login(登陆)"))
        {
            Debug.Log("stringAccount:" + stringAccount);
            Debug.Log("stringPasswd:" + stringPasswd);

            if (stringAccount.Length > 0 && stringPasswd.Length > 5)
            {

            }
            else
            {
                Debug.Log("account is error!(账号错误!)");
            }
        }

        if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 70, 200, 30), "CreateAccount(注册账号)"))
        {
            Debug.Log("stringAccount:" + stringAccount);
            Debug.Log("stringPasswd:" + stringPasswd);

            if (stringAccount.Length > 0 && stringPasswd.Length > 5)
            {

            }
            else
            {
                Debug.Log("account is error!(账号错误!)");
            }
        }

        stringAccount = GUI.TextField(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 30), stringAccount, 20);
        stringPasswd = GUI.PasswordField(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 10, 200, 30), stringPasswd, '*');
    }

    void OnGUI()
    {
        if (ui_state == "login")
        {
            ShowLoginUI();
        }

        GUI.contentColor = labelColor;
        GUI.Label(new Rect((Screen.width / 2) - 100, 40, 400, 100), labelMsg);
    }  
}
