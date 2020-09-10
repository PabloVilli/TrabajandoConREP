Imports REP.ProcesosRep
Public Class Form2

    Dim Rep As New ProcesosRep

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AxAcroPDF1.src = Application.StartupPath + "\Temp\Rep.pdf"

    End Sub
End Class