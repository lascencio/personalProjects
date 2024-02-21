Public Class entCONCAR_Cuenta
    Private m_pcuenta As String
    Private m_pdescri As String
    Private m_pvanexo As String
    Private m_pmonref As String
    Private m_pctacar As String
    Private m_pctaabo As String
    Private m_pvcencos As String
    Private m_pvregcta As String
    Private m_pvtipcta As String
    Private m_pvarea As String
    Private m_pestado As String

    Public Sub New()
        Me.pcuenta = Nothing
        Me.pdescri = Nothing
        Me.pvanexo = Nothing
        Me.pmonref = Nothing
        Me.pctacar = Nothing
        Me.pctaabo = Nothing
        Me.pvcencos = Nothing
        Me.pvregcta = Nothing
        Me.pvtipcta = Nothing
        Me.pvarea = Nothing
        Me.pestado = Nothing
    End Sub

    Public Sub New(ByVal Cuenta As entCONCAR_Cuenta)
        With Cuenta
            m_pcuenta = .pcuenta
            m_pdescri = .pdescri
            m_pvanexo = .pvanexo
            m_pmonref = .pmonref
            m_pctacar = .pctacar
            m_pctaabo = .pctaabo
            m_pvcencos = .pvcencos
            m_pvregcta = .pvregcta
            m_pvtipcta = .pvtipcta
            m_pvarea = .pvarea
            m_pestado = .pestado
        End With
    End Sub

    Public Property pcuenta() As String
        Get
            Return m_pcuenta
        End Get
        Set(ByVal value As String)
            m_pcuenta = value
        End Set
    End Property

    Public Property pdescri() As String
        Get
            Return m_pdescri
        End Get
        Set(ByVal value As String)
            m_pdescri = value
        End Set
    End Property

    Public Property pvanexo() As String
        Get
            Return m_pvanexo
        End Get
        Set(ByVal value As String)
            m_pvanexo = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property pmonref() As String
        Get
            Return m_pmonref
        End Get
        Set(ByVal value As String)
            m_pmonref = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property pctacar() As String
        Get
            Return m_pctacar
        End Get
        Set(ByVal value As String)
            m_pctacar = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property pctaabo() As String
        Get
            Return m_pctaabo
        End Get
        Set(ByVal value As String)
            m_pctaabo = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property pvcencos() As String
        Get
            Return m_pvcencos
        End Get
        Set(ByVal value As String)
            m_pvcencos = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property pvregcta() As String
        Get
            Return m_pvregcta
        End Get
        Set(ByVal value As String)
            m_pvregcta = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property pvtipcta() As String
        Get
            Return m_pvtipcta
        End Get
        Set(ByVal value As String)
            m_pvtipcta = IIf(String.IsNullOrEmpty(value), "X", value)
        End Set
    End Property

    Public Property pvarea() As String
        Get
            Return m_pvarea
        End Get
        Set(ByVal value As String)
            m_pvarea = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property pestado() As String
        Get
            Return m_pestado
        End Get
        Set(ByVal value As String)
            m_pestado = IIf(String.IsNullOrEmpty(value), "V", value)
        End Set
    End Property

End Class
