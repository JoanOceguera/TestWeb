using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Model;
using DevExpress.DataAccess.ObjectBinding;
using System.Collections.Generic;
using DevExpress.XtraReports.Design;
using Model.Entities;

/// <summary>
/// Summary description for Planilla
/// </summary>
public class Planilla : DevExpress.XtraReports.UI.XtraReport
{
    private ServiciosEntities servData = new ServiciosEntities();

    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private DevExpress.DataAccess.ObjectBinding.ObjectDataSource objectDataSource;
    private XRLabel xrLabel4;
    private XRLabel xrLabel5;
    private XRLabel xrLabel6;
    private XRLabel xrLabel9;
    private XRLabel xrLabel10;
    private XRLabel xrLabel15;
    private XRLabel xrLabel16;
    private XRLabel xrLabel17;
    private XRLabel xrLabel18;
    private GroupHeaderBand PaginaPrincipal;
    private XRLabel xrLabel26;
    private XRLabel xrLabel27;
    private XRLabel xrLabel28;
    private XRLabel xrLabel32;
    private XRLabel xrLabel33;
    private XRLabel xrLabel34;
    private XRControlStyle Title;
    private XRControlStyle FieldCaption;
    private XRControlStyle PageInfo;
    private XRControlStyle DataField;
    private DevExpress.XtraBars.Ribbon.RadialMenu radialMenu1;
    private XRLabel xrLabel55;
    private XRShape xrShape4;
    private XRLabel xrLabel35;
    private XRLine xrLine2;
    private XRTableCell xrTableCell9;
    private XRTableCell xrTableCell8;
    private XRTableCell xrTableCell7;
    private XRTableRow xrTableRow3;
    private XRTable xrTable3;
    private XRTableCell xrTableCell12;
    private XRTableCell xrTableCell11;
    private XRTableCell xrTableCell10;
    private XRTableRow xrTableRow4;
    private XRTable xrTable4;
    private XRLabel xrLabel58;
    private XRCheckBox xrCheckBox8;
    private XRCheckBox xrCheckBox7;
    private XRLabel xrLabel57;
    private XRLabel xrLabel56;
    private XRShape xrShape2;
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
    private XRCheckBox checkRenovacion;
    private XRCheckBox checkModificacion;
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
    private XRCheckBox checkDirigente;
    private XRLine xrLine1;
    private XRLabel LabelPersonal;
    private XRLabel LabelRol;
    private XRLabel labelServicios;
    private XRLine xrLine3;
    private XRLabel xrLabel40;
    private XRLabel xrLabel41;
    private XRLabel xrLabel44;
    private XRLabel xrLabel43;
    private XRLabel xrLabel42;
    private XRLabel xrLabel39;
    private XRLabel xrLabel38;
    private XRLabel xrLabel37;
    private XRLabel xrLabel45;
    private XRLabel xrLabel48;
    private XRPageInfo xrPageInfo2;
    private XRLabel xrLabel36;
    private XRShape xrShape3;
    private XRShape xrShape5;
    private XRLine xrLine4;
    private XRLabel xrLabel14;
    private XRLabel xrLabel1;
    private XRLabel xrLabel2;
    private XRLabel xrLabel3;
    private XRLabel xrLabel7;
    private XRLabel xrLabel8;
    private XRLabel xrLabel19;
    private XRLine xrLine6;
    private XRLine xrLine10;
    private XRLine xrLine9;
    private XRLine xrLine5;
    private XRLabel xrLabel20;
    private XRLabel xrLabel13;
    private XRLabel xrLabel12;
    private XRLabel xrLabel11;
    private XRShape xrShape1;
    private XRLabel xrLabel21;
    private XRPageInfo xrPageInfo1;
    private XRCheckBox checkO;
    private XRPictureBox xrPictureBox1;
    private XRLabel xrLabel49;
    private ReportHeaderBand reportHeaderBand1;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public Planilla()
    {
        InitializeComponent();
        this.objectDataSource.DataSource = new List<PlanillaViewModel>() { new PlanillaViewModel() };
        addElement();
        //
        // TODO: Add constructor logic here
        //
    }

    public Planilla(PlanillaViewModel model)
    {
        InitializeComponent();
        this.objectDataSource.DataSource = new List<PlanillaViewModel>() { model };
        addElement();

    }

