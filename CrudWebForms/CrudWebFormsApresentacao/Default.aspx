<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CrudWebFormsApresentacao.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <table>
            <tr>
                <td>Nome</td>
                <td>
                    <asp:TextBox runat="server" ID="NomeTextBox" />
                </td>
            </tr>
            <tr>
                <td>Idade</td>
                <td>
                    <asp:TextBox runat="server" ID="IdadeTextBox" />
                </td>
            </tr>
            <tr>
                <td>CPF</td>
                <td>
                    <asp:TextBox runat="server" ID="CPFTextBox" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button Text="Inserir" ID="InserirButton" runat="server" OnClick="InserirButton_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label Text="" runat="server" ID="MensagemLabel" />
                </td>
            </tr>
        </table>
        <hr />
        <asp:Repeater ID="ListaRepeater" runat="server" OnItemCommand="ListaRepeater_ItemCommand" >
            <HeaderTemplate>
                <table style="border: 1px solid #000; width: 100px;">
                    <thead>
                        <tr>
                            <th>Nome</th>
                            <th>Id</th>
                            <th>CPF</th>
                            <th></th>
                        </tr>
                    </thead>
            </HeaderTemplate>
            <ItemTemplate>
                <tbody>
                    <tr>
                        <td><%# DataBinder.Eval(Container.DataItem, "Nome") %></td>
                        <td><%# DataBinder.Eval(Container.DataItem, "Id") %></td>
                        <td><%# DataBinder.Eval(Container.DataItem, "CPF") %></td>
                        <td>
                            <asp:LinkButton Text="Excluir" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Id") %>' CommandName="Excluir" runat="server" /></td>
                    </tr>
                </tbody>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </form>
</body>
</html>
