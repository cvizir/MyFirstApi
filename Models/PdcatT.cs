using System;
using System.Collections.Generic;

namespace MyFirstApi.Models;

/// <summary>
/// 第一層主分類表
/// </summary>
public partial class PdcatT
{
    public int No { get; set; }

    /// <summary>
    /// 第一層主分類代碼
    /// </summary>
    public string PdcatTCode { get; set; } = null!;

    /// <summary>
    /// 分類名稱/說明
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// 連結網址
    /// </summary>
    public string? Url { get; set; }

    /// <summary>
    /// 連結開啟方式 (例如 _self, _blank)
    /// </summary>
    public string? LinkType { get; set; }

    /// <summary>
    /// 排序 (數字越小越前面)
    /// </summary>
    public int? MSort { get; set; }

    /// <summary>
    /// 是否顯示 (1: 顯示, 0: 隱藏)
    /// </summary>
    public bool? Ishow { get; set; }

    public virtual ICollection<PdcatM> PdcatMs { get; set; } = new List<PdcatM>();
}
