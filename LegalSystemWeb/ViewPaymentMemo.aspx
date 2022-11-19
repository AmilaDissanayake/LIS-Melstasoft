﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewPaymentMemo.aspx.cs" Inherits="LegalSystemWeb.ViewPaymentMemo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div style="height:40px;">
    </div>
    <div class="card mb-4">
        <div class="card-header">
            <i class="fas fa-table me-1"></i>
            Approve Payment Table
        </div>
        <div class="card-body">
        <asp:GridView Id="datatablesSimple" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-striped"
                        CellPadding="4" ForeColor="#333333" GridLines="None" AllowPaging="True">
        <Columns>
            <asp:BoundField DataField="OrderID" HeaderText="Case ID"/>
            <asp:BoundField DataField="CustomerID" HeaderText="Claim Amount"/>
            <asp:BoundField DataField="EmployeeID" HeaderText="Total Paid Amount Upto Now"/>
            <asp:BoundField DataField="Freight" HeaderText="Lawyer Name"/>
            <asp:BoundField DataField="OrderDate" HeaderText="Actions"/>
            <asp:BoundField DataField="ShipCity" HeaderText="Total Payable Amount"/>
            <asp:TemplateField HeaderText="Uploaded Doc/Slip">
                <ItemTemplate>
                    <asp:LinkButton ID="btnEdit" runat="server">View Document</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="View Details">
                <ItemTemplate>
                    <asp:LinkButton ID="btndelete" runat="server">View Details</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
            </div>
    </div>
</asp:Content>
