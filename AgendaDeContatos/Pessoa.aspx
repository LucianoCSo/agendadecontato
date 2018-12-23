﻿<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Pessoa.aspx.cs" Inherits="AgendaDeContatos.Pessoa" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <br />
        <div class="panel panel-default">

            <div class="panel-heading">Pessoa</div>
            <div class="panel-body">

                <fieldset class="col-md-6">
                    <legend>Cadastro Pessoa</legend>

                    <div class="form-row">
                        <div class="form-group col-lg-6">
                            <p>Nome:</p>
                            <asp:TextBox ID="txtNome" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group col-lg-6">
                            <p>Cpf:</p>
                            <input type="text" id="txtCpf" name="txtCpf" class="form-control" />
                        </div>
                    </div>

                    <div class="form-row">
                        <div class="form-group col-md-6">
                            <p>E-Mail:</p>
                            <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-6">
                            <p>Data de Nascimento:</p>
                            <input type="text" id="txtNascimento" name="txtNascimento" class="form-control" />
                        </div>
                    </div>
                </fieldset>
                <div class="clearfix"></div>
            </div>
        </div>
    </div>

    <div class="container">
        <br />
        <div class="panel panel-default">

            <div class="panel-heading">Contatos</div>
            <div class="panel-body">

                <fieldset class="col-md-10">
                    <legend>Telefone</legend>

                    <div class="form-row">

                        <div class="form-group col-mb-2">
                            <p>DDD:</p>
                            <input type="text" id="txtDdd" name="txtDdd" style="width:60px;" class="form-control" />
                        </div>
                        <div class="form-group" style="margin-left: 100px; margin-top: -80px;">
                            <p>Telefone:</p>
                            <input type="text" id="txtTelefone" name="txtTelefone" class="form-control" />
                        </div>

                        <div class="form-group col-mb-2" style="margin-top: -50px; margin-left:400px;">
                            <asp:Button ID="btnAdicionar" runat="server" CssClass="btn btn-primary" Text="Adicionar" OnClick="btnAdicionar_Click" />
                        </div>
                        <asp:Label ID="labAlerta"  CssClass="text-danger" runat="server" Text="Label" Visible="False" Font-Size="15px"></asp:Label>
                        <div>
                            <asp:GridView ID="GridView1" CssClass="table table-hover text-center" runat="server" Width="380" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateDeleteButton="True" OnRowDeleting="GridView1_RowDeleting">
                                <AlternatingRowStyle BackColor="White" />
                                <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                                <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                                <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                                <SortedAscendingCellStyle BackColor="#FDF5AC" />
                                <SortedAscendingHeaderStyle BackColor="#4D0000" />
                                <SortedDescendingCellStyle BackColor="#FCF6C0" />
                                <SortedDescendingHeaderStyle BackColor="#820000" />
                            </asp:GridView>
                        </div>
                    </div>
                </fieldset>
            </div>
        </div>
    </div>
    <asp:Button ID="btnSalvar" CssClass="btn btn-primary" Style="margin-left:15px;" runat="server" Text="Salvar Contato" OnClick="btnSalvar_Click" />

</asp:Content>
