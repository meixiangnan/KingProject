using System.Collections;
using System.Collections.Generic;
using cfg;
using UnityEngine;
using SimpleJSON;
using UnityEditor;

public class LuabanTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var table = new Tables(LoadTable);
        Debug.Log(table.Tbitem.Get(1001).Name);
    }

    public JSONNode LoadTable(string table_name)
    {
        var textAsset = AssetDatabase.LoadAssetAtPath<TextAsset>($"Assets/Res/Config/{table_name}.json");
        return JSON.Parse(textAsset.text);
    }
}
