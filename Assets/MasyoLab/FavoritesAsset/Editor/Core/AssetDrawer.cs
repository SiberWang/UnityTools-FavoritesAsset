﻿#if UNITY_EDITOR
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Events;

//=========================================================
//
//  developer : MasyoLab
//  github    : https://github.com/MasyoLab/UnityTools-FavoritesAsset
//
//=========================================================

namespace MasyoLab.Editor.FavoritesAsset
{
    struct AssetDrawer
    {
        private static PtrLinker<GUIStyle> BUTTON_STYLE = new PtrLinker<GUIStyle>(() =>
        {
            return new GUIStyle(GUI.skin.button);
        });

        /// <summary>
        /// アセットの情報を描画
        /// </summary>
        /// <param name="pipeline"></param>
        /// <param name="info"></param>
        /// <param name="onAction"></param>
        private static void DrawingSetting(IPipeline pipeline, AssetData info, UnityAction<GUIContent, GUIStyle> onAction = null)
        {
            var infoName = GetResultInfoName(pipeline , info);
            
            GUIContent content   = null;
            Texture    assetIcon = null;

            assetIcon = FavoritesAssetWindow.GetFavoritesAssetIcon?.Invoke(info.Path);
            if (assetIcon == null)
            {
                assetIcon = AssetDatabase.GetCachedIcon(info.Path);
            }

            if (assetIcon == null)
            {
                assetIcon = EditorGUIUtility.IconContent(CONST.ICON_ERRORICON).image;
                content = new GUIContent("(missing asset) " + infoName, assetIcon);
            }
            else
            {
                content = new GUIContent(infoName, assetIcon);
            }

            var style = BUTTON_STYLE.Inst;
            var originalAlignment = style.alignment;
            var originalFontStyle = style.fontStyle;
            var originalTextColor = style.normal.textColor;

            style.alignment = TextAnchor.MiddleLeft;
            onAction?.Invoke(content, style);
            style.alignment = originalAlignment;
            style.fontStyle = originalFontStyle;
            style.normal.textColor = originalTextColor;
        }

        /// <summary>
        /// アセットを開くボタン
        /// </summary>
        /// <param name="pipeline"></param>
        /// <param name="rect"></param>
        /// <param name="data"></param>
        /// <param name="onButtonAction"></param>
        public static void OnAssetButton(IPipeline pipeline, Rect rect, AssetData data, UnityAction<AssetData> onButtonAction = null)
        {
            DrawingSetting(pipeline, data, (content, style) =>
            {
                if (GUI.Button(rect, content, style))
                {
                    onButtonAction?.Invoke(data);
                }
            });
        }

        /// <summary>
        /// アセットを開くボタン
        /// </summary>
        /// <param name="pipeline"></param>
        /// <param name="win"></param>
        /// <param name="data"></param>
        /// <param name="onButtonAction"></param>
        public static void OnAssetButton(IPipeline pipeline, EditorWindow win, AssetData data, UnityAction<AssetData> onButtonAction = null)
        {
            DrawingSetting(pipeline, data, (content, style) =>
            {
                float width = win.position.width - 100f;
                if (GUILayout.Button(content, style, GUILayout.MaxWidth(width), GUILayout.Height(CONST.GUI_LAYOUT_HEIGHT)))
                {
                    onButtonAction?.Invoke(data);
                }
            });
        }

        /// <summary>
        /// アセットを開くボタン
        /// </summary>
        /// <param name="pipeline"></param>
        /// <param name="data"></param>
        /// <param name="onButtonAction"></param>
        public static void OnAssetButton(IPipeline pipeline, AssetData data, UnityAction<AssetData> onButtonAction = null)
        {
            DrawingSetting(pipeline, data, (content, style) =>
            {
                if (GUILayout.Button(content, style, GUILayout.ExpandWidth(true), GUILayout.Height(CONST.GUI_LAYOUT_HEIGHT)))
                {
                    onButtonAction?.Invoke(data);
                }
            });
        }

        /// <summary>
        /// アセットをPingする
        /// </summary>
        /// <param name="data"></param>
        public static void OnPingObjectButton(AssetData data)
        {
            // アイコンを指定
            var content = EditorGUIUtility.IconContent(CONST.ICON_ANIMATION_VISIBILITY_TOGGLE_ON);
            if (GUILayout.Button(content, GUILayout.ExpandWidth(false), GUILayout.Height(CONST.GUI_LAYOUT_HEIGHT)))
            {
                // アセットの情報
                var asset = data.GetObject();
                var oldActiveObject = Selection.activeObject;
                Selection.activeObject = asset;
                EditorGUIUtility.PingObject(asset);
                EditorUtility.FocusProjectWindow();
                Selection.activeObject = oldActiveObject;
            }
        }

        /// <summary>
        /// アセットをPingする
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="data"></param>
        public static void OnPingObjectButton(Rect rect, AssetData data)
        {
            // アイコンを指定
            var content = EditorGUIUtility.IconContent(CONST.ICON_ANIMATION_VISIBILITY_TOGGLE_ON);
            if (GUI.Button(rect, content))
            {
                // アセットの情報
                var asset = data.GetObject();
                var oldActiveObject = Selection.activeObject;
                Selection.activeObject = asset;
                EditorGUIUtility.PingObject(asset);
                EditorUtility.FocusProjectWindow();
                Selection.activeObject = oldActiveObject;
            }
        }

        /// <summary>
        /// お気に入り解除
        /// </summary>
        /// <param name="data"></param>
        /// <param name="onButtonAction"></param>
        /// <returns></returns>
        public static bool OnUnfavoriteButton(AssetData data, UnityAction<AssetData> onButtonAction = null)
        {
            // アイコンを指定
            var content = EditorGUIUtility.IconContent(CONST.ICON_CLOSE);
            if (GUILayout.Button(content, GUILayout.ExpandWidth(false), GUILayout.Height(CONST.GUI_LAYOUT_HEIGHT)))
            {
                onButtonAction?.Invoke(data);
                return true;
            }
            return false;
        }

        /// <summary>
        /// お気に入り解除
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="data"></param>
        /// <param name="onButtonAction"></param>
        /// <returns></returns>
        public static bool OnUnfavoriteButton(Rect rect, AssetData data, UnityAction<AssetData> onButtonAction = null)
        {
            // アイコンを指定
            var content = EditorGUIUtility.IconContent(CONST.ICON_CLOSE);
            if (GUI.Button(rect, content))
            {
                onButtonAction?.Invoke(data);
                return true;
            }
            return false;
        }
        
        private static string GetResultInfoName(IPipeline pipeline, AssetData info)
        {
            var settingShowFull = pipeline.Setting.ShowNameEnum;
            return settingShowFull switch
            {
                ShowNameEnum.Normal => info.Name,
                ShowNameEnum.FolderFullPath => AssetDatabase.IsValidFolder(info.Path)
                    ? info.Path
                    : info.Name,
                ShowNameEnum.FullPath => info.Path,
                _                     => throw new ArgumentOutOfRangeException()
            };
        }
    }
}
#endif
