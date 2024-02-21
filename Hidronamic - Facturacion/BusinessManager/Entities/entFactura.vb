Public Class entFactura

    Private m_Venta As String
    Private m_Documento_Serie As String
    Private m_Documento_Numero As String
    Private m_Fecha_Emision As Date
    Private m_Fecha_Vencimiento As Date
    Private m_Razon_Social As String
    Private m_RUC As String
    Private m_Domicilio_01 As String
    Private m_Domicilio_02 As String
    Private m_Condicion_Pago As String
    Private m_Tipo_Moneda As String
    Private m_Valor_Venta As Decimal
    Private m_IGV As Decimal
    Private m_Precio_Venta As Decimal
    Private m_Precio_Venta_Texto As String
    Private m_Contacto_Cliente As String
    Private m_Contacto_Venta As String
    Private m_Indica_Exportacion As String

    Public Sub New()
        Me.Venta = Nothing
        Me.Documento_Serie = Nothing
        Me.Documento_Numero = Nothing
        Me.Fecha_Emision = Nothing
        Me.Fecha_Vencimiento = Nothing
        Me.Razon_Social = Nothing
        Me.RUC = Nothing
        Me.Domicilio_01 = Nothing
        Me.Domicilio_02 = Nothing
        Me.Condicion_Pago = Nothing
        Me.Tipo_Moneda = Nothing
        Me.Valor_Venta = Nothing
        Me.IGV = Nothing
        Me.Precio_Venta = Nothing
        Me.Precio_Venta_Texto = Nothing
        Me.Contacto_Cliente = Nothing
        Me.Contacto_Venta = Nothing
        Me.Indica_Exportacion = Nothing
    End Sub

    Public Sub New(ByVal Factura As entFactura)
        With Factura
            m_Venta = .Venta
            m_Documento_Serie = .Documento_Serie
            m_Documento_Numero = .Documento_Numero
            m_Fecha_Emision = .Fecha_Emision
            m_Fecha_Vencimiento = .Fecha_Vencimiento
            m_Razon_Social = .Razon_Social
            m_RUC = .RUC
            m_Domicilio_01 = .Domicilio_01
            m_Domicilio_02 = .Domicilio_02
            m_Condicion_Pago = .Condicion_Pago
            m_Tipo_Moneda = .Tipo_Moneda
            m_Valor_Venta = .Valor_Venta
            m_IGV = .IGV
            m_Precio_Venta = .Precio_Venta
            m_Precio_Venta_Texto = .Precio_Venta_Texto
            m_Contacto_Cliente = .Contacto_Cliente
            m_Contacto_Venta = .Contacto_Venta
            m_Indica_Exportacion = .Indica_Exportacion
        End With
    End Sub

    Public Property Venta() As String
        Get
            Return m_Venta
        End Get
        Set(ByVal value As String)
            m_Venta = value
        End Set
    End Property

    Public Property Fecha_Emision() As Date
        Get
            Return m_Fecha_Emision
        End Get
        Set(ByVal value As Date)
            m_Fecha_Emision = value
        End Set
    End Property

    Public Property Fecha_Vencimiento() As Date
        Get
            Return m_Fecha_Vencimiento
        End Get
        Set(ByVal value As Date)
            m_Fecha_Vencimiento = value
        End Set
    End Property

    Public Property RUC() As String
        Get
            Return m_RUC
        End Get
        Set(ByVal value As String)
            m_RUC = value
        End Set
    End Property

    Public Property Condicion_Pago() As String
        Get
            Return m_Condicion_Pago
        End Get
        Set(ByVal value As String)
            m_Condicion_Pago = value
        End Set
    End Property

    Public Property IGV() As String
        Get
            Return m_IGV
        End Get
        Set(ByVal value As String)
            m_IGV = value
        End Set
    End Property

    Public Property Precio_Venta() As String
        Get
            Return m_Precio_Venta
        End Get
        Set(ByVal value As String)
            m_Precio_Venta = value
        End Set
    End Property

    Public Property Tipo_Moneda() As String
        Get
            Return m_Tipo_Moneda
        End Get
        Set(ByVal value As String)
            m_Tipo_Moneda = IIf(String.IsNullOrEmpty(value), "1", value)
        End Set
    End Property

    Public Property Valor_Venta() As Double
        Get
            Return m_Valor_Venta
        End Get
        Set(ByVal value As Double)
            m_Valor_Venta = IIf(String.IsNullOrEmpty(value), 0, value)
        End Set
    End Property

    Public Property Documento_Serie() As String
        Get
            Return m_Documento_Serie
        End Get
        Set(ByVal value As String)
            m_Documento_Serie = IIf(String.IsNullOrEmpty(value), "06", value)
        End Set
    End Property

    Public Property Documento_Numero() As String
        Get
            Return m_Documento_Numero
        End Get
        Set(ByVal value As String)
            m_Documento_Numero = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property Razon_Social() As String
        Get
            Return m_Razon_Social
        End Get
        Set(ByVal value As String)
            m_Razon_Social = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property Domicilio_01() As String
        Get
            Return m_Domicilio_01
        End Get
        Set(ByVal value As String)
            m_Domicilio_01 = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property Domicilio_02() As String
        Get
            Return m_Domicilio_02
        End Get
        Set(ByVal value As String)
            m_Domicilio_02 = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property Precio_Venta_Texto() As String
        Get
            Return m_Precio_Venta_Texto
        End Get
        Set(ByVal value As String)
            m_Precio_Venta_Texto = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property Contacto_Cliente() As String
        Get
            Return m_Contacto_Cliente
        End Get
        Set(ByVal value As String)
            m_Contacto_Cliente = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property Contacto_Venta() As String
        Get
            Return m_Contacto_Venta
        End Get
        Set(ByVal value As String)
            m_Contacto_Venta = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property Indica_Exportacion() As String
        Get
            Return m_Indica_Exportacion
        End Get
        Set(ByVal value As String)
            m_Indica_Exportacion = IIf(String.IsNullOrEmpty(value), "NO", value)
        End Set
    End Property
End Class
