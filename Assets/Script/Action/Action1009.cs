using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Action1009 : GameAction {


    public class StaticSever
    {
        public int Id
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }
        public string Ip
        {
            get;
            set;
        }
        public int Port
        {
            get;
            set;    
        }
    }

    private List<StaticSever> serverList = new List<StaticSever>();
 
    private ActionResult actionResult;

    public Action1009()
        : base((int)ActionType.Servers)
    {

    }

    protected override void SendParameter(NetWriter writer, ActionParam actionParam)
    {
        //TODO:登录服务器获取账号
        //writer.writeString("Handler", "Passport");
        //writer.writeString("IMEI", GameSetting.Instance.DeviceID);

    }

    protected override void DecodePackage(NetReader reader)
    {
        if (!reader.Success)
        {
            Debug.LogError(string.Format("Action {0} error {1}-{2}", reader.ActionId, reader.StatusCode, reader.Description));
            return;
        }
        actionResult = new ActionResult();
        //默认Scut流格式解包
        int  length = reader.Buffer.Length;
        while (reader.CurrentPos < reader.Buffer.Length)
        {
            int count = reader.getInt();
            length -= count;
            StaticSever server = new StaticSever();
            server.Id = reader.getInt();
            server.Name = reader.readString();
            server.Ip = reader.readString();
            server.Port = reader.getInt();
            serverList.Add(server);

        }
        Debug.Log(serverList);
        
    }

    public override ActionResult GetResponseData()
    {
        return actionResult;
    }
}
