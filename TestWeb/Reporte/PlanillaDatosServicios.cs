using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Model;
using System.Collections.Generic;

/// <summary>
/// Summary description for DatosServicios
/// </summary>
public partial class PlanillaDatosServicios : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private DevExpress.DataAccess.ObjectBinding.ObjectDataSource objectDataSource1;
    private ReportHeaderBand reportHeaderBand1;
    private XRControlStyle Title;
    private XRControlStyle FieldCaption;
    private XRControlStyle PageInfo;
    private XRControlStyle DataField;
    private XRCheckBox checkModificacion;
    private XRLabel xrLabel35;
    private XRCheckBox checkRenovacion;
    private XRCheckBox checkCreacion;
    private XRLabel xrLabel72;
    private XRCheckBox checkAdministrador;
    private XRCheckBox checkUsuarioA;
    private XRCheckBox checkUsuario;
    private XRCheckBox checkOtros;
    private XRCheckBox checkTecnico;
    private XRCheckBox checkEspecialista;
    private XRLabel labelCheckN;
    private XRLabel labelCheckS;
    private XRCheckBox checkChatN;
    private XRCheckBox checkChatS;
    private XRCheckBox checkCorreoN;
    private XRCheckBox checkCorreoS;
    private XRCheckBox checkNavegacionIS;
    private XRCheckBox checkNavegacionIN;
    private XRCheckBox checkNavegacionNN;
    private XRCheckBox checkNavegacionNS;
    private XRCheckBox checkDirigente;
    private XRLabel labelChat;
    private XRLabel labelCorreo;
    private XRLabel labelNavegacionI;
    private XRLabel labelNavegacionN;
    private XRLine xrLine1;
    private XRLabel LabelPersonal;
    private XRLabel LabelRol;
    private XRLabel labelServicios;
    private XRLine xrLine3;
    private XRShape xrShape4;
    private XRShape xrShape2;
    private XRLabel xrLabel56;
    private XRLabel xrLabel55;
    private XRLine xrLine2;
    private XRTable xrTable3;
    private XRTableRow xrTableRow3;
    private XRTableCell xrTableCell7;
    private XRLabel xrLabel21;
    private XRTableCell xrTableCell8;
    private XRLabel xrLabel12;
    private XRTableCell xrTableCell9;
    private XRLabel xrLabel10;
    private XRTable xrTable4;
    private XRTableRow xrTableRow4;
    private XRTableCell xrTableCell10;
    private XRTableCell xrTableCell11;
    private XRTableCell xrTableCell12;
    private XRLabel xrLabel58;
    private XRCheckBox xrCheckBox8;
    private XRCheckBox xrCheckBox7;
    private XRLabel xrLabel57;
    private XRCheckBox checkMD;
    private XRCheckBox checkLSS;
    private XRCheckBox checkM;
    private XRCheckBox checkLM;
    private XRCheckBox checkSE;
    private XRCheckBox checkCM;
    private XRLabel xrLabel54;
    private XRLabel xrLabel53;
    private XRLabel xrLabel52;
    private XRLabel xrLabel51;
    private XRLabel xrLabel13;
    private XRLabel xrLabel4;
    private XRLabel xrLabel20;
    private XRLabel xrLabel5;
    private XRLabel xrLabel15;
    private XRLabel xrLabel17;
    private XRLabel xrLabel9;
    private XRLabel xrLabel16;
    private XRLabel xrLabel18;
    private XRLabel xrLabel6;
    private XRLabel xrLabel11;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public PlanillaDatosServicios()
    {
        InitializeComponent();
    }

    public PlanillaDatosServicios(PlanillaViewModel model)
    {
        InitializeComponent();
        this.DataSource = new List<PlanillaViewModel> { model};
    }

    /// <summary> 
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void xrLabel16_TextChanged(object sender, EventArgs e)
    {
        switch (xrLabel16.Text)
        {
            case "d":
                checkDirigente.Checked = true;
                break;
            case "e":
                checkEspecialista.Checked = true;
                break;
            case "t":
                checkTecnico.Checked = true;
                break;
            default:
                checkOtros.Checked = true;
                break;
        }
    }

    private void XrLabel17_TextChanged(object sender, EventArgs e)
    {
        switch (xrLabel17.Text)
        {
            case "u":
                checkUsuario.Checked = true;
                break;
            case "ua":
                checkUsuarioA.Checked = true;
                break;
            default:
                checkAdministrador.Checked = true;
                break;
        }
    }

    private void XrLabel11_TextChanged(object sender, EventArgs e)
    {
        if (xrLabel11.Text != "")
        {
            try
            {
                DateTime dt = DateTime.Parse(xrLabel11.Text);
                xrCheckBox8.Checked = true;
                xrCheckBox7.Checked = false;
            }
            catch (Exception)
            {
                xrCheckBox7.Checked = true;
                xrTableCell7.Text = xrTableCell8.Text = xrTableCell9.Text = "";
            }
        }
        else
        {
            xrCheckBox7.Checked = true;
        }
    }

    private void xrLabel6_TextChanged(object sender, EventArgs e)
    {
        switch (xrLabel16.Text)
        {
            case "cm":
                checkCM.Checked = true;
                break;
            case "se":
                checkSE.Checked = true;
                break;
            case "lm":
                checkLM.Checked = true;
                break;
            case "m":
                checkM.Checked = true;
                break;
            case "lss":
                checkLSS.Checked = true;
                break;
            default:
                checkMD.Checked = true;
                break;
        }
    }

    private void xrLabel9_TextChanged(object sender, EventArgs e)
    {
        switch (xrLabel9.Text)
        {
            case "m":
                checkModificacion.Checked = true;
                break;
            case "r":
                checkRenovacion.Checked = true;
                break;
            default:
                checkCreacion.Checked = true;
                break;
        }
    }

    #region Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraPrinting.Shape.ShapeRectangle shapeRectangle1 = new DevExpress.XtraPrinting.Shape.ShapeRectangle();
            DevExpress.XtraPrinting.Shape.ShapeRectangle shapeRectangle2 = new DevExpress.XtraPrinting.Shape.ShapeRectangle();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.objectDataSource1 = new DevExpress.DataAccess.ObjectBinding.ObjectDataSource(this.components);
            this.reportHeaderBand1 = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.Title = new DevExpress.XtraReports.UI.XRControlStyle();
            this.FieldCaption = new DevExpress.XtraReports.UI.XRControlStyle();
            this.PageInfo = new DevExpress.XtraReports.UI.XRControlStyle();
            this.DataField = new DevExpress.XtraReports.UI.XRControlStyle();
            this.checkModificacion = new DevExpress.XtraReports.UI.XRCheckBox();
            this.xrLabel35 = new DevExpress.XtraReports.UI.XRLabel();
            this.checkRenovacion = new DevExpress.XtraReports.UI.XRCheckBox();
            this.checkCreacion = new DevExpress.XtraReports.UI.XRCheckBox();
            this.xrLabel72 = new DevExpress.XtraReports.UI.XRLabel();
            this.checkAdministrador = new DevExpress.XtraReports.UI.XRCheckBox();
            this.checkUsuarioA = new DevExpress.XtraReports.UI.XRCheckBox();
            this.checkUsuario = new DevExpress.XtraReports.UI.XRCheckBox();
            this.checkOtros = new DevExpress.XtraReports.UI.XRCheckBox();
            this.checkTecnico = new DevExpress.XtraReports.UI.XRCheckBox();
            this.checkEspecialista = new DevExpress.XtraReports.UI.XRCheckBox();
            this.labelCheckN = new DevExpress.XtraReports.UI.XRLabel();
            this.labelCheckS = new DevExpress.XtraReports.UI.XRLabel();
            this.checkChatN = new DevExpress.XtraReports.UI.XRCheckBox();
            this.checkChatS = new DevExpress.XtraReports.UI.XRCheckBox();
            this.checkCorreoN = new DevExpress.XtraReports.UI.XRCheckBox();
            this.checkCorreoS = new DevExpress.XtraReports.UI.XRCheckBox();
            this.checkNavegacionIS = new DevExpress.XtraReports.UI.XRCheckBox();
            this.checkNavegacionIN = new DevExpress.XtraReports.UI.XRCheckBox();
            this.checkNavegacionNN = new DevExpress.XtraReports.UI.XRCheckBox();
            this.checkNavegacionNS = new DevExpress.XtraReports.UI.XRCheckBox();
            this.checkDirigente = new DevExpress.XtraReports.UI.XRCheckBox();
            this.labelChat = new DevExpress.XtraReports.UI.XRLabel();
            this.labelCorreo = new DevExpress.XtraReports.UI.XRLabel();
            this.labelNavegacionI = new DevExpress.XtraReports.UI.XRLabel();
            this.labelNavegacionN = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.LabelPersonal = new DevExpress.XtraReports.UI.XRLabel();
            this.LabelRol = new DevExpress.XtraReports.UI.XRLabel();
            this.labelServicios = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine3 = new DevExpress.XtraReports.UI.XRLine();
            this.xrShape4 = new DevExpress.XtraReports.UI.XRShape();
            this.xrLabel56 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel55 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine2 = new DevExpress.XtraReports.UI.XRLine();
            this.xrTable3 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrLabel21 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrTableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrTable4 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow4 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell10 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell11 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell12 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrLabel58 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrCheckBox8 = new DevExpress.XtraReports.UI.XRCheckBox();
            this.xrCheckBox7 = new DevExpress.XtraReports.UI.XRCheckBox();
            this.xrLabel57 = new DevExpress.XtraReports.UI.XRLabel();
            this.checkMD = new DevExpress.XtraReports.UI.XRCheckBox();
            this.checkLSS = new DevExpress.XtraReports.UI.XRCheckBox();
            this.checkM = new DevExpress.XtraReports.UI.XRCheckBox();
            this.checkLM = new DevExpress.XtraReports.UI.XRCheckBox();
            this.checkSE = new DevExpress.XtraReports.UI.XRCheckBox();
            this.checkCM = new DevExpress.XtraReports.UI.XRCheckBox();
            this.xrLabel54 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel53 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel52 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel51 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel20 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel15 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrShape2 = new DevExpress.XtraReports.UI.XRShape();
            this.xrLabel17 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel16 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel18 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this.objectDataSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.HeightF = 16.07785F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.StyleName = "DataField";
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 23F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.HeightF = 0F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // objectDataSource1
            // 
            this.objectDataSource1.DataSource = typeof(Model.PlanillaViewModel);
            this.objectDataSource1.Name = "objectDataSource1";
            // 
            // reportHeaderBand1
            // 
            this.reportHeaderBand1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrShape4,
            this.xrLabel17,
            this.xrLabel9,
            this.xrLabel16,
            this.xrLabel18,
            this.xrLabel6,
            this.xrLabel11,
            this.xrShape2,
            this.xrLabel56,
            this.xrLabel55,
            this.xrLine2,
            this.xrTable3,
            this.xrTable4,
            this.xrLabel58,
            this.xrCheckBox8,
            this.xrCheckBox7,
            this.xrLabel57,
            this.checkMD,
            this.checkLSS,
            this.checkM,
            this.checkLM,
            this.checkSE,
            this.checkCM,
            this.xrLabel54,
            this.xrLabel53,
            this.xrLabel52,
            this.xrLabel51,
            this.xrLabel13,
            this.xrLabel4,
            this.xrLabel20,
            this.xrLabel5,
            this.xrLabel15,
            this.checkModificacion,
            this.xrLabel35,
            this.checkRenovacion,
            this.checkCreacion,
            this.xrLabel72,
            this.checkAdministrador,
            this.checkUsuarioA,
            this.checkUsuario,
            this.checkOtros,
            this.checkTecnico,
            this.checkEspecialista,
            this.labelCheckN,
            this.labelCheckS,
            this.checkChatN,
            this.checkChatS,
            this.checkCorreoN,
            this.checkCorreoS,
            this.checkNavegacionIS,
            this.checkNavegacionIN,
            this.checkNavegacionNN,
            this.checkNavegacionNS,
            this.checkDirigente,
            this.labelChat,
            this.labelCorreo,
            this.labelNavegacionI,
            this.labelNavegacionN,
            this.xrLine1,
            this.LabelPersonal,
            this.LabelRol,
            this.labelServicios,
            this.xrLine3});
            this.reportHeaderBand1.HeightF = 385.3605F;
            this.reportHeaderBand1.Name = "reportHeaderBand1";
            // 
            // Title
            // 
            this.Title.BackColor = System.Drawing.Color.Transparent;
            this.Title.BorderColor = System.Drawing.Color.Black;
            this.Title.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Title.BorderWidth = 1F;
            this.Title.Font = new System.Drawing.Font("Times New Roman", 21F);
            this.Title.ForeColor = System.Drawing.Color.Black;
            this.Title.Name = "Title";
            // 
            // FieldCaption
            // 
            this.FieldCaption.BackColor = System.Drawing.Color.Transparent;
            this.FieldCaption.BorderColor = System.Drawing.Color.Black;
            this.FieldCaption.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.FieldCaption.BorderWidth = 1F;
            this.FieldCaption.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.FieldCaption.ForeColor = System.Drawing.Color.Black;
            this.FieldCaption.Name = "FieldCaption";
            // 
            // PageInfo
            // 
            this.PageInfo.BackColor = System.Drawing.Color.Transparent;
            this.PageInfo.BorderColor = System.Drawing.Color.Black;
            this.PageInfo.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.PageInfo.BorderWidth = 1F;
            this.PageInfo.Font = new System.Drawing.Font("Arial", 8F);
            this.PageInfo.ForeColor = System.Drawing.Color.Black;
            this.PageInfo.Name = "PageInfo";
            // 
            // DataField
            // 
            this.DataField.BackColor = System.Drawing.Color.Transparent;
            this.DataField.BorderColor = System.Drawing.Color.Black;
            this.DataField.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.DataField.BorderWidth = 1F;
            this.DataField.Font = new System.Drawing.Font("Arial", 9F);
            this.DataField.ForeColor = System.Drawing.Color.Black;
            this.DataField.Name = "DataField";
            this.DataField.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            // 
            // checkModificacion
            // 
            this.checkModificacion.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkModificacion.LocationFloat = new DevExpress.Utils.PointFloat(15.03686F, 306.8743F);
            this.checkModificacion.Name = "checkModificacion";
            this.checkModificacion.SizeF = new System.Drawing.SizeF(364.75F, 20F);
            this.checkModificacion.StylePriority.UseFont = false;
            this.checkModificacion.Text = " Modificación de Privilegios de un usuario existente";
            // 
            // xrLabel35
            // 
            this.xrLabel35.Font = new System.Drawing.Font("Arial", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel35.ForeColor = System.Drawing.Color.Black;
            this.xrLabel35.LocationFloat = new DevExpress.Utils.PointFloat(3.999972F, 4.516697F);
            this.xrLabel35.Name = "xrLabel35";
            this.xrLabel35.SizeF = new System.Drawing.SizeF(638F, 22.58333F);
            this.xrLabel35.StylePriority.UseFont = false;
            this.xrLabel35.StylePriority.UseForeColor = false;
            this.xrLabel35.StylePriority.UseTextAlignment = false;
            this.xrLabel35.Text = "Datos del Servicio";
            this.xrLabel35.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // checkRenovacion
            // 
            this.checkRenovacion.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkRenovacion.LocationFloat = new DevExpress.Utils.PointFloat(15.03686F, 338.225F);
            this.checkRenovacion.Name = "checkRenovacion";
            this.checkRenovacion.SizeF = new System.Drawing.SizeF(364.75F, 20F);
            this.checkRenovacion.StylePriority.UseFont = false;
            this.checkRenovacion.Text = " Renovación del Servicio a un usuario existente";
            // 
            // checkCreacion
            // 
            this.checkCreacion.Font = new System.Drawing.Font("Arial", 9.75F);
            this.checkCreacion.LocationFloat = new DevExpress.Utils.PointFloat(15.03686F, 273.4358F);
            this.checkCreacion.Name = "checkCreacion";
            this.checkCreacion.SizeF = new System.Drawing.SizeF(364.75F, 20F);
            this.checkCreacion.StylePriority.UseFont = false;
            this.checkCreacion.Text = " Creación de usuario NO existente";
            // 
            // xrLabel72
            // 
            this.xrLabel72.BackColor = System.Drawing.Color.LightGray;
            this.xrLabel72.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel72.LocationFloat = new DevExpress.Utils.PointFloat(4.036864F, 235.8958F);
            this.xrLabel72.Name = "xrLabel72";
            this.xrLabel72.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel72.SizeF = new System.Drawing.SizeF(393.21F, 23F);
            this.xrLabel72.StylePriority.UseBackColor = false;
            this.xrLabel72.StylePriority.UseFont = false;
            this.xrLabel72.StylePriority.UseTextAlignment = false;
            this.xrLabel72.Text = " Tipo de Solicitud";
            this.xrLabel72.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // checkAdministrador
            // 
            this.checkAdministrador.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkAdministrador.LocationFloat = new DevExpress.Utils.PointFloat(9.999998F, 208.8999F);
            this.checkAdministrador.Name = "checkAdministrador";
            this.checkAdministrador.SizeF = new System.Drawing.SizeF(149.5833F, 20F);
            this.checkAdministrador.StylePriority.UseFont = false;
            this.checkAdministrador.Text = " Administrador";
            // 
            // checkUsuarioA
            // 
            this.checkUsuarioA.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkUsuarioA.LocationFloat = new DevExpress.Utils.PointFloat(9.999998F, 188.8999F);
            this.checkUsuarioA.Name = "checkUsuarioA";
            this.checkUsuarioA.SizeF = new System.Drawing.SizeF(138.7917F, 20F);
            this.checkUsuarioA.StylePriority.UseFont = false;
            this.checkUsuarioA.Text = " Usuario Avanzado";
            // 
            // checkUsuario
            // 
            this.checkUsuario.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkUsuario.LocationFloat = new DevExpress.Utils.PointFloat(9.999998F, 168.8999F);
            this.checkUsuario.Name = "checkUsuario";
            this.checkUsuario.SizeF = new System.Drawing.SizeF(125.5417F, 19.99998F);
            this.checkUsuario.StylePriority.UseFont = false;
            this.checkUsuario.Text = " Usuario";
            // 
            // checkOtros
            // 
            this.checkOtros.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkOtros.LocationFloat = new DevExpress.Utils.PointFloat(9.999998F, 118.5167F);
            this.checkOtros.Name = "checkOtros";
            this.checkOtros.SizeF = new System.Drawing.SizeF(104.7917F, 20F);
            this.checkOtros.StylePriority.UseFont = false;
            this.checkOtros.Text = " Otros";
            // 
            // checkTecnico
            // 
            this.checkTecnico.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkTecnico.LocationFloat = new DevExpress.Utils.PointFloat(9.999998F, 98.51672F);
            this.checkTecnico.Name = "checkTecnico";
            this.checkTecnico.SizeF = new System.Drawing.SizeF(104.7917F, 20F);
            this.checkTecnico.StylePriority.UseFont = false;
            this.checkTecnico.Text = " Técnico";
            // 
            // checkEspecialista
            // 
            this.checkEspecialista.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkEspecialista.LocationFloat = new DevExpress.Utils.PointFloat(9.999998F, 78.51671F);
            this.checkEspecialista.Name = "checkEspecialista";
            this.checkEspecialista.SizeF = new System.Drawing.SizeF(104.7917F, 20F);
            this.checkEspecialista.StylePriority.UseFont = false;
            this.checkEspecialista.Text = " Especialista";
            // 
            // labelCheckN
            // 
            this.labelCheckN.AutoWidth = true;
            this.labelCheckN.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCheckN.LocationFloat = new DevExpress.Utils.PointFloat(186.4584F, 37.51659F);
            this.labelCheckN.Name = "labelCheckN";
            this.labelCheckN.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelCheckN.SizeF = new System.Drawing.SizeF(25F, 20F);
            this.labelCheckN.StylePriority.UseFont = false;
            this.labelCheckN.Text = "NO";
            // 
            // labelCheckS
            // 
            this.labelCheckS.AutoWidth = true;
            this.labelCheckS.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCheckS.LocationFloat = new DevExpress.Utils.PointFloat(160.4583F, 37.5167F);
            this.labelCheckS.Name = "labelCheckS";
            this.labelCheckS.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelCheckS.SizeF = new System.Drawing.SizeF(20F, 20F);
            this.labelCheckS.StylePriority.UseFont = false;
            this.labelCheckS.Text = "SI";
            // 
            // checkChatN
            // 
            this.checkChatN.Checked = true;
            this.checkChatN.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkChatN.LocationFloat = new DevExpress.Utils.PointFloat(188.5833F, 124.5167F);
            this.checkChatN.Name = "checkChatN";
            this.checkChatN.SizeF = new System.Drawing.SizeF(15F, 20F);
            // 
            // checkChatS
            // 
            this.checkChatS.LocationFloat = new DevExpress.Utils.PointFloat(161.9583F, 124.5167F);
            this.checkChatS.Name = "checkChatS";
            this.checkChatS.SizeF = new System.Drawing.SizeF(15F, 20F);
            // 
            // checkCorreoN
            // 
            this.checkCorreoN.Checked = true;
            this.checkCorreoN.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkCorreoN.LocationFloat = new DevExpress.Utils.PointFloat(188.5833F, 101.5167F);
            this.checkCorreoN.Name = "checkCorreoN";
            this.checkCorreoN.SizeF = new System.Drawing.SizeF(15F, 20F);
            // 
            // checkCorreoS
            // 
            this.checkCorreoS.LocationFloat = new DevExpress.Utils.PointFloat(161.9583F, 101.5167F);
            this.checkCorreoS.Name = "checkCorreoS";
            this.checkCorreoS.SizeF = new System.Drawing.SizeF(15F, 20F);
            // 
            // checkNavegacionIS
            // 
            this.checkNavegacionIS.LocationFloat = new DevExpress.Utils.PointFloat(161.9583F, 78.51671F);
            this.checkNavegacionIS.Name = "checkNavegacionIS";
            this.checkNavegacionIS.SizeF = new System.Drawing.SizeF(15F, 20F);
            // 
            // checkNavegacionIN
            // 
            this.checkNavegacionIN.Checked = true;
            this.checkNavegacionIN.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkNavegacionIN.LocationFloat = new DevExpress.Utils.PointFloat(188.5833F, 78.51671F);
            this.checkNavegacionIN.Name = "checkNavegacionIN";
            this.checkNavegacionIN.SizeF = new System.Drawing.SizeF(15F, 20F);
            // 
            // checkNavegacionNN
            // 
            this.checkNavegacionNN.Checked = true;
            this.checkNavegacionNN.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkNavegacionNN.LocationFloat = new DevExpress.Utils.PointFloat(188.5833F, 55.5167F);
            this.checkNavegacionNN.Name = "checkNavegacionNN";
            this.checkNavegacionNN.SizeF = new System.Drawing.SizeF(15F, 20F);
            // 
            // checkNavegacionNS
            // 
            this.checkNavegacionNS.LocationFloat = new DevExpress.Utils.PointFloat(161.9583F, 55.5167F);
            this.checkNavegacionNS.Name = "checkNavegacionNS";
            this.checkNavegacionNS.SizeF = new System.Drawing.SizeF(15F, 20F);
            this.checkNavegacionNS.StylePriority.UseBackColor = false;
            this.checkNavegacionNS.StylePriority.UseBorders = false;
            // 
            // checkDirigente
            // 
            this.checkDirigente.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkDirigente.LocationFloat = new DevExpress.Utils.PointFloat(9.999998F, 58.51671F);
            this.checkDirigente.Name = "checkDirigente";
            this.checkDirigente.SizeF = new System.Drawing.SizeF(104.7917F, 20F);
            this.checkDirigente.StylePriority.UseFont = false;
            this.checkDirigente.StylePriority.UseTextAlignment = false;
            this.checkDirigente.Text = " Dirigente";
            // 
            // labelChat
            // 
            this.labelChat.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelChat.LocationFloat = new DevExpress.Utils.PointFloat(216.75F, 124.5167F);
            this.labelChat.Name = "labelChat";
            this.labelChat.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelChat.SizeF = new System.Drawing.SizeF(181F, 22.99998F);
            this.labelChat.StylePriority.UseFont = false;
            this.labelChat.Text = "Mensajería Instantánea";
            // 
            // labelCorreo
            // 
            this.labelCorreo.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCorreo.LocationFloat = new DevExpress.Utils.PointFloat(216.75F, 101.5167F);
            this.labelCorreo.Name = "labelCorreo";
            this.labelCorreo.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelCorreo.SizeF = new System.Drawing.SizeF(181F, 22.99999F);
            this.labelCorreo.StylePriority.UseFont = false;
            this.labelCorreo.Text = "Correo";
            // 
            // labelNavegacionI
            // 
            this.labelNavegacionI.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNavegacionI.LocationFloat = new DevExpress.Utils.PointFloat(216.75F, 78.51671F);
            this.labelNavegacionI.Name = "labelNavegacionI";
            this.labelNavegacionI.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelNavegacionI.SizeF = new System.Drawing.SizeF(181F, 23F);
            this.labelNavegacionI.StylePriority.UseFont = false;
            this.labelNavegacionI.Text = "Navegación Internacional";
            // 
            // labelNavegacionN
            // 
            this.labelNavegacionN.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNavegacionN.LocationFloat = new DevExpress.Utils.PointFloat(216.75F, 55.51659F);
            this.labelNavegacionN.Name = "labelNavegacionN";
            this.labelNavegacionN.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelNavegacionN.SizeF = new System.Drawing.SizeF(181F, 23F);
            this.labelNavegacionN.StylePriority.UseFont = false;
            this.labelNavegacionN.Text = "Navegación Nacional";
            // 
            // xrLine1
            // 
            this.xrLine1.LineWidth = 2;
            this.xrLine1.LocationFloat = new DevExpress.Utils.PointFloat(148.7917F, 186.8165F);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.SizeF = new System.Drawing.SizeF(248F, 42.08F);
            // 
            // LabelPersonal
            // 
            this.LabelPersonal.LocationFloat = new DevExpress.Utils.PointFloat(9.999998F, 37.51659F);
            this.LabelPersonal.Name = "LabelPersonal";
            this.LabelPersonal.SizeF = new System.Drawing.SizeF(125.5417F, 18F);
            this.LabelPersonal.Text = "Tipo de Personal";
            // 
            // LabelRol
            // 
            this.LabelRol.LocationFloat = new DevExpress.Utils.PointFloat(9.999998F, 148.8999F);
            this.LabelRol.Name = "LabelRol";
            this.LabelRol.SizeF = new System.Drawing.SizeF(125.5417F, 18F);
            this.LabelRol.Text = "Roles en la PC";
            // 
            // labelServicios
            // 
            this.labelServicios.LocationFloat = new DevExpress.Utils.PointFloat(216.75F, 37.51659F);
            this.labelServicios.Name = "labelServicios";
            this.labelServicios.SizeF = new System.Drawing.SizeF(162F, 18F);
            this.labelServicios.Text = "Tipo de Servicios";
            // 
            // xrLine3
            // 
            this.xrLine3.LineDirection = DevExpress.XtraReports.UI.LineDirection.Vertical;
            this.xrLine3.LineWidth = 2;
            this.xrLine3.LocationFloat = new DevExpress.Utils.PointFloat(137.6665F, 27.09999F);
            this.xrLine3.Name = "xrLine3";
            this.xrLine3.SizeF = new System.Drawing.SizeF(22.79167F, 181.7999F);
            // 
            // xrShape4
            // 
            this.xrShape4.BorderWidth = 2F;
            this.xrShape4.LineWidth = 2;
            this.xrShape4.LocationFloat = new DevExpress.Utils.PointFloat(3.999972F, 27.09999F);
            this.xrShape4.Name = "xrShape4";
            this.xrShape4.Shape = shapeRectangle1;
            this.xrShape4.SizeF = new System.Drawing.SizeF(393.75F, 345.5916F);
            this.xrShape4.StylePriority.UseBorderWidth = false;
            // 
            // xrLabel56
            // 
            this.xrLabel56.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel56.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel56.LocationFloat = new DevExpress.Utils.PointFloat(410.2107F, 258.8999F);
            this.xrLabel56.Name = "xrLabel56";
            this.xrLabel56.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel56.SizeF = new System.Drawing.SizeF(393.4998F, 38.62003F);
            this.xrLabel56.StylePriority.UseBorders = false;
            this.xrLabel56.StylePriority.UseFont = false;
            this.xrLabel56.StylePriority.UseTextAlignment = false;
            this.xrLabel56.Text = "  Mientras mantenga vínculo laboral.   ";
            this.xrLabel56.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel55
            // 
            this.xrLabel55.BackColor = System.Drawing.Color.LightGray;
            this.xrLabel55.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel55.LocationFloat = new DevExpress.Utils.PointFloat(409.2475F, 235.8958F);
            this.xrLabel55.Name = "xrLabel55";
            this.xrLabel55.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel55.SizeF = new System.Drawing.SizeF(393.0001F, 22.99997F);
            this.xrLabel55.StylePriority.UseBackColor = false;
            this.xrLabel55.StylePriority.UseFont = false;
            this.xrLabel55.StylePriority.UseTextAlignment = false;
            this.xrLabel55.Text = " Validez de la Solicitud     ";
            this.xrLabel55.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLine2
            // 
            this.xrLine2.LocationFloat = new DevExpress.Utils.PointFloat(470.7107F, 99.51655F);
            this.xrLine2.Name = "xrLine2";
            this.xrLine2.SizeF = new System.Drawing.SizeF(280.7361F, 2F);
            // 
            // xrTable3
            // 
            this.xrTable3.LocationFloat = new DevExpress.Utils.PointFloat(602.9699F, 329.8743F);
            this.xrTable3.Name = "xrTable3";
            this.xrTable3.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow3});
            this.xrTable3.SizeF = new System.Drawing.SizeF(198.4877F, 24.04163F);
            // 
            // xrTableRow3
            // 
            this.xrTableRow3.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell7,
            this.xrTableCell8,
            this.xrTableCell9});
            this.xrTableRow3.Name = "xrTableRow3";
            this.xrTableRow3.Weight = 1D;
            // 
            // xrTableCell7
            // 
            this.xrTableCell7.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell7.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel21});
            this.xrTableCell7.Name = "xrTableCell7";
            this.xrTableCell7.StylePriority.UseBorders = false;
            this.xrTableCell7.StylePriority.UseTextAlignment = false;
            this.xrTableCell7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell7.Weight = 1D;
            // 
            // xrLabel21
            // 
            this.xrLabel21.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "validez", "{0:dd}")});
            this.xrLabel21.LocationFloat = new DevExpress.Utils.PointFloat(5.162601F, 6.041626F);
            this.xrLabel21.Name = "xrLabel21";
            this.xrLabel21.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel21.SizeF = new System.Drawing.SizeF(51F, 18F);
            this.xrLabel21.StyleName = "DataField";
            this.xrLabel21.Text = "xrLabel10";
            // 
            // xrTableCell8
            // 
            this.xrTableCell8.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell8.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel12});
            this.xrTableCell8.Name = "xrTableCell8";
            this.xrTableCell8.StylePriority.UseBorders = false;
            this.xrTableCell8.StylePriority.UseTextAlignment = false;
            this.xrTableCell8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell8.Weight = 1D;
            // 
            // xrLabel12
            // 
            this.xrLabel12.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "validez", "{0:MM}")});
            this.xrLabel12.LocationFloat = new DevExpress.Utils.PointFloat(2.805523F, 8.350671F);
            this.xrLabel12.Name = "xrLabel12";
            this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel12.SizeF = new System.Drawing.SizeF(51F, 18F);
            this.xrLabel12.StyleName = "DataField";
            this.xrLabel12.Text = "xrLabel10";
            // 
            // xrTableCell9
            // 
            this.xrTableCell9.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell9.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel10});
            this.xrTableCell9.Name = "xrTableCell9";
            this.xrTableCell9.StylePriority.UseBorders = false;
            this.xrTableCell9.StylePriority.UseTextAlignment = false;
            this.xrTableCell9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell9.Weight = 1D;
            // 
            // xrLabel10
            // 
            this.xrLabel10.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "validez", "{0:yyyy}")});
            this.xrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(2.805523F, 8.350671F);
            this.xrLabel10.Name = "xrLabel10";
            this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel10.SizeF = new System.Drawing.SizeF(51F, 18F);
            this.xrLabel10.StyleName = "DataField";
            this.xrLabel10.Text = "xrLabel10";
            // 
            // xrTable4
            // 
            this.xrTable4.LocationFloat = new DevExpress.Utils.PointFloat(602.9699F, 306.8743F);
            this.xrTable4.Name = "xrTable4";
            this.xrTable4.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow4});
            this.xrTable4.SizeF = new System.Drawing.SizeF(198.4877F, 23F);
            // 
            // xrTableRow4
            // 
            this.xrTableRow4.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell10,
            this.xrTableCell11,
            this.xrTableCell12});
            this.xrTableRow4.Name = "xrTableRow4";
            this.xrTableRow4.Weight = 1D;
            // 
            // xrTableCell10
            // 
            this.xrTableCell10.BackColor = System.Drawing.Color.LightGray;
            this.xrTableCell10.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell10.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell10.Name = "xrTableCell10";
            this.xrTableCell10.StylePriority.UseBackColor = false;
            this.xrTableCell10.StylePriority.UseBorders = false;
            this.xrTableCell10.StylePriority.UseFont = false;
            this.xrTableCell10.StylePriority.UseTextAlignment = false;
            this.xrTableCell10.Text = "Día";
            this.xrTableCell10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell10.Weight = 1D;
            // 
            // xrTableCell11
            // 
            this.xrTableCell11.BackColor = System.Drawing.Color.LightGray;
            this.xrTableCell11.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell11.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell11.Name = "xrTableCell11";
            this.xrTableCell11.StylePriority.UseBackColor = false;
            this.xrTableCell11.StylePriority.UseBorders = false;
            this.xrTableCell11.StylePriority.UseFont = false;
            this.xrTableCell11.StylePriority.UseTextAlignment = false;
            this.xrTableCell11.Text = "Mes";
            this.xrTableCell11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell11.Weight = 1D;
            // 
            // xrTableCell12
            // 
            this.xrTableCell12.BackColor = System.Drawing.Color.LightGray;
            this.xrTableCell12.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell12.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell12.Name = "xrTableCell12";
            this.xrTableCell12.StylePriority.UseBackColor = false;
            this.xrTableCell12.StylePriority.UseBorders = false;
            this.xrTableCell12.StylePriority.UseFont = false;
            this.xrTableCell12.StylePriority.UseTextAlignment = false;
            this.xrTableCell12.Text = "Año";
            this.xrTableCell12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell12.Weight = 1D;
            // 
            // xrLabel58
            // 
            this.xrLabel58.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel58.LocationFloat = new DevExpress.Utils.PointFloat(530.8636F, 55.51667F);
            this.xrLabel58.Name = "xrLabel58";
            this.xrLabel58.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel58.SizeF = new System.Drawing.SizeF(263.5229F, 23F);
            this.xrLabel58.StylePriority.UseFont = false;
            this.xrLabel58.StylePriority.UseTextAlignment = false;
            this.xrLabel58.Text = "(Su empleo es personal e intransferible)";
            this.xrLabel58.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrCheckBox8
            // 
            this.xrCheckBox8.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrCheckBox8.LocationFloat = new DevExpress.Utils.PointFloat(707.0392F, 258.8999F);
            this.xrCheckBox8.Name = "xrCheckBox8";
            this.xrCheckBox8.SizeF = new System.Drawing.SizeF(54.94446F, 38.62497F);
            this.xrCheckBox8.StylePriority.UseFont = false;
            this.xrCheckBox8.StylePriority.UseTextAlignment = false;
            this.xrCheckBox8.Text = "NO";
            // 
            // xrCheckBox7
            // 
            this.xrCheckBox7.Checked = true;
            this.xrCheckBox7.CheckState = System.Windows.Forms.CheckState.Checked;
            this.xrCheckBox7.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrCheckBox7.LocationFloat = new DevExpress.Utils.PointFloat(655.816F, 258.8999F);
            this.xrCheckBox7.Name = "xrCheckBox7";
            this.xrCheckBox7.SizeF = new System.Drawing.SizeF(33.33337F, 38.62497F);
            this.xrCheckBox7.StylePriority.UseFont = false;
            this.xrCheckBox7.StylePriority.UseTextAlignment = false;
            this.xrCheckBox7.Text = "SI";
            // 
            // xrLabel57
            // 
            this.xrLabel57.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel57.LocationFloat = new DevExpress.Utils.PointFloat(413.4191F, 297.5249F);
            this.xrLabel57.Name = "xrLabel57";
            this.xrLabel57.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel57.SizeF = new System.Drawing.SizeF(186.8751F, 75.16666F);
            this.xrLabel57.StylePriority.UseFont = false;
            this.xrLabel57.StylePriority.UseTextAlignment = false;
            this.xrLabel57.Text = "Hasta la fecha definida por el representante administrativo para asegurar las fun" +
    "ciones o tareas asignadas al usuario.    ";
            this.xrLabel57.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleJustify;
            // 
            // checkMD
            // 
            this.checkMD.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkMD.LocationFloat = new DevExpress.Utils.PointFloat(604.8358F, 171.9F);
            this.checkMD.Name = "checkMD";
            this.checkMD.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.checkMD.SizeF = new System.Drawing.SizeF(177.0833F, 20F);
            this.checkMD.StylePriority.UseFont = false;
            this.checkMD.StylePriority.UseTextAlignment = false;
            this.checkMD.Text = " Medida Disciplinaria        ";
            // 
            // checkLSS
            // 
            this.checkLSS.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkLSS.LocationFloat = new DevExpress.Utils.PointFloat(604.8358F, 148.8999F);
            this.checkLSS.Name = "checkLSS";
            this.checkLSS.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.checkLSS.SizeF = new System.Drawing.SizeF(177.0833F, 20F);
            this.checkLSS.StylePriority.UseFont = false;
            this.checkLSS.StylePriority.UseTextAlignment = false;
            this.checkLSS.Text = " Licencia sin Sueldo                 ";
            // 
            // checkM
            // 
            this.checkM.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkM.LocationFloat = new DevExpress.Utils.PointFloat(604.8358F, 128.8916F);
            this.checkM.Name = "checkM";
            this.checkM.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.checkM.SizeF = new System.Drawing.SizeF(177.0833F, 20F);
            this.checkM.StylePriority.UseFont = false;
            this.checkM.StylePriority.UseTextAlignment = false;
            this.checkM.Text = " Movilización     ";
            // 
            // checkLM
            // 
            this.checkLM.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkLM.LocationFloat = new DevExpress.Utils.PointFloat(413.4191F, 168.8999F);
            this.checkLM.Name = "checkLM";
            this.checkLM.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.checkLM.SizeF = new System.Drawing.SizeF(177.0833F, 20F);
            this.checkLM.StylePriority.UseFont = false;
            this.checkLM.StylePriority.UseTextAlignment = false;
            this.checkLM.Text = " Licencia de Maternidad           ";
            // 
            // checkSE
            // 
            this.checkSE.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkSE.LocationFloat = new DevExpress.Utils.PointFloat(413.4191F, 148.8999F);
            this.checkSE.Name = "checkSE";
            this.checkSE.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.checkSE.SizeF = new System.Drawing.SizeF(177.0833F, 20F);
            this.checkSE.StylePriority.UseFont = false;
            this.checkSE.StylePriority.UseTextAlignment = false;
            this.checkSE.Text = " Exterior                 ";
            // 
            // checkCM
            // 
            this.checkCM.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkCM.LocationFloat = new DevExpress.Utils.PointFloat(413.4191F, 128.8916F);
            this.checkCM.Name = "checkCM";
            this.checkCM.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.checkCM.SizeF = new System.Drawing.SizeF(177.0833F, 20F);
            this.checkCM.StylePriority.UseFont = false;
            this.checkCM.StylePriority.UseTextAlignment = false;
            this.checkCM.Text = " Certificado Médico                   ";
            // 
            // xrLabel54
            // 
            this.xrLabel54.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel54.LocationFloat = new DevExpress.Utils.PointFloat(413.4191F, 101.5167F);
            this.xrLabel54.Name = "xrLabel54";
            this.xrLabel54.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel54.SizeF = new System.Drawing.SizeF(302.0833F, 23F);
            this.xrLabel54.StylePriority.UseFont = false;
            this.xrLabel54.StylePriority.UseTextAlignment = false;
            this.xrLabel54.Text = "Deshabilitar cuenta y servicios por:";
            this.xrLabel54.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel53
            // 
            this.xrLabel53.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel53.LocationFloat = new DevExpress.Utils.PointFloat(413.4191F, 78.51668F);
            this.xrLabel53.Name = "xrLabel53";
            this.xrLabel53.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel53.SizeF = new System.Drawing.SizeF(57.29169F, 22.99998F);
            this.xrLabel53.StylePriority.UseFont = false;
            this.xrLabel53.StylePriority.UseTextAlignment = false;
            this.xrLabel53.Text = "Usuario:";
            this.xrLabel53.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel52
            // 
            this.xrLabel52.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel52.LocationFloat = new DevExpress.Utils.PointFloat(413.4191F, 55.51667F);
            this.xrLabel52.Name = "xrLabel52";
            this.xrLabel52.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel52.SizeF = new System.Drawing.SizeF(117.4445F, 23F);
            this.xrLabel52.StylePriority.UseFont = false;
            this.xrLabel52.StylePriority.UseTextAlignment = false;
            this.xrLabel52.Text = "Usuario de Red";
            this.xrLabel52.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel51
            // 
            this.xrLabel51.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel51.LocationFloat = new DevExpress.Utils.PointFloat(413.4191F, 32.51669F);
            this.xrLabel51.Name = "xrLabel51";
            this.xrLabel51.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel51.SizeF = new System.Drawing.SizeF(177.0833F, 23F);
            this.xrLabel51.StylePriority.UseFont = false;
            this.xrLabel51.StylePriority.UseTextAlignment = false;
            this.xrLabel51.Text = "Solo para el Administrador";
            this.xrLabel51.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel13
            // 
            this.xrLabel13.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel13.LocationFloat = new DevExpress.Utils.PointFloat(416.2894F, 208.8999F);
            this.xrLabel13.Name = "xrLabel13";
            this.xrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel13.SizeF = new System.Drawing.SizeF(55.63885F, 23F);
            this.xrLabel13.StylePriority.UseFont = false;
            this.xrLabel13.StylePriority.UseTextAlignment = false;
            this.xrLabel13.Text = "Desde:";
            this.xrLabel13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel4
            // 
            this.xrLabel4.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "fechaInicio", "{0:dd/MM/yyyy}")});
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(481.5023F, 208.8999F);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(81F, 23F);
            this.xrLabel4.StyleName = "DataField";
            // 
            // xrLabel20
            // 
            this.xrLabel20.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel20.LocationFloat = new DevExpress.Utils.PointFloat(590.5718F, 208.8999F);
            this.xrLabel20.Name = "xrLabel20";
            this.xrLabel20.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel20.SizeF = new System.Drawing.SizeF(55.63885F, 23F);
            this.xrLabel20.StylePriority.UseFont = false;
            this.xrLabel20.StylePriority.UseTextAlignment = false;
            this.xrLabel20.Text = "Hasta:";
            this.xrLabel20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel5
            // 
            this.xrLabel5.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "fechaFin", "{0:dd/MM/yyyy}")});
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(657.1287F, 208.8999F);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(78.1665F, 23.00015F);
            this.xrLabel5.StyleName = "DataField";
            // 
            // xrLabel15
            // 
            this.xrLabel15.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "nombre_usuario")});
            this.xrLabel15.LocationFloat = new DevExpress.Utils.PointFloat(481.5023F, 80.51667F);
            this.xrLabel15.Name = "xrLabel15";
            this.xrLabel15.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel15.SizeF = new System.Drawing.SizeF(269.9444F, 18F);
            this.xrLabel15.StyleName = "DataField";
            this.xrLabel15.Text = "xrLabel15";
            // 
            // xrShape2
            // 
            this.xrShape2.BorderWidth = 2F;
            this.xrShape2.LineWidth = 2;
            this.xrShape2.LocationFloat = new DevExpress.Utils.PointFloat(408.9608F, 27.10003F);
            this.xrShape2.Name = "xrShape2";
            this.xrShape2.Shape = shapeRectangle2;
            this.xrShape2.SizeF = new System.Drawing.SizeF(396.8283F, 345.5916F);
            this.xrShape2.StylePriority.UseBorderWidth = false;
            // 
            // xrLabel17
            // 
            this.xrLabel17.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "rolpc")});
            this.xrLabel17.LocationFloat = new DevExpress.Utils.PointFloat(756.3864F, 80.51667F);
            this.xrLabel17.Name = "xrLabel17";
            this.xrLabel17.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel17.SizeF = new System.Drawing.SizeF(38F, 18F);
            this.xrLabel17.StyleName = "DataField";
            this.xrLabel17.Text = "xrLabel17";
            this.xrLabel17.Visible = false;
            // 
            // xrLabel9
            // 
            this.xrLabel9.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "tipoSolic")});
            this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(727.3865F, 106.5166F);
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel9.SizeF = new System.Drawing.SizeF(67F, 18F);
            this.xrLabel9.StyleName = "DataField";
            this.xrLabel9.Text = "xrLabel9";
            this.xrLabel9.Visible = false;
            // 
            // xrLabel16
            // 
            this.xrLabel16.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "tpersonal")});
            this.xrLabel16.LocationFloat = new DevExpress.Utils.PointFloat(229.5491F, 150.8999F);
            this.xrLabel16.Name = "xrLabel16";
            this.xrLabel16.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel16.SizeF = new System.Drawing.SizeF(67F, 18F);
            this.xrLabel16.StyleName = "DataField";
            this.xrLabel16.Text = "xrLabel16";
            this.xrLabel16.Visible = false;
            // 
            // xrLabel18
            // 
            this.xrLabel18.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "servicios")});
            this.xrLabel18.LocationFloat = new DevExpress.Utils.PointFloat(740.7891F, 208.8999F);
            this.xrLabel18.Name = "xrLabel18";
            this.xrLabel18.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel18.SizeF = new System.Drawing.SizeF(65F, 18F);
            this.xrLabel18.StyleName = "DataField";
            this.xrLabel18.Text = "xrLabel18";
            this.xrLabel18.Visible = false;
            // 
            // xrLabel6
            // 
            this.xrLabel6.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "razonDesh")});
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(300.7869F, 150.8999F);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(79F, 18F);
            this.xrLabel6.StyleName = "DataField";
            this.xrLabel6.Text = "xrLabel6";
            this.xrLabel6.Visible = false;
            // 
            // xrLabel11
            // 
            this.xrLabel11.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "validez")});
            this.xrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(161.9583F, 150.8999F);
            this.xrLabel11.Name = "xrLabel11";
            this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel11.SizeF = new System.Drawing.SizeF(51F, 18F);
            this.xrLabel11.StyleName = "DataField";
            this.xrLabel11.Visible = false;
            // 
            // DatosServicios
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.reportHeaderBand1});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.objectDataSource1});
            this.DataSource = this.objectDataSource1;
            this.Margins = new System.Drawing.Printing.Margins(11, 22, 23, 0);
            this.StyleSheet.AddRange(new DevExpress.XtraReports.UI.XRControlStyle[] {
            this.Title,
            this.FieldCaption,
            this.PageInfo,
            this.DataField});
            this.Version = "17.1";
            ((System.ComponentModel.ISupportInitialize)(this.objectDataSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
