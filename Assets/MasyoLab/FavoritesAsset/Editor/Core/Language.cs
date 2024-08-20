#if UNITY_EDITOR
using System.Collections.Generic;

//=========================================================
//
//  developer : MasyoLab
//  github    : https://github.com/MasyoLab/UnityTools-FavoritesAsset
//
//=========================================================

namespace MasyoLab.Editor.FavoritesAsset
{
    /// <summary>
    /// 言語
    /// </summary>
    [System.Serializable]
    enum LanguageEnum
    {
        English,
        Japanese,
        TradionnalChinese
    }

    /// <summary>
    /// テキスト
    /// </summary>
    enum TextEnum
    {
        Language,
        DragAndDrop,
        UnlockAll,
        NumFav,
        Import,
        Export,
        Menu,
        Home,
        Setting,
        Help,
        ImportAndExportTarget,
        ExportTarget,
        ImportTarget,
        Filename,
        SourceCode,
        License,
        LatestRelease,
        Link,
        AddNewFavoriteGroup,
        FavoriteGroup,
        FavoriteGroupIsEmpty,
        CopyFavoriteGroup,
        CopyFavoriteGroupFeatureDescription,
        CopyFavoriteGroupPulldownDescription,
        CopyFavoriteGroupReplicationButton,
        WarningClear,
        AlreadyClear,
    }

    struct LanguageData
    {
        public static readonly string[] LANGUAGE = {
            "English",
            "Japanese",
            "Tradionnal Chinese",
        };

        private static IReadOnlyDictionary<TextEnum, string> TEXT_EN_DICT = new Dictionary<TextEnum, string>()
        {
            { TextEnum.Language , "Editor Language" },
            { TextEnum.DragAndDrop , "Register via Drag & Drop" },
            { TextEnum.UnlockAll , "Clear All Favorites" },
            { TextEnum.NumFav , "Favorites" },
            { TextEnum.Import , "Load" },
            { TextEnum.Export , "Save As" },
            { TextEnum.Menu , "Menu" },
            { TextEnum.Home , "Home" },
            { TextEnum.Setting , "Settings" },
            { TextEnum.Help , "Help" },
            { TextEnum.ImportAndExportTarget , "Import & Export Destinations" },
            { TextEnum.ExportTarget , "Export Destination" },
            { TextEnum.ImportTarget , "Import Destination" },
            { TextEnum.Filename , "File Name" },
            { TextEnum.SourceCode , "Source Code" },
            { TextEnum.License , "License" },
            { TextEnum.LatestRelease , "Latest Release" },
            { TextEnum.Link , "Links" },
            { TextEnum.AddNewFavoriteGroup , "Add Favorite Group..." },
            { TextEnum.FavoriteGroup , "Favorite Groups" },
            { TextEnum.FavoriteGroupIsEmpty , "Favorite Groups are empty" },
            { TextEnum.CopyFavoriteGroup , "Duplicate Favorite Group" },
            { TextEnum.CopyFavoriteGroupFeatureDescription , "Duplicate the contents of the Favorite Group" },
            { TextEnum.CopyFavoriteGroupPulldownDescription , "Select a group" },
            { TextEnum.CopyFavoriteGroupReplicationButton , "Duplicate" },
            { TextEnum.WarningClear, "<Please press again to confirm deletion>"},
            { TextEnum.AlreadyClear, "<Successfully cleared !>"}
        };

        private static IReadOnlyDictionary<TextEnum, string> TEXT_JA_DICT = new Dictionary<TextEnum, string>()
        {
            { TextEnum.Language , "エディターの言語" },
            { TextEnum.DragAndDrop , "ドラッグ＆ドロップで登録" },
            { TextEnum.UnlockAll , "全てのお気に入りを解除" },
            { TextEnum.NumFav , "個のお気に入り" },
            { TextEnum.Import , "読み込み" },
            { TextEnum.Export , "名前を付けて保存" },
            { TextEnum.Menu , "メニュー" },
            { TextEnum.Home , "Home" },
            { TextEnum.Setting , "設定" },
            { TextEnum.Help , "ヘルプ" },
            { TextEnum.ImportAndExportTarget , "インポート＆エクスポート先" },
            { TextEnum.ExportTarget , "エクスポート先" },
            { TextEnum.ImportTarget , "インポート先" },
            { TextEnum.Filename , "ファイル名" },
            { TextEnum.SourceCode , "ソースコード" },
            { TextEnum.License , "ライセンス" },
            { TextEnum.LatestRelease , "最新のリリース" },
            { TextEnum.Link , "リンク" },
            { TextEnum.AddNewFavoriteGroup , "お気に入りグループを追加..." },
            { TextEnum.FavoriteGroup , "お気に入りグループ" },
            { TextEnum.FavoriteGroupIsEmpty , "お気に入りグループは空です" },
            { TextEnum.CopyFavoriteGroup , "お気に入りグループを複製" },
            { TextEnum.CopyFavoriteGroupFeatureDescription , "お気に入りグループの内容を複製します" },
            { TextEnum.CopyFavoriteGroupPulldownDescription , "グループを選択" },
            { TextEnum.CopyFavoriteGroupReplicationButton , "複製" },
            { TextEnum.WarningClear, "<削除を確認するためにもう一度押してください>"},
            { TextEnum.AlreadyClear, "<正常にクリアしました !>"}
        };
        
        private static IReadOnlyDictionary<TextEnum, string> TEXT_TC_DICT = new Dictionary<TextEnum, string>()
        {
            { TextEnum.Language , "編輯器語言" },
            { TextEnum.DragAndDrop , "收藏檔案可拖移至此 ↓" },
            { TextEnum.UnlockAll , "清除所有收藏" },
            { TextEnum.NumFav , "收藏" },
            { TextEnum.Import , "載入" },
            { TextEnum.Export , "另存為" },
            { TextEnum.Menu , "選單" },
            { TextEnum.Home , "主頁" },
            { TextEnum.Setting , "設置" },
            { TextEnum.Help , "幫助" },
            { TextEnum.ImportAndExportTarget , "導入與導出目標" },
            { TextEnum.ExportTarget , "導出目標" },
            { TextEnum.ImportTarget , "導入目標" },
            { TextEnum.Filename , "檔案名稱" },
            { TextEnum.SourceCode , "源代碼" },
            { TextEnum.License , "許可證" },
            { TextEnum.LatestRelease , "最新版本" },
            { TextEnum.Link , "連結" },
            { TextEnum.AddNewFavoriteGroup , "新增收藏夾群組..." },
            { TextEnum.FavoriteGroup , "收藏夾群組" },
            { TextEnum.FavoriteGroupIsEmpty , "收藏夾群組為空" },
            { TextEnum.CopyFavoriteGroup , "複製收藏夾群組" },
            { TextEnum.CopyFavoriteGroupFeatureDescription , "複製收藏夾群組的內容" },
            { TextEnum.CopyFavoriteGroupPulldownDescription , "選擇一個群組" },
            { TextEnum.CopyFavoriteGroupReplicationButton , "複製" },
            { TextEnum.WarningClear, "<請再按一次以確認刪除>"},
            { TextEnum.AlreadyClear, "<成功清除 !>"}
        };

        public static string GetText(LanguageEnum lang, TextEnum text)
        {
            switch (lang)
            {
                case LanguageEnum.English:
                    return TEXT_EN_DICT[text];
                case LanguageEnum.Japanese:
                    return TEXT_JA_DICT[text];
                case LanguageEnum.TradionnalChinese:
                    return TEXT_TC_DICT[text];
                default:
                    return TEXT_EN_DICT[text];
            }
        }
    }
}
#endif
