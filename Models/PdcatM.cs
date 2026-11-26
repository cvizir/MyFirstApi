using System;
using System.Collections.Generic;

namespace MyFirstApi.Models;

/// <summary>
/// 第二層中分類表
/// </summary>
public partial class PdcatM
{
    public int No { get; set; }

    /// <summary>
    /// 第二層中分類代碼
    /// </summary>
    public string PdcatMCode { get; set; } = null!;

    /// <summary>
    /// 關聯：第一層主分類代碼
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
    /// 連結開啟方式
    /// </summary>
    public string? LinkType { get; set; }

    /// <summary>
    /// 排序
    /// </summary>
    public int? MSort { get; set; }

    /// <summary>
    /// 是否顯示 (1: 顯示, 0: 隱藏)
    /// </summary>
    public bool? Ishow { get; set; }

    public virtual PdcatT PdcatTCodeNavigation { get; set; } = null!;

    public virtual ICollection<Pdcat> Pdcats { get; set; } = new List<Pdcat>();
}
