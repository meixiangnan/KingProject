using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using SimpleJSON;

public class LuabanTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var tables = new cfg.Tables(LoadByteBuf);
        UnityEngine.Debug.LogFormat("item[1].name:{0}", tables.Tbitem.Get(1001).Id);


        UnityEngine.Debug.Log("== load succ==");
    }

    private static JSONNode LoadByteBuf(string file)
    {
        return JSON.Parse(File.ReadAllText(Application.dataPath + "/Res/Config/" + file + ".json", System.Text.Encoding.UTF8));
    }

    // Update is called once per frame
    void Update()
    {

    }
}
