Imports System.IO
Imports System.Xml
Imports System.Text
Imports System.Net
Imports System.Globalization
Imports System.Threading
Imports System.Net.Mail
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.Data.SqlClient
Imports System.Text.RegularExpressions
Module WebHotelier
    Public Class RoomRateTypes
        Dim link As String

        Dim user As String
        Dim password As String
        Dim property_id As String
        Dim connection_string As String

        Structure rate
            Dim day As Date
            Dim amount As String
        End Structure


        Dim id As String
        Dim created_at As String
        Dim updated_at As String
        Dim roomratetype_id As String
        Dim channel_key As String
        Dim channel_id As String
        Dim booking_id As String
        Dim room_booking_id As String
        Dim booking_date As String
        Dim modified_date As String
        Dim status As String
        Dim room_name As String
        Dim confirmed As Byte
        Dim checkin As String
        Dim checkout As String
        Dim mealplantype As String
        Dim guests As String
        Dim total_amount As String
        Dim total_taxes As String
        Dim commission As String
        Dim lead_name As String
        Dim lead_email As String
        Dim state As String
        Dim phones As String
        Dim manual_adults As String
        Dim manual_children As String
        Dim englishCulture As New System.Globalization.CultureInfo("en-US", False)
        Dim greekCulture As New System.Globalization.CultureInfo("el-GR", False)
        Dim roomMap As New Dictionary(Of String, String)
        Dim roomCode As String = Nothing
        Dim from As String '= Me.DbhotelDataSet.Mail(0).ffrom
        Dim subject As String ' = Me.DbhotelDataSet.Mail(2).subject
        Dim smtpServer As String ' = Me.DbhotelDataSet.Mail(0).smtpServer
        Dim smtpUsername As String '= Me.DbhotelDataSet.Mail(0).smtpUsername
        Dim smtpPassword As String ' = Me.DbhotelDataSet.Mail(0).smtpPassword
        Dim body As String '
        Dim dataset As New dbhotelDataSet()
        Dim dataset1 As New dbhotelDataSet1()
        Dim boardMap As New Dictionary(Of Integer, String)


        Public Sub New(ByVal conn As String, ByVal lnk As String, ByVal usr As String, ByVal pwd As String, ByVal prop_id As String)
            connection_string = conn
            link = lnk
            user = usr
            password = pwd
            property_id = prop_id

            ' Define a Dictionary object to map room names to room codes


            ' Add some entries to the map
            roomMap.Add("MAIL", "MELIA")
            roomMap.Add("PERS", "PERSI")
            roomMap.Add("THOI", "THOI")
            roomMap.Add("PUE", "PUEBLO")
            roomMap.Add("EEAN", "EEANTH")

            boardMap.Add(0, "No board or N/A")
            boardMap.Add(1, "All inclusive")
            boardMap.Add(2, "American")
            boardMap.Add(3, "Bed & breakfast")
            boardMap.Add(4, "Buffet breakfast")
            boardMap.Add(5, "Caribbean breakfast")
            boardMap.Add(6, "Continental breakfast")
            boardMap.Add(7, "English breakfast")
            boardMap.Add(8, "European plan")
            boardMap.Add(9, "Family plan")
            boardMap.Add(10, "Full board")
            boardMap.Add(11, "Full breakfast")
            boardMap.Add(12, "Half board")
            boardMap.Add(13, "As brochured")
            boardMap.Add(14, "Room only")
            boardMap.Add(15, "Self catering")
            boardMap.Add(16, "Bermuda")
            boardMap.Add(17, "Dinner bed and breakfast plan")
            boardMap.Add(18, "Family American")
            boardMap.Add(19, "Breakfast")
            boardMap.Add(20, "Modified")
            boardMap.Add(21, "Lunch")
            boardMap.Add(22, "Dinner")
            boardMap.Add(23, "Breakfast & lunch")

        End Sub
        'Public Sub New()
        '    link = "testLinkl"
        '    user = "domisi"
        '    password = "stavros"
        '    property_id = "propID"
        '    response()
        'End Sub
        Public Function StopSells(room As String, fromDate As String, toDate As String, stopsell As Boolean) As Boolean

            If roomMap.TryGetValue(room, roomCode) Then
                Console.WriteLine($"The room code for {room} is {roomCode}.")
                Dim roomName As String = roomMap.FirstOrDefault(Function(x) x.Value = roomCode).Key
            End If


            If roomCode IsNot Nothing Then
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12

                Dim request As HttpWebRequest = HttpWebRequest.Create(link)
                request.Method = "POST"

                ' Add the basic authentication credentials to the request headers
                request.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(user + ":" + password)))
                request.UserAgent = "en-gb;q=0.9, el"
                ' Add the Accept header with the application/json
                request.Accept = "application/json"
                request.ContentType = "application/json"
                ' Create an object to hold the payload data
                Dim payload As New With {
    Key .roomCode = New List(Of Object) From {
        New With {
            .from = DateTime.Parse(fromDate).ToString("yyyy-MM-dd"),
            .to = DateTime.Parse(toDate).ToString("yyyy-MM-dd"),
            .stopsell = If(stopsell, "1", "0")
        }
    }
}


                'MsgBox(payload.ToString)
                ' Serialize the object to JSON
                Dim jsonBody As String = JsonConvert.SerializeObject(payload).Replace("roomCode", roomCode)

                MsgBox(jsonBody)

                Using writer As StreamWriter = New StreamWriter(request.GetRequestStream())
                    writer.Write(jsonBody)
                    writer.Flush()

                    Dim responseText As String = ""
                    Dim httpCode As Integer
                    Try

                        Dim response As HttpWebResponse = request.GetResponse()
                        httpCode = CInt(response.StatusCode)
                        If httpCode = 200 Then
                            Return True
                        Else
                            Return False
                        End If
                        Return True
                    Catch ex As WebException
                        Dim response As HttpWebResponse = ex.Response
                        httpCode = CInt(response.StatusCode)
                        If httpCode <> 200 Then
                            Using streamReader As New StreamReader(response.GetResponseStream())
                                responseText = streamReader.ReadToEnd()

                                Dim errorObject As JObject = JObject.Parse(responseText)
                                Dim errorCode As String = CStr(errorObject("error_code"))
                                Dim errorMessage As String = CStr(errorObject("error_msg"))
                                Console.WriteLine("HTTP Code: " & httpCode)
                                Console.WriteLine("Error Code: " & errorCode)
                                Console.WriteLine("Error Message: " & errorMessage)
                            End Using

                            Return False
                        End If

                    End Try
                End Using

            End If



        End Function
        Public Sub retrieve_booking(ByVal bookingID As Long)
            Dim sb As New StringBuilder
            If fortosi_reservation("https://rest.reserve-online.net/reservation/", bookingID, "NEW", sb) Then

            Else
                MsgBox("Η Κράτηση " + bookingID.ToString + " δεν μπόρεσε να φορρτωθεί στο σύστημα")
            End If
        End Sub
        Public Sub list_pending_bookings()
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
            Dim request As HttpWebRequest = HttpWebRequest.Create(link + "new")
            ' Dim request As HttpWebRequest = HttpWebRequest.Create(link + "35799743")
            request.Method = "GET"

            ' Add the basic authentication credentials to the request headers
            request.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(user + ":" + password)))
            request.UserAgent = "en-gb;q=0.9, el"
            ' Add the Accept header with the application/json
            request.Accept = "application/json"

            Dim responseText As String = ""
            Dim httpCode As Integer
            Dim index As Int16
            Dim fileName As String
            Try

                Dim response As HttpWebResponse = request.GetResponse()

                Using reader As New StreamReader(response.GetResponseStream())
                    responseText = reader.ReadToEnd()

                    ' Write the response to a local JSON file
                    ' Write the response to a local JSON file
                    ' Write the response to a local JSON file
                    Try
                        Dim folderPath As String = "C:\winfo\Reservations\"

                        If Not String.IsNullOrEmpty(folderPath) Then
                            ' Generate a timestamp for the file name
                            'Dim timestamp As String = DateTime.Now.ToString("yyyyMMdd_HHmmss")
                            Dim timestamp As String = DateTime.Now.ToString("ddMMyyyy_HHmmss")
                            fileName = "list_pending_" & timestamp & ".json"

                            ' Check if the folder exists, and create it if it doesn't
                            If Not Directory.Exists(folderPath) Then
                                Directory.CreateDirectory(folderPath)
                            End If

                            ' Create the complete file path
                            Dim filePath As String = Path.Combine(folderPath, fileName)

                            ' Write the response text to the file
                            File.WriteAllText(filePath, responseText)

                            ' File write operation completed successfully
                            Console.WriteLine("File written successfully.")
                        Else
                            Console.WriteLine("Invalid invoice type.")
                        End If
                    Catch ex As DirectoryNotFoundException
                        ' Handle the exception
                        Console.WriteLine("The specified directory does not exist.")
                    Catch ex As Exception
                        ' Handle any other exceptions
                        Console.WriteLine("An error occurred: " + ex.Message)
                    End Try



                    'Dim fileName As String = "list_pending.json"
                    'Dim filePath As String = Path.Combine(Environment.CurrentDirectory, fileName)
                    'File.WriteAllText(filePath, responseText)

                    ' Parse the JSON response
                    Dim jsonObject As Linq.JObject = JObject.Parse(responseText)

                    Dim reservations As JArray = jsonObject.SelectToken("data.reservations")

                    'Dim reservations As JArray = jsonObject.SelectToken("data")

                    Dim sb As New StringBuilder

                    For Each reservation As JObject In reservations
                        Dim id As Integer = CType(reservation("id"), Integer)
                        Dim timestamp As String = reservation("timestamp").ToString()
                        Dim syncType As String = reservation("syncType").ToString()


                        'If Not mark_res_as_sync(link, id) Then

                        '    MsgBox("Αποτυχία συγχρονισμού με Webhotelier!: " + id.ToString, MsgBoxStyle.Exclamation)
                        'End If
                        If fortosi_reservation(link, id, syncType, sb) Then

                            If Not mark_res_as_sync(link, id) Then

                                MsgBox("Αποτυχία συγχρονισμού με Webhotelier!: " + id.ToString, MsgBoxStyle.Exclamation)
                            End If



                        End If

                        Console.WriteLine("id: " & id & "; timestamp: " & timestamp & "; syncType: " & syncType)



                    Next
                    If Not sb.ToString.Equals("") Then
                        MsgBox(String.Format(sb.ToString()))
                    Else
                        MsgBox("Δεν βρέθηκαν νέες κρατήσεις! ")
                    End If
                    ' Access the data
                    'Dim imerominies As JArray = jsonObject.SelectToken("allot")


                    '' Loop through the array
                    'For Each imerominia As JObject In imerominies
                    '    Dim allot As String = imerominia("code").ToString()

                    '    MsgBox(allot)
                    '    'If active Then
                    '    '    execute_insert_roomratetype(id, name, 0)
                    '    'Else
                    '    '    execute_insert_roomratetype(id, name, 1)
                    '    'End If

                    'Next

                    ' Loop through the array

                End Using
            Catch ex As WebException
                Dim response As HttpWebResponse = ex.Response
                httpCode = CInt(response.StatusCode)
                If httpCode <> 200 Then
                    Using streamReader As New StreamReader(response.GetResponseStream())
                        responseText = streamReader.ReadToEnd()

                        Dim errorObject As JObject = JObject.Parse(responseText)
                        Dim errorCode As String = CStr(errorObject("error_code"))
                        Dim errorMessage As String = CStr(errorObject("error_msg"))
                        Console.WriteLine("HTTP Code: " & httpCode)
                        Console.WriteLine("Error Code: " & errorCode)
                        Console.WriteLine("Error Message: " & errorMessage)
                    End Using


                End If

            End Try
        End Sub


        Function fortosi_reservation(ByVal link_reserv As String, ByVal id_res As Int64, ByVal syncType As String, ByRef sb As StringBuilder) As Boolean
            Dim dwmatio As String = ""
            'Dim sb As New StringBuilder
            Dim resp As MsgBoxResult
            Dim threadDirections As Threading.Thread
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
            Dim request As HttpWebRequest = HttpWebRequest.Create(link_reserv + id_res.ToString)
            request.Method = "GET"

            ' Add the basic authentication credentials to the request headers
            request.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(user + ":" + password)))
            request.UserAgent = "en-gb;q=0.9, el"
            ' Add the Accept header with the application/json
            request.Accept = "application/json"

            Dim responseText As String = ""
            Dim httpCode As Integer
            Try

                Dim response As HttpWebResponse = request.GetResponse()

                Using reader As New StreamReader(response.GetResponseStream())
                    responseText = reader.ReadToEnd()

                    ' Write the response to a local JSON file
                    Dim folderPath As String = "C:\winfo\Reservations\"
                    Dim fileName As String = id_res.ToString() & ".json"
                    Dim filePath As String = Path.Combine(folderPath, fileName)

                    File.WriteAllText(filePath, responseText)


                    ' Parse the JSON response
                    Dim jsonObject As Linq.JObject = JObject.Parse(responseText)


                    Dim reservation As Reservation = JsonConvert.DeserializeObject(Of Reservation)(jsonObject("data").ToString())

                    id = reservation.id
                    If reservation.roomStay.roomType IsNot Nothing Then
                        dwmatio = roomMap.FirstOrDefault(Function(x) x.Value = reservation.roomStay.roomType).Key
                    End If

                    created_at = reservation.bookInfo.bookDate.ToString
                    updated_at = reservation.bookInfo.bookDate.ToString
                    roomratetype_id = reservation.roomStay.rateID

                    channel_key = reservation.bookInfo.source
                    booking_id = reservation.bookInfo.bookingCode
                    booking_date = reservation.bookInfo.bookDate.ToString

                    modified_date = reservation.bookInfo.bookDate.ToString

                    room_booking_id = reservation.bookInfo.source

                    'If reservation.status = 1 Then
                    '    status = "Confirmed"
                    'Else
                    '    status = "Canceled"
                    'End If

                    'enumerated values:NEW, MOD, CL 
                    status = syncType

                    room_name = reservation.roomStay.roomName

                    If reservation.status = 1 Then
                        confirmed = 1 'Confirmed
                    Else
                        confirmed = 0 ' "Canceled"
                    End If

                    checkin = reservation.roomStay.from
                    checkout = reservation.roomStay.[to]


                    If String.IsNullOrEmpty(reservation.roomStay.board) Then
                        mealplantype = "rr"
                    Else
                        If reservation.roomStay.board = 14 Then
                            mealplantype = "rr"
                        Else
                            mealplantype = "bb"
                        End If

                    End If

                    If reservation.rooms IsNot Nothing Then
                        guests = reservation.rooms(0).Adults.ToString + "+" + reservation.rooms(0).Children.ToString
                    End If

                    'total_amount = Single.Parse(reservation.pricing.price, englishCulture).ToString("N")
                    'total_taxes = Single.Parse(reservation.pricing.taxes, englishCulture).ToString("N")

                    lead_name = reservation.clientInfo.FirstName + " " + reservation.clientInfo.LastName
                    lead_email = reservation.clientInfo.Email

                    state = reservation.clientInfo.Country
                    phones = reservation.clientInfo.Tel

                    Dim roomList As List(Of Room) = reservation.rooms

                    Dim rateList As List(Of RoomRate) = roomList(0).Rates
                    Dim requests() As String = Nothing

                    Dim rates() As rate
                    ReDim rates(-1)
                    Dim r As Int16 = 0

                    For Each rate As RoomRate In rateList
                        ReDim Preserve rates(r)

                        rates(r).day = rate.[Date]
                        If rate.Price >= rate.price_with_tax Then
                            rates(r).amount = Single.Parse(rate.Price, greekCulture).ToString("N")
                        Else
                            rates(r).amount = Single.Parse(rate.price_with_tax, greekCulture).ToString("N")
                        End If


                        Console.WriteLine("AMOUNT per DAY: " & rates(r).amount)
                        r += 1
                    Next
                    total_amount = Single.Parse(roomList(0).Price, greekCulture).ToString("N")
                    Console.WriteLine("SYNOLIKO PRICE: " & total_amount)
                    total_taxes = Single.Parse(reservation.pricing.taxes, greekCulture).ToString("N")
                    Console.WriteLine("SYNOLIKTAXES : " & total_taxes)


                    Dim boardType As String = boardMap.FirstOrDefault(Function(x) x.Key = reservation.roomStay.board).Value
                    If Not String.IsNullOrEmpty(boardType) Then
                        ReDim Preserve requests(0)
                        requests(0) = boardType
                    End If

                    If Not String.IsNullOrEmpty(reservation.clientInfo.Remarks) Then
                        If requests Is Nothing Then
                            ReDim Preserve requests(0)
                            requests(0) = reservation.clientInfo.Remarks
                        Else
                            ReDim Preserve requests(UBound(requests) + 1)
                            requests(UBound(requests)) = reservation.clientInfo.Remarks
                        End If
                    End If

                    If Not String.IsNullOrEmpty(reservation.special_requests) Then
                        If requests Is Nothing Then
                            ReDim Preserve requests(0)
                            requests(0) = reservation.special_requests
                        Else
                            ReDim Preserve requests(UBound(requests) + 1)
                            requests(UBound(requests)) = reservation.special_requests
                        End If
                    End If


                    Dim guestList As New List(Of String)
                    If reservation.guestNames IsNot Nothing Then

                        guestList = reservation.guestNames
                        For Each name As String In guestList
                            Console.WriteLine(name)
                        Next

                    Else
                        guestList.Add(lead_name)
                    End If
                    Dim additionalFieldsList As List(Of AdditionalFields) = reservation.additional_fields
                    ' Initialize a list to store the ages of children
                    Dim agesOfChildren As List(Of Int16) = New List(Of Int16)()

                    ' Check if 'additional_fields' contains information about children
                    If additionalFieldsList IsNot Nothing AndAlso additionalFieldsList.Count > 0 Then
                        For Each additionalField As AdditionalFields In additionalFieldsList
                            If additionalField.Code = "CHANNEL_NOTES" Then
                                ' Extract the string containing the ages of children from 'additionalField'
                                Dim agesSubstring As String = additionalField.Value

                                ' Check if 'agesSubstring' contains the keyword "Ages:"
                                Dim startIndex As Integer = agesSubstring.IndexOf("Ages:")
                                If startIndex = -1 Then
                                    startIndex = agesSubstring.IndexOf("Age:")
                                End If
                                If startIndex >= 0 Then
                                    agesSubstring = agesSubstring.Substring(startIndex + 5) ' Skip "Ages:"

                                    ' Remove " years old" and the parenthesis from the agesSubstring
                                    agesSubstring = agesSubstring.Replace(" years old)", "")

                                    ' Split the agesSubstring by comma to get individual ages
                                    Dim agesArray As String() = agesSubstring.Split(","c)

                                    ' Parse the ages as integers and add them to the list
                                    For Each age As String In agesArray
                                        If Integer.TryParse(age.Trim(), age) Then
                                            agesOfChildren.Add(age)
                                        End If
                                    Next
                                End If

                                Exit For ' Exit loop once 'CHANNEL_NOTES' code is found
                            End If
                        Next
                    End If



                    For Each age As Integer In agesOfChildren
                        Console.WriteLine("Child age: " & age)
                    Next
                    Dim ok As Byte
                    Dim kwdNeasKratisis As Integer = 0
                    Dim arNeasKratisis As Int16 = 0


                    If syncType.Equals("NEW") Then
                        ok = execute_fortosi_kratisi_transaction(connection_string, id, DateTime.Parse(modified_date), channel_key, booking_id,
                                                                      room_booking_id, roomratetype_id, DateTime.Parse(checkin), DateTime.Parse(checkout),
                                                                      mealplantype, guests, total_amount, total_taxes, status, confirmed, lead_email, state, phones, lead_name, guestList.ToArray,
                                                                      rates, requests, dwmatio, agesOfChildren, kwdNeasKratisis, arNeasKratisis)
                        If ok = 1 Then
                            sb.AppendLine("ΕΠΙΤΥΧΗΣ ΕΙΣΑΓΩΓΗ ID:" + id + " status:" + status + " CHANNEL:  " + channel_key + "  ROOM: " + If(dwmatio IsNot Nothing, dwmatio, "N/A") + "  NAME:" + lead_name + " ARRIVAL: " + DateTime.Parse(checkin).ToString("dd/MM/yyyy") + " DEPARTURE: " + DateTime.Parse(checkout).ToString("dd/MM/yyyy") + " TOTAL: " + total_amount + vbNewLine)
                            'sb.AppendLine("ΕΠΙΤΥΧΗΣ ΕΙΣΑΓΩΓΗ ID:" + If(id IsNot Nothing, id.ToString(), "N/A") + " status:" + If(status IsNot Nothing, status.ToString(), "N/A") + " CHANNEL:  " + If(channel_key IsNot Nothing, channel_key, "N/A") + "  ROOM: " + If(dwmatio IsNot Nothing, dwmatio, "N/A") + "  NAME:" + If(lead_name IsNot Nothing, lead_name, "N/A") + " ARRIVAL: " + If(DateTime.TryParse(checkin, Nothing, Nothing, outDate) Then outDate.ToString("dd/MM/yyyy") Else "N/A" + " DEPARTURE: " + If(DateTime.TryParse(checkout, outDate), outDate.ToString("dd/MM/yyyy"), "N/A") + " TOTAL: " + If(total_amount IsNot Nothing, total_amount, "N/A") + vbNewLine)

                            Try
                                Dim calender As New GoogleCalendarNew(connection_string, kwdNeasKratisis, arNeasKratisis, lead_name, CType(checkin, Date), CType(checkout, Date), dwmatio, dwmatio, "", channel_key)
                                calender.create_new_entry()

                                calender.set_calendarid_thalasses(1)
                                calender.create_new_entry()

                                'Dim calender As New GoogleCalendar(booking_id, lead_name, CType(checkin, Date), CType(checkout, Date), dwmatio, dwmatio, "", channel_key)
                                'calender.send_entry()

                                'calender = New GoogleCalendar(booking_id, lead_name, CType(checkin, Date), CType(checkout, Date), "THLS", dwmatio, "", channel_key)
                                'calender.send_entry()




                            Catch ex As Exception
                                MsgBox(" Παρουσιάστηκε σφάλμα κατά την Ενημέρωση του Google Calendar !", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                            End Try
                            If lead_email <> "" And Not dwmatio.Equals("") Then 'AndAlso DateTime.Parse(checkin).Subtract(System.DateTime.Today.Date).Days < 5

                                resp = MsgBox("Αποστολή email σε " + lead_name + " ?" + ChrW(13) + "  CHANNEL: " + channel_key + ChrW(13) + "  ROOM:" + dwmatio + ChrW(13) + "  ARRIVAL: " + DateTime.Parse(checkin).ToString("dd/MM/yyyy") + ChrW(13) + "  DEPARTURE: " + DateTime.Parse(checkout).ToString("dd/MM/yyyy"), MsgBoxStyle.YesNo, "winfo\nikEl.")
                                If resp = MsgBoxResult.Yes Then
                                    Dim data As String = dwmatio + "+" + lead_email + "+" + lead_name
                                    threadDirections = SendMailwithDirections(data)
                                End If
                            ElseIf lead_email = "" Then
                                MsgBox("Δεν υπάρχει email : " + status + " " + channel_key + " " + lead_name + " " + checkin.ToString + " " + checkout.ToString, MsgBoxStyle.Exclamation)

                            End If
                            Try
                                resp = MsgBox(" Αποστολή email σε Πρακτορεία για ενημέρωση;", MsgBoxStyle.YesNo, "winfo\nikEl.")
                                If resp = MsgBoxResult.Yes Then
                                    SendMailPrakt(dwmatio, 1, CType(checkin, Date), CType(checkout, Date))
                                End If
                            Catch ex As Exception
                                MsgBox(" Παρουσιάστηκε σφάλμα κατά την Ενημέρωση των Πρακτορείων!", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                            End Try

                            dwmatio = ""
                            Return True
                        Else
                            Return False

                        End If
                    ElseIf syncType.Equals("MOD") Then
                        Dim kwdikosDelKrat As Int64 = 0
                        Dim villa As String = ""
                        ok = execute_delete_kratisi(connection_string, DateTime.Parse(modified_date), id, kwdikosDelKrat, villa)
                        If ok = 0 Then
                            sb.AppendLine("Αποτυχία διαγραφής σε κατάσταση MODIFICATION. Κίνδυνος ΔΙΠΛΗΣ ΚΡΑΤΗΣΗΣ! ID:" + id + " " + status + " " + channel_key + " " + lead_name + " " + checkin.ToString + " " + checkout.ToString)

                        End If
                        'If ok <> 2 Then

                        ok = execute_fortosi_kratisi_transaction(connection_string, id, DateTime.Parse(modified_date), channel_key, booking_id,
                                                                      room_booking_id, roomratetype_id, DateTime.Parse(checkin), DateTime.Parse(checkout),
                                                                      mealplantype, guests, total_amount, total_taxes, status, confirmed, lead_email, state, phones, lead_name, guestList.ToArray,
                                                                      rates, requests, dwmatio, agesOfChildren, kwdNeasKratisis, arNeasKratisis)
                        If ok = 1 Then
                            Dim room As String = ""
                            Dim afixi As Date
                            Dim anaxwrisi As Date
                            sb.AppendLine("ΕΠΙΤΥΧΗΣ ΕΙΣΑΓΩΓΗ ID:" + id + " STATUS: " + status + " CHANNEL: " + channel_key + "  BOOKING_ID: " + id + "  ROOM:" + dwmatio + "  NAME:" + lead_name + " ARRIVAL: " + DateTime.Parse(checkin).ToString("dd/MM/yyyy") + " DEPARTURE: " + DateTime.Parse(checkout).ToString("dd/MM/yyyy") + " TOTAL: " + total_amount + vbNewLine)

                            'TEST SQL SERVER 
                            Using connection As New SqlConnection(connection_string)
                                connection.Open()

                                Using command As New SqlCommand()
                                    command.Connection = connection
                                    command.Parameters.AddWithValue("@id", id)
                                    command.Parameters.AddWithValue("@status", "CL")
                                    command.CommandText = "SELECT TOP 1 modified_date, status, room_booking_id, afixi, anaxwrisi FROM Reservations WHERE (id = @id) AND (status = @status) ORDER BY modified_date DESC"

                                    Dim myReader As SqlDataReader = command.ExecuteReader(CommandBehavior.SingleResult)
                                    Try
                                        If myReader.HasRows AndAlso myReader.Read() Then
                                            room = myReader.GetString(2)
                                            afixi = myReader.GetDateTime(3)
                                            anaxwrisi = myReader.GetDateTime(4)

                                            ' Process the retrieved data '
                                        End If
                                    Finally
                                        myReader.Close()
                                        command.Parameters.Clear()
                                    End Try
                                End Using

                                connection.Close()
                            End Using
                            Try

                                Dim calender As New GoogleCalendarNew(connection_string, kwdikosDelKrat, 0, "", DateTime.Parse(modified_date), DateTime.Parse(modified_date), villa, villa, "", "")
                                'calender.DeleteEvent("mv1rt76rgmgd63jg0d83st5tlk@group.calendar.google.com", "ia5006i4jupp2t42ihpuvdbi2s")
                                calender.delete_entry()

                                calender.set_calendarid_thalasses(2)
                                calender.delete_entry()


                                Dim newcalender As New GoogleCalendarNew(connection_string, kwdNeasKratisis, arNeasKratisis, lead_name, CType(checkin, Date), CType(checkout, Date), dwmatio, dwmatio, "", channel_key)

                                newcalender.create_new_entry()

                                newcalender.set_calendarid_thalasses(1)
                                newcalender.create_new_entry()




                            Catch ex As Exception
                                MsgBox(" Παρουσιάστηκε σφάλμα κατά την Ενημέρωση του Google Calendar !", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                            End Try
                            'Try


                            '    If Not room.Equals("") Then

                            '        Dim calender As New GoogleCalendar("", "", afixi, anaxwrisi, room, room, "", "")
                            '        calender.delete_Calendar()

                            '        calender.set_values(id.ToString, "webhotelier", CType(checkin, Date), CType(checkout, Date), dwmatio, dwmatio, "", channel_key)
                            '        calender.create_NewEntry()

                            '        calender = New GoogleCalendar("", "", afixi, anaxwrisi, "THLS", room, "", "")
                            '        calender.delete_Calendar()

                            '        calender.set_values(id.ToString, "webhotelier", CType(checkin, Date), CType(checkout, Date), "THLS", dwmatio, "", channel_key)
                            '        calender.create_NewEntry()
                            '    Else
                            '        MsgBox(" Παρουσιάστηκε σφάλμα κατά την Ενημέρωση του Google Calendar " + dwmatio, MsgBoxStyle.Exclamation, "winfo\nikEl.")
                            '    End If




                            'Catch ex As Exception
                            '    MsgBox(" Παρουσιάστηκε σφάλμα κατά την Ενημέρωση του Google Calendar !" + dwmatio, MsgBoxStyle.Exclamation, "winfo\nikEl.")
                            'End Try
                            If lead_email <> "" And Not dwmatio.Equals("") Then 'AndAlso DateTime.Parse(checkin).Subtract(System.DateTime.Today.Date).Days < 5
                                resp = MsgBox("Αποστολή email σε " + lead_name + " ?" + ChrW(13) + "  CHANNEL: " + channel_key + ChrW(13) + "  ROOM:" + dwmatio + ChrW(13) + "  ARRIVAL: " + DateTime.Parse(checkin).ToString("dd/MM/yyyy") + ChrW(13) + "  DEPARTURE: " + DateTime.Parse(checkout).ToString("dd/MM/yyyy"), MsgBoxStyle.YesNo, "winfo\nikEl.")
                                If resp = MsgBoxResult.Yes Then
                                    Dim data As String = dwmatio + "+" + lead_email + "+" + lead_name
                                    threadDirections = SendMailwithDirections(data)
                                End If

                            End If
                            dwmatio = ""
                            Return True
                        Else
                            sb.AppendLine("Αποτυχία εισαγωγής σε κατάσταση MODIFICATION. Πιθανώς έχει γίνει ήδη εισαγωγή ID: " + id + " " + status + " " + channel_key + " " + lead_name + " " + checkin.ToString + " " + checkout.ToString)
                        End If
                        'End If
                    ElseIf syncType.Equals("CL") Then
                        Dim kwdikosDelKrat As Int64 = 0
                        Dim villa As String = ""
                        ok = execute_delete_kratisi(connection_string, DateTime.Parse(modified_date), id, kwdikosDelKrat, villa)

                        If ok = 1 Then
                            sb.AppendLine("ΕΠΙΤΥΧΗΣ ΔΙΑΓΡΑΦΗ ID:" + id + "STATUS: " + status + " CHANNEL: " + channel_key + "  ROOM: " + dwmatio + "  NAME:" + lead_name + " ARRIVAL: " + DateTime.Parse(checkin).ToString("dd/MM/yyyy") + " DEPARTURE: " + DateTime.Parse(checkout).ToString("dd/MM/yyyy") + " TOTAL: " + total_amount + vbNewLine)
                            'TEST SQL SERVER 
                            Dim calender As New GoogleCalendarNew(connection_string, kwdikosDelKrat, 0, "", DateTime.Parse(modified_date), DateTime.Parse(modified_date), villa, villa, "", "")
                            'calender.DeleteEvent("mv1rt76rgmgd63jg0d83st5tlk@group.calendar.google.com", "ia5006i4jupp2t42ihpuvdbi2s")
                            calender.delete_entry()

                            calender.set_calendarid_thalasses(2)
                            calender.delete_entry()
                            'Try

                            '    Dim calender As New GoogleCalendar("", "", CType(checkin, Date), CType(checkout, Date), dwmatio, dwmatio, "", "")
                            '    calender.delete_entry()

                            '    calender = New GoogleCalendar("", "", CType(checkin, Date), CType(checkout, Date), "THLS", dwmatio, "", "")
                            '    calender.delete_entry()


                            'Catch ex As Exception
                            '    MsgBox(" Παρουσιάστηκε σφάλμα κατά την Ενημέρωση του Google Calendar !", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                            'End Try

                            resp = MsgBox(" Ενημέρωση Πρακτορείων για διαγραφή κράτησης? ROOM: " + dwmatio, MsgBoxStyle.YesNo, "winfo\nikEl.")
                            If resp = MsgBoxResult.Yes Then
                                SendMailPrakt(dwmatio, 2, CType(checkin, Date), CType(checkout, Date))

                            End If
                            dwmatio = ""
                            Return True
                        ElseIf ok = 0 Then
                            sb.AppendLine("Αποτυχία διαγραφής κράτησης για ΒΙΛΑ: " + dwmatio + " ID:" + id + " CHANNEL:" + channel_key + " " + lead_name + " " + checkin.ToString + " " + checkout.ToString)
                        End If



                    End If



                    'Dim id As Integer = CType(reservation("id"), Integer)
                    'Dim channelstream As Boolean = reservation("channelstream")


                    'Console.WriteLine("Type: " & reservation.roomStay.roomType & "; checkin: " & reservation.roomStay.from & "; price: " & reservation.pricing.price & "; clientinfo_lastname: " & reservation.clientInfo.LastName)



                End Using
            Catch ex As WebException
                Dim response As HttpWebResponse = ex.Response
                httpCode = CInt(response.StatusCode)

                If httpCode <> 200 Then
                    Using streamReader As New StreamReader(response.GetResponseStream())
                        responseText = streamReader.ReadToEnd()

                        Dim errorObject As JObject = JObject.Parse(responseText)
                        Dim errorCode As String = CStr(errorObject("error_code"))
                        Dim errorMessage As String = CStr(errorObject("error_msg"))
                        Console.WriteLine("HTTP Code: " & httpCode)
                        Console.WriteLine("Error Code: " & errorCode)
                        Console.WriteLine("Error Message: " & errorMessage)
                    End Using


                End If
                Return False
            End Try
        End Function

        Sub SendMailPrakt(ByVal vila As String, ByVal flag As Byte, ByVal apo As Date, ByVal mexri As Date)
            Dim perigrafi As String

            perigrafi = get_perigrafi_vilas(vila)

            Dim parameter As String
            parameter = vila + "$" + perigrafi + "$" + apo + "$" + mexri

            If flag = 1 Then
                Dim theThread _
           As New Threading.Thread(AddressOf SendMailtoPraktoreia)
                theThread.Start(parameter)
            ElseIf flag = 2 Then
                Dim theThread _
        As New Threading.Thread(AddressOf SendMailtoPraktoreiaCancel)
                theThread.Start(parameter)
            End If

        End Sub
        Private Sub SendMailtoPraktoreia(ByVal parameter As String)
            Dim from, smtpServer, smtpUsername, smtpPassword, subject, allbody As String
            allbody = ""
            Dim mesage As String = "mails to agencies: "
            Dim body() As String
            Dim param() As String
            Dim vila, perigrafi, apo, mexri As String
            param = parameter.Split("$")
            vila = param(0)
            perigrafi = param(1)
            apo = param(2)
            mexri = param(3)
            Dim recipients As New List(Of String)
            Dim j, i As Int16

            Dim mailadapter As New dbhotelDataSetTableAdapters.MailTableAdapter
            Dim Vilapraktoreia1adapter As New dbhotelDataSet1TableAdapters.vilapraktoreia1TableAdapter
            mailadapter.Fill(dataset.Mail)
            'Dim praktadapter As New dbhotelDataSetTableAdapters.praktoreiaTableAdapter
            ' exei idi alaksei i imeromergasias-> ean apykwd =O tote stelnontai mailme to poy alaksei imeromergasias s'autoys pou efugan
            'praktadapter.FillEmailPrakt(Me.DbhotelDataSet.praktoreia)

            'Dim dwmpraktadapter As New dbhotelDataSet1TableAdapters.vilapraktoreiaTableAdapter
            Vilapraktoreia1adapter.FillPraktByDwm(dataset1.vilapraktoreia1, vila)

            from = dataset.Mail(0).ffrom

            subject = dataset.Mail(1).subject
            smtpServer = dataset.Mail(0).smtpServer
            smtpUsername = dataset.Mail(0).smtpUsername
            smtpPassword = dataset.Mail(0).smtpPassword
            body = dataset.Mail(1).body.Split("$")
            'too = "mkallergis@gmail.com"

            For j = 0 To dataset1.vilapraktoreia1.Count - 1

                Try
                    i = dataset1.vilapraktoreia1(j).email.IndexOf("@") ' einai sosto to mail->dld periexei @??
                    If i <> -1 Then
                        'gia  na min ksanasteilw sto IDIO mai (ean exoun kataxorithei >1 onmata se mia kratisi)

                        'If Not IsDBNull(Me.DbhotelDataSet.praktoreia(j).Item("ipeuthinos")) Then
                        '    Name = Me.DbhotelDataSet.praktoreia(j).ipeuthinos
                        'Else
                        '    Name = ""
                        'End If

                        If vila.Equals("HRA") Then
                            vila = "MAVI"
                        End If
                        If dataset1.vilapraktoreia1(j).praktoreio <> 17 Then

                            allbody = body(0) + "," + ChrW(13) + body(1) + "location: " + perigrafi + " (" + vila + ")" + ChrW(13) + "arrival: " + apo + ChrW(13) + "departure: " + mexri + ChrW(13) + body(2)
                        Else
                            Dim kwdikos As String = ""
                            Select Case vila
                                Case "AFR"
                                    kwdikos = "HER02071"
                                Case "ALE"
                                    kwdikos = "HER02069"
                                Case "ARCH"
                                    kwdikos = "HER02065"
                                Case "EEAN"
                                    kwdikos = "HER02072"
                                Case "MAIL"
                                    kwdikos = "HER02072"
                                Case "PERS"
                                    kwdikos = "HER02072"
                                Case "THOI"
                                    kwdikos = "HER02072"
                            End Select
                            allbody = body(0) + "," + ChrW(13) + body(1) + "location: " + perigrafi + " " + kwdikos + " (" + vila + ")" + ChrW(13) + "arrival: " + apo + ChrW(13) + "departure: " + mexri + ChrW(13) + body(2)
                        End If


                        'MsgBox("Sending Email to " + Me.DbhotelDataSet1.vilapraktoreia1(j).email)
                        recipients.Add(dataset1.vilapraktoreia1(j).email)
                        'SendMail(from, dataset1.vilapraktoreia1(j).email, subject, allbody, smtpServer, smtpUsername, smtpPassword)

                        mesage = mesage + ChrW(13) + dataset1.vilapraktoreia1(j).email


                    End If
                Catch ex As NullReferenceException

                End Try

            Next
            If recipients.Count > 0 Then
                SendMailList(from, recipients, subject, allbody, smtpServer, smtpUsername, smtpPassword)
                MsgBox(mesage)
            End If



        End Sub
        Public Shared Sub SendMailList(ByVal from As String, ByVal recipients As List(Of String), ByVal subject As String, ByVal body As String, ByVal smtpServer As String, ByVal smtpUsername As String, ByVal smtpPassword As String)

            Dim message As New MailMessage()

            message.From = New MailAddress(from)

            For Each recipient As String In recipients
                message.Bcc.Add(recipient)
            Next

            message.Subject = subject
            message.Body = body

            Dim smtpClient As New SmtpClient(smtpServer, 25)

            smtpClient.UseDefaultCredentials = False
            Dim credentials As New NetworkCredential(smtpUsername, smtpPassword)
            smtpClient.Credentials = credentials
            smtpClient.EnableSsl = True

            smtpClient.Send(message)
        End Sub
        Public Shared Sub SendMail(ByVal from As String, ByVal [to] As String, ByVal subject As String, ByVal body As String, ByVal smtpServer As String, ByVal smtpUsername As String, ByVal smtpPassword As String)
            'Dim fileName As String = "C:\winfo\testAtach.xlsx"
            'Dim instance As New Attachment(fileName)
            'Dim message As New MailMessage(from, [to], subject, body)
            Dim message As New MailMessage(from, [to], subject, body)
            'message.Attachments.Add(instance)

            Dim smtpClient As New SmtpClient(smtpServer, 25) 'System.Net.Mail.SmtpException 'The operation has timed out.'

            'Dim smtpClient As New SmtpClient("mail.usilkcreations.gr", 25)
            ' Dim smtpClient As New SmtpClient("smtp.mail.yahoo.com", 25)

            smtpClient.UseDefaultCredentials = False
            Dim credentials As New NetworkCredential(smtpUsername, smtpPassword)

            'Dim credentials As New NetworkCredential("sales@usilkcreations.gr", "c2FsZXNA")
            'Dim credentials As New NetworkCredential("dlahnidakis@yahoo.gr", "vvjzcttsdqhuuwrl")
            smtpClient.Credentials = credentials
            smtpClient.EnableSsl = True

            smtpClient.Send(message)

        End Sub
        Private Sub SendMailtoPraktoreiaCancel(ByVal parameter As String)
            Dim from, smtpServer, smtpUsername, smtpPassword, subject, allbody As String
            allbody = ""
            'Dim mesage As String = "mails to agencies: "
            Dim textMessage As String
            Dim body() As String
            Dim param() As String
            Dim vila, perigrafi, apo, mexri As String
            param = parameter.Split("$")
            vila = param(0)
            perigrafi = param(1)
            apo = param(2)
            mexri = param(3)
            Dim recipients As New List(Of String)
            Dim j, i As Int16

            Dim mailadapter As New dbhotelDataSetTableAdapters.MailTableAdapter
            Dim Vilapraktoreia1mailadapter As New dbhotelDataSet1TableAdapters.vilapraktoreia1TableAdapter
            mailadapter.Fill(dataset.Mail)
            'Dim praktadapter As New dbhotelDataSetTableAdapters.praktoreiaTableAdapter
            ' exei idi alaksei i imeromergasias-> ean apykwd =O tote stelnontai mailme to poy alaksei imeromergasias s'autoys pou efugan
            'praktadapter.FillEmailPrakt(Me.DbhotelDataSet.praktoreia)

            'Dim dwmpraktadapter As New dbhotelDataSet1TableAdapters.vilapraktoreiaTableAdapter
            Vilapraktoreia1mailadapter.FillPraktByDwm(dataset1.vilapraktoreia1, vila)

            from = dataset.Mail(0).ffrom
            'ALLAGH 2022
            subject = "CANCELATION" 'Me.DbhotelDataSet.Mail(6).subject
            smtpServer = dataset.Mail(0).smtpServer
            smtpUsername = dataset.Mail(0).smtpUsername
            smtpPassword = dataset.Mail(0).smtpPassword
            textMessage = dataset.Mail(6).body.Replace("availability", "cancelation")
            body = textMessage.Split("$")
            'too = "mkallergis@gmail.com"

            For j = 0 To dataset1.vilapraktoreia1.Count - 1

                Try
                    i = dataset1.vilapraktoreia1(j).email.IndexOf("@") ' einai sosto to mail->dld periexei @??
                    If i <> -1 Then
                        'gia  na min ksanasteilw sto IDIO mai (ean exoun kataxorithei >1 onmata se mia kratisi)

                        'If Not IsDBNull(Me.DbhotelDataSet.praktoreia(j).Item("ipeuthinos")) Then
                        '    Name = Me.DbhotelDataSet.praktoreia(j).ipeuthinos
                        'Else
                        '    Name = ""
                        'End If
                        'Name = ""
                        If vila.Equals("HRA") Then
                            vila = "MAVI"
                        End If
                        If dataset1.vilapraktoreia1(j).praktoreio <> 17 Then
                            allbody = body(0) + "," + ChrW(13) + body(1) + "location: " + perigrafi + " (" + vila + ")" + ChrW(13) + "arrival: " + apo + ChrW(13) + "departure: " + mexri + ChrW(13) + body(2)
                        Else
                            Dim kwdikos As String = ""
                            Select Case vila
                                Case "AFR"
                                    kwdikos = "HER02071"
                                Case "ALE"
                                    kwdikos = "HER02069"
                                Case "ARCH"
                                    kwdikos = "HER02065"
                                Case "EEAN"
                                    kwdikos = "HER02072"
                                Case "MAIL"
                                    kwdikos = "HER02072"
                                Case "PERS"
                                    kwdikos = "HER02072"
                                Case "THOI"
                                    kwdikos = "HER02072"
                            End Select
                            allbody = body(0) + "," + ChrW(13) + body(1) + "location: " + perigrafi + " " + kwdikos + " (" + vila + ")" + ChrW(13) + "arrival: " + apo + ChrW(13) + "departure: " + mexri + ChrW(13) + body(2)
                        End If


                        'MsgBox("Sending Email to " + Me.DbhotelDataSet1.vilapraktoreia1(j).email)

                        recipients.Add(dataset1.vilapraktoreia1(j).email)

                        'mesage = mesage + ChrW(13) + dataset1.vilapraktoreia1(j).email


                    End If
                Catch ex As NullReferenceException

                End Try

            Next
            If recipients.Count > 0 Then
                SendMailList(from, recipients, subject, allbody, smtpServer, smtpUsername, smtpPassword)
                'MsgBox(mesage)
            End If



        End Sub

        Private Function get_perigrafi_vilas(ByVal vila As String) As String
            Dim j As Int16

            For j = 0 To dataset.dwmatia.Count - 1
                If dataset.dwmatia(j).arithmos.Equals(vila) Then
                    Return dataset.dwmatia(j).perigrafi
                End If
            Next
            Return ""
        End Function
        'Private Function execute_delete_kratisi(ByVal connectionString As String, ByVal modified_date As Date, ByVal id As String) As Int16
        '    Using connection As New SqlConnection(connectionString)
        '        Dim command As New SqlCommand()
        '        Dim transaction As SqlTransaction = Nothing
        '        Dim counter As Int16 = 0
        '        Dim kwdRes As Int64
        '        connection.Open()
        '        transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted)



        '        ' Assign transaction object for a pending local transaction.
        '        command.Connection = connection
        '        command.Transaction = transaction
        '        Dim myReader As SqlDataReader


        '        Dim kwdikosDelKrat As String


        '        command.Parameters.AddWithValue("@id", id)

        '        command.Parameters.AddWithValue("@status", "CL")
        '        command.CommandText = "Select kwd, kratisi FROM Reservations WHERE (id=@id) AND (status<>@status)"


        '        myReader = command.ExecuteReader(CommandBehavior.SingleResult)
        '        myReader.Read()
        '        Try
        '            kwdRes = myReader.GetInt32(0)
        '            kwdikosDelKrat = myReader.GetInt32(1)

        '        Catch ex As InvalidCastException
        '            myReader.Close()
        '            command.Parameters.Clear()
        '            Return -1
        '        Catch ex1 As InvalidOperationException
        '            myReader.Close()
        '            command.Parameters.Clear()
        '            Return -1
        '        End Try
        '        myReader.Close()
        '        command.Parameters.Clear()

        '        command.Parameters.AddWithValue("@kratisi", kwdikosDelKrat)
        '        command.CommandText = "DELETE FROM Reservations where (kratisi=@kratisi)"
        '        command.ExecuteNonQuery()
        '        command.Parameters.Clear()

        '        command.Parameters.AddWithValue("@kratisi", kwdikosDelKrat)
        '        command.CommandText = "DELETE FROM timeskratisis where (kratisi=@kratisi)"
        '        counter = command.ExecuteNonQuery()
        '        command.Parameters.Clear()
        '        If counter = 1 Then

        '            command.Parameters.AddWithValue("@kratisi", kwdikosDelKrat)
        '            command.CommandText = "DELETE FROM enilikes where (kratisi=@kratisi)"
        '            command.ExecuteNonQuery()
        '            command.Parameters.Clear()

        '            command.Parameters.AddWithValue("@kratisi", kwdikosDelKrat)
        '            command.CommandText = "DELETE FROM status where (kratisi=@kratisi)"
        '            command.ExecuteNonQuery()
        '            command.Parameters.Clear()

        '            command.Parameters.Clear()
        '            command.Parameters.AddWithValue("@kwd", kwdikosDelKrat)
        '            command.CommandText = "DELETE FROM kratiseis where (kwd=@kwd)"
        '            command.ExecuteNonQuery()
        '            command.Parameters.Clear()


        '            command.Parameters.AddWithValue("@modified_date", CType(modified_date, Date))
        '            command.Parameters.AddWithValue("@status", "CL")
        '            command.Parameters.AddWithValue("@kwd", kwdRes)
        '            command.CommandText = "UPDATE Reservations SET modified_date=@modified_date, status=@status WHERE (kwd=@kwd)"

        '            'command.Parameters.AddWithValue("modified_date", CType(modified_date, Date))
        '            'command.Parameters.AddWithValue("channel_key", channel_key)
        '            'command.Parameters.AddWithValue("booking_id", booking_id)
        '            'command.Parameters.AddWithValue("room_booking_id", room_booking_id)

        '            'command.Parameters.AddWithValue("status", "CL")

        '            'command.CommandText = "INSERT INTO Reservations (modified_date,channel_key,booking_id,room_booking_id,status) " &
        '            '"values (modified_date,channel_key,booking_id,room_booking_id,status)"
        '            command.ExecuteNonQuery()
        '            command.Parameters.Clear()
        '            transaction.Commit()
        '            Return 1
        '        Else
        '            transaction.Commit()
        '            Return -1
        '        End If
        '    End Using
        'End Function
        Private Function execute_delete_kratisi(ByVal connectionString As String, ByVal modified_date As Date, ByVal id As String, ByRef kwddelkrat As Int64, ByRef vila As String) As Byte
            Using connection As New SqlConnection(connectionString)
                Dim command As New SqlCommand()
                Dim transaction As SqlTransaction = Nothing
                Dim counter As Int16 = 0
                Dim kwdRes As Int64
                connection.Open()
                transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted)



                ' Assign transaction object for a pending local transaction.
                command.Connection = connection
                command.Transaction = transaction
                Dim myReader As SqlDataReader


                Dim kwdikosDelKrat As String
                Dim room As String

                command.Parameters.AddWithValue("@id", id)

                command.Parameters.AddWithValue("@status", "CL")
                command.CommandText = "SELECT TOP 1 kwd, kratisi, modified_date, room_booking_id FROM Reservations WHERE (id=@id) AND (status<>@status) ORDER BY modified_date DESC"


                myReader = command.ExecuteReader(CommandBehavior.SingleResult)
                myReader.Read()
                Try
                    kwdRes = myReader.GetInt32(0)
                    kwdikosDelKrat = myReader.GetInt32(1)
                    room = myReader.GetString(3)
                Catch ex As InvalidCastException
                    myReader.Close()
                    command.Parameters.Clear()
                    Return 0
                Catch ex1 As InvalidOperationException
                    myReader.Close()
                    command.Parameters.Clear()
                    Return 0
                End Try
                myReader.Close()
                command.Parameters.Clear()

                'command.Parameters.AddWithValue("@kratisi", kwdikosDelKrat)
                'command.CommandText = "DELETE FROM Reservations where (kratisi=@kratisi)"
                'command.ExecuteNonQuery()
                'command.Parameters.Clear()

                command.Parameters.AddWithValue("@kratisi", kwdikosDelKrat)
                command.CommandText = "DELETE FROM timeskratisis where (kratisi=@kratisi)"
                counter = command.ExecuteNonQuery()
                command.Parameters.Clear()
                If counter = 1 Then

                    command.Parameters.AddWithValue("@kratisi", kwdikosDelKrat)
                    command.CommandText = "DELETE FROM enilikes where (kratisi=@kratisi)"
                    command.ExecuteNonQuery()
                    command.Parameters.Clear()

                    command.Parameters.AddWithValue("@kratisi", CType(kwdikosDelKrat, Integer))
                    command.CommandText = "DELETE FROM eventarkratisi where (kratisi=@kratisi)"
                    command.ExecuteNonQuery()
                    command.Parameters.Clear()


                    command.Parameters.AddWithValue("@kratisi", kwdikosDelKrat)
                    command.CommandText = "DELETE FROM status where (kratisi=@kratisi)"
                    command.ExecuteNonQuery()
                    command.Parameters.Clear()


                    command.Parameters.AddWithValue("@kratisi", kwdikosDelKrat)
                    command.CommandText = "DELETE FROM paidia where (kratisi=@kratisi)"
                    command.ExecuteNonQuery()
                    command.Parameters.Clear()

                    command.Parameters.Clear()
                    command.Parameters.AddWithValue("@kwd", kwdikosDelKrat)
                    command.CommandText = "DELETE FROM kratiseis where (kwd=@kwd)"
                    command.ExecuteNonQuery()
                    command.Parameters.Clear()


                    command.Parameters.AddWithValue("@modified_date", CType(modified_date, Date))
                    command.Parameters.AddWithValue("@status", "CL")
                    command.Parameters.AddWithValue("@kwd", kwdRes)
                    command.CommandText = "UPDATE Reservations SET modified_date=@modified_date, status=@status WHERE (kwd=@kwd)"

                    'command.Parameters.AddWithValue("modified_date", CType(modified_date, Date))
                    'command.Parameters.AddWithValue("channel_key", channel_key)
                    'command.Parameters.AddWithValue("booking_id", booking_id)
                    'command.Parameters.AddWithValue("room_booking_id", room_booking_id)

                    'command.Parameters.AddWithValue("status", "CL")

                    'command.CommandText = "INSERT INTO Reservations (modified_date,channel_key,booking_id,room_booking_id,status) " &
                    '"values (modified_date,channel_key,booking_id,room_booking_id,status)"
                    command.ExecuteNonQuery()
                    command.Parameters.Clear()
                    transaction.Commit()
                    kwddelkrat = kwdikosDelKrat
                    vila = room
                    Return 1
                Else
                    transaction.Rollback()
                    Return 0
                End If
            End Using
        End Function
        Private Function mark_res_as_sync(ByVal link_reserv As String, ByVal id_res As Int64) As Boolean
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
            Dim request As HttpWebRequest = HttpWebRequest.Create(link_reserv + "sync/" + id_res.ToString)
            request.Method = "GET"

            ' Add the basic authentication credentials to the request headers
            request.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(user + ":" + password)))
            request.UserAgent = "en-gb;q=0.9, el"
            ' Add the Accept header with the application/json
            request.Accept = "application/json"

            Dim responseText As String = ""
            Dim httpCode As Integer
            Try

                Dim response As HttpWebResponse = request.GetResponse()

                Using reader As New StreamReader(response.GetResponseStream())
                    responseText = reader.ReadToEnd()

                    ' Write the response to a local JSON file
                    Dim folderPath As String = "C:\winfo\Reservations\"
                    Dim fileName As String = id_res.ToString() & "_sync.json"
                    Dim filePath As String = Path.Combine(folderPath, fileName)

                    File.WriteAllText(filePath, responseText)

                    ' Parse the JSON response
                    Dim jsonObject As Linq.JObject = JObject.Parse(responseText)
                    httpCode = CInt(response.StatusCode)
                    If httpCode = 200 Then
                        Return True
                    End If
                End Using

            Catch ex As WebException
                Dim response As HttpWebResponse = ex.Response
                httpCode = CInt(response.StatusCode)

                If httpCode <> 200 Then
                    Using streamReader As New StreamReader(response.GetResponseStream())
                        responseText = streamReader.ReadToEnd()

                        Dim errorObject As JObject = JObject.Parse(responseText)
                        Dim errorCode As String = CStr(errorObject("error_code"))
                        Dim errorMessage As String = CStr(errorObject("error_msg"))
                        Console.WriteLine("HTTP Code: " & httpCode)
                        Console.WriteLine("Error Code: " & errorCode)
                        Console.WriteLine("Error Message: " & errorMessage)
                    End Using


                End If
                Return False
            End Try
        End Function
        Public Sub store_rates_local()
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
            Dim request As HttpWebRequest = HttpWebRequest.Create(link + property_id)
            request.Method = "GET"

            ' Add the basic authentication credentials to the request headers
            request.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(user + ":" + password)))
            request.UserAgent = "en-gb;q=0.9, el"
            ' Add the Accept header with the application/json
            request.Accept = "application/json"

            Dim responseText As String = ""
            Dim httpCode As Integer
            Try

                Dim response As HttpWebResponse = request.GetResponse()

                Using reader As New StreamReader(response.GetResponseStream())
                    responseText = reader.ReadToEnd()

                    ' Write the response to a local JSON file
                    Dim fileName As String = "rates_feed.json"
                    Dim filePath As String = Path.Combine(Environment.CurrentDirectory, fileName)
                    File.WriteAllText(filePath, responseText)

                    ' Parse the JSON response
                    Dim jsonObject As Linq.JObject = JObject.Parse(responseText)

                    ' Access the data
                    Dim rates As JArray = jsonObject.SelectToken("data.rates")


                    ' Loop through the array
                    For Each rate As JObject In rates
                        Dim id As Integer = CType(rate("id"), Integer)
                        Dim name As String = rate("name").ToString()
                        Dim room As String = rate("room").ToString
                        Dim active As Boolean = rate("active")
                        If active Then
                            execute_insert_roomratetype(id, name, room, 0)
                        Else
                            execute_insert_roomratetype(id, name, room, 1)
                        End If

                    Next

                    ' Loop through the array

                End Using
            Catch ex As WebException
                Dim response As HttpWebResponse = ex.Response
                httpCode = CInt(response.StatusCode)
                If httpCode <> 200 Then
                    Using streamReader As New StreamReader(response.GetResponseStream())
                        responseText = streamReader.ReadToEnd()

                        Dim errorObject As JObject = JObject.Parse(responseText)
                        Dim errorCode As String = CStr(errorObject("error_code"))
                        Dim errorMessage As String = CStr(errorObject("error_msg"))
                        Console.WriteLine("HTTP Code: " & httpCode)
                        Console.WriteLine("Error Code: " & errorCode)
                        Console.WriteLine("Error Message: " & errorMessage)
                    End Using


                End If

            End Try
        End Sub
        Public Sub availability_request_from_bis()

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
            '/manage/availability/{roomcode} and dates parameters
            Dim request As HttpWebRequest = HttpWebRequest.Create(link + "/DBL?from=2023-02-21&to=2023-02-25")


            'Dim request As HttpWebRequest = HttpWebRequest.Create(link + property_id + "/DBL/535278?fromd=2023-02-01&tod=2023-03-01")
            'Dim request As HttpWebRequest = HttpWebRequest.Create(link + property_id + "?fromd=2023-03-01&tod=2023-03-02")


            request.Method = "GET"

            ' Add the basic authentication credentials to the request headers
            request.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(user + ":" + password)))
            request.UserAgent = "en-gb;q=0.9, el"
            ' Add the Accept header with the application/json
            request.Accept = "application/json"

            Dim responseText As String = ""
            Dim httpCode As Integer
            Try

                Dim response As HttpWebResponse = request.GetResponse()
                Using reader As New StreamReader(response.GetResponseStream())
                    responseText = reader.ReadToEnd()

                    Dim allotList As List(Of Allotment) = JsonConvert.DeserializeObject(Of List(Of Allotment))(responseText)

                    For Each allotment As Allotment In allotList
                        Console.WriteLine(allotment.allot)
                    Next
                End Using
                httpCode = CInt(response.StatusCode)


                'Using reader As New StreamReader(response.GetResponseStream())
                '    responseText = reader.ReadToEnd()

                '    ' Write the response to a local JSON file
                '    Dim fileName As String = "allotm.json"
                '    Dim filePath As String = Path.Combine(Environment.CurrentDirectory, fileName)
                '    File.WriteAllText(filePath, responseText)

                '    ' Parse the JSON response
                '    Dim jsonObject As Linq.JObject = JObject.Parse(responseText)

                '    ' Access the data
                '    Dim imerominies As JArray = jsonObject.SelectToken("allot")


                '    ' Loop through the array
                '    For Each imerominia As JObject In imerominies
                '        Dim allot As String = imerominia("code").ToString()

                '        MsgBox(allot)
                '        'If active Then
                '        '    execute_insert_roomratetype(id, name, 0)
                '        'Else
                '        '    execute_insert_roomratetype(id, name, 1)
                '        'End If

                '    Next

                '    ' Loop through the array

                'End Using
            Catch ex As WebException
                Dim response As HttpWebResponse = ex.Response
                httpCode = CInt(response.StatusCode)
                If httpCode <> 200 Then
                    Using streamReader As New StreamReader(response.GetResponseStream())
                        responseText = streamReader.ReadToEnd()

                        Dim errorObject As JObject = JObject.Parse(responseText)
                        Dim errorCode As String = CStr(errorObject("error_code"))
                        Dim errorMessage As String = CStr(errorObject("error_msg"))
                        Console.WriteLine("HTTP Code: " & httpCode)
                        Console.WriteLine("Error Code: " & errorCode)
                        Console.WriteLine("Error Message: " & errorMessage)
                    End Using


                End If

            End Try


        End Sub


        Private Sub execute_insert_roomratetype(ByVal id As String, ByVal name As String, ByVal room As String, ByVal stopsales As Byte)



            Using connection As New SqlConnection(connection_string)
                Dim command As New SqlCommand()
                Dim transaction As SqlTransaction = Nothing
                Try
                    connection.Open()
                    transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted)
                    command.Connection = connection
                    command.Transaction = transaction

                    ' Adding parameters
                    command.Parameters.AddWithValue("@id", id)
                    command.Parameters.AddWithValue("@property", property_id)
                    command.Parameters.AddWithValue("@name", name)
                    command.Parameters.AddWithValue("@room", room)
                    command.Parameters.AddWithValue("@stopsales", stopsales)
                    command.Parameters.AddWithValue("@created_at", DateTime.Now)

                    ' Modifying the SQL command to include created_at
                    command.CommandText = "INSERT INTO RoomRateTypes (id, property_id, name, master_roomratetype_id, stop_sell, created_at)" &
                                          "VALUES (@id, @property, @name, @room, @stopsales, @created_at)"
                    command.ExecuteNonQuery()
                    command.Parameters.Clear()

                    transaction.Commit()
                    ' Return 1
                Catch ex As Exception
                    MsgBox("Η Διαδικασία απέτυχε !", MsgBoxStyle.Critical, "winfo\nikEl.")
                    Try
                        transaction.Rollback()
                        ' Return -1
                    Catch
                        ' Return -1
                    End Try
                End Try

            End Using
        End Sub

        Private Function execute_fortosi_kratisi_transaction(ByVal connectionString As String, ByVal id As String, ByVal modified_date As Date, ByVal channel_key As String, ByVal booking_id As String,
                                                        ByVal room_booking_id As String, ByVal roomratetype_id As String, ByVal checkin As Date, ByVal checkout As Date,
                                                        ByVal meal_plan As String, ByVal guests As String, ByVal total_amount As String, ByVal total_taxes As String, ByVal status As String, ByVal confirmed As String, ByVal email As String, ByVal state As String, ByVal phones As String, ByVal lead_name As String, ByVal guest() As String,
                                                        ByVal rates() As rate, ByVal requests() As String, ByRef dwm As String, ByVal agesOfChildren As List(Of Int16), ByRef kwdneaskratisis As Int64, ByRef arkratisis As Int16) As Byte
            Using connection As New SqlConnection(connectionString)
                Dim overKwd As Integer = -1
                Dim counter As Int16 = 0
                ' Dim arkrat As Int16
                Dim kwdneaskrat As Integer
                Dim command, command2 As New SqlCommand()
                Dim transaction As SqlTransaction = Nothing
                Dim touristperiod As Integer
                Dim flag As Byte = 0 '1=me dwmatio 0=xwris dwmatio 

                Try

                    connection.Open()
                    transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted)



                    ' Assign transaction object for a pending local transaction.
                    command.Connection = connection
                    command.Transaction = transaction
                    command2.Connection = connection
                    command2.Transaction = transaction
                    Dim myReader As SqlDataReader

                    command.Parameters.AddWithValue("@id", CType(id, Int64))
                    command.Parameters.AddWithValue("@status", "CL")
                    command.CommandText = "SELECT COUNT(*) FROM Reservations WHERE (id=@id) AND (status<>@status)"

                    myReader = command.ExecuteReader(CommandBehavior.SingleResult)
                    Try
                        If myReader.HasRows AndAlso myReader.Read() Then
                            counter = myReader.GetInt32(0)
                            If counter <> 0 Then
                                Return 0
                            End If
                        End If
                        myReader.Close()
                        command.Parameters.Clear()
                    Catch ex As InvalidCastException
                        myReader.Close()
                        command.Parameters.Clear()
                    Catch ex2 As InvalidOperationException
                        myReader.Close()
                        command.Parameters.Clear()
                    End Try

                    command.CommandText = "SELECT MAX(arithmos) FROM kratiseis"

                    myReader = command.ExecuteReader()
                    ' Always call Read before accessing data.
                    myReader.Read()
                    Dim arithmos As Int16 = myReader.GetInt16(0)
                    arithmos += 1
                    myReader.Close()

                    command.Parameters.AddWithValue("@id", CType(roomratetype_id, Integer))
                    command.Parameters.AddWithValue("@etos", checkin.Year)
                    command.CommandText = "SELECT RoomRateTypes.simbolaio, RoomRateTypes.tipos, simbolaia.praktoreio FROM RoomRateTypes INNER JOIN simbolaia ON RoomRateTypes.simbolaio = simbolaia.kwd WHERE (id=@id) AND (simbolaia.etos=@etos)"

                    myReader = command.ExecuteReader()
                    ' to access now sql server database!

                    ' Always call Read before accessing data.
                    myReader.Read()
                    Dim simbolaio As Int32 = myReader.GetInt32(0)
                    Dim tipos As Int32 = myReader.GetInt32(1)
                    Dim praktoreio As Int32 = myReader.GetInt32(2)

                    'If tipos >= 13 And tipos <= 16 Then
                    '    praktoreio = 48
                    'ElseIf tipos >= 17 And tipos <= 22 Then
                    '    praktoreio = 49
                    'End If
                    myReader.Close()

                    Dim praktimologio As Int32 = 1 ' Standard INDIVIDUAL!
                    Select Case channel_key
                        Case "Booking.com"
                            praktimologio = 2
                        Case "Airbnb"
                            praktimologio = 4
                        Case "Expedia"
                            praktimologio = 43
                        Case "bookonlinenow"
                            praktimologio = 50

                    End Select
                    ' always call Close when done reading.
                    Dim enilikes, paidia As Int16
                    Dim parts As String()
                    Try
                        parts = guests.Split(New Char() {"+"c})

                        enilikes = CType(parts(0).TrimStart.Substring(0, 1), Int16)
                        paidia = CType(parts(1).TrimStart.Substring(0, 1), Int16)
                    Catch ex1 As ArgumentOutOfRangeException
                        enilikes = 1
                        paidia = 0
                    Catch ex As IndexOutOfRangeException
                        paidia = 0
                    End Try

                    'Try
                    '    paidia = CType(parts(1).TrimStart.Substring(0, 1), Int16)
                    'Catch ex As IndexOutOfRangeException
                    '    paidia = 0
                    'End Try

                    command.Parameters.Clear()


                    Dim dwmatia As New List(Of String)

                    command.Parameters.AddWithValue("afixi", checkout.AddDays(-1).Date)
                    command.Parameters.AddWithValue("anaxwrisi", checkin.Date)
                    command.CommandText = "SELECT DISTINCT kratiseis.dwmatio FROM kratiseis WHERE (kratiseis.afixi<=@afixi) AND (kratiseis.anaxwrisi>@anaxwrisi)"
                    myReader = command.ExecuteReader()

                    While myReader.Read()
                        If Not myReader.IsDBNull(0) Then ' Check if the value is not null
                            dwmatia.Add(myReader.GetString(0))
                        End If
                    End While

                    myReader.Close()
                    command.Parameters.Clear()

                    command.Parameters.AddWithValue("@arithmos", dwm)

                    command.CommandText = "SELECT dwmatia.arithmos, dwmatia.klines FROM dwmatia WHERE(dwmatia.arithmos=@arithmos) "

                    myReader = command.ExecuteReader()
                    ' Always call Read before accessing data.

                    Dim dwmatio As String = ""
                    Dim klines As Int16
                    While myReader.Read()
                        If Not dwmatia.Contains(myReader.GetString(0)) Then
                            dwmatio = myReader.GetString(0)
                            klines = myReader.GetInt16(1)
                            flag = 1

                            Exit While
                        End If
                    End While
                    myReader.Close()
                    command.Parameters.Clear()
                    'EDW ENERGOPOIHSE KWDIKA 25/7/2023!!!!!!!!!!!!!!!!
                    If dwm <> dwmatio Then
                        MsgBox("ΠΡΟΣΟΧΗ: Δεν μπόρεσε να γίνει allocation  στην κράτηση " + room_booking_id, MsgBoxStyle.Critical)
                        flag = 0
                        transaction.Rollback()
                        Return 0
                    End If


                    Dim epithimia As String = String.Join(" / ", requests)
                    If epithimia.Length > 250 Then
                        epithimia = epithimia.Trim.Substring(0, 249)
                    End If


                    Dim ethnoskwd As Int16 = 0
                    command.Parameters.AddWithValue("@state", state)
                    command.CommandText = "SELECT kwd FROM ethnikotites WHERE sintomeusi=@state"
                    myReader = command.ExecuteReader()
                    ' Always call Read before accessing data.
                    If myReader.HasRows AndAlso myReader.Read() Then
                        ethnoskwd = myReader.GetInt16(0)
                    End If
                    myReader.Close()
                    command.Parameters.Clear()


                    command.Parameters.AddWithValue("@etos", CType(modified_date, Date).Year)
                    command.Parameters.AddWithValue("@arithmos", arithmos)
                    command.Parameters.AddWithValue("@praktoreio", praktoreio)
                    command.Parameters.AddWithValue("@praktimologio", praktimologio)
                    command.Parameters.AddWithValue("@voucher", email)
                    command.Parameters.AddWithValue("@enilikes", enilikes)
                    command.Parameters.AddWithValue("@paidia", paidia)
                    command.Parameters.AddWithValue("@afixi", CType(checkin, Date))
                    command.Parameters.AddWithValue("@wra", checkin.TimeOfDay)
                    command.Parameters.AddWithValue("@anaxwrisi", CType(checkout, Date))
                    command.Parameters.AddWithValue("@klines", klines)
                    command.Parameters.AddWithValue("@tipos", tipos)

                    If flag = 1 Then
                        command.Parameters.AddWithValue("@dwmatio", dwm)
                    End If

                    command.Parameters.AddWithValue("@pliromi", "Πίστωση")
                    command.Parameters.AddWithValue("@synolo", CType(total_amount, Single))
                    command.Parameters.AddWithValue("@anzethnikotites", enilikes)
                    command.Parameters.AddWithValue("@anzethnikotites2", 0)
                    command.Parameters.AddWithValue("@ethnikotites", ethnoskwd)
                    command.Parameters.AddWithValue("@epithimdate", CType(modified_date, Date))
                    command.Parameters.AddWithValue("@epithimia", epithimia)
                    command.Parameters.AddWithValue("@prokatdate", CType(modified_date, Date))
                    command.Parameters.AddWithValue("@tilefonomem", phones)
                    command.Parameters.AddWithValue("@imeromkratisis", CType(modified_date, Date).Date)
                    command.Parameters.AddWithValue("@simbolaio", simbolaio)
                    command.Parameters.AddWithValue("@ethnikotites2", 0)
                    command.Parameters.AddWithValue("@datein", checkin)

                    If flag = 1 Then
                        command.CommandText = "INSERT INTO kratiseis (etos, arithmos, praktoreio, praktimologio, voucher, enilikes, paidia, afixi, wra, anaxwrisi, klines, tipos, dwmatio, pliromi, synolo, anzethnikotites, anzethnikotites2, ethnikotites, epithimdate, epithimia, prokatdate, tilefonomem, imeromkratisis, simbolaio, ethnikotites2, checkin, checkout, datein) VALUES (@etos, @arithmos, @praktoreio, @praktimologio, @voucher, @enilikes, @paidia, @afixi, @wra, @anaxwrisi, @klines, @tipos, @dwmatio, @pliromi, @synolo, @anzethnikotites, @anzethnikotites2, @ethnikotites, @epithimdate, @epithimia, @prokatdate, @tilefonomem, @imeromkratisis, @simbolaio, @ethnikotites2, 0, 0, @datein)"
                    ElseIf flag = 0 Then
                        command.CommandText = "INSERT INTO kratiseis (etos, arithmos, praktoreio, praktimologio, voucher, enilikes, paidia, afixi, wra, anaxwrisi, klines, tipos, pliromi, synolo, anzethnikotites, anzethnikotites2, ethnikotites, epithimdate, epithimia, prokatdate, tilefonomem, imeromkratisis, simbolaio, ethnikotites2, checkin, checkout, datein) VALUES (@etos, @arithmos, @praktoreio, @praktimologio, @voucher, @enilikes, @paidia, @afixi, @wra, @anaxwrisi, @klines, @tipos, @pliromi, @synolo, @anzethnikotites, @anzethnikotites2, @ethnikotites, @epithimdate, @epithimia, @prokatdate, @tilefonomem, @imeromkratisis, @simbolaio, @ethnikotites2, 0, 0, @datein)"
                    End If

                    command.ExecuteNonQuery()
                    command.Parameters.Clear()



                    command.Parameters.AddWithValue("@etos", CType(modified_date, Date).Year)
                    command.Parameters.AddWithValue("@arithmos", arithmos)
                    command.CommandText = "SELECT kwd FROM kratiseis where (etos=@etos) and (arithmos=@arithmos)"

                    myReader = command.ExecuteReader()
                    ' Always call Read before accessing data.
                    While myReader.Read()
                        kwdneaskrat = myReader.GetInt32(0)
                        counter += 1
                    End While
                    ' always call Close when done reading.
                    myReader.Close()
                    command.Parameters.Clear()

                    If counter <> 1 Then ' paei na pei oti brethikan parapanw kratiseis me ton idio arithmo kratisis
                        transaction.Rollback()
                        Return 0
                    End If

                    command.Parameters.AddWithValue("@aakratisis", arithmos)
                    command.CommandText = "UPDATE etaireia SET  aakratisis=@aakratisis"
                    command.ExecuteNonQuery()
                    command.Parameters.Clear()

                    If flag = 1 Then
                        command.Parameters.AddWithValue("@dwmatio", dwm)
                        command.Parameters.AddWithValue("@kratsi", kwdneaskrat)
                        command.Parameters.AddWithValue("@enarxi", CType(checkin, Date))
                        command.Parameters.AddWithValue("@lixi", CType(checkout.AddDays(-1), Date))
                        command.Parameters.AddWithValue("@dwmatiostatus", 1)

                        command.CommandText = "INSERT INTO status (dwmatio, kratisi, enarxi, lixi, dwmatiostatus) VALUES (@dwmatio, @kratsi, @enarxi, @lixi, @dwmatiostatus)"
                        command.ExecuteNonQuery()
                        command.Parameters.Clear()

                    End If


                    Dim i, imeres As Int16
                    Dim day_taxes As Single = Math.Round(CType(total_taxes, Single) / checkout.Date.Subtract(checkin).Days, 2)
                    If rates.Length > 1 Then
                        Dim j As Int16
                        Dim ammount As Single
                        While (i < rates.Length - 1)
                            'Dim imeres As Int16
                            j = i
                            ammount = CType(rates(i).amount, Single) ' Single.Parse(rates(i).amount.Remove("")) 'Single.Parse(rates(i).amount).ToString("0.00") 'CType(rates(i).amount, Single)
                            'Dim Total As String = "0"
                            'Dim s As String = "427.00"
                            'Total = (Single.Parse(Total) + Single.Parse(s)).ToString("0.00")
                            While ammount = CType(rates(j).amount, Single) 'Single.Parse(rates(j).amount).ToString("0.00") 'rates(j).amount
                                j += 1
                                If j >= rates.Length - 1 Then

                                    Exit While
                                End If
                            End While

                            command2.Parameters.AddWithValue("@simbolaio", simbolaio)
                            command2.Parameters.AddWithValue("@apo", CType(rates(i).day, Date))
                            command2.Parameters.AddWithValue("@mexri", CType(rates(j).day.AddDays(-1), Date))

                            command2.CommandText = "SELECT kwd FROM touristperiodoi WHERE (simbolaio=@simbolaio) AND (apo<=@apo) AND (mexri>=@mexri)"
                            myReader = command2.ExecuteReader()
                            command2.Parameters.Clear()


                            myReader.Read()
                            '   counter = 0
                            'While myReader.Read

                            Try  'allagh timwn XWRIS allagh periodou 
                                If Not (i <> 0 And touristperiod = myReader.GetInt32(0)) Then ' And counter = 1

                                    touristperiod = myReader.GetInt32(0)
                                    myReader.Close()
                                    Dim xrewsi As Int16
                                    If meal_plan.Contains("bb") Then
                                        xrewsi = 2
                                    Else
                                        xrewsi = 1

                                    End If

                                    command.Parameters.AddWithValue("@kratisi", kwdneaskrat)
                                    command.Parameters.AddWithValue("@timi", -1)
                                    command.Parameters.AddWithValue("@apo", rates(i).day)
                                    If j < rates.Length - 1 Then
                                        command.Parameters.AddWithValue("@mexri", rates(j - 1).day)
                                        imeres = rates(j).day.Date.Subtract(rates(i).day.Date).Days
                                    Else
                                        command.Parameters.AddWithValue("@mexri", checkout)
                                        imeres = checkout.Date.Subtract(rates(i).day.Date).Days
                                    End If

                                    command.Parameters.AddWithValue("@ypnos", ammount + day_taxes)
                                    command.Parameters.AddWithValue("@imeres", imeres)
                                    command.Parameters.AddWithValue("@synolo", (CType(rates(i).amount, Single) + day_taxes) * imeres)
                                    command.Parameters.AddWithValue("@touristperiod", touristperiod)
                                    command.Parameters.AddWithValue("@xrewsi", xrewsi)

                                    command.CommandText = "INSERT INTO timeskratisis (kratisi, timi, apo, mexri, ypnos, imeres, synolo, touristperiod, xrewsi) " &
                      "VALUES (@kratisi, @timi, @apo, @mexri, @ypnos, @imeres, @synolo, @touristperiod, @xrewsi)"

                                    command.ExecuteNonQuery()

                                    command.Parameters.Clear()

                                    ' always call Close when done reading.

                                    command.Parameters.Clear()
                                    i = j

                                Else 'Αλλαγή τιμών χωρις αλλαγή τουρ. περιόδου!!!!!!!!!!!!!!!!!!!!!
                                    Try
                                        myReader.Close()
                                        'ddelete ta proigoumena insert stis timeskratisis
                                        command.Parameters.AddWithValue("@kratisi", kwdneaskrat)
                                        command.CommandText = "DELETE FROM timeskratisis where (kratisi=@kratisi)"
                                        command.ExecuteNonQuery()
                                        command.Parameters.Clear()

                                        'PROSOXI ALAZEI KATHEE XRONO!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                                        'kwdikoi toyristikis periodou KAI simbolaiou ME TO XERI!!!!!!!!!!!!!
                                        'touristperiod = 614
                                        '  touristperiod = 235970136
                                        Dim xrewsi As Int16

                                        If meal_plan.Contains("bb") Then
                                            xrewsi = 2
                                        Else
                                            xrewsi = 1

                                        End If

                                        command.Parameters.AddWithValue("@kratisi", kwdneaskrat)
                                        command.Parameters.AddWithValue("@timi", -1)
                                        command.Parameters.AddWithValue("@apo", checkin)
                                        command.Parameters.AddWithValue("@mexri", checkout)

                                        Dim ypnos As Single = Math.Round(total_amount / checkout.Date.Subtract(checkin).Days, 2) + day_taxes
                                        imeres = checkout.Date.Subtract(checkin).Days

                                        command.Parameters.AddWithValue("@ypnos", ypnos)
                                        command.Parameters.AddWithValue("@imeres", imeres)
                                        command.Parameters.AddWithValue("@synolo", ypnos * imeres)
                                        command.Parameters.AddWithValue("@touristperiod", touristperiod)
                                        command.Parameters.AddWithValue("@xrewsi", xrewsi)

                                        command.CommandText = "INSERT INTO timeskratisis (kratisi, timi, apo, mexri, ypnos, imeres, synolo, touristperiod, xrewsi) " &
                      "VALUES (@kratisi, @timi, @apo, @mexri, @ypnos, @imeres, @synolo, @touristperiod, @xrewsi)"

                                        command.ExecuteNonQuery()

                                        command.Parameters.Clear()

                                        ' always call Close when done reading.

                                        command.Parameters.Clear()
                                        '  command.Parameters.AddWithValue("simbolaio", 33650606)
                                        command.Parameters.AddWithValue("@simbolaio", simbolaio)
                                        command.Parameters.AddWithValue("@kwd", kwdneaskrat)
                                        command.CommandText = "UPDATE kratiseis SET simbolaio=@simbolaio WHERE (kwd=@kwd)"
                                        command.ExecuteNonQuery()
                                        command.Parameters.Clear()
                                        Exit While
                                    Catch ex As InvalidOperationException
                                        MsgBox("Δεν μπόρεσε φορτωθεί η κράτηση: " + booking_id + " Αλλαγή τουρ. περιόδου χωρις αλλαγή τιμών", MsgBoxStyle.Critical)
                                        transaction.Rollback()
                                        Return 0
                                    End Try
                                    'MsgBox("Δεν μπόρεσε φορτωθεί η κράτηση: " + booking_id + " Αλλαγή τιμών χωρις αλλαγή τουρ. περιόδου", MsgBoxStyle.Critical)
                                    'transaction.Rollback()
                                    'Return -1
                                End If
                                ' den brethike tourisitkh periodos
                            Catch ex As InvalidOperationException
                                MsgBox("Δεν μπόρεσε φορτωθεί η κράτηση: " + booking_id + " Αλλαγή τουρ. περιόδου χωρις αλλαγή τιμών", MsgBoxStyle.Critical)
                                transaction.Rollback()
                                Return 0
                            End Try

                            'End While
                            'myReader.Close()
                            'elegxos ean ypa;rxei allagi timwn xwris allagi peri;odwn ->ERROR

                        End While
                    Else
                        command.Parameters.AddWithValue("@simbolaio", simbolaio)
                        command.Parameters.AddWithValue("@apo", checkin)

                        command.Parameters.AddWithValue("@mexri", checkout.AddDays(-1))
                        command.CommandText = "SELECT kwd FROM touristperiodoi where (simbolaio=@simbolaio) and (apo<=@apo) and (mexri>=@mexri)"
                        myReader = command.ExecuteReader()
                        command.Parameters.Clear()

                        myReader.Read()

                        Try
                            touristperiod = myReader.GetInt32(0)
                            myReader.Close()
                            Dim xrewsi As Int16

                            If meal_plan.Contains("bb") Then
                                xrewsi = 2
                            Else
                                xrewsi = 1

                            End If

                            '          command.Parameters.AddWithValue("kratisi", kwdneaskrat)
                            '          command.Parameters.AddWithValue("timi", -1)
                            '          command.Parameters.AddWithValue("apo", checkin)
                            '          command.Parameters.AddWithValue("mexri", checkout)

                            '          command.Parameters.AddWithValue("ypnos", Math.Round(total_amount / checkout.Date.Subtract(checkin).Days, 2) + day_taxes)
                            '          'MsgBox("apo " + rates(i).day)
                            '          'MsgBox("mexri " + rates(j).day)
                            '          imeres = checkout.Date.Subtract(checkin).Days
                            '          'MsgBox("imeres" + rates(j).day.Date.Subtract(rates(i).day.Date).Days.ToString)
                            '          command.Parameters.AddWithValue("imeres", imeres)
                            '          command.Parameters.AddWithValue("synolo", (CType(total_amount, Single) + day_taxes) * imeres)
                            '          command.Parameters.AddWithValue("touristperiod", touristperiod)
                            '          command.Parameters.AddWithValue("xrewsi", xrewsi)
                            '          command.CommandText = "INSERT INTO timeskratisis (kratisi, timi,  apo, mexri,  ypnos,imeres,synolo, touristperiod, xrewsi)" &
                            '"values (kratisi, timi,apo, mexri,ypnos, imeres,  synolo, touristperiod, xrewsi)"
                            '          command.ExecuteNonQuery()
                            command.Parameters.AddWithValue("@kratisi", kwdneaskrat)
                            command.Parameters.AddWithValue("@timi", -1)
                            command.Parameters.AddWithValue("@apo", checkin)
                            command.Parameters.AddWithValue("@mexri", checkout)

                            ' Dim ypnos As Single = Math.Round(total_amount / checkout.Date.Subtract(checkin).Days, 2) + day_taxes
                            'Dim ypnos As Single = Math.Ceiling(total_amount / checkout.Date.Subtract(checkin).Days * 100) / 100 + day_taxes
                            Dim ypnos As Single = Math.Ceiling(total_amount / checkout.Date.Subtract(checkin).Days * 100) / 100 + day_taxes
                            imeres = checkout.Date.Subtract(checkin).Days

                            command.Parameters.AddWithValue("@ypnos", ypnos)
                            command.Parameters.AddWithValue("@imeres", imeres)
                            command.Parameters.AddWithValue("@synolo", ypnos * imeres)
                            command.Parameters.AddWithValue("@touristperiod", touristperiod)
                            command.Parameters.AddWithValue("@xrewsi", xrewsi)

                            command.CommandText = "INSERT INTO timeskratisis (kratisi, timi, apo, mexri, ypnos, imeres, synolo, touristperiod, xrewsi) " &
                      "VALUES (@kratisi, @timi, @apo, @mexri, @ypnos, @imeres, @synolo, @touristperiod, @xrewsi)"

                            command.ExecuteNonQuery()

                            command.Parameters.Clear()

                            ' always call Close when done reading.

                            command.Parameters.Clear()
                        Catch ex As InvalidOperationException
                            MsgBox("Δεν μπόρεσε φορτωθεί η κράτηση: " + booking_id + " Αλλαγή τουρ. περιόδου χωρις αλλαγή τιμών", MsgBoxStyle.Critical)
                            transaction.Rollback()
                            Return 0
                        End Try
                    End If

                    'elegxos ean timeskratisis synolo einai to isio me synolo stis kratiseis!
                    command.Parameters.AddWithValue("@kratisi", kwdneaskrat)
                    command.CommandText = "SELECT SUM(synolo) from timeskratisis WHERE (kratisi=@kratisi)"
                    myReader = command.ExecuteReader()
                    ' Always call Read before accessing data.
                    myReader.Read()
                    Dim poso As Single = myReader.GetDouble(0)
                    command.Parameters.Clear()
                    myReader.Close()

                    Dim posoDiff As Double = 0
                    If poso <> CType(total_amount, Single) Then
                        posoDiff = Math.Round(poso - total_amount, 2)

                    End If
                    If posoDiff <> 0 Then
                        command.Parameters.AddWithValue("@ekptosi", 1)
                        command.Parameters.AddWithValue("@ekptposo", posoDiff)
                        command.Parameters.AddWithValue("@kwd", kwdneaskrat)
                        command.CommandText = "UPDATE kratiseis SET ekptosi=@ekptosi, ekptposo=@ekptposo  WHERE (kwd=@kwd)"
                        command.ExecuteNonQuery()
                        command.Parameters.Clear()
                    End If



                    If guest.Length = 0 Then
                        command.Parameters.AddWithValue("@kratisi", kwdneaskrat)
                        If lead_name <> "" Then
                            command.Parameters.AddWithValue("@onomateponimo", lead_name)
                        Else
                            command.Parameters.AddWithValue("@onomateponimo", booking_id)
                        End If


                        command.CommandText = "INSERT INTO enilikes (kratisi, onomateponimo)" &
                      "values (@kratisi, @onomateponimo)"

                        command.ExecuteNonQuery()
                        command.Parameters.Clear()
                    Else
                        For i = 0 To guest.Length - 1
                            command.Parameters.AddWithValue("@kratisi", kwdneaskrat)
                            command.Parameters.AddWithValue("@onomateponimo", guest(i))
                            command.CommandText = "INSERT INTO enilikes (kratisi, onomateponimo)" &
                          "values (@kratisi, @onomateponimo)"

                            command.ExecuteNonQuery()
                            command.Parameters.Clear()
                        Next
                    End If


                    If agesOfChildren IsNot Nothing AndAlso agesOfChildren.Count > 0 Then
                        ' 'ages' is not null and contains at least one element
                        For Each age As Integer In agesOfChildren
                            command.Parameters.AddWithValue("@kratisi", kwdneaskrat)
                            command.Parameters.AddWithValue("@ilikia", age)
                            command.Parameters.AddWithValue("@cot", "")
                            command.CommandText = "INSERT INTO paidia (kratisi, ilikia, cot)" &
                          "values (@kratisi, @ilikia, @cot)"

                            command.ExecuteNonQuery()
                            command.Parameters.Clear()
                        Next
                    Else
                        ' 'ages' is either null or empty
                        Console.WriteLine("No ages of children found.")
                    End If

                    command.Parameters.AddWithValue("@kratisi", kwdneaskrat)
                    command.Parameters.AddWithValue("@name", lead_name)
                    command.Parameters.AddWithValue("@id", id)
                    command.Parameters.AddWithValue("@modified_date", CType(modified_date, Date))
                    command.Parameters.AddWithValue("@channel_key", channel_key)
                    command.Parameters.AddWithValue("@booking_id", booking_id)
                    command.Parameters.AddWithValue("@room_booking_id", dwm)
                    command.Parameters.AddWithValue("@room_rate_type", roomratetype_id)
                    command.Parameters.AddWithValue("@status", status)
                    command.Parameters.AddWithValue("@confirmed", CType(confirmed, Byte))
                    command.Parameters.AddWithValue("@state", state)
                    command.Parameters.AddWithValue("@afixi", CType(checkin, Date))
                    command.Parameters.AddWithValue("@anaxwrisi", CType(checkout, Date))

                    command.CommandText = "INSERT INTO Reservations (kratisi, name, id, modified_date, channel_key, booking_id, room_booking_id, room_rate_type, status, confirmed, state, afixi, anaxwrisi) " &
                      "VALUES (@kratisi, @name, @id, @modified_date, @channel_key, @booking_id, @room_booking_id, @room_rate_type, @status, @confirmed, @state, @afixi, @anaxwrisi)"

                    command.ExecuteNonQuery()

                    command.Parameters.Clear()
                    'edw NEO copy kratisis   command.Parameters.AddWithValue("kwd", myReader.Item("kwd"))




                    transaction.Commit()

                    'TEST SQL SERVER 
                    'Try

                    '    Dim calender As New GoogleCalendar(arithmos, lead_name, CType(checkin, Date), CType(checkout, Date), dwm, dwm, epithimia, praktimologio)
                    '    calender.send_entry()

                    '    calender = New GoogleCalendar(arithmos, lead_name, CType(checkin, Date), CType(checkout, Date), "THLS", dwm, epithimia, praktimologio)
                    '    calender.send_entry()




                    'Catch ex As Exception
                    '    MsgBox(" Παρουσιάστηκε σφάλμα κατά την Ενημέρωση του Google Calendar !", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                    'End Try
                    kwdneaskratisis = kwdneaskrat
                    arkratisis = arithmos

                    Return 1
                Catch ex As Exception
                    MsgBox("Η Διαδικασία απέτυχε ! " + ex.Message, MsgBoxStyle.Critical, "winfo\nikEl.")
                    Try
                        transaction.Rollback()
                        Return 0
                    Catch
                        Return 0
                    End Try

                End Try



            End Using


        End Function
        Function SendMailwithDirections(ByVal data As String) As Threading.Thread
            Dim theThread _
                As New Threading.Thread(AddressOf SendMailDirections)
            theThread.Start(data)

            Return theThread

        End Function
        Private Sub SendMailDirections(ByVal data As String)
            Dim parts As String()
            Try
                parts = data.Split(New Char() {"+"c})


            Catch ex1 As ArgumentOutOfRangeException
                Exit Sub

            Catch ex As IndexOutOfRangeException
                Exit Sub
            End Try
            If parts(0) <> "" And parts(2) <> "" And parts(1) <> "" Then
                Dim body_ As String

                body_ = "Dear Mrs./Mr. " + parts(2) + "," + ChrW(13) + ChrW(13) + body + ChrW(13) + ChrW(13) + "Best regards, " + ChrW(13) + "Stelios Christidis" + ChrW(13) + " Executive Director"

                SendMailMultiAttach(from, parts(1), subject, body_, parts(0), smtpServer, smtpUsername, smtpPassword)
            End If

        End Sub
        'Private Sub SendMailDirections1(ByVal parameter As String)
        '    Dim from, body, smtpServer, smtpUsername, smtpPassword, subject As String
        '    Dim mailTemp, name, vila As String
        '    Dim j, i As Int16
        '    'Dim datum As Date

        '    Dim param() As String
        '    param = parameter.Split("$")
        '    vila = param(0)
        '    mailTemp = param(1)
        '    name = param(2)
        '    Dim mailadapter As New dbhotelDataSetTableAdapters.MailTableAdapter
        '    mailadapter.Fill(Me.DbhotelDataSet.Mail)


        '    'Me.AfixeisAnaxwriseis2TableAdapter.AfixeisByEtosImerom_(Me.DbhotelDataSet.AfixeisAnaxwriseis2, etos, ImerKatastPicker.Value.Date, ImerKatastPicker.Value.Date, ImerKatastPicker.Value.Date, ImerKatastPicker.Value.Date, etos, ImerKatastPicker.Value.Date, ImerKatastPicker.Value.Date, ImerKatastPicker.Value.Date, ImerKatastPicker.Value.Date)


        '    from = Me.DbhotelDataSet.Mail(0).ffrom
        '    subject = Me.DbhotelDataSet.Mail(2).subject
        '    smtpServer = Me.DbhotelDataSet.Mail(0).smtpServer
        '    smtpUsername = Me.DbhotelDataSet.Mail(0).smtpUsername
        '    smtpPassword = Me.DbhotelDataSet.Mail(0).smtpPassword
        '    'too = "mkallergis@gmail.com"
        '    body = "Dear Mrs./Mr. " + name + "," + ChrW(13) + ChrW(13) + Me.DbhotelDataSet.Mail(2).body
        '    SendMailMultiAttach(from, mailTemp, subject, body, vila, smtpServer, smtpUsername, smtpPassword)

        'End Sub
        Public Sub SendMailMultiAttach(ByVal from As String, ByVal [to] As String, ByVal subject As String, ByVal body As String, ByVal dwmatio As String, ByVal smtpServer As String, ByVal smtpUsername As String, ByVal smtpPassword As String)
            Dim j As Int16
            Dim instance As Attachment
            Dim pathstart As String = ""
            Dim fileName As String = ""
            Dim directionsAdapter As New dbhotelDataSetTableAdapters.directionsTableAdapter
            Dim directionsTable As New dbhotelDataSet.directionsDataTable
            directionsAdapter.FillDirectionsByVila(directionsTable, dwmatio)
            Try

                Dim message As New MailMessage(from, [to], subject, body)

                For j = 0 To directionsTable.Count - 1
                    If Not IsDBNull(directionsTable(j).Item("path")) Then
                        Try
                            Try
                                pathstart = Environment.GetEnvironmentVariable("location")
                                If pathstart <> "" Then
                                    fileName = directionsTable(j).path.Replace("N:", pathstart)
                                    instance = New Attachment(fileName)
                                Else
                                    instance = New Attachment(directionsTable(j).path)
                                End If

                            Catch ex1 As ArgumentNullException
                                instance = New Attachment(directionsTable(j).path)
                            End Try

                            '    instance As New Attachment(directionsTable(j).path)

                            message.Attachments.Add(instance)

                        Catch ex As System.IO.DirectoryNotFoundException
                            MsgBox("Αδυναμία επισύναψης DIRECTIONS ", MsgBoxStyle.Exclamation)
                        End Try
                        'Try
                        '    Dim instance2 As New Attachment(Me.DbhotelDataSet.etaireia(0).dieuthinsi)
                        '    message.Attachments.Add(instance2)
                        'Catch ex As System.IO.DirectoryNotFoundException
                        '    MsgBox("Αδυναμία επισύναψης έντυπου υποδοχής ", MsgBoxStyle.Exclamation)
                        'End Try
                    End If
                Next

                If message.Attachments.Count <> 0 Then
                    Dim smtpClient As New SmtpClient(smtpServer, 25)

                    smtpClient.UseDefaultCredentials = False

                    Dim credentials As New NetworkCredential(smtpUsername, smtpPassword)

                    smtpClient.Credentials = credentials
                    smtpClient.EnableSsl = True
                    smtpClient.Send(message)

                End If


                'Dim instance As New Attachment(fileName)




            Catch ex1 As System.IO.FileNotFoundException
                MsgBox("Δεν βρέθηκε Attachment για Directions ", MsgBoxStyle.Exclamation)
            Catch ex3 As System.FormatException
                MsgBox("Η Διεύθυνση email για αποστολή Directions είναι λάθος καταχωρημένη ", MsgBoxStyle.Exclamation)
            Catch ex2 As System.IO.DirectoryNotFoundException
                MsgBox("Δεν βρέθηκε o φάκελος για αποστολή Directions ", MsgBoxStyle.Exclamation)

            Catch ex As Exception
                MsgBox("Αδυναμία αποστολής email " + ex.ToString, MsgBoxStyle.Exclamation)
            End Try

        End Sub

        Public Sub set_email_parameter(ByVal from_ As String, ByVal subject_ As String, ByVal server As String, ByVal user As String, ByVal pass As String, ByVal body_ As String)
            from = from_
            subject = subject_
            smtpServer = server
            smtpUsername = user
            smtpPassword = pass
            body = body_

        End Sub
    End Class
    Public Class Allotment
        Public Property [from] As String
        Public Property [to] As String
        Public Property allot As Integer
    End Class

    Public Class Reservation
        Public Property id As Int32
        Public Property status As Byte
        Public Property roomStay As RoomStay
        Public Property pricing As Pricing
        Public Property bookInfo As BookInfo
        Public Property clientInfo As ClientInfo
        Public Property guestNames As List(Of String)
        Public Property constraints As Constraints
        Public Property policies As Policies
        Public Property rooms As List(Of Room)
        Public Property extras As List(Of Extras)
        Public Property taxes As List(Of Taxes)
        Public Property excluded_charges As List(Of ExcludedCharge)
        Public Property preferences As List(Of Preference)
        Public Property changes As List(Of Changes)
        Public Property special_requests As String
        Public Property channel_notes As String
        Public Property additional_fields As List(Of AdditionalFields)
    End Class
    Public Class RoomStay
        Public Property roomType As String 'FAM
        Public Property roomName As String ' Family Room
        Public Property rateID As Integer '535283
        Public Property rateName As String' ' Family Room Non Refundable
        Public Property board As Integer?
        Public Property rooms As Integer
        Public Property from As String ' 2023-02-25
        Public Property [to] As String ' 2023-03-04
        Public Property rateDesc As String
    End Class
    Public Class Pricing
        Public Property price As Double ' 1120.00
        Public Property currency As String
        Public Property subTotal As Double '1120.00
        Public Property extras As Double '0.00
        Public Property taxes As Double '0.00
        Public Property excluded_charges As Double '0.00
    End Class


    Public Class BookInfo
        Public Property bookDate As DateTime '2023-02-07T11:19:19Z
        Public Property bookingCode As String ' ""
        Public Property voucherCode As String ' ""
        Public Property voucherCredt As VoucherCredit
        Public Property referer As String
        Public Property source As String
        Public Property source_id As String
        Public Property agent_id As Object
        Public Property agent As String
        Public Property corp_id As Object ' NULL
        Public Property corp As String '""
        Public Property remote_ip As String
        Public Property remote_country As String ' "GR"
    End Class
    Public Class VoucherCredit
        Public Property voucherCode As String
        Public Property voucherValue As Decimal
    End Class
    'Dim pricing As Pricing = JsonConvert.DeserializeObject(Of Pricing)(jsonObject("pricing").ToString())
    Public Class ClientInfo
        Public Property FirstName As String ' "Αθηνά"
        Public Property LastName As String ' "Τασιοπούλου
        Public Property Email As String ' "makkk@asfd
        Public Property Tel As String ' "6973983915"
        Public Property Country As String ' "GR"
        Public Property Address As String ' "Δασκαλάλη22 
        Public Property Postal As String ' "74100"
        Public Property Location As String ' "Ρεθυμνου
        Public Property Region As String
        Public Property Company As String
        Public Property Purpose As String
        Public Property Remarks As String
        Public Property Arrival As ArrivalDetails
        Public Property Departure As DepartureDetails
    End Class
    Public Class ArrivalDetails
        Public Property ArrivalDate As String
        Public Property Time As String
        Public Property Details As String
    End Class

    Public Class DepartureDetails
        Public Property [Date] As DateTime
        Public Property Time As String
        Public Property Details As String
    End Class
    Public Class Constraints
        Property MinStay As Integer ' 1
        Property MaxStay As Integer? ' null
        Property FreeCancelDays As Integer '-1
        Property FreeCancelExpiry As String ' ""
    End Class
    Public Class Policies
        Public Property Cancellation As String
        Public Property Payment As String ' On Arrival
        Public Property External As String
        Public Property Payments As List(Of Payment) ' 
        Public Property Cancellation_fees As List(Of CancellationFee)


    End Class
    Public Class Payment
        Public Property Due As DateTime '2023-02-27-4T16:00:00Z mallon tote poy egine i kratisi kai bebaiwthike to synoliko poso apo katw!
        Public Property Amount As Double ' poso synolo 1120.00
    End Class

    Public Class CancellationFee
        Public Property After As DateTime
        Public Property Fee As Double
    End Class
    'Public Property Price As Double ' SYNOLO 1120
    'Public Property PriceWithTax As Double ' 1120
    Public Class Room
        Public Property RoomNo As Integer ' No 1
        Public Property Adults As Integer ' 2
        Public Property Children As Integer ' 0
        Public Property Infants As Integer ' 0
        Public Property Rates As List(Of RoomRate) ' mera mera timi ana imera 
        Public ReadOnly Property Price As Double
            Get
                Dim prAmount As Double = 0.0
                For Each rate As RoomRate In Rates
                    prAmount += rate.Price
                Next
                Return prAmount
            End Get
        End Property

        Public ReadOnly Property PriceWithTax As Double
            Get
                Dim prtaxAmount As Double = 0.0
                For Each rate As RoomRate In Rates
                    prtaxAmount += rate.price_with_tax
                Next
                Return prtaxAmount
            End Get
        End Property
    End Class

    Public Class RoomRate
        Public Property [Date] As DateTime  '2023-02-25 
        Public Property Price As Double ' poso imeras sunolo 160.00 
        Public Property price_with_tax As Double
    End Class

    Public Class Extras
        Public Property Id As Integer
        Public Property Name As String
        Public Property Quantity As Integer
        Public Property Price As Decimal
        Public Property Pricingextras As Pricing
    End Class
    Public Class Pricingextras
        Public Property UnitPrice As Decimal
        Public Property PerRoom As Boolean
        Public Property PerDay As Boolean
        Public Property PerAdult As Boolean
        Public Property PerChild As Boolean
        Public Property PerInfant As Boolean
    End Class
    Public Class Taxes
        Public Property Order As Integer
        Public Property Description As String
        Public Property Included As Boolean
        Public Property Type As String
        Public Property Value As Decimal
        Public Property Pricing As TaxPricing
    End Class

    Public Class TaxPricing
        Public Property PerRoom As Boolean
        Public Property PerDay As Boolean
        Public Property PerAdult As Boolean
        Public Property PerChild As Boolean
        Public Property PerInfant As Boolean
    End Class

    Public Class ExcludedCharge
        Property Description As String
        Property Type As String
        Property Value As Decimal
        Property Pricing As ExcludedChargePricing
    End Class

    Public Class ExcludedChargePricing
        Property PerRoom As Boolean
        Property PerDay As Boolean
        Property PerAdult As Boolean
        Property PerChild As Boolean
        Property PerInfant As Boolean
    End Class
    Public Class Preference
        Public Property Id As Integer
        Public Property Type As String
        Public Property Name As String
        Public Property Title As String
        Public Property Value As String
    End Class
    Public Class Changes
        Public Property UserType As String
        Public Property UserName As String
        Public Property [Date] As DateTime
        Public Property Type As String
    End Class
    Public Class AdditionalFields
        Public Property Code As String
        Public Property Value As String
    End Class


End Module
