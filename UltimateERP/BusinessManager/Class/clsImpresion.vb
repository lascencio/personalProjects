Imports System
Imports System.IO
Imports System.Data
Imports System.Text
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Drawing.Printing
Imports System.Collections.Generic
Imports System.Windows.Forms
Imports Microsoft.Reporting.WinForms

Public Class clsImpresion
    Implements IDisposable
    Private m_currentPageIndex As Integer
    Private m_streams As IList(Of Stream)

    Public Shared Sub Imprimir(ByRef rp As LocalReport)
        Using demo As New clsImpresion
            demo.Run(rp)
        End Using
    End Sub

    ' Create a local report for Report.rdlc, load the data,
    ' export the report to an .emf file, and print it.
    Private Sub Run(ByVal rp As LocalReport)
        Export(rp)
        Print()
    End Sub

    ' Export the given report as an EMF (Enhanced Metafile) file.
    Private Sub Export(ByVal report As LocalReport)
        'Dim deviceInfo As String = "<DeviceInfo>" &
        '                           "<OutputFormat>EMF</OutputFormat>" &
        '                           "<PageHeight>0in</PageHeight>" &
        '                           "<PageWidth>8.75in</PageWidth>" &
        '                           "</DeviceInfo>"

        ''Impresora Nueva
        'Dim deviceInfo As String = "<DeviceInfo>" &
        '                           "<OutputFormat>EMF</OutputFormat>" &
        '                           "<PageHeight>0in</PageHeight>" &
        '                           "<PageWidth>2.95in</PageWidth>" &
        '                           "</DeviceInfo>"

        Dim deviceInfo As String = "<DeviceInfo>" &
                                   "<OutputFormat>EMF</OutputFormat>" &
                                   "<PageHeight>0in</PageHeight>" &
                                   "<PageWidth>3.12in</PageWidth>" &
                                   "</DeviceInfo>"

        'Dim deviceInfo = "<DeviceInfo>" &
        '             "<OutputFormat>PDF</OutputFormat>" &
        '             "<HumanReadablePDF>False</HumanReadablePDF>" &
        '             "</DeviceInfo>"

        Dim warnings As Warning()
        m_streams = New List(Of Stream)()
        report.Render("Image", deviceInfo, AddressOf CreateStream, warnings)
        For Each stream As Stream In m_streams
            stream.Position = 0
        Next
    End Sub

    Private Sub Print()
        If m_streams Is Nothing OrElse m_streams.Count = 0 Then
            Throw New Exception("Error: no se puede imprimir.")
        End If
        Dim printDoc As New PrintDocument()
        If Not printDoc.PrinterSettings.IsValid Then
            Throw New Exception("Error: no se puede hallar la impresora.")
        Else
            AddHandler printDoc.PrintPage, AddressOf PrintPage
            m_currentPageIndex = 0
            printDoc.DefaultPageSettings.Landscape = False
            printDoc.Print()
        End If
    End Sub

    ' Handler for PrintPageEvents
    Private Sub PrintPage(ByVal sender As Object, ByVal ev As PrintPageEventArgs)
        Dim pageImage As New Metafile(m_streams(m_currentPageIndex))

        ' Adjust rectangular area with printer margins.
        Dim adjustedRect As New Rectangle(ev.PageBounds.Left - CInt(ev.PageSettings.HardMarginX),
                                          ev.PageBounds.Top - CInt(ev.PageSettings.HardMarginY),
                                          ev.PageBounds.Width,
                                          ev.PageBounds.Height)

        ' Draw a white background for the report
        ev.Graphics.FillRectangle(Brushes.White, adjustedRect)

        ' Draw the report content
        ev.Graphics.DrawImage(pageImage, adjustedRect)

        ' Prepare for the next page. Make sure we haven't hit the end.
        m_currentPageIndex += 1
        ev.HasMorePages = (m_currentPageIndex < m_streams.Count)
    End Sub

    ' Routine to provide to the report renderer, in order to
    ' save an image for each page of the report.
    Private Function CreateStream(ByVal name As String, ByVal fileNameExtension As String, ByVal encoding As Encoding, ByVal mimeType As String, ByVal willSeek As Boolean) As Stream
        Dim stream As Stream = New MemoryStream()
        m_streams.Add(stream)
        Return stream
    End Function

    Public Sub Dispose() Implements IDisposable.Dispose
        If m_streams IsNot Nothing Then
            For Each stream As Stream In m_streams
                stream.Close()
            Next
            m_streams = Nothing
        End If
    End Sub

End Class
