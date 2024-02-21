Imports System.Data.SqlClient

Public Class UserControlPOS

    Public Event TB_btnEnter_Click()
    Public Event TB_btnItem_Click()
    'Public Event TB_cmbBotonera_SelectedIndexChanged()

    Public Shared myEmpresa As String
    Public Shared myConnectionString As String
    Public Shared myStringCommand As String

    Private m_CodigoProducto As String
    Private m_Cantidad As Decimal
    Private m_Botonera As String

    Private MyButton As Button

    Private MyBotonera As New dsBotoneras.BOTONERASDataTable
    Private MyBotones As New dsBotoneras.BOTONERAS_DETDataTable

    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        MyButton = New Button


    End Sub

    Public WriteOnly Property Botonera() As String
        Set(ByVal Value As String)
            m_Botonera = Value
        End Set
    End Property

    Public ReadOnly Property CodigoProducto() As String
        Get
            Return m_CodigoProducto
        End Get
    End Property

    Public ReadOnly Property Cantidad() As Decimal
        Get
            Return m_Cantidad
        End Get
    End Property

    Private Sub cmbBotonera_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbBotonera.SelectedIndexChanged
        If cmbBotonera.SelectedIndex <> -1 Then Call RefrescarBotones(cmbBotonera.SelectedValue)
    End Sub

    Private Sub InicializarFormulario()
        For Each ctrl As Object In Me.Controls
            If TypeOf ctrl Is Button Then
                If ctrl.Name.Substring(0, 7) = "btnItem" Then
                    ctrl.ImageIndex = 0
                    ctrl.ForeColor = Color.Black
                End If
            End If
        Next
    End Sub

    Public Sub RefrescarBotones(ByVal Botonera As String)
        MyBotones = New dsBotoneras.BOTONERAS_DETDataTable

        myStringCommand = "SELECT EMPRESA, BOTONERA, BOTON, DESCRIPCION, COLOR, PRODUCTO, IMAGEN, INDICA_IMAGEN, INDICA_VISIBLE, " & _
                          "USUARIO_REGISTRO, FECHA_REGISTRO, USUARIO_MODIFICA, FECHA_MODIFICA " & _
                          "FROM VEN.BOTONERAS_DET " & _
                          "WHERE Empresa='" & myEmpresa & "' AND BOTONERA='" & Botonera & "' " & _
                          "ORDER BY BOTON "

        Call ObtenerDataTableSQL(MyBotones)

        For Each ctrl As Object In Me.Controls
            If TypeOf ctrl Is Button Then
                If ctrl.Name.Substring(0, 7) = "btnItem" Then
                    ctrl.ImageList = imlButtons
                    ctrl.ImageIndex = 0
                    ctrl.ForeColor = Color.Black
                    ctrl.Text = Space(1)
                    ctrl.Tag = Space(1)
                End If
            End If
        Next

        If MyBotones.Rows.Count <> 0 Then
            For NEle As Integer = 0 To MyBotones.Rows.Count - 1
                For Each ctrl As Object In Me.Controls
                    If TypeOf ctrl Is Button Then
                        With MyBotones(NEle)
                            If ctrl.Name = "btnItem" & .BOTON Then
                                Select Case .COLOR
                                    Case Is = 1 : ctrl.ImageList = imlButtons_blue
                                    Case Is = 2 : ctrl.ImageList = imlButtons_green
                                    Case Is = 4 : ctrl.ImageList = imlButtons_red
                                    Case Is = 6 : ctrl.ImageList = imlButtons_yellow
                                    Case Is = 7 : ctrl.ImageList = imlButtons_white
                                    Case Else : ctrl.ImageList = imlButtons
                                End Select
                                ctrl.ImageIndex = 0
                                ctrl.ForeColor = Color.Black
                                ctrl.Text = .DESCRIPCION
                                ctrl.Tag = .PRODUCTO
                                ctrl.Visible = IIf(.INDICA_VISIBLE = "SI", True, False)
                            End If
                        End With
                    End If
                Next
            Next
        End If
    End Sub

    Private Sub LlenarCantidad(Numero As String)
        txtQuantity.Text = txtQuantity.Text & Numero
    End Sub

    Public Sub ObtenerBotoneras(ByVal Empresa As String, ByVal myConnectionStringSQL_Repository As String)
        myEmpresa = Empresa
        myConnectionString = myConnectionStringSQL_Repository

        MyBotonera = New dsBotoneras.BOTONERASDataTable

        myStringCommand = "SELECT EMPRESA, BOTONERA, DESCRIPCION, ESTADO, USUARIO_REGISTRO, FECHA_REGISTRO, USUARIO_MODIFICA, FECHA_MODIFICA " & _
                          "FROM VEN.BOTONERAS " & _
                          "WHERE Empresa='" & myEmpresa & "' AND ESTADO='A' " & _
                          "ORDER BY DESCRIPCION "

        Call ObtenerDataTableSQL(MyBotonera)
        cmbBotonera.DataSource = MyBotonera

    End Sub

    Public Shared Sub ObtenerDataTableSQL(ByRef myDataTable As Object)
        Dim myConnection As New SqlConnection(myConnectionString)
        Dim myDataAdapter As New SqlDataAdapter(myStringCommand, myConnection)
        myDataAdapter.Fill(myDataTable)
    End Sub

    Private Sub btnItem_Click(sender As Object, e As EventArgs) Handles btnItem01.Click, btnItem02.Click, btnItem03.Click, btnItem04.Click, btnItem05.Click, btnItem06.Click, btnItem07.Click, btnItem08.Click, btnItem09.Click, btnItem10.Click, btnItem11.Click, btnItem12.Click, btnItem13.Click, btnItem14.Click, btnItem15.Click, btnItem16.Click, btnItem17.Click, btnItem18.Click, btnItem19.Click, btnItem20.Click, btnItem21.Click, btnItem22.Click, btnItem23.Click, btnItem24.Click, btnItem25.Click
        MyButton = New Button
        If sender.Text.Trim.Length <> 0 Then
            MyButton.Name = sender.Name
            MyButton.Tag = sender.Tag
            MyButton.Text = sender.Text
            MyButton.ForeColor = sender.ForeColor

            Call InicializarFormulario()

            sender.ImageIndex = 2
            sender.ForeColor = Color.White
        Else
            RaiseEvent TB_btnItem_Click()
        End If
    End Sub

    Private Sub btnNumber_Click(sender As Object, e As EventArgs) Handles btnNumber1.Click, btnNumber2.Click, btnNumber3.Click, btnNumber4.Click, btnNumber5.Click, btnNumber6.Click, btnNumber7.Click, btnNumber8.Click, btnNumber9.Click, btnNumber0.Click
        If MyButton.Name.Trim.Length <> 0 Then
            If txtQuantity.Text.Trim.Length = 0 Then
                If sender.Name <> "btnNumber0" Then Call LlenarCantidad(sender.Tag)
            Else
                Call LlenarCantidad(sender.Tag)
            End If
        End If
    End Sub

    Private Sub btnClean_Click(sender As Object, e As EventArgs) Handles btnClean.Click
        Call InicializarFormulario()
        txtQuantity.Text = Nothing
    End Sub

    Private Sub btnEnter_Click(sender As Object, e As EventArgs) Handles btnEnter.Click
        If MyButton.Text.ToString.Trim.Length <> 0 Then
            If MyButton.Tag.ToString.Trim.Length <> 0 And txtQuantity.Text.Trim.Length <> 0 Then
                m_CodigoProducto = MyButton.Tag
                m_Cantidad = CDec(txtQuantity.Text)

                Call InicializarFormulario()
                txtQuantity.Text = Nothing
            Else
                m_CodigoProducto = Space(1)
                m_Cantidad = 0
            End If

            RaiseEvent TB_btnEnter_Click()
        End If
    End Sub

End Class
