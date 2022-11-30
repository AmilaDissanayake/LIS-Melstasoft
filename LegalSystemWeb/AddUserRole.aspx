﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddUserRole.aspx.cs" Inherits="LegalSystemWeb.AddUserRole" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div style="height: 40px;"></div>
    <div class="card" style="width: 70%; margin-left: auto; margin-right: auto">

        <h2 style="text-align: center; margin-bottom: 40px; margin-top: 30px;">Add User Role</h2>

        <div class="row mb-5" style="text-align: center">

            <div class="col-sm-3">
                User Role Name : 
            </div>
            <div class="col-sm-6">
                <asp:TextBox ID="txtRoleName" Style="width: 100%;" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="text-danger"
                    ControlToValidate="txtRoleName" ErrorMessage="Email is Required" ValidationGroup="1">This field is Required</asp:RequiredFieldValidator>
            </div>
            <div class="col-sm-3">
                <asp:Button ID="btnSave" runat="server" Text="Add" Style="width: 80%;" OnClick="btnSave_Click" ValidationGroup="1" />
            </div>

        </div>
        <div class="row mb-5" style="text-align: center; width: 100%; padding-left: 20px;">
            <div class="table-responsive" style="width: 100%; padding-left: 40px; padding-right: 40px;">
                <asp:GridView Style="margin-top: 30px;" ID="gvUserRole" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-hover"
                    CellPadding="4" ForeColor="#333333" GridLines="None" AllowPaging="True" OnPageIndexChanging="gvUserRole_OnPageIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="RoleId" HeaderText="Role Id" />
                        <asp:BoundField DataField="RoleName" HeaderText="Role Name" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="btnEdit" runat="server" OnClick="btnEdit_Click">Edit</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="btndelete" runat="server" OnClick="btndelete_Click">Delete</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>

        </div>
    </div>
    <div style="height: 40px;"></div>

</asp:Content>
