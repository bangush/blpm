﻿<%@ Page Title="Redactar Mensaje" Language="C#" MasterPageFile="~/EDUARMaster.Master"
    AutoEventWireup="true" CodeBehind="MsjeRedactar.aspx.cs" Inherits="EDUAR_UI.MsjeRedactar"
    Theme="Tema" StylesheetTheme="Tema" ValidateRequest="false" %>

<%@ MasterType VirtualPath="~/EDUARMaster.Master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/UserControls/Editor.ascx" TagName="Editor" TagPrefix="edi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
        function EndRequestHandler(sender, args) {
            if (args.get_error() == undefined) {
                alertTest();
            }
        }

        function alertTest() {
            $(document).ready(function () {
                $(".chzn-select").chosen();
            });
        }

        alertTest();    
    </script>
    <asp:UpdatePanel ID="udpFiltros" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table class="tablaInterna" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <h2>
                            <asp:Label ID="lblTitulo" Text="Nuevo Mensaje" runat="server" /></h2>
                        <br />
                    </td>
                    <td align="right">
                        <asp:ImageButton ID="btnEnviar" OnClick="btnEnviar_Click" runat="server" ToolTip="Enviar"
                            ImageUrl="~/Images/botonEnviarMail.png" />
                        <asp:ImageButton ID="btnRecibidos" OnClick="btnRecibidos_Click" runat="server" ToolTip="Recibidos"
                            ImageUrl="~/Images/verMensajes.png" Visible="true" />
                        <asp:ImageButton ID="btnEnviados" OnClick="btnEnviados_Click" runat="server" ToolTip="Enviados"
                            ImageUrl="~/Images/botonEnviados.png" Visible="true" />
                        <asp:ImageButton ID="btnVolver" OnClick="btnVolver_Click" runat="server" ToolTip="Volver"
                            ImageUrl="~/Images/botonVolver.png" />
                    </td>
                </tr>
            </table>
            <table class="tablaInterna" width="100%">
                <tr>
                    <td>
                    </td>
                </tr>
            </table>
            <table class="tablaInternaSinBorde" width="100%">
                <tr>
                    <td class="TD110px" valign="middle">
                        <asp:Label ID="lblFiltrado" Text="Filtrado por Curso" runat="server" Visible="false" />
                    </td>
                    <td class="TD50px">
                        <asp:CheckBox ID="chkFiltrado" runat="server" OnCheckedChanged="chkFiltrado_CheckedChanged"
                            AutoPostBack="true" Text="" Visible="False" />
                    </td>
                    <td>
                    </td>
                </tr>
            </table>
            <div id="divDocente" runat="server" visible="false">
                <table class="tablaInternaSinBorde" width="100%">
                    <tr>
                        <td class="TD110px" valign="middle">
                            Curso:
                        </td>
                        <td class="TD80">
                            <asp:DropDownList ID="ddlCurso" runat="server" AutoPostBack="true" CssClass="EstiloTxtMedio120"
                                OnSelectedIndexChanged="ddlCurso_OnSelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            Tipo de
                            <br />
                            Destinatario:
                        </td>
                        <td rowspan="3">
                            <asp:RadioButtonList ID="rdlDestinatarios" runat="server" OnSelectedIndexChanged="rdlDestinatarios_OnSelectedIndexChanged"
                                AutoPostBack="true">
                                <asp:ListItem Text="Seleccionar Alumnos" Value="1" Enabled="true" />
                                <asp:ListItem Text="Seleccionar Tutores" Value="2" />
                                <asp:ListItem Text="Seleccionar otros Docentes" Value="3" />
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                </table>
            </div>
            <table class="tablaInternaSinBorde" width="100%">
                <tr>
                    <td class="TD20" valign="middle">
                        Destinatarios
                    </td>
                    <td class="TD80">
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <select data-placeholder="Seleccione los destinatarios" style="width: 714px;" multiple="true"
                                    class="chzn-select" runat="server" id="ddlDestino" enableviewstate="true">
                                </select>
                            </ContentTemplate>
                            <Triggers>
                                <asp:PostBackTrigger ControlID="ddlDestino" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td class="TD20">
                        Asunto
                    </td>
                    <td class="TD80">
                        <input id="txtAsunto" type="text" runat="server" style="width: 710px; background-color: #FFFFFF;
                            background-image: -moz-linear-gradient(center bottom , white 85%, #EEEEEE 99%);
                            border: 1px solid #AAAAAA; cursor: text; height: 26px !important; margin: 0;
                            overflow: hidden; padding: 0; position: relative; font-family: sans-serif; font-size: 1em" />
                    </td>
                </tr>
                <tr>
                    <td class="TD20">
                    </td>
                    <td class="TD80">
                        <edi:Editor ID="textoMensaje" runat="server" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="ddlCurso" />
            <asp:PostBackTrigger ControlID="rdlDestinatarios" />
        </Triggers>
    </asp:UpdatePanel>
    <script type="text/javascript">        $(".chzn-select").chosen();</script>
</asp:Content>
