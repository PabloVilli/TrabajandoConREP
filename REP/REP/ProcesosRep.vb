Imports Microsoft.Reporting.WinForms
Imports System.Xml
Imports System.IO
Imports System.Data.SqlClient
Imports System.Data.SqlTypes

Public Class ProcesosRep

    Dim F18_dsDocumentoCFD As New DataSet
    Dim F18_dsComplementoPago As New DataSet
    Dim F18_dsComplementoTimbreFiscalDigital As New DataSet

    Dim F18_xmlString As String
    Dim F18_rutaDeBusqueda As String

    Dim F18_docu As XmlDocument
    Dim F18_xmlReturn As SqlXml
    Dim F18_pdfContent As Byte()
    Dim F18_rutaXMLenUso As String = Application.StartupPath + "\XMLenUso\"
    Public F18_archivosXMLenUso As New List(Of String)

    Dim F18_table As New DataTable("Archivos")
    Dim F18_column As New DataColumn
    Dim F18_row As DataRow

    Public F18_objWriter As StreamWriter
    Dim F18_directorio As String

    Dim F18_tipoXml As String
    Dim F18_cadenaUUID As String

    Dim F18_rutaGeneralXML As String
    Dim repo As New ReportViewer

    'Cosntructor.
    Public Sub New()

        F18_column = New DataColumn
        F18_column.DataType = Type.GetType("System.String")
        F18_column.ColumnName = "Archivos"
        F18_table.Columns.Add(F18_column)
        F18_rutaDeBusqueda = Environment.GetFolderPath(Environment.SpecialFolder.CommonDesktopDirectory)
        F18_directorio = Application.StartupPath + "\BitacorasRep\BitacoraREP_" + Replace(Date.Now, "/", "-").Replace(":", "").Replace("p.", "").Replace("m.", "") + ".txt"
        F18_rutaGeneralXML = File.ReadAllText(F18_rutaDeBusqueda + "\ruta.txt")

    End Sub

    'Inicialización de la BitacoraREP.
    Public Sub F18_CrearBitacora()

        Try
            File.Create(F18_directorio).Dispose()
            F18_objWriter = New StreamWriter(F18_directorio, True)
            F18_objWriter.WriteLine("BITACORA DE ENVIO DE DOCUMENTOS RECEPCION ELECTRONICA DE PÁGOS")
            F18_objWriter.WriteLine("Empresa                : ")
            F18_objWriter.WriteLine("Fecha y Hora de Inicio : " + Date.Now.ToString)
            F18_objWriter.WriteLine("------------------------------------------------------------------------------------------------------------------------------------------------------")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    'Vuelve a abrir la Bitacora para agregar lineas.
    Public Sub F18_AbrirBitacora()

        Try
            F18_objWriter = New StreamWriter(F18_directorio, True)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    'Agregar una linea.
    Public Sub F18_AgregarLinea(ByVal texto As String)
        Try
            F18_objWriter.WriteLine(texto)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    'Cerrar Bitacora.
    Public Sub F18_CerrarBitacora()

        Try
            F18_objWriter.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    'Abrir la Bitacora.
    Public Sub F18_VerBitacora()

        Try
            Process.Start("notepad.exe", F18_directorio)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    'Metodo que busca los archivos y los muestra en pantalla.
    Public Sub F18_BuscarArchivos(ByVal grid As DataGridView)

        F18_table.Clear()
        Dim F18_rutaGeneralXML = File.ReadAllText(F18_rutaDeBusqueda + "\ruta.txt")
        Dim diretorioBusqueda = New DirectoryInfo(F18_rutaGeneralXML)
        Dim index As Integer = diretorioBusqueda.GetFiles("*", SearchOption.AllDirectories).Count()

        If index <= 0 Then

            MsgBox("No hay archivos nuevos")

        Else

            For Each arc In diretorioBusqueda.GetFiles("*", SearchOption.AllDirectories)

                F18_ObtenerNombreXML(arc.FullName)

            Next

            grid.DataSource = F18_table
            grid.Columns(0).Width = 900

        End If

    End Sub

    'Metodo que obtiene una lista de archivos XML, unicamente de  tipo pago,
    'ignora los que no son tipo pago y los que tienen timbre de prueba.
    Public Sub F18_ObtenerNombreXML(ByVal F18_archivo As String)

        Try
            F18_InicializarTipoYCadenaaUUID(F18_archivo)

            If F18_tipoXml = "P" And F18_cadenaUUID <> "00000000-0000-0000-0000-000000000000" Then

                F18_row = F18_table.NewRow
                F18_row("Archivos") = F18_archivo
                F18_table.Rows.Add(F18_row)
                F18_archivosXMLenUso.Add(F18_archivo + "|" + F18_cadenaUUID)
                'File.Delete(F18_archivo, F18_rutDocPago)
                F18_AgregarLinea(vbCrLf + "  -Documento valido: " + F18_archivo + " el archivo anterior se cargo correctamente")

            Else

                'File.Move(F18_archivo, F18_rutDocErroneo)
                F18_AgregarLinea(vbCrLf + "*Documento invalido: " + F18_archivo + " el archivo no corresponde a un xml de REP o el UUDI es de prueba, UUID: " + F18_cadenaUUID)

            End If

        Catch ex As Exception

            F18_AgregarLinea("*01" + ex.Message)

        End Try
        
    End Sub

    'Metodo que obtiene el tipo de documento y su UUID  
    Public Sub F18_InicializarTipoYCadenaaUUID(ByVal archivo As String)

        Try
            F18_dsDocumentoCFD.Reset()
            F18_dsDocumentoCFD.ReadXml(archivo)
            F18_dsComplementoTimbreFiscalDigital.Reset()
            F18_dsComplementoTimbreFiscalDigital.ReadXml(archivo)
            Dim row As DataRow = F18_dsDocumentoCFD.Tables("Comprobante").Rows(0)
            F18_tipoXml = row("TipoDeComprobante").ToString()
            Dim row1 As DataRow = F18_dsComplementoTimbreFiscalDigital.Tables("TimbreFiscalDigital").Rows(0)
            F18_cadenaUUID = row1("UUID").ToString()
        Catch ex As Exception
            F18_AgregarLinea(vbCrLf + "*02" + ex.Message + " " + archivo)
        End Try

    End Sub

    'Metodo que carga los datos de la BD en el grid
    Public Sub F18_LlenarGridView(ByVal F18_dgv As DataGridView)

        Try
            Dim F18_cn As New SqlConnection(My.Settings.PruebasCfdiPagosConnectionString)
            Dim F18_sqlInst As String = "SELECT cfdiCodigoCliente, cfdiRazonSocial_R, cfdiSerie, cfdiFolio, cfdiUUID, cfdiFechaDeEmision, cfdiTotal FROM CFDPagos"
            Dim F18_sqlComm As New SqlCommand(F18_sqlInst, F18_cn)
            Dim F18_da As New SqlDataAdapter(F18_sqlComm)
            F18_cn.Open()
            Dim F18_dt As New DataTable()
            F18_da.Fill(F18_dt)
            F18_dgv.DataSource = F18_dt
            F18_dgv.Columns(0).Width = 85
            F18_dgv.Columns(1).Width = 240
            F18_dgv.Columns(2).Width = 40
            F18_dgv.Columns(3).Width = 40
            F18_dgv.Columns(4).Width = 240
            F18_dgv.Columns(5).Width = 150
            F18_dgv.Columns(6).Width = 100
            F18_cn.Close()
            F18_table.Clear()
        Catch ex As Exception
            F18_AgregarLinea(vbCrLf + "*03" + ex.Message)
        End Try
        
    End Sub


    'Insertar los datos del XML en la BD
    Public Sub F18_ValidarExiste(ByVal archivo As String)

        Dim b As String = "|"
        Dim posicion As Integer = archivo.LastIndexOf(b)
        Dim uuid As String = archivo.Substring(posicion + 1)
        Dim rutaArc As String = archivo.Substring(0, posicion)
        
        Dim cn As New SqlConnection(My.Settings.PruebasCfdiPagosConnectionString)
        Dim sqlComm As New SqlCommand("sp_VerificarExiste", cn)

        Try

            sqlComm.CommandType = CommandType.StoredProcedure
            cn.Open()
            Dim parametroSalida = New SqlParameter("@registroExistente", SqlDbType.VarChar, 60)
            parametroSalida.Direction = ParameterDirection.Output
            sqlComm.Parameters.Add(parametroSalida)
            sqlComm.Parameters.AddWithValue("cfdi_UUID", uuid)

            sqlComm.ExecuteNonQuery()

            Dim ret As String = sqlComm.Parameters("@registroExistente").Value

            If ret = " " Then

                F18_LlenarDataSetParaTabla(F18_dsDocumentoCFD, "cfdv33.xsd", rutaArc)
                F18_LlenarDataSetParaTabla(F18_dsComplementoPago, "Pagos10.xsd", rutaArc)
                F18_LlenarDataSetParaTabla(F18_dsComplementoTimbreFiscalDigital, "TimbreFiscalDigitalv11.xsd", rutaArc)

                Dim row As DataRow = F18_dsDocumentoCFD.Tables("Comprobante").Rows(0)
                Dim row1 As DataRow = F18_dsDocumentoCFD.Tables("Receptor").Rows(0)
                Dim row2 As DataRow = F18_dsComplementoTimbreFiscalDigital.Tables("TimbreFiscalDigital").Rows(0)
                Dim row3 As DataRow = F18_dsComplementoPago.Tables("Pago").Rows(0)

                Dim val1 As String = row1("Nombre").ToString()
                Dim val2 As String = row("Serie").ToString()
                Dim val3 As String = row("Folio").ToString()
                Dim val4 As String = row2("UUID").ToString()
                Dim val5 As String = row2("FechaTimbrado").ToString()
                Dim val6 As String = row3("Monto").ToString()

               
                F18_InsertarDatosBD(rutaArc, val1, val2, val3, val4, val5, val6)

            Else

                F18_AgregarLinea(vbCrLf + "*  -" + ret + uuid + "   " + rutaArc)

            End If

        Catch ex As Exception

            F18_AgregarLinea(vbCrLf + "*04 " + ex.Message)

        End Try
        cn.Close()

    End Sub

    Public Sub F18_InsertarDatosBD(ByVal archivo As String, ByVal razon As String, ByVal serie As String, ByVal folio As String, ByVal uuid As String, ByVal fecha As String, ByVal total As String)

        Dim parametroSQLXML As SqlXml = New SqlXml(New XmlTextReader(archivo))

        F18_CrearPDF(archivo)

        Dim cn As New SqlConnection(My.Settings.PruebasCfdiPagosConnectionString)
        Dim sqlComm As New SqlCommand("sp_AgregarRegistro", cn)

        Try
            sqlComm.CommandType = CommandType.StoredProcedure
            cn.Open()
            Dim parametroSalida = New SqlParameter("@registroExistente", SqlDbType.VarChar, 60)
            parametroSalida.Direction = ParameterDirection.Output
            sqlComm.Parameters.Add(parametroSalida)
            sqlComm.Parameters.AddWithValue("cfdi_RazonSocial_R", razon)
            sqlComm.Parameters.AddWithValue("cfdi_Serie", serie)
            sqlComm.Parameters.AddWithValue("cfdi_Folio", folio)
            sqlComm.Parameters.AddWithValue("cfdi_UUID", uuid)
            sqlComm.Parameters.AddWithValue("cfdi_FechaDeEmision", fecha)
            sqlComm.Parameters.AddWithValue("cfdi_Total", total)
            sqlComm.Parameters.AddWithValue("cfdi_XML", parametroSQLXML)
            sqlComm.Parameters.AddWithValue("cfdi_PDF", F18_pdfContent)
            sqlComm.ExecuteNonQuery()

            Dim ret As String = sqlComm.Parameters("@registroExistente").Value

            F18_AgregarLinea(vbCrLf + "  -" + ret + uuid)

        Catch ex As Exception
            F18_AgregarLinea(vbCrLf + "*05 " + ex.Message)
        End Try
        cn.Close()

    End Sub

    'Lee  un esquema para manipular xml
    Public Sub F18_LlenarDataSetParaTabla(ByVal dataSet As DataSet, ByVal NombreXsd As String, ByVal rutaArc As String)

        dataSet.Reset()
        dataSet.ReadXmlSchema(Application.StartupPath + "\Xsd\" + NombreXsd)
        dataSet.ReadXml(rutaArc)

    End Sub

    'Inicializa la variable que contendra en PDF 
    Public Sub F18_CrearPDF(ByVal path As String)

        repo.Reset()
        repo.ProcessingMode = ProcessingMode.Local
        repo.LocalReport.DataSources.Clear()
        repo.LocalReport.ReportPath = Application.StartupPath + "\Reportes\FormatoREP.rdlc"

        F18_LlenarDataSet(F18_dsDocumentoCFD, "cfdv33.xsd", path, repo)
        F18_LlenarDataSet(F18_dsComplementoPago, "Pagos10.xsd", path, repo)
        F18_LlenarDataSet(F18_dsComplementoTimbreFiscalDigital, "TimbreFiscalDigitalv11.xsd", path, repo)

        F18_pdfContent = repo.LocalReport.Render("PDF", Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)

        'report.RefreshReport()

        'File.Delete(Application.StartupPath + "\Temp\OutputXml.xml")

    End Sub

    'Inicializa los esquemas para que el reporte tenga informacion
    Public Sub F18_LlenarDataSet(ByVal dataSet As DataSet, ByVal NombreXsd As String, ByVal path As String, ByVal report As ReportViewer)

        dataSet.Reset()
        dataSet.ReadXmlSchema(Application.StartupPath + "\Xsd\" + NombreXsd)
        dataSet.ReadXml(path)
        For Each tbl1 As DataTable In dataSet.Tables
            report.LocalReport.DataSources.Add(New ReportDataSource("ds" & tbl1.TableName, tbl1))
        Next

    End Sub

    Public Sub ObtenerPDFDB(ByVal valor As String)

        Dim pdfBin As SqlBinary
        Dim ruta As String = Application.StartupPath + "\Temp\"
        Try
            Dim cn As New SqlConnection(My.Settings.PruebasCfdiPagosConnectionString)
            Dim sqlInst As String = "SELECT cfdiPDF FROM CFDPagos WHERE cfdiPagoId = " + valor
            Dim sqlComm As New SqlCommand(sqlInst, cn)
            cn.Open()
            Dim sqlDR As SqlDataReader
            sqlDR = sqlComm.ExecuteReader()
            If (sqlDR.Read) Then
                pdfBin = sqlDR.GetSqlValue(0)
            End If
            File.WriteAllBytes(ruta + "Rep.pdf", pdfBin)
            cn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

End Class
