
Public Class UserControlPOS_01

    Public Event TB_btnEnter_Click()

    Private MyButton As Button

    Private m_CodigoProducto As String
    Private m_Cantidad As Decimal

    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        MyButton = New Button

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

    Private Sub LlenarCantidad(Numero As String)
        txtQuantity.Text = txtQuantity.Text & Numero
    End Sub

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
