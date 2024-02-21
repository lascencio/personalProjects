Public Class entOperacionTransferencia
    Private m_empresa As String
    Private m_operacion As String
    Private m_almacen_origen As String
    Private m_almacen_destino As String
    Private m_referencia_cuo As String
    Private m_estado As String
    Private m_usuario_registro As String
    Private m_fecha_registro As Date
    Private m_usuario_modifica As String
    Private m_fecha_modifica As Date

    Public Sub New()
        Me.empresa = Nothing
        Me.operacion = Nothing
        Me.almacen_origen = Nothing
        Me.almacen_destino = Nothing
        Me.referencia_cuo = Nothing
        Me.estado = Nothing
        Me.usuario_registro = Nothing
        Me.fecha_registro = Nothing
        Me.usuario_modifica = Nothing
        Me.fecha_modifica = Nothing
    End Sub

    Public Sub New(ByVal Operacionalmacen_origen As entOperacionTransferencia)

        With Operacionalmacen_origen
            m_empresa = .empresa
            m_operacion = .operacion
            m_almacen_origen = .almacen_origen
            m_almacen_destino = .almacen_destino
            m_referencia_cuo = .referencia_cuo
            m_estado = .estado
            m_usuario_registro = .usuario_registro
            m_fecha_registro = .fecha_registro
            m_usuario_modifica = .usuario_modifica
            m_fecha_modifica = .fecha_modifica
        End With
    End Sub

    Public Property empresa() As String
        Get
            Return m_empresa
        End Get
        Set(ByVal value As String)
            m_empresa = value
        End Set
    End Property

    Public Property operacion() As String
        Get
            Return m_operacion
        End Get
        Set(ByVal value As String)
            m_operacion = value
        End Set
    End Property

    Public Property almacen_origen() As String
        Get
            Return m_almacen_origen
        End Get
        Set(ByVal value As String)
            m_almacen_origen = value
        End Set
    End Property

    Public Property almacen_destino() As String
        Get
            Return m_almacen_destino
        End Get
        Set(ByVal value As String)
            m_almacen_destino = value
        End Set
    End Property

    Public Property referencia_cuo() As String
        Get
            Return m_referencia_cuo
        End Get
        Set(ByVal value As String)
            m_referencia_cuo = IIf(String.IsNullOrEmpty(value), CUO_Nulo, value)
        End Set
    End Property

    Public Property estado() As String
        Get
            Return m_estado
        End Get
        Set(ByVal value As String)
            m_estado = IIf(String.IsNullOrEmpty(value), "A", value)
        End Set
    End Property

    Public Property usuario_registro() As String
        Get
            Return m_usuario_registro
        End Get
        Set(ByVal value As String)
            m_usuario_registro = value
        End Set
    End Property

    Public Property fecha_registro() As Date
        Get
            Return m_fecha_registro
        End Get
        Set(ByVal value As Date)
            m_fecha_registro = IIf(value.Ticks = 0, FechaNulo, value)
        End Set
    End Property

    Public Property usuario_modifica() As String
        Get
            Return m_usuario_modifica
        End Get
        Set(ByVal value As String)
            m_usuario_modifica = value
        End Set
    End Property

    Public Property fecha_modifica() As Date
        Get
            Return m_fecha_modifica
        End Get
        Set(ByVal value As Date)
            m_fecha_modifica = IIf(value.Ticks = 0, FechaNulo, value)
        End Set
    End Property
End Class
