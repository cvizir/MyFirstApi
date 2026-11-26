using System;
using System.Collections.Generic;

namespace MyFirstApi.Models;

/// <summary>
/// 會員資料表
/// </summary>
public partial class Member
{
    /// <summary>
    /// 會員流水號
    /// </summary>
    public int No { get; set; }

    /// <summary>
    /// 更新時間
    /// </summary>
    public DateTime? Uptime { get; set; }

    /// <summary>
    /// 真實姓名
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// 會員代碼(英數混合9位)
    /// </summary>
    public string MemberCode { get; set; } = null!;

    /// <summary>
    /// 暱稱(英文名)
    /// </summary>
    public string? Nickname { get; set; }

    /// <summary>
    /// 性別
    /// </summary>
    public int? Sex { get; set; }

    /// <summary>
    /// 身分證字號
    /// </summary>
    public string? Pid { get; set; }

    /// <summary>
    /// 會員狀態
    /// </summary>
    public sbyte? MemberMode { get; set; }

    /// <summary>
    /// 註冊時間
    /// </summary>
    public DateTime? Regtime { get; set; }

    /// <summary>
    /// 電子郵件
    /// </summary>
    public string Email { get; set; } = null!;

    /// <summary>
    /// 大頭照
    /// </summary>
    public string? Photo { get; set; }

    /// <summary>
    /// 密碼
    /// </summary>
    public string Psw { get; set; } = null!;

    /// <summary>
    /// 市內電話
    /// </summary>
    public string? Tel { get; set; }

    /// <summary>
    /// 手機號碼
    /// </summary>
    public string? Phone { get; set; }

    /// <summary>
    /// 郵遞區號
    /// </summary>
    public string? Zipcode { get; set; }

    /// <summary>
    /// 居住縣市
    /// </summary>
    public string? City { get; set; }

    /// <summary>
    /// 鄉鎮市區
    /// </summary>
    public string? Area { get; set; }

    /// <summary>
    /// 詳細地址
    /// </summary>
    public string? Addr { get; set; }

    /// <summary>
    /// 公司統編
    /// </summary>
    public string? CpId { get; set; }

    /// <summary>
    /// 公司抬頭
    /// </summary>
    public string? CpTitle { get; set; }

    /// <summary>
    /// 生日
    /// </summary>
    public DateTime? Birthday { get; set; }

    /// <summary>
    /// 訂閱電子報
    /// </summary>
    public int? Esend { get; set; }

    /// <summary>
    /// 信箱驗證
    /// </summary>
    public int? EmailCheck { get; set; }
}
