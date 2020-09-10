Imports Microsoft.Reporting.WinForms
Imports REP.ProcesosRep
Public Class Form1
    Dim contBitacora As Integer = 0
    Dim Rep As New ProcesosRep

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Rep.F18_CrearBitacora()

    End Sub

    Private Sub btnEnviar_Click(sender As Object, e As EventArgs) Handles btnEnviar.Click

        If contBitacora <> 0 Then
            Rep.F18_AbrirBitacora()
        End If


        Rep.F18_BuscarArchivos(DataGridView1)
        txtCntRegistros.Text = Rep.F18_archivosXMLenUso.Count.ToString()

        Dim cont As Integer = 0

        Rep.F18_AgregarLinea(vbCrLf + "------------------------------------------------------------------------------------------------------------------------------------------------------")
        If Rep.F18_archivosXMLenUso.Count <= 0 Then
            MsgBox("Selecciona Archivos para cargar")
        Else
            While cont <= Rep.F18_archivosXMLenUso.Count() - 1

                Rep.F18_ValidarExiste(Rep.F18_archivosXMLenUso.Item(cont))
                cont = cont + 1

            End While
            Rep.F18_LlenarGridView(DataGridView1)
            Rep.F18_archivosXMLenUso.Clear()
            Rep.F18_CerrarBitacora()
            Rep.F18_VerBitacora()
        End If

        contBitacora = contBitacora + 1

    End Sub

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click

        MsgBox("Enviar por correo")

    End Sub

    Private Sub DataGridView1_DoubleClick(sender As Object, e As EventArgs) Handles DataGridView1.DoubleClick

        Try
            Dim valorDelGrid As Integer
            valorDelGrid = DataGridView1.CurrentCell.RowIndex + 1
            Rep.ObtenerPDFDB(valorDelGrid.ToString())
            Form2.Show()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        
    End Sub

   
    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Application.ExitThread()
    End Sub
End Class
