using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telerik.Web.UI;

/// <summary>
/// Summary description for GridTraductor
/// </summary>
public static class GridTraductor
{
	public static void TraducirGrupoRadGrid(RadGrid rdg)
    {
        GridGroupingSettings ggs = rdg.GroupingSettings;
        ggs.CollapseTooltip = "Contraer grupo";
        ggs.ExpandTooltip = "Explandir grupo";
        ggs.GroupContinuedFormatString = "...el grupo continua en la página anterior.";
        ggs.GroupContinuesFormatString = "...el grupo continua en la página siguiente.";
        ggs.GroupSplitDisplayFormat = "Visualizando {0} of {1} items.";
        ggs.UnGroupButtonTooltip = "Pulsa aquí para desagrupar.";
        ggs.UnGroupTooltip = "Arrastre fuera de la barra para desagrupar";

        GridGroupPanel ggp = rdg.GroupPanel;
        ggp.Text = "Para agrupar, arrastre aquí la cabecera de una columna.";

        GridPagerStyle gps = rdg.PagerStyle;
        gps.FirstPageText = "";
        gps.FirstPageToolTip = "Primera página";
        gps.LastPageText = "";
        gps.LastPageToolTip = "Última página";
        gps.NextPagesToolTip = "Página siguientes";
        gps.NextPageText = "";
        gps.NextPageToolTip = "Página siguiente";
        gps.PagerTextFormat = "Cambiar de página: {4} &nbsp;Página <strong>{0}</strong> de <strong>{1}</strong>, items <strong>{2}</strong> al <strong>{3}</strong> de <strong>{5}</strong>.";
        gps.PageSizeLabelText = "Tamaño de página";
        gps.PrevPagesToolTip = "Páginas anteriores";
        gps.PrevPageToolTip = "Página anterior";
        
    }
    
    public static void TraducirFiltrosRadGrid(RadGrid rdg)
    {
        GridFilterMenu rfm = rdg.FilterMenu;
        rfm.ToolTip = "Filtro";
        foreach (RadMenuItem item in rfm.Items)
        {
            switch (item.Text)
            {
                case "NoFilter":
                    item.Text = "Quitar filtro";
                    break;
                case "EqualTo":
                    item.Text = "Igual a";
                    break;
                case "NotEqualTo":
                    item.Text = "No igual a";
                    break;
                case "GreaterThan":
                    item.Text = "Mayor que";
                    break;
                case "LessThan":
                    item.Text = "Menor que";
                    break;
                case "GreaterThanOrEqualTo":
                    item.Text = "Mayor o igual que";
                    break;
                case "LessThanOrEqualTo":
                    item.Text = "Menor o igual que";
                    break;
                case "Between":
                    item.Text = "Entre";
                    break;
                case "NotBetween":
                    item.Text = "No entre";
                    break;
                case "IsNull":
                    item.Text = "Es nulo";
                    break;
                case "NotIsNull":
                    item.Text = "No es nulo";
                    break;

                case "Contains":
                    item.Text = "Contiene";
                    break;
                case "DoesNotContain":
                    item.Text = "No contiene";
                    break;
                case "StartsWith":
                    item.Text = "Comienza con";
                    break;
                case "EndsWith":
                    item.Text = "Termina con";
                    break;
                case "IsEmpty":
                    item.Text = "Está vacio";
                    break;
                case "NotIsEmpty":
                    item.Text = "No está vacio";
                    break;
                default:
                    break;
            }
        }
    }
}