using UnityEngine;
using System; 
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class LoginUI : MonoBehaviour
{
    public string ui_state = "login";
 
    private string m_strLabelMsg  = "";
    private Color m_LabelColor    = Color.green;

    private string m_stringAccount = "";
    private string m_stringPasswd  = "";

    private StCharPickInfo[] m_SelCharList = new StCharPickInfo[4];

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
    
    void ShowSelectUI()
    {
        if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height - 40, 200, 30), "CreateAvatar(创建角色)"))    
        {
        }

        if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height - 75, 200, 30), "EnterGame(进入游戏)"))    
        {
        }
		
        for(int i = 0; i < 4; i++)
        {
            GUI.Label(Rect(0,i * 20,100,20),"名字");
            GUI.Label(Rect(100,i * 20,100,20),"等级");
            GUI.Label(Rect(200,i * 20,100,20),"职业");
            GUI.Label(Rect(300,i * 20,100,20),"性别");
        }

        return ;
    }
    
    void ShowLoginUI()
    {
        if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 30, 200, 30), "登陆"))
        {
            Debug.Log("stringAccount:" + stringAccount);
            Debug.Log("stringPasswd:" + stringPasswd);

            if (stringAccount.Length > 0 && stringPasswd.Length > 5)
            {
                ClientEngine.s_ClientConnector.m_strLoginIp = "127.0.0.1";
                ClientEngine.s_ClientConnector.m_sLoginPort = 7994;
                ClientEngine.s_ClientConnector.Login(stringAccount, stringPasswd);
            }
            else
            {
                Debug.Log("account is error!(账号错误!)");
            }
        }

        if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 70, 200, 30), "注册账号"))
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
        stringPasswd  = GUI.PasswordField(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 10, 200, 30), stringPasswd, '*');
    }

    void OnGUI()
    {
        if (ui_state == "login")
        {
            ShowLoginUI();
        }
        else if (ui_state == "select")
        {
            ShowSelectUI();
        }

        GUI.contentColor = labelColor;
        GUI.Label(new Rect((Screen.width / 2) - 100, 40, 400, 100), labelMsg);
    }

    void OnCharLoginAck(ReadBufferHelper ReadHelper)
    {
        StCharLoginAck Ack = new StCharLoginAck();
        Ack.Read(ReadHelper);

        if (Ack.nRetCode != 0)
        {
            labelMsg = "登录失败!!!";
            return;
        }

        for (int i = 0; i < Ack.Count; i++)
        {
            m_SelCharList[i] = new StCharPickInfo();
             m_SelCharList[i] = Ack.CharPickInfo[i];
        }

        ui_state = "select";

        return;
    }


    public override Boolean OnCommandHandle(Command_ID wCommandID, UInt64 u64ConnID, ReadBufferHelper ReadHelper)
    {
        switch (wCommandID)
        {
            case Command_ID.CMD_CHAR_LOGIN_ACK:
                {
                    OnCharLoginAck(ReadHelper);
                }
                break;
            case Command_ID.CMD_CHAR_NEW_CHAR_ACK:
                {

                }
                break;
            case Command_ID.CMD_CHAR_DEL_CHAR_ACK:
                {

                }
                break;
            case Command_ID.CMD_CHAR_NEW_ACCOUNT_ACK:
                {
                    UInt16 nRetCode = ReadHelper.ReadUint16();
                }
                break;
            case Command_ID.CMD_CHAR_ENTER_GAME_ACK:
                {

                }
                break;
            case Command_ID.CMD_CHAR_NEARBY_ADD:
                {

                }
                break;
            case Command_ID.CMD_CHAR_NEARBY_UPDATE:
                {

                }
                break;
            case Command_ID.CMD_CHAR_NEARBY_REMOVE:
                {

                }
                break;

            default:
                {

                }
                break;
        }

        return true;
    }
}
