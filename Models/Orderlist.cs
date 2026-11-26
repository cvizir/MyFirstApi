using System;
using System.Collections.Generic;

namespace MyFirstApi.Models;

public partial class Orderlist
{
    public int No { get; set; }

    public string OrderCode { get; set; } = null!;

    public string TransactionId { get; set; } = null!;

    public DateTime Uptime { get; set; }

    public DateTime Buytime { get; set; }

    public string MemberNo { get; set; } = null!;

    public string MemberCode { get; set; } = null!;

    public string PostCpy { get; set; } = null!;

    public string PostNum { get; set; } = null!;

    public string AtmNum { get; set; } = null!;

    public string StoreNum { get; set; } = null!;

    public string OrderInfo { get; set; } = null!;

    public string OrderHtml { get; set; } = null!;

    public int Amount { get; set; }

    public string InvoiceName { get; set; } = null!;

    public string InvoiceEmail { get; set; } = null!;

    public string InvoiceTel { get; set; } = null!;

    public int InvoiceGet { get; set; }

    public string InvoiceCountry { get; set; } = null!;

    public string InvoiceStore { get; set; } = null!;

    public string InvoiceCity { get; set; } = null!;

    public string InvoiceArea { get; set; } = null!;

    public string InvoiceAddr { get; set; } = null!;

    public string InvoiceZipcode { get; set; } = null!;

    public string ReceivesName { get; set; } = null!;

    public string ReceivesTel { get; set; } = null!;

    public string ReceivesMphone { get; set; } = null!;

    public string ReceivesCountry { get; set; } = null!;

    public string ReceivesCity { get; set; } = null!;

    public string ReceivesArea { get; set; } = null!;

    public string ReceivesAddr { get; set; } = null!;

    public string ReceivesZipcode { get; set; } = null!;

    public int ReceivesTime { get; set; }

    public string InvoiceType { get; set; } = null!;

    public string InvoiceTitle { get; set; } = null!;

    public string InvoiceNum { get; set; } = null!;

    public int Transportation { get; set; }

    public string PayMode { get; set; } = null!;

    public int PayModePrice { get; set; }

    public string PayInfo { get; set; } = null!;

    public string GetMode { get; set; } = null!;

    public string Ps { get; set; } = null!;

    public string OrderPs { get; set; } = null!;

    public string TransportationPs { get; set; } = null!;

    public int OtherPrice { get; set; }

    public string OtherPs { get; set; } = null!;

    public int TotalAmount { get; set; }

    public int CounterState { get; set; }

    public string OrderState { get; set; } = null!;

    public DateTime PostDate { get; set; }

    public DateTime PrePostDate { get; set; }
}
