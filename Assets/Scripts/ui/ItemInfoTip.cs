using System.Collections;
using System.Collections.Generic;
using cfg;
using UnityEngine;

public class ItemInfoTip : DialogMonoBehaviour
{
    public GameObject closebtn;
    public UILabel nameLabel;
    public UILabel desLabel;
    public UISprite icongen;
    TexPaintNode paintnode;
    Reward itemdata;
    private void Awake()
    {
        setShowAnim(true);
        setClickOutZoneClose(true);
        UIEventListener.Get(closebtn).onClick = closeDialog;
    }

    public void InitData(Reward reward)
    {
        itemdata = reward;
        setUI();
    }

    void setUI()
    {
        //data_resourcesBean resoursbean = data_resourcesDef.dicdatas[itemdata.mainType][0];
        resources resoursbean = GameGlobal.LubanTables.Tbresources.DataMap[itemdata.mainType];
        GameObject texframeobjs = ResManager.getGameObject("allpre", "vtexpaintnode");
        texframeobjs.name = "icon";
        TexPaintNode temppaintnode = texframeobjs.GetComponent<TexPaintNode>();
        temppaintnode.create1(icongen.gameObject, "item");
        temppaintnode.setdepth(402);
        paintnode = temppaintnode;
        paintnode.playAction(resoursbean.ResourcesPicture);
        nameLabel.text = resoursbean.ResourcesName;
        desLabel.text = resoursbean.ResourcesDescribe;
    }
}
