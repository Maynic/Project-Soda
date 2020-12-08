using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(AvatarSetting))]
public class AvatarSettingEditor : Editor
{
    public override void OnInspectorGUI()
    {
        AvatarSetting avatar = target as AvatarSetting;
        if (DrawDefaultInspector())//인스펙터에서 값이 갱신되었을때만 true를 리턴함
        {
           avatar.SetAvatar();
           //avatar.SetAvatarColor();
        }

        //수동으로도 갱신할수 있도록 버튼을 심어야하지만...GUILayout.button() 이 없음
    }
}
