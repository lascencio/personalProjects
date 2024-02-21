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

        Me.SetStyle(ControlStyles.SupportsTransparentBackColor, True)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        MyPrintPreview = New PrintPreviewDialog
        MyPrintDocument = New Printing.PrintDocument
        MyPrintPageSettings = New Printing.PageSettings

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