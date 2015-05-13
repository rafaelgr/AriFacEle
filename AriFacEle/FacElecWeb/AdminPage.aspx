<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="AdminPage.aspx.cs" Inherits="AdminPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="FacElecStyle.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">



    <div id="contenido">

        <telerik:RadWindowManager ID="RadWindowManager2" runat="server" EnableShadow="true">

        </telerik:RadWindowManager>

        <telerik:RadTabStrip ID="RadTabStrip1" runat="server" SelectedIndex="1" MultiPageID="RadMultiPage1">
            <Tabs>
                <telerik:RadTab Text="Mi cuenta">
                </telerik:RadTab>
                <telerik:RadTab Text="Notificar a clientes" Selected="True">
                </telerik:RadTab>
            </Tabs>
        </telerik:RadTabStrip>
        <br />
        <telerik:RadMultiPage ID="RadMultiPage1" runat="server" SelectedIndex="1">
            <telerik:RadPageView ID="pvCuenta" runat="server">
                <div id="content_Micuenta" class="headContent" style="left: 10%; position: relative; width: 80%;">
                    <table id="table_Micuenta">
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="Label6" runat="server" Text="Datos de la cuenta:"></asp:Label>
                                <br />
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label7" runat="server" Text="Email:"></asp:Label>
                            </td>
                            <td>
                                <telerik:RadTextBox ID="txtEmail" runat="server" Width="170px">
                                </telerik:RadTextBox>
                                <asp:Image ID="Image3" runat="server" Visible="false" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label3" runat="server" Text="Login:"></asp:Label>
                                <br />
                                <br />
                            </td>
                            <td>
                                <telerik:RadTextBox ID="txtLogin" runat="server">
                                </telerik:RadTextBox>
                                <br />
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label4" runat="server" Text="Contraseña:"></asp:Label>
                            </td>
                            <td>
                                <telerik:RadTextBox ID="txtPass1" runat="server" TextMode="Password">
                                </telerik:RadTextBox>
                                <asp:Image ID="Image1" runat="server" Visible="false" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label5" runat="server" Text="Repetir"></asp:Label>
                                <br />
                                <asp:Label ID="Label8" runat="server" Text="contraseña:"></asp:Label>
                                <br />
                                <br />
                            </td>
                            <td>
                                <telerik:RadTextBox ID="txtPass2" runat="server" TextMode="Password">
                                </telerik:RadTextBox>
                                <asp:Image ID="Image2" runat="server" Visible="false" />
                                <br />
                                <br />
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <telerik:RadButton ID="btnGuardar" runat="server" Text="Guardar cambios" 
                                                   onclick="btnGuardar_Click">
                                </telerik:RadButton>
                            </td>
                        </tr>
                    </table>
                </div>
            </telerik:RadPageView>
            <telerik:RadPageView ID="pvFacturas" runat="server">
                <div style="left: 10%; position: relative; width: 80%;">
                    <div>
                        <table>
                            <tr>
                                <td>
                                    <asp:CheckBox ID="chkSelec" runat="server" Text="Seleccionar todos" 
                                                  oncheckedchanged="chkSelec_CheckedChanged" AutoPostBack="True" />
                                </td>
                                <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                <td>
                                    <asp:ImageButton ID="btnEnviar" runat="server" Height="32px" 
                                                     ImageUrl="~/img/btnEnviar.png" Width="84px" onclick="btnEnviar_Click" />
                                </td>
                                <td>
                                    <asp:ImageButton ID="btnEditPlantilla" runat="server" Height="32px" 
                                                     ImageUrl="~/img/editplantilla.png" onclick="btnEditPlantilla_Click" 
                                                     ToolTip="Editar plantilla" Width="32px" /> Editar plantilla <br />
                                </td>
                                <td style="color: #00CC00">
                                    <asp:Label ID="lblMensaje" runat="server" Text="Las facturas se han enviado correctamente a los clientes seleccionados." Visible="false"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <telerik:RadGrid ID="grdEnvio" runat="server" GridLines="None" Width="100%"
                                     BackColor="White" BorderStyle="None"  AllowFilteringByColumn="True" 
                                     AllowPaging="True" PageSize="15" AllowSorting="True" ShowGroupPanel="True"
                                     onneeddatasource="grdEnvio_NeedDataSource" onitemcommand="grdEnvio_ItemCommand"
                                     onitemdatabound="grdEnvio_ItemDataBound" AllowMultiRowSelection="True" >
                        <GroupingSettings CollapseTooltip="Colapsar grupo" 
                                          ExpandTooltip="Expandir grupo" 
                                          GroupContinuedFormatString="... el grupo continua de la página anterior. " 
                                          GroupContinuesFormatString="El grupo continúa en la siguiente página." 
                                          GroupSplitDisplayFormat="Mostrando {0} de {1} items." 
                                          UnGroupButtonTooltip="Haga clic para desagruprar" 
                                          UnGroupTooltip="Arrastre fuera de la barra para desagrupar."
                                          ShowUnGroupButton="true" />
                        <SortingSettings SortedAscToolTip="Orden asc" SortedDescToolTip="Orden desc" 
                                         SortToolTip="Haga click para ordenar" />
                        <ClientSettings AllowDragToGroup="True" Selecting-AllowRowSelect="true">
                            <Selecting EnableDragToSelectRows="False" />
                        </ClientSettings>
                        <GroupPanel Text="Arrastre aquí la columna que quiera agrupar.">
                        </GroupPanel>
                        <MasterTableView autogeneratecolumns="False" datakeynames="ID" ClientDataKeyNames="ID"
                                         PagerStyle-AlwaysVisible="true" TableLayout="Auto" PagerStyle-NextPagesToolTip="Páginas siguientes" PagerStyle-NextPageToolTip="Siguiente" PagerStyle-PageSizeLabelText="Tamaño de página" PagerStyle-PrevPagesToolTip="Páginas anteriores" PagerStyle-PrevPageToolTip="Anterior" PagerStyle-FirstPageToolTip="Primera página" PagerStyle-LastPageToolTip="Última página">
                            <CommandItemSettings ShowAddNewRecordButton="False" ShowRefreshButton="False">
                            </CommandItemSettings>
                            <ItemStyle Width="20%" />
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="20%" />
                            <FilterItemStyle HorizontalAlign="Right" VerticalAlign="Middle"/>
                            <Columns>
                                <telerik:GridBoundColumn DataField="ID" DataType="System.Int32" Visible="false"
                                                         HeaderText="ID" ReadOnly="True" SortExpression="ID" UniqueName="ID">
                                </telerik:GridBoundColumn>
                                <%--                                <telerik:GridClientSelectColumn UniqueName="chkSelected" CommandName="ChSelect" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="10%"></telerik:GridClientSelectColumn>
                                --%> <telerik:GridButtonColumn UniqueName="SelectColumn" CommandName="Selecion" Text="Añadir" ButtonType="PushButton"/>
                                <%--                                <telerik:GridTemplateColumn  UniqueName="TemplateEditColumn" AllowFiltering="false" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="10%">
                                <ItemTemplate >
                                <asp:CheckBox ID="check" runat="server" OnCheckedChanged="grdEnvio_checkedchanged" AutoPostBack="True"/>
                                </ItemTemplate>
                                </telerik:GridTemplateColumn>--%>
                                <telerik:GridBoundColumn DataField = "Cif" HeaderText ="CIF" SortExpression="Cif" HeaderStyle-Width="20%">
                                    <HeaderStyle Width="20%" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField = "Nombre" HeaderText ="Contacto" SortExpression="Nombre" HeaderStyle-Width="50%">
                                    <HeaderStyle Width="50%" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField = "Email" HeaderText ="Email" SortExpression="Email" HeaderStyle-Width="20%">
                                    <HeaderStyle Width="20%" />
                                </telerik:GridBoundColumn>
                            </Columns>
                            <PagerStyle AlwaysVisible="True"></PagerStyle>
                        </MasterTableView>
                        <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default" 
                                           EnableImageSprites="True">
                        </HeaderContextMenu>
                    </telerik:RadGrid>
                </div>
            </telerik:RadPageView>
        </telerik:RadMultiPage>
    </div>
</asp:Content>

