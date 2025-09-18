using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RTip : DialogMonoBehaviour
{
    public UIInput input, input2, input3, input4;
    public GameObject but, zhucebut,shuomingbut;
    void Start()
    {
        UIEventListener.Get(but).onClick = closeDialog;
        UIEventListener.Get(zhucebut).onClick = onClick16;
        UIEventListener.Get(shuomingbut).onClick = onClickshuoming;
    }

    private void onClickshuoming(GameObject go)
    {
        string str = "\n"
+ "���ݹ������ų����𷢲������ڷ�ֹδ�����˳���������Ϸ��֪ͨ���͡����ڽ�һ���ϸ���� ��ʵ��ֹδ�����˳���������Ϸ��֪ͨ����������ʵ��д�����Ϣ������Ϸ��δ����������������:\n\n"

        + "��Ϸ��¼\n"
+ "1.ÿ���塢���������պͷ����ڼ���ÿ20ʱ�� 21ʱ�ṩ1Сʱ������Ϸ����\n"
+ "��Ϸ��ֵ\n"
+ "1.����Ϸ��Ϊδ��12������û��ṩ��Ϸ����\n"
+ "2.δ��8������û����ܸ��ѡ�\n"
+ "3.8��������δ��16�����δ�������û������γ�ֵ���ó���50Ԫ����ң�ÿ�³�ֵ����ۼƲ��ó���200Ԫ����ң�16�������ϵ�δ�������û������γ�ֵ���ó���100Ԫ����ң�ÿ�³�ֵ����ۼƲ��ó���400Ԫ����ҡ�\n";


        UIManager.showTip(str, null, null, null, null, "δ�����˷���������˵��");
    }

    private void onClick16(GameObject go)
    {
        if (input.value.Length < 6)
        {
            UIManager.showToast("�˺ų�����СΪ6λ��");
            return;
        }else if (input.value.Length >64)
        {
            UIManager.showToast("�˺ų������64λ��");
            return;
        }
        if (input2.value.Length < 6)
        {
            UIManager.showToast("�˺ų�����СΪ6λ��");
            return;
        }
        else if (input2.value.Length > 16)
        {
            UIManager.showToast("���볤�����16λ��");
            return;
        }

        if (input4.value.Length <= 1)
        {
            UIManager.showToast("��������ȷ��������");
            return;
        }

        if (IsValidIdNumber(input3.value))
        {
            UIManager.showToast("��������ȷ�����֤�š�");
            return;
        }
        HttpManager.instance.sendLogin1(input.value, input2.value, input3.value, (code0) =>
        {

            if (code0 == Callback.SUCCESS)
            {
                UIManager.showToast("�˺�ע��ɹ���");
                CoverDlg.instance.input.value = input.value;
                CoverDlg.instance.input2.value = input2.value;
                CoverDlg.instance.onClick(null);
                closeDialog(null);

            }

        });
    }

    public bool IsValidIdNumber(string idNumber)
    {
        if (idNumber == null || idNumber.Length != 18)
            return false; // ���Ȳ���18λ

        // ��ȡ���֤�����ǰ17λ
        string idNumber17 = idNumber.Substring(0, 17);

        // ����ǰ17λ�ļ�Ȩ��
        int[] weights = { 7, 9, 10, 5, 8, 4, 2, 1, 6, 3, 7, 9, 10, 5, 8, 4, 2 };
        int sum = 0;
        for (int i = 0; i < idNumber17.Length; i++)
        {
            sum += (idNumber17[i] - '0') * weights[i];
        }

        // ����У����
        int checkCode = (12 - sum % 11) % 11;
        char[] checkCodes = { '1', '0', 'X', '9', '8', '7', '6', '5', '4', '3', '2' };
        char expectedCheckCode = checkCodes[checkCode];

        // �Ƚϼ������У��������һλ
        char actualCheckCode = idNumber[17];
        return char.ToUpper(actualCheckCode) == char.ToUpper(expectedCheckCode);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
