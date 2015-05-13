<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="InvoiceViewer.aspx.cs" Inherits="InvoiceViewer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="FacElecStyle.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <%--<telerik:RadAjaxManager ID="RadAjaxManager2" runat="server">
    </telerik:RadAjaxManager>--%>
    </div>
    <div>
        <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
            <script type="text/javascript" language="javascript">
                function openinvoice(idFactura) {
                    window.open('http://facturae.ariadnasoftware.com/Invoice.aspx?Factura=' + idFactura, 'Factura', " toolbar=0,location=0,status=0,menubar=0,scrollbars=yes,resizable=yes, width=screen.width,width=" + screen.width / 4 + " height=400,top=500");
                }
            </script>
        </telerik:RadScriptBlock>

    </div>
    <div id="contenido">
        <telerik:RadTabStrip ID="RadTabStrip1" runat="server" SelectedIndex="1" MultiPageID="RadMultiPage1">
            <Tabs>
                <telerik:RadTab Text="Mi cuenta">
                </telerik:RadTab>
                <telerik:RadTab Text="Facturas" Selected="True">
                </telerik:RadTab>
                <telerik:RadTab Text="Facturas de proveedor">
                </telerik:RadTab>
                <telerik:RadTab Text="Datos personales">
                </telerik:RadTab>
                <telerik:RadTab Text="Campos">
                </telerik:RadTab>
                <telerik:RadTab Text="Articulos">
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
                                <asp:Label ID="Label1" runat="server" Text="Nombre:"></asp:Label>
                            </td>
                            <td>
                                <telerik:RadTextBox ID="txtNombre" runat="server" Width="200px">
                                </telerik:RadTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label2" runat="server" Text="Cif:"></asp:Label>
                            </td>
                            <td>
                                <telerik:RadTextBox ID="txtCif" runat="server">
                                </telerik:RadTextBox>
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
                                <telerik:RadButton ID="RadButton1" runat="server" Text="Guardar cambios" 
                                                   onclick="RadButton1_Click">
                                </telerik:RadButton>
                            </td>
                        </tr>
                    </table>
                </div>
            </telerik:RadPageView>
            <telerik:RadPageView ID="pvFacturas" runat="server">
                <div id="divCombos" class="headContent" style="left: 10%; position: relative; width: 80%;">
                    <table id="tableCombos">
                        <tr>
                            <td>
                                <asp:Label ID="lblAño" runat="server" Text="Año:"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblMes" runat="server" Text="Mes:"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblBase" runat="server" Text="Base:"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblCuota" runat="server" Text="Cuota:"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblTotal" runat="server" Text="Importe total:"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblDescargas" runat="server" Text="Descargas:"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <telerik:RadComboBox ID="cmbAño" runat="server" 
                                                     onselectedindexchanged="cmbAño_SelectedIndexChanged" 
                                                     AutoPostBack="True" Width="120px">
                                </telerik:RadComboBox>
                            </td>
                            <td>
                                <telerik:RadComboBox ID="cmbMes" runat="server" AutoPostBack="True" 
                                                     onselectedindexchanged="cmbMes_SelectedIndexChanged" 
                                                     Width="120px">
                                </telerik:RadComboBox>
                            </td>
                            <td>
                                <telerik:RadTextBox ID="txtBase" runat="server" Enabled="False">
                                </telerik:RadTextBox>
                            </td>
                            <td>
                                <telerik:RadTextBox ID="txtCuota" runat="server" Enabled="False">
                                </telerik:RadTextBox>
                            </td>
                            <td>
                                <telerik:RadTextBox ID="txtImporte" runat="server" Enabled="False">
                                </telerik:RadTextBox>
                            </td>
                            <td align="center">
                                <asp:ImageButton ID="imgBtnPDF" runat="server" ImageUrl="~/img/pdf_logo.png" ToolTip="Zip PDF"
                                                 onclick="imgBtnPDF_Click" />
                                <asp:ImageButton ID="imgBtnXML" runat="server" ImageUrl="~/img/xml_logo.png" ToolTip="Zip XML"
                                                 onclick="imgBtnXML_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
                <br />
                <div style="left: 10%; position: relative; width: 80%;">
                    <telerik:RadGrid ID="grdFacturas" runat="server" 
                                     onneeddatasource="RadGrid1_NeedDataSource"
                                     GridLines="None" Width="100%"
                                     BackColor="White" BorderStyle="None" 
                                     onitemcommand="grdFacturas_ItemCommand" AllowFilteringByColumn="True" 
                                     AllowPaging="True" PageSize="15" AllowSorting="True" 
                                     ShowGroupPanel="True" onitemdatabound="grdFacturas_ItemDataBound">
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
                        <ClientSettings AllowDragToGroup="True">
                        </ClientSettings>
                        <GroupPanel Text="Arrastre aquí la columna que quiera agrupar.">
                        </GroupPanel>
                        <MasterTableView autogeneratecolumns="False" datakeynames="Id_Factura" PagerStyle-AlwaysVisible="true" 
                                         TableLayout="Auto" PagerStyle-NextPagesToolTip="Páginas siguientes" PagerStyle-NextPageToolTip="Siguiente" 
                                         PagerStyle-PageSizeLabelText="Tamaño de página" PagerStyle-PrevPagesToolTip="Páginas anteriores" 
                                         PagerStyle-PrevPageToolTip="Anterior" PagerStyle-FirstPageToolTip="Primera página" PagerStyle-LastPageToolTip="Última página">
                            <CommandItemSettings ShowAddNewRecordButton="False" ShowRefreshButton="False">
                            </CommandItemSettings>
                            <ItemStyle Width="20%" />
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="20%" />
                            <FilterItemStyle HorizontalAlign="Right" VerticalAlign="Middle"/>
                            <Columns>
                                <telerik:GridBoundColumn DataField="Id_Factura" DataType="System.Int32" Visible="false"
                                                         HeaderText="ID" ReadOnly="True" SortExpression="Id_Factura" UniqueName="Id_Factura">
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn  UniqueName="TemplateEditColumn" AllowFiltering="false" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="20px">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="FacturaNueva" runat="server" ImageUrl="~/img/new.png" ToolTip="¡Nueva!" Enabled="False" Visible="False" />
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="Sistema.descripcion" HeaderText="SISTEMA" SortExpression="Sistema.descripcion" ItemStyle-HorizontalAlign="Center">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Fecha" HeaderText="Fecha " SortExpression="Fecha" UniqueName="Fecha" DataType="System.DateTime"
                                                         DataFormatString="{0:dd/MM/yyyy}" ItemStyle-HorizontalAlign="Center" AllowFiltering="false">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Num_serie" HeaderText="Serie " SortExpression="Num_serie" ItemStyle-HorizontalAlign="Center">
                                </telerik:GridBoundColumn>
                                <telerik:GridNumericColumn DataField = "Num_factura" HeaderText ="Número de factura" SortExpression="Num_factura" ItemStyle-HorizontalAlign="Right" >
                                </telerik:GridNumericColumn>
                                <telerik:GridNumericColumn DataField = "Ttal" HeaderText ="Importe" SortExpression="Ttal" DataType="System.Double" ItemStyle-HorizontalAlign="Right" 
                                                           DataFormatString="{0:c}" >
                                    <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                </telerik:GridNumericColumn>
                                <telerik:GridTemplateColumn  UniqueName="TemplateEditColumn" AllowFiltering="false" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="Verfactura" runat="server" ImageUrl="img/pdf_logo.png" ToolTip="Ver/Descargar factura"/>
                                        <asp:ImageButton ID="VerfacturaE" runat="server" ImageUrl="img/xml_logo.png" ToolTip="Descargar XML-facturaE"/>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                            </Columns>
                            <PagerStyle AlwaysVisible="True"></PagerStyle>
                        </MasterTableView>
                    </telerik:RadGrid>
                </div>
            </telerik:RadPageView>
            <telerik:RadPageView ID="pvFacturasProveedor" runat="server">
                <div id="div1" class="headContent" style="left: 10%; position: relative; width: 80%;">
                    <table id="table1">
                        <tr>
                            <td>
                                <asp:Label ID="Label9" runat="server" Text="Año:"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label10" runat="server" Text="Mes:"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label11" runat="server" Text="Base:"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label12" runat="server" Text="Cuota:"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label15" runat="server" Text="Retención:"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label13" runat="server" Text="Importe total:"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label14" runat="server" Text="Descargas:"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <telerik:RadComboBox ID="cmbAnyoP" runat="server" 
                                                     onselectedindexchanged="cmbAnyoP_SelectedIndexChanged" 
                                                     AutoPostBack="True" Width="120px">
                                </telerik:RadComboBox>
                            </td>
                            <td>
                                <telerik:RadComboBox ID="cmbMesP" runat="server" AutoPostBack="True" 
                                                     onselectedindexchanged="cmbMesP_SelectedIndexChanged" 
                                                     Width="120px">
                                </telerik:RadComboBox>
                            </td>
                            <td>
                                <telerik:RadTextBox ID="BaseProv" runat="server" Enabled="False">
                                </telerik:RadTextBox>
                            </td>
                            <td>
                                <telerik:RadTextBox ID="CuotaProv" runat="server" Enabled="False">
                                </telerik:RadTextBox>
                            </td>
                            <td>
                                <telerik:RadTextBox ID="RetenProv" runat="server" Enabled="False">
                                </telerik:RadTextBox>
                            </td>
                            <td>
                                <telerik:RadTextBox ID="TotalProv" runat="server" Enabled="False">
                                </telerik:RadTextBox>
                            </td>
                            <td align="center">
                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/img/pdf_logo.png" ToolTip="Zip PDF"
                                                 onclick="imgBtnPDFProv_Click" />
                                <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/img/xml_logo.png" ToolTip="Zip XML"
                                                 onclick="imgBtnXMLProve_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
                <br />
                <div style="left: 10%; position: relative; width: 80%;">
                    <telerik:RadGrid ID="grdFacturasProve" runat="server" 
                                     onneeddatasource="RadGridProve_NeedDataSource"
                                     GridLines="None" Width="100%"
                                     BackColor="White" BorderStyle="None" 
                                     onitemcommand="grdFacturasProve_ItemCommand" AllowFilteringByColumn="True" 
                                     AllowPaging="True" PageSize="15" AllowSorting="True" 
                                     ShowGroupPanel="True" onitemdatabound="grdFacturasProve_ItemDataBound">
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
                        <ClientSettings AllowDragToGroup="True">
                        </ClientSettings>
                        <GroupPanel Text="Arrastre aquí la columna que quiera agrupar.">
                        </GroupPanel>
                        <MasterTableView autogeneratecolumns="False" datakeynames="Id_Factura" PagerStyle-AlwaysVisible="true" 
                                         TableLayout="Auto" PagerStyle-NextPagesToolTip="Páginas siguientes" PagerStyle-NextPageToolTip="Siguiente" 
                                         PagerStyle-PageSizeLabelText="Tamaño de página" PagerStyle-PrevPagesToolTip="Páginas anteriores" 
                                         PagerStyle-PrevPageToolTip="Anterior" PagerStyle-FirstPageToolTip="Primera página" PagerStyle-LastPageToolTip="Última página">
                            <CommandItemSettings ShowAddNewRecordButton="False" ShowRefreshButton="False">
                            </CommandItemSettings>
                            <ItemStyle Width="20%" />
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="20%" />
                            <FilterItemStyle HorizontalAlign="Right" VerticalAlign="Middle"/>
                            <Columns>
                                <telerik:GridBoundColumn DataField="Id_Factura" DataType="System.Int32" Visible="false"
                                                         HeaderText="ID" ReadOnly="True" SortExpression="Id_Factura" UniqueName="Id_Factura">
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn  UniqueName="TemplateEditColumn" AllowFiltering="false" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="20px">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="FacturaNueva" runat="server" ImageUrl="~/img/new.png" ToolTip="¡Nueva!" Enabled="False" Visible="False" />
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="Sistema.descripcion" HeaderText="SISTEMA" SortExpression="Sistema.descripcion" ItemStyle-HorizontalAlign="Center">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Fecha" HeaderText="Fecha " SortExpression="Fecha" UniqueName="Fecha" DataType="System.DateTime"
                                                         DataFormatString="{0:dd/MM/yyyy}" ItemStyle-HorizontalAlign="Center" AllowFiltering="false">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Num_serie" HeaderText="Serie " SortExpression="Num_serie" ItemStyle-HorizontalAlign="Center">
                                </telerik:GridBoundColumn>
                                <telerik:GridNumericColumn DataField = "Num_factura" HeaderText ="Número de factura" SortExpression="Num_factura" ItemStyle-HorizontalAlign="Right" >
                                </telerik:GridNumericColumn>
                                <telerik:GridNumericColumn DataField = "Ttal" HeaderText ="Importe" SortExpression="Ttal" DataType="System.Double" ItemStyle-HorizontalAlign="Right" 
                                                           DataFormatString="{0:c}" >
                                    <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                </telerik:GridNumericColumn>
                                <telerik:GridTemplateColumn  UniqueName="TemplateEditColumn" AllowFiltering="false" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="Verfactura" runat="server" ImageUrl="img/pdf_logo.png" ToolTip="Ver factura"/>
                                        <asp:ImageButton ID="VerfacturaE" runat="server" ImageUrl="img/xml_logo.png" ToolTip="Descargar facturaE"/>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                            </Columns>
                            <PagerStyle AlwaysVisible="True"></PagerStyle>
                        </MasterTableView>
                    </telerik:RadGrid>
                </div>
            </telerik:RadPageView>
            <telerik:RadPageView ID="pvDatosPersonales" runat="server">
                <div id="divDatosPersonales" class="headContent" style="left: 10%; position: relative; width: 80%;">
                    <table id="table2">
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="Label16" runat="server" Text="Datos personales:"></asp:Label>
                                <br />
                                <p>Estos son sus datos en nuestras bases, puede solicitarnos la modificación de los mismos.</p>
                                <p>Para ello realice los cambios pertinentes en los siguientes campos y haga clic en "Enviar solicitud"</p>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblNif" runat="server" Text="Nif:"></asp:Label>
                            </td>
                            <td>
                                <telerik:RadTextBox ID="txtNif" runat="server" Width="200px">
                                </telerik:RadTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblNomLargo" runat="server" Text="Nombre:"></asp:Label>
                            </td>
                            <td>
                                <telerik:RadTextBox ID="txtNomLargo" runat="server" Width="400px">
                                </telerik:RadTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblDireccion" runat="server" Text="Direccion:"></asp:Label>
                            </td>
                            <td>
                                <telerik:RadTextBox ID="txtDireccion" runat="server" Width="400px">
                                </telerik:RadTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblPoblacion" runat="server" Text="Población:"></asp:Label>
                            </td>
                            <td>
                                <telerik:RadTextBox ID="txtPoblacion" runat="server" Width="400px">
                                </telerik:RadTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblCodPostal" runat="server" Text="Código postal:"></asp:Label>
                            </td>
                            <td>
                                <telerik:RadTextBox ID="txtCodPostal" runat="server" Width="200px">
                                </telerik:RadTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblProvincia" runat="server" Text="Provincia:"></asp:Label>
                            </td>
                            <td>
                                <telerik:RadTextBox ID="txtProvincia" runat="server" Width="400px">
                                </telerik:RadTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblFechaNacimiento" runat="server" Text="Fecha nacimiento:"></asp:Label>
                            </td>
                            <td>
                                <telerik:RadTextBox ID="txtFechaNacimiento" runat="server" Width="200px">
                                </telerik:RadTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblTelefono1" runat="server" Text="Teléfono (1):"></asp:Label>
                            </td>
                            <td>
                                <telerik:RadTextBox ID="txtTelefono1" runat="server" Width="200px">
                                </telerik:RadTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblTelefono2" runat="server" Text="Teléfono (2):"></asp:Label>
                            </td>
                            <td>
                                <telerik:RadTextBox ID="txtTelefono2" runat="server" Width="200px">
                                </telerik:RadTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblMovil" runat="server" Text="Móvil:"></asp:Label>
                            </td>
                            <td>
                                <telerik:RadTextBox ID="txtMovil" runat="server" Width="200px">
                                </telerik:RadTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblMail" runat="server" Text="Correo electrónico:"></asp:Label>
                            </td>
                            <td>
                                <telerik:RadTextBox ID="txtMail" runat="server" Width="400px">
                                </telerik:RadTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblCuenta" runat="server" Text="Cuenta bancaria:"></asp:Label>
                            </td>
                            <td>
                                <telerik:RadTextBox ID="txtIban" runat="server" Width="50px" MaxLength="4">
                                </telerik:RadTextBox>
                                -
                                <telerik:RadTextBox ID="txtEntidad" runat="server" Width="50px" MaxLength="4">
                                </telerik:RadTextBox>
                                -
                                <telerik:RadTextBox ID="txtSucursal" runat="server" Width="50px" MaxLength="4">
                                </telerik:RadTextBox>
                                -
                                <telerik:RadTextBox ID="txtDc" runat="server" Width="25px" MaxLength="2">
                                </telerik:RadTextBox>
                                -
                                <telerik:RadTextBox ID="txtNumcc" runat="server" Width="150px" MaxLength="10">
                                </telerik:RadTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblComentarios" runat="server" Text="Comentarios / Sugerencias:"></asp:Label>
                            </td>
                            <td>
                                <telerik:RadTextBox ID="txtComentarios" runat="server" Width="400px" Height="90px" TextMode="MultiLine">
                                </telerik:RadTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <telerik:RadButton ID="RadButton2" runat="server" Text="Enviar solicitud de cambio / Sugerencias" OnClick="RadButton2_Click">
                                </telerik:RadButton>
                            </td>
                        </tr>
                    </table>
                </div>
            </telerik:RadPageView>
            <telerik:RadPageView ID="pvCampos" runat="server">
                <div id="div2" class="headContent" style="left: 10%; position: relative; width: 80%;">

                </div>
                <br />
                <div style="left: 10%; position: relative; width: 80%;">
                    <telerik:RadGrid ID="grdCampos" runat="server" 
                                     onneeddatasource="RadCampos_NeedDataSource"
                                     GridLines="None"
                                     BackColor="White" BorderStyle="None" 
                                     onitemcommand="grdCampos_ItemCommand" AllowFilteringByColumn="True" 
                                     AllowPaging="True" PageSize="15" AllowSorting="True">
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
                        <ClientSettings AllowDragToGroup="True">
                        </ClientSettings>
                        <GroupPanel Text="Arrastre aquí la columna que quiera agrupar.">
                        </GroupPanel>
                        <MasterTableView autogeneratecolumns="False" datakeynames="Codcampo" PagerStyle-AlwaysVisible="true" 
                                         TableLayout="Auto" PagerStyle-NextPagesToolTip="Páginas siguientes" PagerStyle-NextPageToolTip="Siguiente" 
                                         PagerStyle-PageSizeLabelText="Tamaño de página" PagerStyle-PrevPagesToolTip="Páginas anteriores" 
                                         PagerStyle-PrevPageToolTip="Anterior" PagerStyle-FirstPageToolTip="Primera página" PagerStyle-LastPageToolTip="Última página">
                            <CommandItemSettings ShowAddNewRecordButton="False" ShowRefreshButton="False">
                            </CommandItemSettings>
                            <ItemStyle Width="20%" />
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="20%" />
                            <FilterItemStyle HorizontalAlign="Right" VerticalAlign="Middle"/>
                            <Columns>
                                <telerik:GridBoundColumn DataField="Codcampo" DataType="System.Int32" Visible="false"
                                                         HeaderText="ID" ReadOnly="True" SortExpression="Codcampo" UniqueName="Codcampo">
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn  UniqueName="TemplateEditColumn" AllowFiltering="false" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="20px">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="FacturaNueva" runat="server" ImageUrl="~/img/new.png" ToolTip="¡Nueva!" Enabled="False" Visible="False" />
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="NroCampo" HeaderText="Nr.Campo" SortExpression="NroCampo">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Nomvarie" HeaderText="Variedad" SortExpression="Nomvarie">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Nomparti" HeaderText="Partida" SortExpression="Nomparti">
                                </telerik:GridBoundColumn>
                                <telerik:GridNumericColumn DataField = "Supsigpa" HeaderText ="Superficie" SortExpression="Supsigpa" DataType="System.Decimal" ItemStyle-HorizontalAlign="Right" 
                                                           DataFormatString="{0:0.0000}" >
                                    <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                </telerik:GridNumericColumn>
                                <telerik:GridBoundColumn DataField="Provincia" HeaderText="Provincia" SortExpression="Provincia" ItemStyle-HorizontalAlign="Center">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Municipio" HeaderText="Municipio" SortExpression="Municipio" ItemStyle-HorizontalAlign="Center">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Poligono" HeaderText="Poligono" SortExpression="Poligono" ItemStyle-HorizontalAlign="Center">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Parcela" HeaderText="Parcela" SortExpression="Parcela" ItemStyle-HorizontalAlign="Center">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Nomsitua" HeaderText="Situación" SortExpression="Nomsitua" >
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn  UniqueName="TemplateEditColumn" AllowFiltering="false" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="Versigpac" runat="server" ImageUrl="img/earth_view.png" ToolTip="Ver SIGPAC"/>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                            </Columns>
                            <PagerStyle AlwaysVisible="True"></PagerStyle>
                        </MasterTableView>
                    </telerik:RadGrid>
                </div>
            </telerik:RadPageView>
            <telerik:RadPageView ID="pvArticulos" runat="server">
                <div id="div3" class="headContent" style="left: 10%; position: relative; width: 80%;">

                </div>
                <br />
                <div style="left: 10%; position: relative; width: 80%;">
                    <telerik:RadGrid ID="grdArticulos" runat="server" 
                                     onneeddatasource="RadArticulos_NeedDataSource"
                                     GridLines="None"
                                     BackColor="White" BorderStyle="None" 
                                     onitemcommand="grdArticulos_ItemCommand" AllowFilteringByColumn="True" 
                                     AllowPaging="True" PageSize="15" AllowSorting="True">
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
                        <ClientSettings AllowDragToGroup="True">
                        </ClientSettings>
                        <GroupPanel Text="Arrastre aquí la columna que quiera agrupar.">
                        </GroupPanel>
                        <MasterTableView autogeneratecolumns="False" datakeynames="CodArtic" PagerStyle-AlwaysVisible="true" 
                                         TableLayout="Auto" PagerStyle-NextPagesToolTip="Páginas siguientes" PagerStyle-NextPageToolTip="Siguiente" 
                                         PagerStyle-PageSizeLabelText="Tamaño de página" PagerStyle-PrevPagesToolTip="Páginas anteriores" 
                                         PagerStyle-PrevPageToolTip="Anterior" PagerStyle-FirstPageToolTip="Primera página" PagerStyle-LastPageToolTip="Última página">
                            <CommandItemSettings ShowAddNewRecordButton="False" ShowRefreshButton="False">
                            </CommandItemSettings>
                            <ItemStyle Width="20%" />
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="20%" />
                            <FilterItemStyle HorizontalAlign="Right" VerticalAlign="Middle"/>
                            <Columns>
                                <telerik:GridBoundColumn DataField="CodArtic" DataType="System.String" Visible="false"
                                                         HeaderText="CODIGO" ReadOnly="True" SortExpression="CodArtic" UniqueName="CodArtic">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="NomArtic" HeaderText="ARTICULO" SortExpression="NomArtic">
                                </telerik:GridBoundColumn>
                                <telerik:GridNumericColumn DataField = "PVP" HeaderText ="PVP" SortExpression="PVP" DataType="System.Decimal" ItemStyle-HorizontalAlign="Right" 
                                                           DataFormatString="{0:0.00}" >
                                    <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                </telerik:GridNumericColumn>
<%--                                
                                <telerik:GridTemplateColumn  UniqueName="TemplateEditColumn" AllowFiltering="false" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="Versigpac" runat="server" ImageUrl="img/earth_view.png" ToolTip="Ver SIGPAC"/>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
    --%>
                            </Columns>
                            <PagerStyle AlwaysVisible="True"></PagerStyle>
                        </MasterTableView>
                    </telerik:RadGrid>
                </div>
            </telerik:RadPageView>
        </telerik:RadMultiPage>
    </div>
</asp:Content>