    protected void addElement()
    {
        var x = 170.42f;
        var y = 190.08F;
        var datasource = this.objectDataSource.DataSource;
        var model = ((List<PlanillaViewModel>)datasource)[0];
        foreach (var item in servData.Servicios)
        {
            XRCheckBox checkS = new XRCheckBox();
            XRCheckBox checkN = new XRCheckBox();
            XRLabel labelServ = new XRLabel();
            string[] servicio_nombre = item.nombre.Split(' ');
            if (servicio_nombre.Length > 1)
            {
                checkS.Name = "check" + servicio_nombre[0] + servicio_nombre[1].ToCharArray()[0] + "S";
                checkN.Name = "check" + servicio_nombre[0] + servicio_nombre[1].ToCharArray()[0] + "N";
                labelServ.Name = "label" + servicio_nombre[0] + servicio_nombre[1].ToCharArray()[0];
            }
            else
            {
                checkS.Name = "check" + servicio_nombre[0] + "S";
                checkN.Name = "check" + servicio_nombre[0] + "N";
                labelServ.Name = "label" + servicio_nombre[0];
            }
            checkS.LocationFloat = new DevExpress.Utils.PointFloat(x, y);
            checkS.SizeF = new System.Drawing.SizeF(15F, 20F);

            

            if (model.servicios.ContainsKey(item.id))
            {
                checkS.Checked = true;
                checkS.CheckState = System.Windows.Forms.CheckState.Checked;
            }
            else
            {
                checkN.Checked = true;
                checkN.CheckState = System.Windows.Forms.CheckState.Checked;
            }
            
            checkN.LocationFloat = new DevExpress.Utils.PointFloat(x + 29, y);
            checkN.SizeF = new System.Drawing.SizeF(15F, 20F);

            labelServ.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            labelServ.LocationFloat = new DevExpress.Utils.PointFloat(x + 54, y+2);
            labelServ.Name = "labelNavegacionN";
            labelServ.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            labelServ.SizeF = new System.Drawing.SizeF(181F, 16F);
            labelServ.StylePriority.UseFont = false;
            labelServ.Text = item.nombre;

            this.xrShape4.Band.Controls.Add(checkS);
            this.xrShape4.Band.Controls.Add(checkN);
            this.xrShape4.Band.Controls.Add(labelServ);
            y = y + 18f;
        }

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
        switch (xrLabel6.Text)
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
            case "md":
                checkMD.Checked = true;
                break;
            case "o":
                checkO.Checked = true;
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
            DevExpress.XtraPrinting.Shape.ShapeRectangle shapeRectangle3 = new DevExpress.XtraPrinting.Shape.ShapeRectangle();
            DevExpress.XtraPrinting.Shape.ShapeRectangle shapeRectangle4 = new DevExpress.XtraPrinting.Shape.ShapeRectangle();
            DevExpress.XtraPrinting.Shape.ShapeRectangle shapeRectangle5 = new DevExpress.XtraPrinting.Shape.ShapeRectangle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Planilla));
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.objectDataSource = new DevExpress.DataAccess.ObjectBinding.ObjectDataSource(this.components);
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel15 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel16 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel17 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel18 = new DevExpress.XtraReports.UI.XRLabel();
            this.PaginaPrincipal = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrShape2 = new DevExpress.XtraReports.UI.XRShape();
            this.xrShape3 = new DevExpress.XtraReports.UI.XRShape();
            this.xrShape1 = new DevExpress.XtraReports.UI.XRShape();
            this.xrShape4 = new DevExpress.XtraReports.UI.XRShape();
            this.checkO = new DevExpress.XtraReports.UI.XRCheckBox();
            this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel28 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel42 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel27 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel34 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel33 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel26 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel32 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel20 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPageInfo2 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrLabel48 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel45 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel38 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine3 = new DevExpress.XtraReports.UI.XRLine();
            this.labelServicios = new DevExpress.XtraReports.UI.XRLabel();
            this.LabelRol = new DevExpress.XtraReports.UI.XRLabel();
            this.LabelPersonal = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.checkDirigente = new DevExpress.XtraReports.UI.XRCheckBox();
            this.labelCheckS = new DevExpress.XtraReports.UI.XRLabel();
            this.labelCheckN = new DevExpress.XtraReports.UI.XRLabel();
            this.checkEspecialista = new DevExpress.XtraReports.UI.XRCheckBox();
            this.checkTecnico = new DevExpress.XtraReports.UI.XRCheckBox();
            this.checkOtros = new DevExpress.XtraReports.UI.XRCheckBox();
            this.checkUsuario = new DevExpress.XtraReports.UI.XRCheckBox();
            this.checkUsuarioA = new DevExpress.XtraReports.UI.XRCheckBox();
            this.checkAdministrador = new DevExpress.XtraReports.UI.XRCheckBox();
            this.xrLabel72 = new DevExpress.XtraReports.UI.XRLabel();
            this.checkCreacion = new DevExpress.XtraReports.UI.XRCheckBox();
            this.checkRenovacion = new DevExpress.XtraReports.UI.XRCheckBox();
            this.xrLabel51 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel52 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel53 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel54 = new DevExpress.XtraReports.UI.XRLabel();
            this.checkCM = new DevExpress.XtraReports.UI.XRCheckBox();
            this.checkSE = new DevExpress.XtraReports.UI.XRCheckBox();
            this.checkLM = new DevExpress.XtraReports.UI.XRCheckBox();
            this.checkM = new DevExpress.XtraReports.UI.XRCheckBox();
            this.checkLSS = new DevExpress.XtraReports.UI.XRCheckBox();
            this.checkMD = new DevExpress.XtraReports.UI.XRCheckBox();
            this.xrLabel57 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrCheckBox7 = new DevExpress.XtraReports.UI.XRCheckBox();
            this.xrCheckBox8 = new DevExpress.XtraReports.UI.XRCheckBox();
            this.xrLabel58 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrTable4 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow4 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell10 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell11 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell12 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable3 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrLabel21 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrTableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrLine2 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel35 = new DevExpress.XtraReports.UI.XRLabel();
            this.checkModificacion = new DevExpress.XtraReports.UI.XRCheckBox();
            this.xrLine5 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLine10 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLine9 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLine4 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel19 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine6 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel55 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel56 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel44 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel43 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel37 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrLabel40 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrShape5 = new DevExpress.XtraReports.UI.XRShape();
            this.xrLabel41 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel36 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel39 = new DevExpress.XtraReports.UI.XRLabel();
            this.Title = new DevExpress.XtraReports.UI.XRControlStyle();
            this.FieldCaption = new DevExpress.XtraReports.UI.XRControlStyle();
            this.PageInfo = new DevExpress.XtraReports.UI.XRControlStyle();
            this.DataField = new DevExpress.XtraReports.UI.XRControlStyle();
            this.radialMenu1 = new DevExpress.XtraBars.Ribbon.RadialMenu(this.components);
            this.xrPictureBox1 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.xrLabel49 = new DevExpress.XtraReports.UI.XRLabel();
            this.reportHeaderBand1 = new DevExpress.XtraReports.UI.ReportHeaderBand();
            ((System.ComponentModel.ISupportInitialize)(this.objectDataSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radialMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.HeightF = 20F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.StyleName = "DataField";
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 0F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.HeightF = 11F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // objectDataSource
            // 
            this.objectDataSource.DataSource = typeof(Model.PlanillaViewModel);
            this.objectDataSource.Name = "objectDataSource";
            // 
            // xrLabel4
            // 
            this.xrLabel4.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "fechaInicio", "{0:dd/MM/yyyy}")});
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(487.023F, 347.0699F);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(81F, 23F);
            this.xrLabel4.StyleName = "DataField";
            // 
            // xrLabel5
            // 
            this.xrLabel5.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "fechaFin", "{0:dd/MM/yyyy}")});
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(662.6493F, 347.0697F);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(78.1665F, 23.00015F);
            this.xrLabel5.StyleName = "DataField";
            // 
            // xrLabel6
            // 
            this.xrLabel6.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "razonDesh")});
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(343.0196F, 812.1201F);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(79F, 18F);
            this.xrLabel6.StyleName = "DataField";
            this.xrLabel6.Text = "xrLabel6";
            this.xrLabel6.Visible = false;
            this.xrLabel6.TextChanged += new System.EventHandler(this.xrLabel6_TextChanged);
            // 
            // xrLabel9
            // 
            this.xrLabel9.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "tipoSolic")});
            this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(259.3073F, 812.1201F);
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel9.SizeF = new System.Drawing.SizeF(67F, 18F);
            this.xrLabel9.StyleName = "DataField";
            this.xrLabel9.Text = "xrLabel9";
            this.xrLabel9.Visible = false;
            this.xrLabel9.TextChanged += new System.EventHandler(this.xrLabel9_TextChanged);
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
            // xrLabel15
            // 
            this.xrLabel15.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "nombre_usuario")});
            this.xrLabel15.LocationFloat = new DevExpress.Utils.PointFloat(487.023F, 214.6908F);
            this.xrLabel15.Name = "xrLabel15";
            this.xrLabel15.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel15.SizeF = new System.Drawing.SizeF(269.9444F, 18F);
            this.xrLabel15.StyleName = "DataField";
            this.xrLabel15.Text = "xrLabel15";
            // 
            // xrLabel16
            // 
            this.xrLabel16.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "tpersonal")});
            this.xrLabel16.LocationFloat = new DevExpress.Utils.PointFloat(13.73131F, 812.1201F);
            this.xrLabel16.Name = "xrLabel16";
            this.xrLabel16.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel16.SizeF = new System.Drawing.SizeF(67F, 18F);
            this.xrLabel16.StyleName = "DataField";
            this.xrLabel16.Visible = false;
            this.xrLabel16.TextChanged += new System.EventHandler(this.xrLabel16_TextChanged);
            // 
            // xrLabel17
            // 
            this.xrLabel17.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "rolpc")});
            this.xrLabel17.LocationFloat = new DevExpress.Utils.PointFloat(201.0462F, 812.1201F);
            this.xrLabel17.Name = "xrLabel17";
            this.xrLabel17.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel17.SizeF = new System.Drawing.SizeF(38F, 18F);
            this.xrLabel17.StyleName = "DataField";
            this.xrLabel17.Text = "xrLabel17";
            this.xrLabel17.Visible = false;
            this.xrLabel17.TextChanged += new System.EventHandler(this.XrLabel17_TextChanged);
            // 
            // xrLabel18
            // 
            this.xrLabel18.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "servicios")});
            this.xrLabel18.LocationFloat = new DevExpress.Utils.PointFloat(100.1995F, 812.1201F);
            this.xrLabel18.Name = "xrLabel18";
            this.xrLabel18.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel18.SizeF = new System.Drawing.SizeF(65F, 18F);
            this.xrLabel18.StyleName = "DataField";
            this.xrLabel18.Text = "xrLabel18";
            this.xrLabel18.Visible = false;
            // 
            // PaginaPrincipal
            // 
            this.PaginaPrincipal.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrShape2,
            this.xrShape3,
            this.xrShape1,
            this.xrShape4,
            this.checkO,
            this.xrLabel11,
            this.xrLabel6,
            this.xrLabel28,
            this.xrLabel18,
            this.xrLabel16,
            this.xrLabel9,
            this.xrLabel17,
            this.xrLabel42,
            this.xrLabel27,
            this.xrLabel34,
            this.xrLabel33,
            this.xrLabel26,
            this.xrLabel32,
            this.xrLabel15,
            this.xrLabel5,
            this.xrLabel20,
            this.xrLabel4,
            this.xrLabel13,
            this.xrPageInfo2,
            this.xrLabel48,
            this.xrLabel45,
            this.xrLabel38,
            this.xrLine3,
            this.labelServicios,
            this.LabelRol,
            this.LabelPersonal,
            this.xrLine1,
            this.checkDirigente,
            this.labelCheckS,
            this.labelCheckN,
            this.checkEspecialista,
            this.checkTecnico,
            this.checkOtros,
            this.checkUsuario,
            this.checkUsuarioA,
            this.checkAdministrador,
            this.xrLabel72,
            this.checkCreacion,
            this.checkRenovacion,
            this.xrLabel51,
            this.xrLabel52,
            this.xrLabel53,
            this.xrLabel54,
            this.checkCM,
            this.checkSE,
            this.checkLM,
            this.checkM,
            this.checkLSS,
            this.checkMD,
            this.xrLabel57,
            this.xrCheckBox7,
            this.xrCheckBox8,
            this.xrLabel58,
            this.xrTable4,
            this.xrTable3,
            this.xrLine2,
            this.xrLabel35,
            this.checkModificacion,
            this.xrLine5,
            this.xrLine10,
            this.xrLine9,
            this.xrLine4,
            this.xrLabel14,
            this.xrLabel1,
            this.xrLabel2,
            this.xrLabel3,
            this.xrLabel7,
            this.xrLabel8,
            this.xrLabel19,
            this.xrLine6,
            this.xrLabel55,
            this.xrLabel56,
            this.xrLabel44,
            this.xrLabel43,
            this.xrLabel37,
            this.xrPageInfo1,
            this.xrLabel40,
            this.xrShape5,
            this.xrLabel41,
            this.xrLabel36,
            this.xrLabel39});
            this.PaginaPrincipal.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("exp", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending),
            new DevExpress.XtraReports.UI.GroupField("cargo_benef", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending),
            new DevExpress.XtraReports.UI.GroupField("area", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.PaginaPrincipal.HeightF = 840.1201F;
            this.PaginaPrincipal.Name = "PaginaPrincipal";
            // 
            // xrShape2
            // 
            this.xrShape2.BorderWidth = 2F;
            this.xrShape2.LineWidth = 2;
            this.xrShape2.LocationFloat = new DevExpress.Utils.PointFloat(414.4815F, 161.2741F);
            this.xrShape2.Name = "xrShape2";
            this.xrShape2.Shape = shapeRectangle1;
            this.xrShape2.SizeF = new System.Drawing.SizeF(396.8283F, 345.5916F);
            this.xrShape2.StylePriority.UseBorderWidth = false;
            // 
            // xrShape3
            // 
            this.xrShape3.LineWidth = 2;
            this.xrShape3.LocationFloat = new DevExpress.Utils.PointFloat(11.46298F, 518.8871F);
            this.xrShape3.Name = "xrShape3";
            this.xrShape3.Shape = shapeRectangle2;
            this.xrShape3.SizeF = new System.Drawing.SizeF(798F, 282.08F);
            // 
            // xrShape1
            // 
            this.xrShape1.LineWidth = 2;
            this.xrShape1.LocationFloat = new DevExpress.Utils.PointFloat(407.4998F, 518.8899F);
            this.xrShape1.Name = "xrShape1";
            this.xrShape1.Shape = shapeRectangle3;
            this.xrShape1.SizeF = new System.Drawing.SizeF(402.0002F, 282.0757F);
            // 
            // xrShape4
            // 
            this.xrShape4.BorderWidth = 2F;
            this.xrShape4.LineWidth = 2;
            this.xrShape4.LocationFloat = new DevExpress.Utils.PointFloat(13.73131F, 161.2741F);
            this.xrShape4.Name = "xrShape4";
            this.xrShape4.Shape = shapeRectangle4;
            this.xrShape4.SizeF = new System.Drawing.SizeF(393.75F, 345.5916F);
            this.xrShape4.StylePriority.UseBorderWidth = false;
            // 
            // checkO
            // 
            this.checkO.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkO.LocationFloat = new DevExpress.Utils.PointFloat(418.9397F, 328.1575F);
            this.checkO.Name = "checkO";
            this.checkO.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.checkO.SizeF = new System.Drawing.SizeF(177.0834F, 14.91647F);
            this.checkO.StylePriority.UseFont = false;
            this.checkO.StylePriority.UseTextAlignment = false;
            this.checkO.Text = "Otros";
            // 
            // xrLabel11
            // 
            this.xrLabel11.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "validez")});
            this.xrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(451.2412F, 812.1201F);
            this.xrLabel11.Name = "xrLabel11";
            this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel11.SizeF = new System.Drawing.SizeF(51F, 18F);
            this.xrLabel11.StyleName = "DataField";
            this.xrLabel11.Visible = false;
            this.xrLabel11.TextChanged += new System.EventHandler(this.XrLabel11_TextChanged);
            // 
            // xrLabel28
            // 
            this.xrLabel28.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "area")});
            this.xrLabel28.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.xrLabel28.LocationFloat = new DevExpress.Utils.PointFloat(541.5002F, 85.74838F);
            this.xrLabel28.Name = "xrLabel28";
            this.xrLabel28.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel28.SizeF = new System.Drawing.SizeF(253.3529F, 17.99994F);
            this.xrLabel28.StyleName = "DataField";
            this.xrLabel28.StylePriority.UseFont = false;
            this.xrLabel28.Text = "xrLabel28";
            // 
            // xrLabel42
            // 
            this.xrLabel42.BackColor = System.Drawing.Color.LightGray;
            this.xrLabel42.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel42.BorderWidth = 1F;
            this.xrLabel42.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel42.LocationFloat = new DevExpress.Utils.PointFloat(408.963F, 518.8871F);
            this.xrLabel42.Name = "xrLabel42";
            this.xrLabel42.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel42.SizeF = new System.Drawing.SizeF(398F, 23F);
            this.xrLabel42.StylePriority.UseBackColor = false;
            this.xrLabel42.StylePriority.UseBorders = false;
            this.xrLabel42.StylePriority.UseBorderWidth = false;
            this.xrLabel42.StylePriority.UseFont = false;
            this.xrLabel42.StylePriority.UseTextAlignment = false;
            this.xrLabel42.Text = "Dirigente que solicita";
            this.xrLabel42.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel27
            // 
            this.xrLabel27.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "cargo_benef")});
            this.xrLabel27.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.xrLabel27.LocationFloat = new DevExpress.Utils.PointFloat(19.96313F, 85.74832F);
            this.xrLabel27.Name = "xrLabel27";
            this.xrLabel27.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel27.SizeF = new System.Drawing.SizeF(479.6436F, 37.83258F);
            this.xrLabel27.StyleName = "DataField";
            this.xrLabel27.StylePriority.UseFont = false;
            this.xrLabel27.Text = "xrLabel27";
            // 
            // xrLabel34
            // 
            this.xrLabel34.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "apellido2_benef")});
            this.xrLabel34.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.xrLabel34.LocationFloat = new DevExpress.Utils.PointFloat(358.0744F, 40.91668F);
            this.xrLabel34.Name = "xrLabel34";
            this.xrLabel34.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel34.SizeF = new System.Drawing.SizeF(144.1668F, 18F);
            this.xrLabel34.StyleName = "DataField";
            this.xrLabel34.StylePriority.UseFont = false;
            this.xrLabel34.Text = "xrLabel34";
            // 
            // xrLabel33
            // 
            this.xrLabel33.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "apellido1_benef")});
            this.xrLabel33.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.xrLabel33.LocationFloat = new DevExpress.Utils.PointFloat(171.9215F, 40.91668F);
            this.xrLabel33.Name = "xrLabel33";
            this.xrLabel33.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel33.SizeF = new System.Drawing.SizeF(144.1746F, 18F);
            this.xrLabel33.StyleName = "DataField";
            this.xrLabel33.StylePriority.UseFont = false;
            this.xrLabel33.Text = "xrLabel33";
            // 
            // xrLabel26
            // 
            this.xrLabel26.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "exp")});
            this.xrLabel26.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.xrLabel26.LocationFloat = new DevExpress.Utils.PointFloat(19.96313F, 40.70834F);
            this.xrLabel26.Name = "xrLabel26";
            this.xrLabel26.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel26.SizeF = new System.Drawing.SizeF(42.58334F, 18F);
            this.xrLabel26.StyleName = "DataField";
            this.xrLabel26.StylePriority.UseFont = false;
            this.xrLabel26.Text = "xrLabel26";
            // 
            // xrLabel32
            // 
            this.xrLabel32.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "nombre_benef")});
            this.xrLabel32.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.xrLabel32.LocationFloat = new DevExpress.Utils.PointFloat(540.1068F, 40.91668F);
            this.xrLabel32.Name = "xrLabel32";
            this.xrLabel32.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel32.SizeF = new System.Drawing.SizeF(247.5649F, 18F);
            this.xrLabel32.StyleName = "DataField";
            this.xrLabel32.StylePriority.UseFont = false;
            this.xrLabel32.Text = "Nombre";
            // 
            // xrLabel20
            // 
            this.xrLabel20.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel20.LocationFloat = new DevExpress.Utils.PointFloat(596.0925F, 343.074F);
            this.xrLabel20.Name = "xrLabel20";
            this.xrLabel20.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel20.SizeF = new System.Drawing.SizeF(55.63885F, 23F);
            this.xrLabel20.StylePriority.UseFont = false;
            this.xrLabel20.StylePriority.UseTextAlignment = false;
            this.xrLabel20.Text = "Hasta:";
            this.xrLabel20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel13
            // 
            this.xrLabel13.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel13.LocationFloat = new DevExpress.Utils.PointFloat(421.81F, 343.074F);
            this.xrLabel13.Name = "xrLabel13";
            this.xrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel13.SizeF = new System.Drawing.SizeF(55.63885F, 23F);
            this.xrLabel13.StylePriority.UseFont = false;
            this.xrLabel13.StylePriority.UseTextAlignment = false;
            this.xrLabel13.Text = "Desde:";
            this.xrLabel13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrPageInfo2
            // 
            this.xrPageInfo2.Font = new System.Drawing.Font("Arial", 9.75F);
            this.xrPageInfo2.Format = "{0:dd/MM/yyyy}";
            this.xrPageInfo2.LocationFloat = new DevExpress.Utils.PointFloat(408.963F, 628.6523F);
            this.xrPageInfo2.Name = "xrPageInfo2";
            this.xrPageInfo2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo2.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.xrPageInfo2.SizeF = new System.Drawing.SizeF(77.07217F, 23F);
            this.xrPageInfo2.StylePriority.UseFont = false;
            // 
            // xrLabel48
            // 
            this.xrLabel48.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "cargo_solic")});
            this.xrLabel48.Font = new System.Drawing.Font("Arial", 9.75F);
            this.xrLabel48.LocationFloat = new DevExpress.Utils.PointFloat(544.2F, 575.62F);
            this.xrLabel48.Name = "xrLabel48";
            this.xrLabel48.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel48.SizeF = new System.Drawing.SizeF(250.4258F, 18F);
            this.xrLabel48.StylePriority.UseFont = false;
            this.xrLabel48.Text = "xrLabel22";
            // 
            // xrLabel45
            // 
            this.xrLabel45.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "nombre_solic")});
            this.xrLabel45.Font = new System.Drawing.Font("Arial", 9.75F);
            this.xrLabel45.LocationFloat = new DevExpress.Utils.PointFloat(543.96F, 545.89F);
            this.xrLabel45.Name = "xrLabel45";
            this.xrLabel45.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel45.SizeF = new System.Drawing.SizeF(250.4258F, 18F);
            this.xrLabel45.StylePriority.UseFont = false;
            this.xrLabel45.Text = "xrLabel21";
            // 
            // xrLabel38
            // 
            this.xrLabel38.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel38.BorderWidth = 1F;
            this.xrLabel38.Font = new System.Drawing.Font("Arial", 9.75F);
            this.xrLabel38.LocationFloat = new DevExpress.Utils.PointFloat(408.963F, 674.6523F);
            this.xrLabel38.Name = "xrLabel38";
            this.xrLabel38.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel38.SizeF = new System.Drawing.SizeF(393F, 47.83F);
            this.xrLabel38.StylePriority.UseBorders = false;
            this.xrLabel38.StylePriority.UseBorderWidth = false;
            this.xrLabel38.StylePriority.UseFont = false;
            this.xrLabel38.Text = "Firma y Fecha";
            // 
            // xrLine3
            // 
            this.xrLine3.LineDirection = DevExpress.XtraReports.UI.LineDirection.Vertical;
            this.xrLine3.LineWidth = 2;
            this.xrLine3.LocationFloat = new DevExpress.Utils.PointFloat(147.3979F, 161.2741F);
            this.xrLine3.Name = "xrLine3";
            this.xrLine3.SizeF = new System.Drawing.SizeF(22.79F, 185F);
            // 
            // labelServicios
            // 
            this.labelServicios.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelServicios.LocationFloat = new DevExpress.Utils.PointFloat(226.4814F, 171.6907F);
            this.labelServicios.Name = "labelServicios";
            this.labelServicios.SizeF = new System.Drawing.SizeF(162F, 18F);
            this.labelServicios.StylePriority.UseFont = false;
            this.labelServicios.Text = "Tipo de Servicios";
            // 
            // LabelRol
            // 
            this.LabelRol.LocationFloat = new DevExpress.Utils.PointFloat(19.73132F, 283.074F);
            this.LabelRol.Name = "LabelRol";
            this.LabelRol.SizeF = new System.Drawing.SizeF(125.5417F, 18F);
            this.LabelRol.Text = "Roles en la PC";
            // 
            // LabelPersonal
            // 
            this.LabelPersonal.LocationFloat = new DevExpress.Utils.PointFloat(19.73132F, 171.6907F);
            this.LabelPersonal.Name = "LabelPersonal";
            this.LabelPersonal.SizeF = new System.Drawing.SizeF(125.5417F, 18F);
            this.LabelPersonal.Text = "Tipo de Personal";
            // 
            // xrLine1
            // 
            this.xrLine1.LineWidth = 2;
            this.xrLine1.LocationFloat = new DevExpress.Utils.PointFloat(158.523F, 320.9906F);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.SizeF = new System.Drawing.SizeF(247.4601F, 42.08005F);
            // 
            // checkDirigente
            // 
            this.checkDirigente.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkDirigente.LocationFloat = new DevExpress.Utils.PointFloat(19.73132F, 192.6908F);
            this.checkDirigente.Name = "checkDirigente";
            this.checkDirigente.SizeF = new System.Drawing.SizeF(104.7917F, 20F);
            this.checkDirigente.StylePriority.UseFont = false;
            this.checkDirigente.StylePriority.UseTextAlignment = false;
            this.checkDirigente.Text = " Dirigente";
            // 
            // labelCheckS
            // 
            this.labelCheckS.AutoWidth = true;
            this.labelCheckS.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCheckS.LocationFloat = new DevExpress.Utils.PointFloat(170.1896F, 171.6908F);
            this.labelCheckS.Name = "labelCheckS";
            this.labelCheckS.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelCheckS.SizeF = new System.Drawing.SizeF(20F, 20F);
            this.labelCheckS.StylePriority.UseFont = false;
            this.labelCheckS.Text = "SI";
            // 
            // labelCheckN
            // 
            this.labelCheckN.AutoWidth = true;
            this.labelCheckN.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCheckN.LocationFloat = new DevExpress.Utils.PointFloat(196.1897F, 171.6907F);
            this.labelCheckN.Name = "labelCheckN";
            this.labelCheckN.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelCheckN.SizeF = new System.Drawing.SizeF(25F, 20F);
            this.labelCheckN.StylePriority.UseFont = false;
            this.labelCheckN.Text = "NO";
            // 
            // checkEspecialista
            // 
            this.checkEspecialista.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkEspecialista.LocationFloat = new DevExpress.Utils.PointFloat(19.73132F, 212.6908F);
            this.checkEspecialista.Name = "checkEspecialista";
            this.checkEspecialista.SizeF = new System.Drawing.SizeF(104.7917F, 20F);
            this.checkEspecialista.StylePriority.UseFont = false;
            this.checkEspecialista.Text = " Especialista";
            // 
            // checkTecnico
            // 
            this.checkTecnico.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkTecnico.LocationFloat = new DevExpress.Utils.PointFloat(19.73132F, 232.6908F);
            this.checkTecnico.Name = "checkTecnico";
            this.checkTecnico.SizeF = new System.Drawing.SizeF(104.7917F, 20F);
            this.checkTecnico.StylePriority.UseFont = false;
            this.checkTecnico.Text = " Técnico";
            // 
            // checkOtros
            // 
            this.checkOtros.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkOtros.LocationFloat = new DevExpress.Utils.PointFloat(19.73132F, 252.6908F);
            this.checkOtros.Name = "checkOtros";
            this.checkOtros.SizeF = new System.Drawing.SizeF(104.7917F, 20F);
            this.checkOtros.StylePriority.UseFont = false;
            this.checkOtros.Text = " Otros";
            // 
            // checkUsuario
            // 
            this.checkUsuario.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkUsuario.LocationFloat = new DevExpress.Utils.PointFloat(19.73132F, 303.074F);
            this.checkUsuario.Name = "checkUsuario";
            this.checkUsuario.SizeF = new System.Drawing.SizeF(125.5417F, 19.99998F);
            this.checkUsuario.StylePriority.UseFont = false;
            this.checkUsuario.Text = " Usuario";
            // 
            // checkUsuarioA
            // 
            this.checkUsuarioA.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkUsuarioA.LocationFloat = new DevExpress.Utils.PointFloat(19.73132F, 323.074F);
            this.checkUsuarioA.Name = "checkUsuarioA";
            this.checkUsuarioA.SizeF = new System.Drawing.SizeF(138.7917F, 20F);
            this.checkUsuarioA.StylePriority.UseFont = false;
            this.checkUsuarioA.Text = " Usuario Avanzado";
            // 
            // checkAdministrador
            // 
            this.checkAdministrador.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkAdministrador.LocationFloat = new DevExpress.Utils.PointFloat(19.73132F, 343.074F);
            this.checkAdministrador.Name = "checkAdministrador";
            this.checkAdministrador.SizeF = new System.Drawing.SizeF(149.5833F, 20F);
            this.checkAdministrador.StylePriority.UseFont = false;
            this.checkAdministrador.Text = " Administrador";
            // 
            // xrLabel72
            // 
            this.xrLabel72.BackColor = System.Drawing.Color.LightGray;
            this.xrLabel72.BorderColor = System.Drawing.Color.DarkGray;
            this.xrLabel72.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel72.BorderWidth = 0.5F;
            this.xrLabel72.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel72.LocationFloat = new DevExpress.Utils.PointFloat(13.7682F, 370.0699F);
            this.xrLabel72.Name = "xrLabel72";
            this.xrLabel72.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel72.SizeF = new System.Drawing.SizeF(392.2149F, 23.00003F);
            this.xrLabel72.StylePriority.UseBackColor = false;
            this.xrLabel72.StylePriority.UseBorderColor = false;
            this.xrLabel72.StylePriority.UseBorders = false;
            this.xrLabel72.StylePriority.UseBorderWidth = false;
            this.xrLabel72.StylePriority.UseFont = false;
            this.xrLabel72.StylePriority.UseTextAlignment = false;
            this.xrLabel72.Text = " Tipo de Solicitud";
            this.xrLabel72.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // checkCreacion
            // 
            this.checkCreacion.Font = new System.Drawing.Font("Arial", 9.75F);
            this.checkCreacion.LocationFloat = new DevExpress.Utils.PointFloat(24.76819F, 407.6099F);
            this.checkCreacion.Name = "checkCreacion";
            this.checkCreacion.SizeF = new System.Drawing.SizeF(364.75F, 20F);
            this.checkCreacion.StylePriority.UseFont = false;
            this.checkCreacion.Text = " Creación de usuario NO existente";
            // 
            // checkRenovacion
            // 
            this.checkRenovacion.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkRenovacion.LocationFloat = new DevExpress.Utils.PointFloat(24.76819F, 472.3992F);
            this.checkRenovacion.Name = "checkRenovacion";
            this.checkRenovacion.SizeF = new System.Drawing.SizeF(364.75F, 20F);
            this.checkRenovacion.StylePriority.UseFont = false;
            this.checkRenovacion.Text = " Renovación del Servicio a un usuario existente";
            // 
            // xrLabel51
            // 
            this.xrLabel51.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel51.LocationFloat = new DevExpress.Utils.PointFloat(418.9397F, 166.6908F);
            this.xrLabel51.Name = "xrLabel51";
            this.xrLabel51.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel51.SizeF = new System.Drawing.SizeF(177.0833F, 23F);
            this.xrLabel51.StylePriority.UseFont = false;
            this.xrLabel51.StylePriority.UseTextAlignment = false;
            this.xrLabel51.Text = "Solo para el Administrador";
            this.xrLabel51.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel52
            // 
            this.xrLabel52.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel52.LocationFloat = new DevExpress.Utils.PointFloat(418.9397F, 189.6908F);
            this.xrLabel52.Name = "xrLabel52";
            this.xrLabel52.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel52.SizeF = new System.Drawing.SizeF(117.4445F, 23F);
            this.xrLabel52.StylePriority.UseFont = false;
            this.xrLabel52.StylePriority.UseTextAlignment = false;
            this.xrLabel52.Text = "Usuario de Red";
            this.xrLabel52.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel53
            // 
            this.xrLabel53.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel53.LocationFloat = new DevExpress.Utils.PointFloat(418.9397F, 212.6908F);
            this.xrLabel53.Name = "xrLabel53";
            this.xrLabel53.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel53.SizeF = new System.Drawing.SizeF(57.29169F, 22.99998F);
            this.xrLabel53.StylePriority.UseFont = false;
            this.xrLabel53.StylePriority.UseTextAlignment = false;
            this.xrLabel53.Text = "Usuario:";
            this.xrLabel53.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel54
            // 
            this.xrLabel54.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel54.LocationFloat = new DevExpress.Utils.PointFloat(418.9397F, 235.6908F);
            this.xrLabel54.Name = "xrLabel54";
            this.xrLabel54.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel54.SizeF = new System.Drawing.SizeF(302.0833F, 23F);
            this.xrLabel54.StylePriority.UseFont = false;
            this.xrLabel54.StylePriority.UseTextAlignment = false;
            this.xrLabel54.Text = "Deshabilitar cuenta y servicios por:";
            this.xrLabel54.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // checkCM
            // 
            this.checkCM.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkCM.LocationFloat = new DevExpress.Utils.PointFloat(418.9397F, 263.0657F);
            this.checkCM.Name = "checkCM";
            this.checkCM.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.checkCM.SizeF = new System.Drawing.SizeF(177.0833F, 20F);
            this.checkCM.StylePriority.UseFont = false;
            this.checkCM.StylePriority.UseTextAlignment = false;
            this.checkCM.Text = " Certificado Médico                   ";
            // 
            // checkSE
            // 
            this.checkSE.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkSE.LocationFloat = new DevExpress.Utils.PointFloat(418.9397F, 283.074F);
            this.checkSE.Name = "checkSE";
            this.checkSE.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.checkSE.SizeF = new System.Drawing.SizeF(177.0833F, 20F);
            this.checkSE.StylePriority.UseFont = false;
            this.checkSE.StylePriority.UseTextAlignment = false;
            this.checkSE.Text = " Exterior                 ";
            // 
            // checkLM
            // 
            this.checkLM.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkLM.LocationFloat = new DevExpress.Utils.PointFloat(418.9397F, 303.074F);
            this.checkLM.Name = "checkLM";
            this.checkLM.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.checkLM.SizeF = new System.Drawing.SizeF(177.0833F, 20F);
            this.checkLM.StylePriority.UseFont = false;
            this.checkLM.StylePriority.UseTextAlignment = false;
            this.checkLM.Text = " Licencia de Maternidad           ";
            // 
            // checkM
            // 
            this.checkM.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkM.LocationFloat = new DevExpress.Utils.PointFloat(610.3566F, 263.0657F);
            this.checkM.Name = "checkM";
            this.checkM.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.checkM.SizeF = new System.Drawing.SizeF(177.0833F, 20F);
            this.checkM.StylePriority.UseFont = false;
            this.checkM.StylePriority.UseTextAlignment = false;
            this.checkM.Text = " Movilización     ";
            // 
            // checkLSS
            // 
            this.checkLSS.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkLSS.LocationFloat = new DevExpress.Utils.PointFloat(610.3566F, 283.074F);
            this.checkLSS.Name = "checkLSS";
            this.checkLSS.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.checkLSS.SizeF = new System.Drawing.SizeF(177.0833F, 20F);
            this.checkLSS.StylePriority.UseFont = false;
            this.checkLSS.StylePriority.UseTextAlignment = false;
            this.checkLSS.Text = " Licencia sin Sueldo                 ";
            // 
            // checkMD
            // 
            this.checkMD.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkMD.LocationFloat = new DevExpress.Utils.PointFloat(610.3566F, 303.074F);
            this.checkMD.Name = "checkMD";
            this.checkMD.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.checkMD.SizeF = new System.Drawing.SizeF(177.0833F, 20F);
            this.checkMD.StylePriority.UseFont = false;
            this.checkMD.StylePriority.UseTextAlignment = false;
            this.checkMD.Text = " Medida Disciplinaria        ";
            // 
            // xrLabel57
            // 
            this.xrLabel57.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel57.LocationFloat = new DevExpress.Utils.PointFloat(418.9397F, 431.699F);
            this.xrLabel57.Name = "xrLabel57";
            this.xrLabel57.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel57.SizeF = new System.Drawing.SizeF(186.8751F, 75.16666F);
            this.xrLabel57.StylePriority.UseFont = false;
            this.xrLabel57.StylePriority.UseTextAlignment = false;
            this.xrLabel57.Text = "Hasta la fecha definida por el representante administrativo para asegurar las fun" +
    "ciones o tareas asignadas al usuario.    ";
            this.xrLabel57.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleJustify;
            // 
            // xrCheckBox7
            // 
            this.xrCheckBox7.Checked = true;
            this.xrCheckBox7.CheckState = System.Windows.Forms.CheckState.Checked;
            this.xrCheckBox7.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrCheckBox7.LocationFloat = new DevExpress.Utils.PointFloat(661.3367F, 393.074F);
            this.xrCheckBox7.Name = "xrCheckBox7";
            this.xrCheckBox7.SizeF = new System.Drawing.SizeF(33.33337F, 38.62497F);
            this.xrCheckBox7.StylePriority.UseFont = false;
            this.xrCheckBox7.StylePriority.UseTextAlignment = false;
            this.xrCheckBox7.Text = "SI";
            // 
            // xrCheckBox8
            // 
            this.xrCheckBox8.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrCheckBox8.LocationFloat = new DevExpress.Utils.PointFloat(712.5599F, 393.074F);
            this.xrCheckBox8.Name = "xrCheckBox8";
            this.xrCheckBox8.SizeF = new System.Drawing.SizeF(54.94446F, 38.62497F);
            this.xrCheckBox8.StylePriority.UseFont = false;
            this.xrCheckBox8.StylePriority.UseTextAlignment = false;
            this.xrCheckBox8.Text = "NO";
            // 
            // xrLabel58
            // 
            this.xrLabel58.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel58.LocationFloat = new DevExpress.Utils.PointFloat(536.3842F, 189.6908F);
            this.xrLabel58.Name = "xrLabel58";
            this.xrLabel58.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel58.SizeF = new System.Drawing.SizeF(263.5229F, 23F);
            this.xrLabel58.StylePriority.UseFont = false;
            this.xrLabel58.StylePriority.UseTextAlignment = false;
            this.xrLabel58.Text = "(Su empleo es personal e intransferible)";
            this.xrLabel58.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrTable4
            // 
            this.xrTable4.LocationFloat = new DevExpress.Utils.PointFloat(608.4905F, 441.0484F);
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
            // xrTable3
            // 
            this.xrTable3.LocationFloat = new DevExpress.Utils.PointFloat(608.4905F, 464.0484F);
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
            // xrLine2
            // 
            this.xrLine2.LocationFloat = new DevExpress.Utils.PointFloat(476.2314F, 233.6907F);
            this.xrLine2.Name = "xrLine2";
            this.xrLine2.SizeF = new System.Drawing.SizeF(280.7361F, 2F);
            // 
            // xrLabel35
            // 
            this.xrLabel35.Font = new System.Drawing.Font("Arial", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel35.ForeColor = System.Drawing.Color.Black;
            this.xrLabel35.LocationFloat = new DevExpress.Utils.PointFloat(13.73131F, 138.6908F);
            this.xrLabel35.Name = "xrLabel35";
            this.xrLabel35.SizeF = new System.Drawing.SizeF(638F, 22.58333F);
            this.xrLabel35.StylePriority.UseFont = false;
            this.xrLabel35.StylePriority.UseForeColor = false;
            this.xrLabel35.StylePriority.UseTextAlignment = false;
            this.xrLabel35.Text = "Datos del Servicio";
            this.xrLabel35.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // checkModificacion
            // 
            this.checkModificacion.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkModificacion.LocationFloat = new DevExpress.Utils.PointFloat(24.76819F, 441.0484F);
            this.checkModificacion.Name = "checkModificacion";
            this.checkModificacion.SizeF = new System.Drawing.SizeF(364.75F, 20F);
            this.checkModificacion.StylePriority.UseFont = false;
            this.checkModificacion.Text = " Modificación de Privilegios de un usuario existente";
            // 
            // xrLine5
            // 
            this.xrLine5.LineDirection = DevExpress.XtraReports.UI.LineDirection.Vertical;
            this.xrLine5.LocationFloat = new DevExpress.Utils.PointFloat(512.416F, 22.70832F);
            this.xrLine5.Name = "xrLine5";
            this.xrLine5.SizeF = new System.Drawing.SizeF(34.4F, 45F);
            // 
            // xrLine10
            // 
            this.xrLine10.LineDirection = DevExpress.XtraReports.UI.LineDirection.Vertical;
            this.xrLine10.LocationFloat = new DevExpress.Utils.PointFloat(331.861F, 22.70832F);
            this.xrLine10.Name = "xrLine10";
            this.xrLine10.SizeF = new System.Drawing.SizeF(34.4F, 45F);
            // 
            // xrLine9
            // 
            this.xrLine9.LineDirection = DevExpress.XtraReports.UI.LineDirection.Vertical;
            this.xrLine9.LocationFloat = new DevExpress.Utils.PointFloat(146.972F, 21.33325F);
            this.xrLine9.Name = "xrLine9";
            this.xrLine9.SizeF = new System.Drawing.SizeF(34.37498F, 46.41508F);
            // 
            // xrLine4
            // 
            this.xrLine4.LocationFloat = new DevExpress.Utils.PointFloat(13.96311F, 55.2084F);
            this.xrLine4.Name = "xrLine4";
            this.xrLine4.SizeF = new System.Drawing.SizeF(795.4998F, 23.00001F);
            // 
            // xrLabel14
            // 
            this.xrLabel14.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel14.Font = new System.Drawing.Font("Arial", 9.75F);
            this.xrLabel14.LocationFloat = new DevExpress.Utils.PointFloat(540.1068F, 23.91669F);
            this.xrLabel14.Name = "xrLabel14";
            this.xrLabel14.SizeF = new System.Drawing.SizeF(168.9529F, 16.79165F);
            this.xrLabel14.StyleName = "FieldCaption";
            this.xrLabel14.StylePriority.UseBorders = false;
            this.xrLabel14.StylePriority.UseFont = false;
            this.xrLabel14.Text = " Nombre(s)";
            // 
            // xrLabel1
            // 
            this.xrLabel1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 9.75F);
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(358.0744F, 23.91669F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.SizeF = new System.Drawing.SizeF(178.5417F, 16.99999F);
            this.xrLabel1.StyleName = "FieldCaption";
            this.xrLabel1.StylePriority.UseBorders = false;
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.Text = " Segundo Apellido";
            // 
            // xrLabel2
            // 
            this.xrLabel2.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel2.Font = new System.Drawing.Font("Arial", 9.75F);
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(19.96313F, 67.74832F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.SizeF = new System.Drawing.SizeF(244.305F, 18F);
            this.xrLabel2.StyleName = "FieldCaption";
            this.xrLabel2.StylePriority.UseBorders = false;
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.Text = " Cargo que ocupa";
            // 
            // xrLabel3
            // 
            this.xrLabel3.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel3.Font = new System.Drawing.Font("Arial", 9.75F);
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(171.9215F, 23.91669F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.SizeF = new System.Drawing.SizeF(168.9529F, 16.99999F);
            this.xrLabel3.StyleName = "FieldCaption";
            this.xrLabel3.StylePriority.UseBorders = false;
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.Text = " Primer Apellido";
            // 
            // xrLabel7
            // 
            this.xrLabel7.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel7.Font = new System.Drawing.Font("Arial", 9.75F);
            this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(540.1068F, 67.70834F);
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.SizeF = new System.Drawing.SizeF(220.9503F, 17.99998F);
            this.xrLabel7.StyleName = "FieldCaption";
            this.xrLabel7.StylePriority.UseBorders = false;
            this.xrLabel7.StylePriority.UseFont = false;
            this.xrLabel7.Text = " Departamento / Área / Grupo";
            // 
            // xrLabel8
            // 
            this.xrLabel8.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel8.Font = new System.Drawing.Font("Arial", 9.75F);
            this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(19.96314F, 22.70832F);
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.SizeF = new System.Drawing.SizeF(128.4304F, 18.00002F);
            this.xrLabel8.StyleName = "FieldCaption";
            this.xrLabel8.StylePriority.UseBorders = false;
            this.xrLabel8.StylePriority.UseFont = false;
            this.xrLabel8.Text = " Número de Solapín";
            // 
            // xrLabel19
            // 
            this.xrLabel19.Font = new System.Drawing.Font("Arial", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.xrLabel19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.xrLabel19.LocationFloat = new DevExpress.Utils.PointFloat(13.50001F, 0F);
            this.xrLabel19.Name = "xrLabel19";
            this.xrLabel19.SizeF = new System.Drawing.SizeF(609.875F, 21.54167F);
            this.xrLabel19.StyleName = "Title";
            this.xrLabel19.StylePriority.UseFont = false;
            this.xrLabel19.StylePriority.UseForeColor = false;
            this.xrLabel19.Text = "Datos Personales y Laborales";
            // 
            // xrLine6
            // 
            this.xrLine6.LineDirection = DevExpress.XtraReports.UI.LineDirection.Vertical;
            this.xrLine6.LocationFloat = new DevExpress.Utils.PointFloat(512.4161F, 55.20842F);
            this.xrLine6.Name = "xrLine6";
            this.xrLine6.SizeF = new System.Drawing.SizeF(34.37F, 74.37F);
            // 
            // xrLabel55
            // 
            this.xrLabel55.BackColor = System.Drawing.Color.LightGray;
            this.xrLabel55.BorderColor = System.Drawing.Color.DarkGray;
            this.xrLabel55.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel55.BorderWidth = 0.5F;
            this.xrLabel55.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel55.LocationFloat = new DevExpress.Utils.PointFloat(414.7683F, 370.0699F);
            this.xrLabel55.Name = "xrLabel55";
            this.xrLabel55.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel55.SizeF = new System.Drawing.SizeF(394.463F, 23F);
            this.xrLabel55.StylePriority.UseBackColor = false;
            this.xrLabel55.StylePriority.UseBorderColor = false;
            this.xrLabel55.StylePriority.UseBorders = false;
            this.xrLabel55.StylePriority.UseBorderWidth = false;
            this.xrLabel55.StylePriority.UseFont = false;
            this.xrLabel55.StylePriority.UseTextAlignment = false;
            this.xrLabel55.Text = " Validez de la Solicitud     ";
            this.xrLabel55.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel56
            // 
            this.xrLabel56.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel56.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel56.LocationFloat = new DevExpress.Utils.PointFloat(415.7314F, 393.074F);
            this.xrLabel56.Name = "xrLabel56";
            this.xrLabel56.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel56.SizeF = new System.Drawing.SizeF(393.4998F, 38.62003F);
            this.xrLabel56.StylePriority.UseBorders = false;
            this.xrLabel56.StylePriority.UseFont = false;
            this.xrLabel56.StylePriority.UseTextAlignment = false;
            this.xrLabel56.Text = "  Mientras mantenga vínculo laboral.   ";
            this.xrLabel56.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel44
            // 
            this.xrLabel44.BackColor = System.Drawing.Color.LightGray;
            this.xrLabel44.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel44.BorderWidth = 0.5F;
            this.xrLabel44.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel44.LocationFloat = new DevExpress.Utils.PointFloat(408.4197F, 651.6523F);
            this.xrLabel44.Name = "xrLabel44";
            this.xrLabel44.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel44.SizeF = new System.Drawing.SizeF(399.6216F, 23F);
            this.xrLabel44.StylePriority.UseBackColor = false;
            this.xrLabel44.StylePriority.UseBorders = false;
            this.xrLabel44.StylePriority.UseBorderWidth = false;
            this.xrLabel44.StylePriority.UseFont = false;
            this.xrLabel44.StylePriority.UseTextAlignment = false;
            this.xrLabel44.Text = "Vicedirector Informática y Comunicaciones";
            this.xrLabel44.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel43
            // 
            this.xrLabel43.BackColor = System.Drawing.Color.LightGray;
            this.xrLabel43.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel43.BorderWidth = 0.5F;
            this.xrLabel43.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel43.LocationFloat = new DevExpress.Utils.PointFloat(408.4197F, 722.4855F);
            this.xrLabel43.Name = "xrLabel43";
            this.xrLabel43.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel43.SizeF = new System.Drawing.SizeF(399.6215F, 23F);
            this.xrLabel43.StylePriority.UseBackColor = false;
            this.xrLabel43.StylePriority.UseBorders = false;
            this.xrLabel43.StylePriority.UseBorderWidth = false;
            this.xrLabel43.StylePriority.UseFont = false;
            this.xrLabel43.StylePriority.UseTextAlignment = false;
            this.xrLabel43.Text = "Director General";
            this.xrLabel43.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel37
            // 
            this.xrLabel37.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel37.BorderWidth = 1F;
            this.xrLabel37.Font = new System.Drawing.Font("Arial", 9.75F);
            this.xrLabel37.LocationFloat = new DevExpress.Utils.PointFloat(413.4212F, 745.4723F);
            this.xrLabel37.Name = "xrLabel37";
            this.xrLabel37.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel37.SizeF = new System.Drawing.SizeF(395F, 55.49F);
            this.xrLabel37.StylePriority.UseBorders = false;
            this.xrLabel37.StylePriority.UseBorderWidth = false;
            this.xrLabel37.StylePriority.UseFont = false;
            this.xrLabel37.Text = "Firma y Fecha";
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.AnchorVertical = DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom;
            this.xrPageInfo1.Font = new System.Drawing.Font("Arial", 9.75F);
            this.xrPageInfo1.Format = "{0:dd/MM/yyyy}";
            this.xrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(72.38543F, 764.3798F);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.xrPageInfo1.SizeF = new System.Drawing.SizeF(76.0081F, 17.99994F);
            this.xrPageInfo1.StylePriority.UseFont = false;
            // 
            // xrLabel40
            // 
            this.xrLabel40.BorderColor = System.Drawing.Color.Black;
            this.xrLabel40.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel40.BorderWidth = 0.5F;
            this.xrLabel40.Font = new System.Drawing.Font("Arial", 9.75F);
            this.xrLabel40.LocationFloat = new DevExpress.Utils.PointFloat(408.4596F, 570.6155F);
            this.xrLabel40.Name = "xrLabel40";
            this.xrLabel40.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel40.SizeF = new System.Drawing.SizeF(399.96F, 38.43F);
            this.xrLabel40.StylePriority.UseBorderColor = false;
            this.xrLabel40.StylePriority.UseBorders = false;
            this.xrLabel40.StylePriority.UseBorderWidth = false;
            this.xrLabel40.StylePriority.UseFont = false;
            this.xrLabel40.Text = "Cargo";
            // 
            // xrShape5
            // 
            this.xrShape5.LineWidth = 2;
            this.xrShape5.LocationFloat = new DevExpress.Utils.PointFloat(13.54157F, 21.54166F);
            this.xrShape5.Name = "xrShape5";
            this.xrShape5.Shape = shapeRectangle5;
            this.xrShape5.SizeF = new System.Drawing.SizeF(798F, 110.04F);
            // 
            // xrLabel41
            // 
            this.xrLabel41.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel41.BorderWidth = 1F;
            this.xrLabel41.Font = new System.Drawing.Font("Arial", 9.75F);
            this.xrLabel41.LocationFloat = new DevExpress.Utils.PointFloat(408.963F, 541.8871F);
            this.xrLabel41.Name = "xrLabel41";
            this.xrLabel41.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel41.SizeF = new System.Drawing.SizeF(393F, 28.72467F);
            this.xrLabel41.StylePriority.UseBorders = false;
            this.xrLabel41.StylePriority.UseBorderWidth = false;
            this.xrLabel41.StylePriority.UseFont = false;
            this.xrLabel41.Text = "Nombre y Apellidos";
            // 
            // xrLabel36
            // 
            this.xrLabel36.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel36.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel36.LocationFloat = new DevExpress.Utils.PointFloat(16.29139F, 526.8835F);
            this.xrLabel36.Multiline = true;
            this.xrLabel36.Name = "xrLabel36";
            this.xrLabel36.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel36.SizeF = new System.Drawing.SizeF(391.2085F, 274.0797F);
            this.xrLabel36.StylePriority.UseBorders = false;
            this.xrLabel36.StylePriority.UseFont = false;
            this.xrLabel36.Text = resources.GetString("xrLabel36.Text");
            // 
            // xrLabel39
            // 
            this.xrLabel39.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel39.BorderWidth = 1F;
            this.xrLabel39.Font = new System.Drawing.Font("Arial", 9.75F);
            this.xrLabel39.LocationFloat = new DevExpress.Utils.PointFloat(408.963F, 609.0455F);
            this.xrLabel39.Name = "xrLabel39";
            this.xrLabel39.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel39.SizeF = new System.Drawing.SizeF(395F, 42.60681F);
            this.xrLabel39.StylePriority.UseBorders = false;
            this.xrLabel39.StylePriority.UseBorderWidth = false;
            this.xrLabel39.StylePriority.UseFont = false;
            this.xrLabel39.Text = "Firma y Fecha";
            // 
            // Title
            // 
            this.Title.BackColor = System.Drawing.Color.Transparent;
            this.Title.BorderColor = System.Drawing.Color.Black;
            this.Title.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Title.BorderWidth = 1F;
            this.Title.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold);
            this.Title.ForeColor = System.Drawing.Color.Teal;
            this.Title.Name = "Title";
            // 
            // FieldCaption
            // 
            this.FieldCaption.BackColor = System.Drawing.Color.Transparent;
            this.FieldCaption.BorderColor = System.Drawing.Color.Black;
            this.FieldCaption.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.FieldCaption.BorderWidth = 1F;
            this.FieldCaption.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.FieldCaption.ForeColor = System.Drawing.Color.Black;
            this.FieldCaption.Name = "FieldCaption";
            // 
            // PageInfo
            // 
            this.PageInfo.BackColor = System.Drawing.Color.Transparent;
            this.PageInfo.BorderColor = System.Drawing.Color.Black;
            this.PageInfo.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.PageInfo.BorderWidth = 1F;
            this.PageInfo.Font = new System.Drawing.Font("Arial", 9F);
            this.PageInfo.ForeColor = System.Drawing.Color.Black;
            this.PageInfo.Name = "PageInfo";
            // 
            // DataField
            // 
            this.DataField.BackColor = System.Drawing.Color.Transparent;
            this.DataField.BorderColor = System.Drawing.Color.Black;
            this.DataField.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.DataField.BorderWidth = 1F;
            this.DataField.Font = new System.Drawing.Font("Arial", 10F);
            this.DataField.ForeColor = System.Drawing.Color.Black;
            this.DataField.Name = "DataField";
            this.DataField.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            // 
            // radialMenu1
            // 
            this.radialMenu1.Name = "radialMenu1";
            // 
            // xrPictureBox1
            // 
            this.xrPictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("xrPictureBox1.Image")));
            this.xrPictureBox1.LocationFloat = new DevExpress.Utils.PointFloat(380.86F, 0F);
            this.xrPictureBox1.Name = "xrPictureBox1";
            this.xrPictureBox1.SizeF = new System.Drawing.SizeF(75F, 75F);
            // 
            // xrLabel49
            // 
            this.xrLabel49.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel49.ForeColor = System.Drawing.Color.Black;
            this.xrLabel49.LocationFloat = new DevExpress.Utils.PointFloat(0F, 78.49998F);
            this.xrLabel49.Name = "xrLabel49";
            this.xrLabel49.SizeF = new System.Drawing.SizeF(825.0001F, 33F);
            this.xrLabel49.StyleName = "Title";
            this.xrLabel49.StylePriority.UseFont = false;
            this.xrLabel49.StylePriority.UseForeColor = false;
            this.xrLabel49.StylePriority.UseTextAlignment = false;
            this.xrLabel49.Text = "SOLICITUD DE SERVICIOS DE RED";
            this.xrLabel49.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // reportHeaderBand1
            // 
            this.reportHeaderBand1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel49,
            this.xrPictureBox1});
            this.reportHeaderBand1.HeightF = 133.3333F;
            this.reportHeaderBand1.Name = "reportHeaderBand1";
            // 
            // Planilla
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.PaginaPrincipal,
            this.reportHeaderBand1});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.objectDataSource});
            this.DataSource = this.objectDataSource;
            this.Margins = new System.Drawing.Printing.Margins(5, 1, 0, 11);
            this.StyleSheet.AddRange(new DevExpress.XtraReports.UI.XRControlStyle[] {
            this.Title,
            this.FieldCaption,
            this.PageInfo,
            this.DataField});
            this.Version = "17.1";
            ((System.ComponentModel.ISupportInitialize)(this.objectDataSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radialMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}

