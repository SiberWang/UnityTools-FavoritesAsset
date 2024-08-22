#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

//=========================================================
//
//  developer : MasyoLab
//  github    : https://github.com/MasyoLab/UnityTools-FavoritesAsset
//
//=========================================================

namespace MasyoLab.Editor.FavoritesAsset
{
    class SettingWindow : BaseWindow
    {
        private Vector2 m_scrollVec = Vector2.zero;
        
        private bool isDeleteButtonPressedOnce      = false;
        private bool isAlreadyClear = false;
        
        public override void OnGUI()
        {
            m_scrollVec = GUILayout.BeginScrollView(m_scrollVec);

            EditorGUI.BeginChangeCheck();
            {
                var newLanguage = (LanguageEnum)EditorGUILayout.Popup(LanguageData.GetText(m_pipeline.Setting.Language, TextEnum.Language), (int)m_pipeline.Setting.Language, LanguageData.LANGUAGE);
                var isUpdate = m_pipeline.Setting.Language != newLanguage;
                m_pipeline.Setting.Language = newLanguage;
                if (isUpdate)
                { 
                    m_pipeline.Group.UpdateGroupNameList();
                }
                
                var selectNameEnumLabel = $"{LanguageData.GetText(m_pipeline.Setting.Language, TextEnum.ShowNameType)}";
                var newNameEnum = (ShowNameEnum)EditorGUILayout.EnumPopup(selectNameEnumLabel, m_pipeline.Setting.ShowNameEnum);
                var isUpdateNameEnum = m_pipeline.Setting.ShowNameEnum != newNameEnum;
                m_pipeline.Setting.ShowNameEnum = newNameEnum;
                if (isUpdateNameEnum)
                { 
                    m_pipeline.Group.UpdateGroupNameList();
                }
            }
            EditorGUI.EndChangeCheck();

            Utils.GUILine();
            {
                // お気に入り全解除
                GUILayout.Label($"{LanguageData.GetText(m_pipeline.Setting.Language, TextEnum.FavoriteGroup)} : " +
                    $"{m_pipeline.Group.GetGroupNameByGUID(m_pipeline.Group.SelectGroupFileName)}");
                
                GUILayout.BeginHorizontal();
                var content = new GUIContent(LanguageData.GetText(m_pipeline.Setting.Language, TextEnum.UnlockAll));
                if (GUILayout.Button(content, GUILayout.ExpandWidth(false), GUILayout.ExpandHeight(false)))
                {
                    if (isDeleteButtonPressedOnce)
                    {
                        m_pipeline.Favorites.RemoveAll();
                        m_pipeline.Favorites.SaveFavoritesData();
                        (m_pipeline.Root as MainWindow).Reload();
                        isDeleteButtonPressedOnce = false;
                        isAlreadyClear            = true;
                    }
                    else
                    {
                        isDeleteButtonPressedOnce = true;
                        isAlreadyClear            = false;
                    }
                }
                
                // Warning again: Prevent accidental touch
                if (isDeleteButtonPressedOnce)
                {
                    GUIStyle warningStyle = new GUIStyle(GUI.skin.label);
                    warningStyle.normal.textColor = Color.yellow;
                    var warning = new GUIContent(LanguageData.GetText(m_pipeline.Setting.Language, TextEnum.WarningClear));
                    GUILayout.Label(warning, warningStyle, GUILayout.ExpandWidth(false), GUILayout.ExpandHeight(false));
                }

                if (isAlreadyClear)
                {
                    GUIStyle alreadyClearStyle = new GUIStyle(GUI.skin.label);
                    alreadyClearStyle.normal.textColor = Color.green;
                    var alreadyClear = new GUIContent(LanguageData.GetText(m_pipeline.Setting.Language, TextEnum.AlreadyClear));
                    GUILayout.Label(alreadyClear, alreadyClearStyle, GUILayout.ExpandWidth(false), GUILayout.ExpandHeight(false));
                }
                
                GUILayout.EndHorizontal();
            }

            Utils.GUILine();
            GUILayout.Label(LanguageData.GetText(m_pipeline.Setting.Language, TextEnum.ImportAndExportTarget));

            GUILayout.BeginHorizontal();
            {
                GUILayout.Label(LanguageData.GetText(m_pipeline.Setting.Language, TextEnum.ExportTarget));
                EditorGUI.BeginDisabledGroup(true);
                EditorGUILayout.TextField(m_pipeline.Setting.IOTarget);
                EditorGUI.EndDisabledGroup();
            }
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            {
                GUILayout.Label(LanguageData.GetText(m_pipeline.Setting.Language, TextEnum.ImportTarget));
                EditorGUI.BeginDisabledGroup(true);
                EditorGUILayout.TextField(m_pipeline.Setting.IOTarget);
                EditorGUI.EndDisabledGroup();
            }
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            {
                GUILayout.Label(LanguageData.GetText(m_pipeline.Setting.Language, TextEnum.Filename));
                EditorGUI.BeginDisabledGroup(true);
                EditorGUILayout.TextField(m_pipeline.Setting.IOFileName);
                EditorGUI.EndDisabledGroup();
            }
            GUILayout.EndHorizontal();

            Utils.GUILine();
            GUILayout.EndScrollView();
        }

        public override void Close()
        {
            isDeleteButtonPressedOnce = false;
            isAlreadyClear            = false;
        }
    }
}
#endif
