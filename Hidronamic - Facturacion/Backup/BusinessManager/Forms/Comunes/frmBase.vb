Public Class frmBase

    Private m_privilegios As Byte
    Private m_permitir_imprimir As Boolean
    Private m_tipo_accion As String

    Public MyPrintDocument As Printing.PrintDocument
    Public MyPrintPageSettings As Printing.PageSettings
    Public MyPrintPreview As PrintPreviewDialog

    Private MyButtonImprimir As New ToolStripButton
    Public MyLabel As New ToolStripLabel
    Public MyTextboxSerie As New ToolStripTextBox
    Public MyTextboxNumero As New ToolStripTextBox
    Public MyTextboxFecha As New ToolStripTextBox
    Public MyComboboxImpresoras As New ToolStripComboBox

    'Public MyPrinters As String

    Public ControlarCorrelativo As Boolean
    Public AsignarCorrelativo As Boolean

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        AddHandler MyButtonImprimir.Click, AddressOf Click_MyButtonImprimir
        AddHandler MyTextboxFecha.Validated, AddressOf Validated_MyTextboxFecha

        MyPrintPreview = New PrintPreviewDialog

        MyButtonImprimir.BackgroundImage = My.Resources.Print_48
        MyButtonImprimir.BackgroundImageLayout = ImageLayout.Stretch

        MyButtonImprimir.AutoSize = False
        MyButtonImprimir.Height = 40 : MyButtonImprimir.Width = 50
        MyTextboxSerie.AutoSize = False : MyTextboxSerie.ReadOnly = True : MyTextboxSerie.Width = 40 : MyTextboxSerie.Font = New Font("Arial Narrow", 12, FontStyle.Bold)
        MyTextboxNumero.AutoSize = False : MyTextboxNumero.ReadOnly = True : MyTextboxNumero.Width = 55 : MyTextboxNumero.Font = New Font("Arial Narrow", 12, FontStyle.Bold)
        MyTextboxFecha.AutoSize = False : MyTextboxFecha.ReadOnly = True : MyTextboxFecha.Width = 70 : MyTextboxFecha.Font = New Font("Arial Narrow", 12, FontStyle.Bold)
        MyLabel.Font = New Font("Arial Narrow", 12, FontStyle.Bold) : MyLabel.ForeColor = Color.DarkRed
        MyComboboxImpresoras.AutoSize = False
        MyComboboxImpresoras.Width = 250

        DirectCast(MyPrintPreview.Controls(1), ToolStrip).Items.RemoveAt(0) ' Remover botón de impresora que viene por default

        'For NEle = 0 To 5 'DirectCast(MyPrintPreview.Controls(1), ToolStrip).Items.Count - 1
        '    DirectCast(MyPrintPreview.Controls(1), ToolStrip).Items(NEle).Visible = False
        '    DirectCast(MyPrintPreview.Controls(1), ToolStrip).Items.RemoveAt(NEle)
        'Next

        DirectCast(MyPrintPreview.Controls(1), ToolStrip).Items.Insert(0, MyComboboxImpresoras)
        DirectCast(MyPrintPreview.Controls(1), ToolStrip).Items.Insert(1, MyButtonImprimir)
        DirectCast(MyPrintPreview.Controls(1), ToolStrip).Items.Insert(2, MyLabel)
        DirectCast(MyPrintPreview.Controls(1), ToolStrip).Items.Insert(3, MyTextboxSerie)
        DirectCast(MyPrintPreview.Controls(1), ToolStrip).Items.Insert(4, MyTextboxNumero)
        DirectCast(MyPrintPreview.Controls(1), ToolStrip).Items.Insert(5, MyTextboxFecha)


        DirectCast(MyPrintPreview.Controls(1), ToolStrip).Height = 40

        'DirectCast(MyPrintPreview, Form).WindowState = FormWindowState.Maximized

        MyPrintPreview.WindowState = FormWindowState.Normal
        MyPrintPreview.PrintPreviewControl.Zoom = 1.0

        'DirectCast(MyPrintPreview.Controls(1), ToolStrip).Items(0).Margin = New System.Windows.Forms.Padding(0, 0, 800, 0)
        DirectCast(MyPrintPreview.Controls(1), ToolStrip).Items(1).Margin = New System.Windows.Forms.Padding(0, 0, 100, 0)
        'DirectCast(MyPrintPreview.Controls(1), ToolStrip).Items(2).Margin = New System.Windows.Forms.Padding(0, 0, 400, 0)

        ' Default printer       
        MyPrintDocument = New Printing.PrintDocument
        MyPrintPageSettings = New Printing.PageSettings

        Dim MyDefaultPrinter As String = MyPrintDocument.PrinterSettings.PrinterName

        ' recorre las impresoras instaladas   
        For Each MyPrinters In Printing.PrinterSettings.InstalledPrinters
            MyComboboxImpresoras.Items.Add(MyPrinters.ToString)
        Next
        ' selecciona la impresora predeterminada   
        MyComboboxImpresoras.Text = MyDefaultPrinter

        AsignarCorrelativo = False
    End Sub

    Private Sub Click_MyButtonImprimir(ByVal sender As Object, ByVal e As System.EventArgs)
        'MyPrintDocument.PrinterSettings.PrinterName = MyComboboxImpresoras.Text
        MyPrintDocument.Print()
        If ControlarCorrelativo Then
            Resp = MsgBox("Se imprimió correctamente el documento?.", MsgBoxStyle.YesNo, " CONTROL DE CORRELATIVOS")
            If Resp.ToString = vbYes Then
                AsignarCorrelativo = True
                MyPrintPreview.Close()
            End If
        Else
            MyPrintPreview.Close()
        End If
    End Sub

    Private Sub Validated_MyTextboxFecha(ByVal sender As Object, ByVal e As System.EventArgs)
        sender.text = EvalDato(sender.text, "FV")
    End Sub

    Public Property Tipo_accion() As String
        Get
            Return m_tipo_accion
        End Get
        Set(ByVal value As String)
            m_tipo_accion = value
        End Set
    End Property

    Public Property Privilegios() As Byte
        Get
            Return m_privilegios
        End Get
        Set(ByVal value As Byte)
            m_privilegios = value
        End Set
    End Property

    Public Property Permitir_imprimir() As Boolean
        Get
            Return m_permitir_imprimir
        End Get
        Set(ByVal value As Boolean)
            m_permitir_imprimir = value
        End Set
    End Property

    'Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
    '    MyBase.OnPaint(e)
    '    Dim AnchoBorde As Integer = 1
    '    Dim ColorBorde As Color = Color.Maroon ' ColorTranslator.FromOle(RGB(239, 130, 0))

    '    ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, ColorBorde, _
    '    AnchoBorde, ButtonBorderStyle.Solid, ColorBorde, AnchoBorde, _
    '    ButtonBorderStyle.Solid, ColorBorde, AnchoBorde, ButtonBorderStyle.Solid, _
    '    ColorBorde, AnchoBorde, ButtonBorderStyle.Solid)
    'End Sub

End Class