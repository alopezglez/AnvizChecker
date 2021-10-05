Imports Excel = Microsoft.Office.Interop.Excel
Imports System
Imports System.Globalization



Public Class frmMain
    Const MinIndexUsers = 2
    Const MaxIndexUsers = 1000

    Dim APP As New Excel.Application
    Dim worksheet As Excel.Worksheet
    Dim workbook As Excel.Workbook
    Dim listID(MaxIndexUsers) As String
    Dim listREPORT(MaxIndexUsers) As String



    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click

    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click

        Application.Exit()

    End Sub

    Private Sub AcercadeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AcercadeToolStripMenuItem.Click
        Dim about As New Form2

        about.ShowDialog()

    End Sub

    Private Sub ImportarUsuariosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportarUsuariosToolStripMenuItem.Click
        Try

            Dim filenameWPath As String
            Dim filenameNPath As String
            Dim tempSplit() As String


            Dim i As Integer
            Dim countUsers As Integer = 0
            Dim tID As String
            Dim tStr As String
            Dim xRange As Excel.Range

            openXLS.FileName = ""
            openXLS.Title = "Seleccione el archivo de empleados"

            If openXLS.ShowDialog = False Then
                AbrirArchivoDeFichajesToolStripMenuItem.Enabled = False
                Exit Sub
            End If

            filenameWPath = openXLS.FileName 'Ruta de archivo y nombre
            filenameNPath = openXLS.SafeFileName 'Nombre y extension solamente

            tempSplit = filenameNPath.Split(".") 'Divide el nombre de archivos usando los '.'

            workbook = APP.Workbooks.Open(filenameWPath)
            worksheet = workbook.Worksheets(tempSplit(0))

            '1 - Código
            '2 - ID
            '3 - Tarjeta Nº
            '4 - Nombre
            '5 - Departamento
            '12 - ID Dispositivo Autorizado

            'Establece ProgressBar
            tsPB.Minimum = 0
            tsPB.Maximum = MaxIndexUsers
            tsText.Text = "Leyendo archivo (" & filenameNPath & ") ..."

            For i = MaxIndexUsers To MinIndexUsers Step -1

                tsPB.Value = MaxIndexUsers - i

                Application.DoEvents()

                xRange = worksheet.Cells(i, 1)

                If Trim(xRange.Text) <> "" Then

                    'Contador de usuarios agrega 1
                    countUsers += 1

                    'ID Temporal
                    tID = xRange.Text

                    'Nombre Usuario
                    xRange = worksheet.Cells(i, 4)
                    tStr = xRange.Text

                    'Muestra Usuario en PB
                    tsText.Text = tStr

                    listID(CInt(tID)) = Trim(tStr)

                End If


            Next

            lstEmpleados.Items.Clear()

            For i = MinIndexUsers To MaxIndexUsers

                If listID(i) = Nothing Then
                    'Nada
                Else
                    lstEmpleados.Items.Add(listID(i).ToUpper)
                End If

            Next

            'Muestra Usuario en PB
            tsText.Text = "Base de datos cargada cargada (" & countUsers & " usuarios.)"
            tsPB.Value = tsPB.Minimum

            'aCTIVA EL MENU DE CARGA DE FICHERO DE FICHAJES
            AbrirArchivoDeFichajesToolStripMenuItem.Enabled = True


        Catch ex As Exception

            MessageBox.Show("Error al cargar la base de datos de empleados.")
            AbrirArchivoDeFichajesToolStripMenuItem.Enabled = False
        End Try

    End Sub

    Private Sub AbrirArchivoDeFichajesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AbrirArchivoDeFichajesToolStripMenuItem.Click
        Dim filenameWPath As String
        Dim Archivo As Integer = FreeFile()
        Dim Texto As String
        Dim tempSplit() As String

        openXLS.FileName = ""
        openXLS.Title = "Seleccione el archivo de fichajes"

        If openXLS.ShowDialog = False Then
            Exit Sub
        End If

        filenameWPath = openXLS.FileName 'Ruta de archivo y nombre

        If System.IO.File.Exists(filenameWPath) = False Then
            MessageBox.Show("El archivo especificado no existe.")
            Exit Sub
        End If


        ' Abrimos el archivo y lo recorremos hasta el final línea por línea
        FileOpen(Archivo, filenameWPath, OpenMode.Input, OpenAccess.Read)

        Do While Not EOF(Archivo)

            ' Leemos la línea de texto del archivo
            Texto = LineInput(Archivo)

            ' Aqui se puede hacer el tratamiento que se desee con la línea de texto

            'Si la linea que lee no está en blanco entonces procesa
            If Trim(Texto) <> "" Then

                'Separa la linea leida en cada tabulacion
                tempSplit = Texto.Split(vbTab)

                'Comprueba si el espacio reservado para el usuario X ha sido inicializado
                If listREPORT(CInt(tempSplit(0))) = Nothing Then
                    listREPORT(CInt(tempSplit(0))) = Texto
                Else
                    listREPORT(CInt(tempSplit(0))) &= vbCrLf & Texto
                End If

            End If

        Loop

        ' Cerramos el archivo
        FileClose(Archivo)


    End Sub


    Private Sub lstEmpleados_DoubleClick(sender As Object, e As EventArgs) Handles lstEmpleados.DoubleClick
        Dim i As Integer

        For i = MinIndexUsers To MaxIndexUsers

            If listID(i) = Nothing Then
                'nada
            Else
                If listID(i).Trim.ToUpper = lstEmpleados.Text Then

                    If listREPORT(i) = Nothing Then
                        txtReport.Text = "¡ No se han encontrado fichajes para este empleado !"
                    Else
                        txtReport.Text = listREPORT(i)
                    End If
                    Exit Sub
                End If
            End If
        Next

    End Sub

    Private Sub ComprobarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ComprobarToolStripMenuItem.Click
        'El cometido de esta rutina es comprobar las siguientes condiciones:
        '
        '1- Que el trabajador haya trabajado 7,30 horas
        '2- Que el trabajador haya disfrutado de 30 min de descanso cuando su turno es seguido
        '3- Que el trabajador tenga todos los fichajes OK, es decir por cada entrada tiene que haber una salida
        '4- Que el trabajador tenga dos dias libres a la semana

        'Primero leer la fecha de todas las lineas y la hora, codificarlas de la siguiente forma:
        '
        'DDMMAAAAHHMM
        '2 digitos del dia
        '2 digitos del mes
        '4 digitos del año
        '2 digitos de la hora
        '2 digitos de los minutos

        'De esta forma siempre el dia antes y la hora antes generaran un numero mas pequeño
        'y según se avance en dia, mes, hora o miuto el numero generado es mayor, de esa forma
        'ordenamos los registros, luego separar por dia y leer todos del mismo dia, comprobar
        'que por cada entrada hay una salida, de lo contrario generar un log de error por dia,
        'al final se generará un reporte que especifique que dias estan bien y cuales mal

        'calcular tiempo entre cada entrada y salida e ir sumando para el total de horas

        'tiene que haber un minimo de 4 fichajes por dia:
        '       entrada jornada
        '       salida a descanso
        '       entrada de descanso
        '       salida de jornada

        Dim listCode As New List(Of String)()

        Dim reportLine() As String
        Dim reportType As String
        Dim reportDateTime() As String

        Dim actualDATE As DateTime
        Dim runDate As String
        Dim lastDate As String
        Dim runType As Integer
        Dim lastType As Integer = 1




        'Recorre el reporte linea por linea y genera una lista con la
        'fecha y hora y el tipo de registro

        For Each line In txtReport.Lines

            reportLine = line.Split(vbTab)

            reportDateTime = reportLine(1).Split(" ")

            Select Case reportLine(3)
                Case "1"
                    reportType = "OUT"

                Case "0"
                    reportType = "IN"
            End Select

            listCode.Add(CodeDATE(reportDateTime(1), reportDateTime(0)) & vbTab & reportType)

        Next

        'Ordena la lista de reportes por orden de realizacion
        listCode.Sort()

        Dim i As Integer
        For i = 0 To listCode.Count - 1

            'Separa el codigo de fecha y hora del tipo de regisgro
            reportLine = listCode(i).Split(vbTab)

            'Lee la fecha y hora de la linea actual
            actualDATE = DecodeDATE(listCode(i).Substring(0, 12))

            'Transforma esa fecha en string para mejor manejo
            runDate = actualDATE.Year & actualDATE.Month & actualDATE.Day



            If lastDate = "" Then lastDate = runDate




            'Se supone que está empezando y que el primero debe _
            'ser un IN, entonces establecemos el último como un
            'OUT para que no de error.

            Select Case Trim(UCase(reportLine(1)))
                Case "IN"
                    runType = 0
                Case "OUT"
                    runType = 1
            End Select

            'MsgBox(listCode(i) & " -> " & reportLine(1) & " (" & runType & ") - > " & runDate & vbCrLf & vbCrLf & "lastType -> " & lastType)

            If runDate = lastDate Then

                If lastType <> runType Then
                    listCode(i) &= vbTab & "[OK]" 'Esta OK porque el tipo de registro cambia
                Else
                    listCode(i) &= vbTab & "[ERROR]" 'Esta mal porque el registro es el mismo
                End If

            Else

                If lastType = 0 Then
                    If actualDATE.Hour = 0 Or actualDATE.Hour = 1 Then

                        'Si la hora de este fichaje se encuentra entra las 00 y las 01 de la
                        'madrugada se entiende que puede haber un cierre a esa hora

                        If lastType <> runType Then
                            listCode(i) &= vbTab & "[OK]" 'Esta OK porque el tipo de registro cambia
                        Else
                            listCode(i) &= vbTab & "[ERROR]" 'Esta mal porque el registro es el mismo
                        End If

                    Else

                        'Si la hora no se encuentra entre las 00 y las 01 entonces se considera
                        'que no ha cerrado el dia anterior

                        listCode(i - 1) &= vbTab & "[FALTA CIERRE DE DIA]"

                        'Empieza comprobación de un nuevo dia
                        lastType = 1

                        If lastType <> runType Then
                            listCode(i) &= vbTab & "[OK]" 'Esta OK porque el tipo de registro cambia
                        Else
                            listCode(i) &= vbTab & "[ERROR]" 'Esta mal porque el registro es el mismo
                        End If

                    End If

                Else

                    If lastType <> runType Then
                        listCode(i) &= vbTab & "[OK]" 'Esta OK porque el tipo de registro cambia
                    Else
                        listCode(i) &= vbTab & "[ERROR]" 'Esta mal porque el registro es el mismo
                    End If

                End If

            End If

            'Actualiza estado de ultimos registros leidos
            lastType = runType
            lastDate = runDate

        Next


        'hacer calculos de horas trabajadas entre cada IN y OUT si no hay OUT correspondiente entonced error
        'en horas trabajadas

        'hacer algoritmo que comprueba x dias libres



        TextBox1.Lines = listCode.ToArray

    End Sub

    Private Function CodeDATE(sTime As String, sDate As String) As String
        Dim tHour As String
        Dim tMinute As String
        Dim tDay As String
        Dim tMonth As String
        Dim tYear As String
        Dim tString As String

        Dim splitTime() As String
        Dim splitDate() As String

        ' MessageBox.Show(sTime & "   -   " & sDate)

        splitTime = sTime.Split(":")
        splitDate = sDate.Split("-")

        tHour = splitTime(0)
        tMinute = splitTime(1)

        'Este apartado cambiará dependiendo de la configuracion regional
        tDay = splitDate(2)
        tMonth = splitDate(1)
        tYear = splitDate(0)

        If tHour.Trim.Length = 1 Then tHour = "0" & tHour
        If tMinute.Trim.Length = 1 Then tMinute = "0" & tMinute
        If tDay.Trim.Length = 1 Then tDay = "0" & tDay
        If tMonth.Trim.Length = 1 Then tMonth = "0" & tMonth

        tString = tYear & tMonth & tDay & tHour & tMinute

        If tString.Length <> 12 Then
            Return "ERROR"
        Else
            Return tString
        End If

    End Function

    Private Function DecodeDATE(tDateCodified As String) As DateTime
        Dim tDate As String
        Dim tHour As String
        Dim tMinute As String
        Dim tDay As String
        Dim tMonth As String
        Dim tYear As String

        tYear = tDateCodified.Substring(0, 4)
        tMonth = tDateCodified.Substring(4, 2)
        tDay = tDateCodified.Substring(6, 2)
        tHour = tDateCodified.Substring(8, 2)
        tMinute = tDateCodified.Substring(10, 2)

        'MessageBox.Show(tHour & ":" & tMinute & "  " & tDay & "/" & tMonth & "/" & tYear)

        Dim resultDate As DateTime = New DateTime(Int32.Parse(tYear), Int32.Parse(tMonth), Int32.Parse(tDay), Int32.Parse(tHour), Int32.Parse(tMinute), 0)


        Return resultDate


    End Function

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub
End Class
