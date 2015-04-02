using UnityEngine;
using System; 
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class LoginUI_Logic : MessageHandler
{
    public string ui_state = "login";
 
    private string m_strLabelMsg  = "";
    private Color m_LabelColor    = Color.green;

    private string m_stringAccount = "test0";
    private string m_stringPasswd  = "123456";

    private UInt64 m_SelectCharID = 0;

    private int m_nCharCount = 0;
    private StCharPickInfo[] m_SelCharList = new StCharPickInfo[4];

    Texture2D BgImage;

    public void Start()
    {
        ClientEngine.s_ClientConnector.RegisterMsgHandler(this);

        BgImage = (Texture2D)Resources.Load("Login_BG", typeof(Texture2D));

    }

    public void OnDestroy()
    {
        ClientEngine.s_ClientConnector.UnregisterMsgHandler(this);
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    void ShowSelectUI()
    {
        if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height - 40, 200, 30), "创建角色"))    
        {

        }

        if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height - 75, 200, 30), "进入游戏"))    
        {

        }

        for (int i = 0; i < m_nCharCount; i++)
        {
            StCharPickInfo CharInfo = m_SelCharList[i];
            GUI.Label(new Rect(100, i * 20, 100, 20), ""+CharInfo.dwLevel);
            GUI.Label(new Rect(200, i * 20, 100, 20), "" + CharInfo.dwFeature);
            GUI.Label(new Rect(300, i * 20, 100, 20), "男");

            if (GUI.Button(new Rect(0, i * 20, 100, 20), CharInfo.szCharName))
            {
                m_SelectCharID = CharInfo.u64CharID;

                GUI.contentColor = Color.red;
            }
        }

        return ;
    }
    
    void ShowLoginUI()
    {
        GUI.DrawTexture(new Rect((Screen.width - BgImage.width) / 2, (Screen.height - BgImage.height) / 2, BgImage.width, BgImage.height), BgImage, ScaleMode.ScaleAndCrop);

        if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 30, 200, 30), "登陆"))
        {
            Debug.Log("stringAccount:" + m_stringAccount);
            Debug.Log("stringPasswd:" + m_stringPasswd);

            if (m_stringAccount.Length > 0 && m_stringPasswd.Length > 0)
            {
                ClientEngine.s_ClientConnector.m_strLoginIp = "127.0.0.1";
                ClientEngine.s_ClientConnector.m_sLoginPort = 7994;
                if (!ClientEngine.s_ClientConnector.Login(m_stringAccount, m_stringPasswd, true))
                {
                    m_strLabelMsg = "登录失败!";
                }
                else
                {
                    m_strLabelMsg = "登录成功!";
                }
            }
            else
            {
                Debug.Log("account is error!(账号错误!)");
            }
        }

        if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 70, 200, 30), "注册账号"))
        {
            Debug.Log("stringAccount:" + m_stringAccount);
            Debug.Log("stringPasswd:" + m_stringPasswd);

            if (m_stringAccount.Length > 0 && m_stringPasswd.Length > 5)
            {

            }
            else
            {
                Debug.Log("account is error!(账号错误!)");
            }
        }

        m_stringAccount = GUI.TextField(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 30), m_stringAccount, 20);
        m_stringPasswd = GUI.PasswordField(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 10, 200, 30), m_stringPasswd, '*');
    }

    public void OnGUI()
    {
        if (ui_state == "login")
        {
            ShowLoginUI();
        }
        else if (ui_state == "select")
        {
            ShowSelectUI();
        }

        GUI.contentColor = m_LabelColor;
        GUI.Label(new Rect((Screen.width / 2) - 100, 40, 400, 100), m_strLabelMsg);
    }

    void OnCharLoginAck(ReadBufferHelper ReadHelper)
    {
        StCharLoginAck Ack = new StCharLoginAck();
        Ack.Read(ReadHelper);

        if (Ack.nRetCode != 0)
        {
            m_strLabelMsg = "登录失败!!!";
            return;
        }

        m_nCharCount = Ack.nCount;
        for (int i = 0; i < Ack.nCount; i++)
        {
            m_SelCharList[i] = new StCharPickInfo();
            m_SelCharList[i].u64CharID = Ack.CharPickInfo[i].u64CharID;
            m_SelCharList[i].szCharName = Ack.CharPickInfo[i].szCharName;
            m_SelCharList[i].dwLevel = Ack.CharPickInfo[i].dwLevel;
            m_SelCharList[i].dwFeature = Ack.CharPickInfo[i].dwFeature;
        }

        ui_state = "select";

        m_strLabelMsg = "登录成功!!!";

        return;
    }


    public override Boolean OnCommandHandle(Command_ID wCommandID, UInt64 u64ConnID, ReadBufferHelper ReadHelper)
    {
        switch (wCommandID)
        {
            case Command_ID.CMD_CHAR_LOGIN_ACK:
                {
                    m_strLabelMsg = "CMD_CHAR_LOGIN_ACK!!!";
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
