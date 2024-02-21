Public Class entCliente
    Private m_empresa As String
    Private m_cuenta_comercial As String
    Private m_razon_social As String
    Private m_prefijo As String
    Private m_domicilio As String
    Private m_codigo_postal As String
    Private m_telefono As String
    Private m_celular As String
    Private m_email_contacto As String
    Private m_email_facturacion As String
    Private m_pagina_web As String
    Private m_contacto_venta As String
    Private m_contacto_compra As String
    Private m_tipo_moneda As String
    Private m_indica_no_domiciliado As String
    Private m_condicion_pago As String
    Private m_tipo_pago As String
    Private m_exige_orden_compra As String
    Private m_exige_orden_pago As String
    Private m_exige_acta_conformidad As String
    Private m_usuario_web As String
    Private m_clave_web As String
    Private m_comentario As String
    Private m_estado As String
    Private m_usuario_registro As String
    Private m_fecha_registro As Date
    Private m_usuario_modifica As String
    Private m_fecha_modifica As Date

    Public Sub New()
        Me.empresa = Nothing
        Me.cuenta_comercial = Nothing
        Me.razon_social = Nothing
        Me.prefijo = Nothing
        Me.domicilio = Nothing
        Me.codigo_postal = Nothing
        Me.telefono = Nothing
        Me.celular = Nothing
        Me.email_contacto = Nothing
        Me.email_facturacion = Nothing
        Me.pagina_web = Nothing
        Me.contacto_venta = Nothing
        Me.contacto_compra = Nothing
        Me.tipo_moneda = Nothing
        Me.indica_no_domiciliado = Nothing
        Me.condicion_pago = Nothing
        Me.tipo_pago = Nothing
        Me.exige_orden_compra = Nothing
        Me.exige_orden_pago = Nothing
        Me.exige_acta_conformidad = Nothing
        Me.usuario_web = Nothing
        Me.clave_web = Nothing
        Me.comentario = Nothing
        Me.estado = Nothing
        Me.usuario_registro = Nothing
        Me.fecha_registro = Nothing
        Me.usuario_modifica = Nothing
        Me.fecha_modifica = Nothing
    End Sub

    Public Sub New(ByVal Cliente As entCliente)

        With Cliente
            m_empresa = .empresa
            m_cuenta_comercial = .cuenta_comercial
            m_razon_social = .razon_social
            m_prefijo = .prefijo
            m_domicilio = .domicilio
            m_codigo_postal = .codigo_postal
            m_telefono = .telefono
            m_celular = .celular
            m_email_contacto = .email_contacto
            m_email_facturacion = .email_facturacion
            m_pagina_web = .pagina_web
            m_contacto_venta = .contacto_venta
            m_contacto_compra = .contacto_compra
            m_tipo_moneda = .tipo_moneda
            m_indica_no_domiciliado = .indica_no_domiciliado
            m_condicion_pago = .condicion_pago
            m_tipo_pago = .tipo_pago
            m_exige_orden_compra = .exige_orden_compra
            m_exige_orden_pago = exige_orden_pago
            m_exige_acta_conformidad = .exige_acta_conformidad
            m_usuario_web = .usuario_web
            m_clave_web = .clave_web
            m_comentario = comentario
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

    Public Property cuenta_comercial() As String
        Get
            Return m_cuenta_comercial
        End Get
        Set(ByVal value As String)
            m_cuenta_comercial = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property razon_social() As String
        Get
            Return m_razon_social
        End Get
        Set(ByVal value As String)
            m_razon_social = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property prefijo() As String
        Get
            Return m_prefijo
        End Get
        Set(ByVal value As String)
            m_prefijo = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property domicilio() As String
        Get
            Return m_domicilio
        End Get
        Set(ByVal value As String)
            m_domicilio = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property codigo_postal() As String
        Get
            Return m_codigo_postal
        End Get
        Set(ByVal value As String)
            m_codigo_postal = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property telefono() As String
        Get
            Return m_telefono
        End Get
        Set(ByVal value As String)
            m_telefono = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property celular() As String
        Get
            Return m_celular
        End Get
        Set(ByVal value As String)
            m_celular = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property email_contacto() As String
        Get
            Return m_email_contacto
        End Get
        Set(ByVal value As String)
            m_email_contacto = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property email_facturacion() As String
        Get
            Return m_email_facturacion
        End Get
        Set(ByVal value As String)
            m_email_facturacion = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property pagina_web() As String
        Get
            Return m_pagina_web
        End Get
        Set(ByVal value As String)
            m_pagina_web = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property contacto_venta() As String
        Get
            Return m_contacto_venta
        End Get
        Set(ByVal value As String)
            m_contacto_venta = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property contacto_compra() As String
        Get
            Return m_contacto_compra
        End Get
        Set(ByVal value As String)
            m_contacto_compra = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property tipo_moneda() As String
        Get
            Return m_tipo_moneda
        End Get
        Set(ByVal value As String)
            m_tipo_moneda = IIf(String.IsNullOrEmpty(value), "2", value)
        End Set
    End Property

    Public Property indica_no_domiciliado() As String
        Get
            Return m_indica_no_domiciliado
        End Get
        Set(ByVal value As String)
            m_indica_no_domiciliado = IIf(String.IsNullOrEmpty(value), "NO", value)
        End Set
    End Property

    Public Property condicion_pago() As String
        Get
            Return m_condicion_pago
        End Get
        Set(ByVal value As String)
            m_condicion_pago = IIf(String.IsNullOrEmpty(value), "30", value)
        End Set
    End Property

    Public Property tipo_pago() As String
        Get
            Return m_tipo_pago
        End Get
        Set(ByVal value As String)
            m_tipo_pago = IIf(String.IsNullOrEmpty(value), "007", value)
        End Set
    End Property

    Public Property exige_orden_compra() As String
        Get
            Return m_exige_orden_compra
        End Get
        Set(ByVal value As String)
            m_exige_orden_compra = IIf(String.IsNullOrEmpty(value), "NO", value)
        End Set
    End Property

    Public Property exige_orden_pago() As String
        Get
            Return m_exige_orden_pago
        End Get
        Set(ByVal value As String)
            m_exige_orden_pago = IIf(String.IsNullOrEmpty(value), "NO", value)
        End Set
    End Property

    Public Property exige_acta_conformidad() As String
        Get
            Return m_exige_acta_conformidad
        End Get
        Set(ByVal value As String)
            m_exige_acta_conformidad = IIf(String.IsNullOrEmpty(value), "NO", value)
        End Set
    End Property

    Public Property usuario_web() As String
        Get
            Return m_usuario_web
        End Get
        Set(ByVal value As String)
            m_usuario_web = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property clave_web() As String
        Get
            Return m_clave_web
        End Get
        Set(ByVal value As String)
            m_clave_web = IIf(String.IsNullOrEmpty(value), Space(1), value)
        End Set
    End Property

    Public Property comentario() As String
        Get
            Return m_comentario
        End Get
        Set(ByVal value As String)
            m_comentario = IIf(String.IsNullOrEmpty(value), Space(1), value)
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
            m_fecha_registro = IIf(value.Ticks = 0, Now, value)
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
            m_fecha_modifica = IIf(value.Ticks = 0, Now, value)
        End Set
    End Property

End Class
