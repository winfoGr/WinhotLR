Imports System.IO
Imports System.Xml
Imports System.Text
Imports System.Net
Imports System.Globalization
Imports System.Threading
Imports System.Net.Mail

Module HotelAvailabilities


    Public Class RoomRateTypes
        Dim link As String

        Dim user As String
        Dim password As String
        Dim property_id As String
        Dim connection_string As String
        Public Sub New(ByVal conn As String, ByVal lnk As String, ByVal usr As String, ByVal pwd As String, ByVal prop_id As String)
            connection_string = conn
            link = lnk
            user = usr
            password = pwd
            property_id = prop_id
            '  response()
        End Sub
        'Public Sub New()
        '    link = "testLinkl"
        '    user = "domisi"
        '    password = "stavros"
        '    property_id = "propID"
        '    response()
        'End Sub
        Public Function make_XML_request() As Boolean
            Dim result As String = ""
            Dim Stream As New MemoryStream()
            Dim writer As New XmlTextWriter(Stream, System.Text.Encoding.UTF8)
            'Dim writer As New XmlTextWriter("file.xml", System.Text.Encoding.UTF8)

            '  Dim writer As New StringWriter(sb)

            writer.WriteProcessingInstruction("xml", "version=""1.0"" encoding=""UTF-8""")
            ' writer.WriteStartDocument(False)
            writer.Formatting = Formatting.Indented
            writer.Indentation = 2
            writer.WriteStartElement("Request")

            writer.WriteStartElement("Language")
            writer.WriteString("el")
            writer.WriteEndElement()

            writer.WriteStartElement("Authentication")
            writer.WriteAttributeString("User", user)
            writer.WriteAttributeString("Password", password)

            writer.WriteEndElement()

            writer.WriteStartElement("GetRoomRateTypes")
            writer.WriteAttributeString("property_id", property_id)
            writer.WriteEndElement()

            writer.WriteEndElement()
            writer.Flush()

            Dim reader = New StreamReader(Stream, Encoding.UTF8, True)
            Stream.Seek(0, SeekOrigin.Begin)
            result = reader.ReadToEnd()
            ' MsgBox(result)
            '  Return False

            Return send_request_get_roomtypes(result)
        End Function

        Public Function send_request_get_roomtypes(ByVal req As String) As Boolean
            Dim istOK As Boolean = False
            Dim id As String = ""

            '  Dim master_roomratetype_i As String
            '   Dim linked_roomratetype_id As String
            Dim created_at As Date
            Dim updated_at As Date
            Dim name As String = ""
            ' Dim show_on_calendar As Byte
            '  Dim lowest_price As Single
            Dim total_rooms As Int16
            Dim min_stay As Int16
            Dim stop_sell As Byte
            'Dim cta As Byte
            'Dim ctd As Byte
            Dim xmldoc As New XmlDocument
            Dim xmlError, xmlnode As XmlNodeList
            '   ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
            Dim request As WebRequest = WebRequest.Create(link)
            request.Credentials = CredentialCache.DefaultCredentials
            request.Method = "POST"

            Dim byteArray As Byte() = Encoding.UTF8.GetBytes(req)

            request.ContentType = "text/xml"
            request.ContentLength = byteArray.Length

            ' Get the request stream.  
            Dim dataStream As Stream = request.GetRequestStream()
            ' Write the data to the request stream.  
            dataStream.Write(byteArray, 0, byteArray.Length)
            ' Close the Stream object.  
            dataStream.Close()

            Dim response As WebResponse = request.GetResponse()

            Using Stream As Stream = response.GetResponseStream()
                ' Open the stream using a StreamReader for easy access.  

                ' Read the content.  
                xmldoc.Load(Stream)

                xmlError = xmldoc.GetElementsByTagName("Error")

                If xmlError.Count <> 0 Then
                    For Each node1 As XmlNode In xmlError
                        MsgBox(node1.InnerText)
                        istOK = False
                    Next
                Else
                    xmlnode = xmldoc.GetElementsByTagName("RoomRateType")

                    If xmlnode.Count <> 0 Then
                        For Each node As XmlNode In xmlnode
                            For Each attr As XmlAttribute In node.Attributes
                                If attr.Name.Equals("id") Then
                                    id = attr.InnerText
                                ElseIf attr.Name.Equals("created_at") Then
                                    created_at = attr.InnerText
                                ElseIf attr.Name.Equals("updated_at") Then
                                    updated_at = attr.InnerText
                                ElseIf attr.Name.Equals("name") Then
                                    name = attr.InnerText
                                    'ElseIf attr.Name.Equals("lowest_price") Then
                                    '    lowest_price = attr.InnerText
                                ElseIf attr.Name.Equals("total_rooms") Then
                                    total_rooms = attr.InnerText
                                ElseIf attr.Name.Equals("min_stay") Then
                                    min_stay = attr.InnerText
                                ElseIf attr.Name.Equals("stop_sell") Then
                                    stop_sell = attr.InnerText
                                End If
                                Console.WriteLine("{0}", attr.Name & " = " & attr.InnerText)
                            Next
                            execute_insert_roomratetype(id, created_at, updated_at, name, total_rooms, min_stay, stop_sell)
                        Next
                        istOK = True
                    Else
                        MsgBox("error")
                    End If

                End If

            End Using
            Return istOK
        End Function
        Public Sub response()
            Dim id As String = ""

            '  Dim master_roomratetype_i As String
            '   Dim linked_roomratetype_id As String
            Dim created_at As Date
            Dim updated_at As Date
            Dim name As String = ""
            ' Dim show_on_calendar As Byte
            '  Dim lowest_price As Single
            Dim total_rooms As Int16
            Dim min_stay As Int16
            Dim stop_sell As Byte
            'Dim cta As Byte
            'Dim ctd As Byte
            Dim xmldoc As New XmlDocument
            Dim xmlnode As XmlNodeList

            Dim fs As New FileStream("file.xml", FileMode.Open, FileAccess.Read)
            xmldoc.Load(fs)
            xmlnode = xmldoc.GetElementsByTagName("RoomRateType")

            For Each node As XmlNode In xmlnode
                For Each attr As XmlAttribute In node.Attributes
                    If attr.Name.Equals("id") Then
                        id = attr.InnerText
                    ElseIf attr.Name.Equals("created_at") Then
                        created_at = attr.InnerText
                    ElseIf attr.Name.Equals("updated_at") Then
                        updated_at = attr.InnerText
                    ElseIf attr.Name.Equals("name") Then
                        name = attr.InnerText
                        'ElseIf attr.Name.Equals("lowest_price") Then
                        '    lowest_price = attr.InnerText
                    ElseIf attr.Name.Equals("total_rooms") Then
                        total_rooms = attr.InnerText
                    ElseIf attr.Name.Equals("min_stay") Then
                        min_stay = attr.InnerText
                    ElseIf attr.Name.Equals("stop_sell") Then
                        stop_sell = attr.InnerText


                    End If
                    Console.WriteLine("{0}", attr.Name & " = " & attr.InnerText)
                Next
                execute_insert_roomratetype(id, created_at, updated_at, name, total_rooms, min_stay, stop_sell)
            Next

        End Sub

        Private Sub execute_insert_roomratetype(ByVal id As String, ByVal created As Date, ByVal updated As Date, ByVal name As String, _
                                                ByVal trooms As Int16, ByVal minstay As Int16, ByVal stopsales As Byte)



            Using connection As New OleDb.OleDbConnection(connection_string)
                Dim command As New OleDb.OleDbCommand()
                Dim transaction As OleDb.OleDbTransaction = Nothing
                Try

                    connection.Open()
                    transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted)
                    command.Connection = connection
                    command.Transaction = transaction
                    command.Parameters.AddWithValue("id", id)
                    command.Parameters.AddWithValue("created", created)
                    command.Parameters.AddWithValue("updated", updated)
                    command.Parameters.AddWithValue("property", property_id)
                    command.Parameters.AddWithValue("name", name)
                    command.Parameters.AddWithValue("trooms", trooms)
                    command.Parameters.AddWithValue("minstay", minstay)
                    command.Parameters.AddWithValue("stopsales", stopsales)

                    command.CommandText = "INSERT INTO RoomRateTypes (id, created_at, updated_at, property_id, name, total_rooms,  min_stay, stop_sell)" & _
                     "values (id, created, updated, property, name, trooms, minstay, stopsales)"
                    command.ExecuteNonQuery()
                    command.Parameters.Clear()

                    transaction.Commit()
                    '   Return 1
                Catch ex As Exception
                    MsgBox("Η Διαδικασία απέτυχε !", MsgBoxStyle.Critical, "winfo\nikEl.")
                    Try
                        transaction.Rollback()
                        '  Return -1
                    Catch
                        '    Return -1
                    End Try

                End Try
            End Using
        End Sub
    End Class



    Public Class GetReservations
        Structure rate
            Dim day As Date
            Dim amount As String
        End Structure

        Dim link As String

        Dim user As String
        Dim password As String
        Dim property_id As String
        Dim connection_string As String
        Dim from_modified As String
        Dim to_modified As String
        Dim from_checkin As String
        Dim to_checkout As String

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

        Dim from As String '= Me.DbhotelDataSet.Mail(0).ffrom
        Dim subject As String ' = Me.DbhotelDataSet.Mail(2).subject
        Dim smtpServer As String ' = Me.DbhotelDataSet.Mail(0).smtpServer
        Dim smtpUsername As String '= Me.DbhotelDataSet.Mail(0).smtpUsername
        Dim smtpPassword As String ' = Me.DbhotelDataSet.Mail(0).smtpPassword
        Dim body As String '
        Public Sub New(ByVal conn As String, ByVal lnk As String, ByVal usr As String, ByVal pwd As String, ByVal prop_id As String, ByVal fromod As Date, ByVal tomod As Date, ByVal fromin As Date, ByVal toout As Date)

            System.Threading.Thread.CurrentThread.CurrentCulture = englishCulture
            connection_string = conn
            link = lnk
            user = usr
            password = pwd
            property_id = prop_id
            from_modified = fromod
            to_modified = tomod
            from_checkin = fromin
            to_checkout = toout
        End Sub
        Public Sub set_email_parameter(ByVal from_ As String, ByVal subject_ As String, ByVal server As String, ByVal user As String, ByVal pass As String, ByVal body_ As String)
            from = from_
            subject = subject_
            smtpServer = server
            smtpUsername = user
            smtpPassword = pass
            body = body_

        End Sub
        Public Sub make_XML_file_for_request()
            Dim i As Int16
            '   Dim result As String = ""
            Dim Stream As New MemoryStream()


            Dim mySettings As New XmlWriterSettings()
            mySettings.NewLineOnAttributes = True
            mySettings.Encoding = System.Text.Encoding.UTF8
            mySettings.Indent = True
            mySettings.IndentChars = "      "

            Dim writer = (XmlTextWriter).Create("file" + DateTime.Parse(from_modified).ToString("yyyy-MM-dd") + ".xml", mySettings)

            '   Dim writer As New XmlTextWriter(Stream, System.Text.Encoding.UTF8)
            '  Dim writer As New XmlTextWriter("file.xml", System.Text.Encoding.UTF8)

            '  Dim writer As New StringWriter(sb)

            '  writer.WriteProcessingInstruction("xml", "version=""1.0"" encoding=""UTF-8""")
            writer.WriteStartDocument(True)
            'writer.Formatting = Formatting.Indented
            'writer.Indentation = 2
            writer.WriteStartElement("Request")

            writer.WriteStartElement("Language")
            writer.WriteString("el")
            writer.WriteEndElement()

            writer.WriteStartElement("Authentication")
            writer.WriteAttributeString("User", user)
            writer.WriteAttributeString("Password", password)

            writer.WriteEndElement()

            writer.WriteStartElement("GetReservations")
            writer.WriteAttributeString("property_id", property_id)

            writer.WriteAttributeString("from_modified_date", DateTime.Parse(from_modified).ToString("yyyy-MM-dd"))
            writer.WriteAttributeString("to_modified_date", DateTime.Parse(to_modified).ToString("yyyy-MM-dd"))
            writer.WriteAttributeString("from_checkin", DateTime.Parse(from_checkin).ToString("yyyy-MM-dd"))
            writer.WriteAttributeString("to_checkout", DateTime.Parse(to_checkout).ToString("yyyy-MM-dd"))

            writer.WriteEndElement()

            writer.WriteEndElement()
            'writer.Flush()
            writer.WriteEndDocument()
            writer.close()
            'Dim reader = New StreamReader(Stream, Encoding.UTF8, True)
            'Stream.Seek(0, SeekOrigin.Begin)
            'result = reader.ReadToEnd()

        End Sub

        Public Function request() As String
            Dim result As String = ""
            Dim Stream As New MemoryStream()

            'Dim myXmlString As String
            Dim mySettings As New XmlWriterSettings()
            mySettings.NewLineOnAttributes = True
            mySettings.Encoding = System.Text.Encoding.UTF8
            mySettings.Indent = True
            mySettings.IndentChars = "      "

            Dim writer = (XmlTextWriter).Create(Stream, mySettings)

            '    Dim writer As New XmlTextWriter(Stream, System.Text.Encoding.UTF8)


            '  writer.WriteProcessingInstruction("xml", "version=""1.0"" encoding=""UTF-8""")
            '   writer.Formatting = Formatting.Indented
            ' writer.Formatting = Formatting.Indented
            'writer.Indentation = 3

            '  writer.Settings.NewLineOnAttributes = True

            writer.WriteStartElement("Request")

            writer.WriteStartElement("Language")
            writer.WriteString("el")
            writer.WriteEndElement()

            writer.WriteStartElement("Authentication")
            writer.WriteAttributeString("User", user)
            writer.WriteAttributeString("Password", password)

            writer.WriteEndElement()

            writer.WriteStartElement("GetReservations")
            writer.WriteAttributeString("property_id", property_id)

            writer.WriteAttributeString("from_modified_date", DateTime.Parse(from_modified).ToString("yyyy-MM-dd"))
            writer.WriteAttributeString("to_modified_date", DateTime.Parse(to_modified).ToString("yyyy-MM-dd"))
            writer.WriteAttributeString("from_checkin", DateTime.Parse(from_checkin).ToString("yyyy-MM-dd"))
            writer.WriteAttributeString("to_checkout", DateTime.Parse(to_checkout).ToString("yyyy-MM-dd"))

            writer.WriteEndElement()

            writer.WriteEndElement()
            writer.Flush()
            'Dim file As New FileStream("file.xml", FileMode.Create, FileAccess.Write)
            'Stream.WriteTo(file)
            'file.Close()
            Dim reader = New StreamReader(Stream, Encoding.UTF8, True)
            Stream.Seek(0, SeekOrigin.Begin)


            result = reader.ReadToEnd()
            Return send_request(result) 'false
        End Function
        'Public Function send_request_test() As Boolean
        '    'Dim id As String = ""

        '    ''  Dim master_roomratetype_i As String
        '    ''   Dim linked_roomratetype_id As String
        '    'Dim created_at As Date
        '    'Dim updated_at As Date
        '    'Dim name As String = ""
        '    '' Dim show_on_calendar As Byte
        '    ''  Dim lowest_price As Single
        '    'Dim total_rooms As Int16
        '    'Dim min_stay As Int16
        '    'Dim stop_sell As Byte
        '    ''Dim cta As Byte
        '    ''Dim ctd As Byte
        '    Dim greekCulture As New System.Globalization.CultureInfo("en-US", False)
        '    System.Threading.Thread.CurrentThread.CurrentCulture = greekCulture
        '    Dim xmldoc As New XmlDocument
        '    Dim xmlnode As XmlNodeList

        '    Dim fs As New FileStream("file.xml", FileMode.Open, FileAccess.Read)


        '    'Dim xmlnode As XmlNodeList
        '    Dim istOK As Boolean

        '    'ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
        '    'Dim request As WebRequest = WebRequest.Create(link)
        '    'request.Credentials = CredentialCache.DefaultCredentials
        '    'request.Method = "POST"

        '    'Dim byteArray As Byte() = Encoding.UTF8.GetBytes(requestString)

        '    'request.ContentType = "text/xml"
        '    'request.ContentLength = byteArray.Length

        '    '' Get the request stream.  
        '    'Dim dataStream As Stream = request.GetRequestStream()
        '    '' Write the data to the request stream.  
        '    'dataStream.Write(byteArray, 0, byteArray.Length)
        '    '' Close the Stream object.  
        '    'dataStream.Close()

        '    'Dim response As WebResponse = request.GetResponse()

        '    Using Stream As Stream = fs
        '        xmldoc.Load(Stream)
        '        xmlnode = xmldoc.GetElementsByTagName("Error")
        '        If xmlnode.Count <> 0 Then
        '            For Each node1 As XmlNode In xmlnode
        '                MsgBox(node1.InnerText)
        '                istOK = False
        '            Next
        '        Else
        '            xmlnode = xmldoc.GetElementsByTagName("Success")
        '            If xmlnode.Count <> 0 Then
        '                xmlnode = xmldoc.GetElementsByTagName("Reservation")

        '                For Each node As XmlNode In xmlnode

        '                    Dim rates() As rate
        '                    ReDim rates(-1)
        '                    Dim guest() As String
        '                    ReDim guest(-1)
        '                    Dim requests() As String
        '                    ReDim requests(-1)
        '                    For Each attr As XmlAttribute In node.Attributes
        '                        If attr.Name.Equals("id") Then
        '                            id = attr.InnerText
        '                        ElseIf attr.Name.Equals("created_at") Then
        '                            created_at = attr.InnerText
        '                        ElseIf attr.Name.Equals("updated_at") Then
        '                            updated_at = attr.InnerText
        '                        ElseIf attr.Name.Equals("roomratetype_id") Then
        '                            roomratetype_id = attr.InnerText
        '                            'ElseIf attr.Name.Equals("lowest_price") Then
        '                            '    lowest_price = attr.InnerText
        '                        ElseIf attr.Name.Equals("channel_key") Then
        '                            channel_key = attr.InnerText
        '                        ElseIf attr.Name.Equals("channel_id") Then
        '                            channel_id = attr.InnerText
        '                        ElseIf attr.Name.Equals("booking_id") Then
        '                            booking_id = attr.InnerText
        '                        ElseIf attr.Name.Equals("booking_date") Then
        '                            booking_date = attr.InnerText
        '                        ElseIf attr.Name.Equals("modified_date") Then
        '                            modified_date = attr.InnerText

        '                        ElseIf attr.Name.Equals("room_booking_id") Then
        '                            room_booking_id = attr.InnerText
        '                        ElseIf attr.Name.Equals("status") Then
        '                            status = attr.InnerText
        '                        ElseIf attr.Name.Equals("room_name") Then
        '                            room_name = attr.InnerText
        '                        ElseIf attr.Name.Equals("confirmed") Then
        '                            confirmed = attr.InnerText
        '                        ElseIf attr.Name.Equals("checkin") Then
        '                            checkin = attr.InnerText
        '                        ElseIf attr.Name.Equals("checkout") Then
        '                            checkout = attr.InnerText
        '                        ElseIf attr.Name.Equals("meal_plan") Then
        '                            meal_plan = attr.InnerText
        '                        ElseIf attr.Name.Equals("guests") Then
        '                            guests = attr.InnerText
        '                        ElseIf attr.Name.Equals("total_amount") Then
        '                            total_amount = Single.Parse(attr.InnerText, greekCulture).ToString("N")                                   ' total_amount = total_amount.ToString("C2")

        '                        ElseIf attr.Name.Equals("total_taxes") Then
        '                            total_taxes = attr.InnerText
        '                        ElseIf attr.Name.Equals("commission") Then
        '                            commission = attr.InnerText
        '                        ElseIf attr.Name.Equals("lead_name") Then
        '                            lead_name = attr.InnerText
        '                        ElseIf attr.Name.Equals("lead_email") Then
        '                            lead_email = attr.InnerText
        '                        ElseIf attr.Name.Equals("state") Then
        '                            state = attr.InnerText
        '                        ElseIf attr.Name.Equals("phones") Then
        '                            phones = attr.InnerText

        '                        End If

        '                        Console.WriteLine("{0}", attr.Name & " = " & attr.InnerText)
        '                    Next
        '                    If node.HasChildNodes Then
        '                        Dim i, r, g, q As Int16
        '                        r = 0
        '                        g = 0
        '                        q = 0

        '                        For i = 0 To node.ChildNodes.Count - 1

        '                            If node.ChildNodes(i).Name.Equals("rate") Then
        '                                ReDim Preserve rates(r)
        '                                For Each attr1 As XmlAttribute In node.ChildNodes(i).Attributes
        '                                    If attr1.Name.Equals("date") Then

        '                                        rates(r).day = attr1.InnerText
        '                                    ElseIf attr1.Name.Equals("amount") Then
        '                                        rates(r).amount = Single.Parse(attr1.InnerText, greekCulture).ToString("N")
        '                                        r += 1
        '                                    End If
        '                                Next

        '                            ElseIf node.ChildNodes(i).Name.Equals("guest") Then
        '                                ReDim Preserve guest(g)
        '                                guest(g) = node.ChildNodes(i).InnerText
        '                                g += 1
        '                            ElseIf node.ChildNodes(i).Name.Equals("request") Then
        '                                ReDim Preserve requests(q)
        '                                requests(q) = node.ChildNodes(i).InnerText
        '                                q += 1
        '                            End If

        '                        Next i
        '                    End If

        '                    If Not status.Equals("Cancellation") Then
        '                        execute_fortosi_kratisi_transaction(connection_string, id, DateTime.Parse(modified_date), channel_key, booking_id, _
        '                                                           room_booking_id, roomratetype_id, DateTime.Parse(checkin), DateTime.Parse(checkout), _
        '                                                           meal_plan, guests, total_amount, status, confirmed, lead_email, state, phones, lead_name, guest, _
        '                                                           rates, requests)
        '                    Else
        '                        execute_delete_kratisi(connection_string, DateTime.Parse(modified_date), channel_key, booking_id, room_booking_id, status)
        '                    End If

        '                    'ReDim rates(-1)
        '                    ''    MsgBox(rates.Length)
        '                    'ReDim guest(-1)
        '                    'ReDim requests(-1)
        '                Next

        '                istOK = True
        '            End If
        '        End If

        '    End Using
        'End Function


        Public Function send_request(ByVal requestString As String) As Boolean
            Dim resp As MsgBoxResult
            Dim threadDirections As Threading.Thread
            '    Dim file As New FileStream("file.xml", FileMode.Create, FileAccess.Write)
            Dim sb As New StringBuilder

            Dim xmldoc As New XmlDocument

            Dim xmlnode As XmlNodeList
            Dim istOK As Boolean

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
            Dim request As WebRequest = WebRequest.Create(link)
            request.Credentials = CredentialCache.DefaultCredentials
            request.Method = "POST"

            Dim byteArray As Byte() = Encoding.UTF8.GetBytes(requestString)
            Dim dwmatio As String = ""
            request.ContentType = "text/xml"
            request.ContentLength = byteArray.Length

            ' Get the request stream.  
            Dim dataStream As Stream = request.GetRequestStream()
            ' Write the data to the request stream.  
            dataStream.Write(byteArray, 0, byteArray.Length)
            ' Close the Stream object.  
            dataStream.Close()
            Try
                Dim response As WebResponse = request.GetResponse()




                Using Stream As Stream = response.GetResponseStream()

                    'Stream.CopyTo(File)
                    'File.Close()
                    xmldoc.Load(Stream)
                    xmlnode = xmldoc.GetElementsByTagName("Error")
                    If xmlnode.Count <> 0 Then
                        For Each node1 As XmlNode In xmlnode
                            MsgBox(node1.InnerText)
                            istOK = False
                        Next
                    Else
                        xmlnode = xmldoc.GetElementsByTagName("Success")
                        If xmlnode.Count <> 0 Then
                            xmlnode = xmldoc.GetElementsByTagName("Reservation")

                            For Each node As XmlNode In xmlnode

                                Dim rates() As rate
                                ReDim rates(-1)
                                Dim guest() As String
                                ReDim guest(-1)
                                Dim requests() As String
                                ReDim requests(-1)
                                For Each attr As XmlAttribute In node.Attributes
                                    If attr.Name.Equals("id") Then
                                        id = attr.InnerText
                                    ElseIf attr.Name.Equals("created_at") Then
                                        created_at = attr.InnerText
                                    ElseIf attr.Name.Equals("updated_at") Then
                                        updated_at = attr.InnerText
                                    ElseIf attr.Name.Equals("roomratetype_id") Then
                                        roomratetype_id = attr.InnerText
                                        'ElseIf attr.Name.Equals("lowest_price") Then
                                        '    lowest_price = attr.InnerText
                                    ElseIf attr.Name.Equals("channel_key") Then
                                        channel_key = attr.InnerText
                                    ElseIf attr.Name.Equals("channel_id") Then
                                        channel_id = attr.InnerText
                                    ElseIf attr.Name.Equals("booking_id") Then
                                        booking_id = attr.InnerText
                                    ElseIf attr.Name.Equals("booking_date") Then
                                        booking_date = attr.InnerText
                                    ElseIf attr.Name.Equals("modified_date") Then
                                        modified_date = attr.InnerText

                                    ElseIf attr.Name.Equals("room_booking_id") Then
                                        room_booking_id = attr.InnerText
                                    ElseIf attr.Name.Equals("status") Then
                                        status = attr.InnerText
                                    ElseIf attr.Name.Equals("room_name") Then
                                        room_name = attr.InnerText
                                    ElseIf attr.Name.Equals("confirmed") Then
                                        confirmed = attr.InnerText
                                    ElseIf attr.Name.Equals("checkin") Then
                                        checkin = attr.InnerText
                                    ElseIf attr.Name.Equals("checkout") Then
                                        checkout = attr.InnerText
                                    ElseIf attr.Name.Equals("mealplantype") Then
                                        mealplantype = attr.InnerText
                                    ElseIf attr.Name.Equals("guests") Then
                                        guests = attr.InnerText
                                    ElseIf attr.Name.Equals("total_amount") Then
                                        total_amount = Single.Parse(attr.InnerText, englishCulture).ToString("N")
                                    ElseIf attr.Name.Equals("total_taxes") Then
                                        total_taxes = Single.Parse(attr.InnerText, englishCulture).ToString("N")
                                    ElseIf attr.Name.Equals("commission") Then
                                        commission = attr.InnerText
                                    ElseIf attr.Name.Equals("lead_name") Then
                                        lead_name = attr.InnerText
                                    ElseIf attr.Name.Equals("lead_email") Then
                                        lead_email = attr.InnerText
                                    ElseIf attr.Name.Equals("state") Then
                                        state = attr.InnerText
                                    ElseIf attr.Name.Equals("phones") Then
                                        phones = attr.InnerText
                                    ElseIf attr.Name.Equals("manual_adults") Then
                                        manual_adults = attr.InnerText
                                    ElseIf attr.Name.Equals("manual_children") Then
                                        manual_children = attr.InnerText
                                    End If

                                    Console.WriteLine("{0}", attr.Name & " = " & attr.InnerText)
                                Next
                                If node.HasChildNodes Then
                                    Dim i, r, g, q As Int16
                                    r = 0
                                    g = 0
                                    q = 0

                                    For i = 0 To node.ChildNodes.Count - 1

                                        If node.ChildNodes(i).Name.Equals("rate") Then
                                            ReDim Preserve rates(r)
                                            For Each attr1 As XmlAttribute In node.ChildNodes(i).Attributes
                                                If attr1.Name.Equals("date") Then

                                                    rates(r).day = attr1.InnerText
                                                ElseIf attr1.Name.Equals("amount") Then
                                                    rates(r).amount = Single.Parse(attr1.InnerText, englishCulture).ToString("N")
                                                    r += 1
                                                End If
                                            Next

                                        ElseIf node.ChildNodes(i).Name.Equals("guest") Then
                                            ReDim Preserve guest(g)
                                            guest(g) = node.ChildNodes(i).InnerText
                                            g += 1
                                        ElseIf node.ChildNodes(i).Name.Equals("request") Then
                                            ReDim Preserve requests(q)
                                            requests(q) = node.ChildNodes(i).InnerText
                                            q += 1
                                        End If

                                    Next i
                                End If
                                Dim ok As Int16
                                If status.Equals("Booking") Then
                                    ok = execute_fortosi_kratisi_transaction(connection_string, id, DateTime.Parse(modified_date), channel_key, booking_id, _
                                                                       room_booking_id, roomratetype_id, DateTime.Parse(checkin), DateTime.Parse(checkout), _
                                                                       mealplantype, guests, total_amount, total_taxes, status, confirmed, lead_email, state, phones, lead_name, guest, _
                                                                       rates, requests, dwmatio)
                                    If ok = 1 Then
                                        sb.AppendLine("STATUS: " + status + " CHANNEL: " + channel_key + "  BOOKING_ID: " + booking_id + "  ROOM: " + dwmatio + "  NAME:" + lead_name + " ARRIVAL: " + DateTime.Parse(checkin).ToString("dd/MM/yyyy") + " DEPARTURE: " + DateTime.Parse(checkout).ToString("dd/MM/yyyy") + " TOTAL: " + total_amount + vbNewLine)


                                        If lead_email <> "" And Not dwmatio.Equals("") Then 'AndAlso DateTime.Parse(checkin).Subtract(System.DateTime.Today.Date).Days < 5

                                            resp = MsgBox("Αποστολή email σε " + lead_name + " ?" + ChrW(13) + "  CHANNEL: " + channel_key + ChrW(13) + "  ROOM:" + dwmatio + ChrW(13) + "  ARRIVAL: " + DateTime.Parse(checkin).ToString("dd/MM/yyyy") + ChrW(13) + "  DEPARTURE: " + DateTime.Parse(checkout).ToString("dd/MM/yyyy"), MsgBoxStyle.YesNo, "winfo\nikEl.")
                                            If resp = MsgBoxResult.Yes Then
                                                Dim data As String = dwmatio + "+" + lead_email + "+" + lead_name
                                                threadDirections = SendMailwithDirections(data)
                                            End If
                                        ElseIf lead_email = "" Then
                                            MsgBox("Δεν υπάρχει email : " + status + " " + channel_key + " " + lead_name + " " + checkin.ToString + " " + checkout.ToString, MsgBoxStyle.Exclamation)

                                        End If
                                        dwmatio = ""
                                    End If
                                ElseIf status.Equals("Cancellation") Then

                                    ok = execute_delete_kratisi(connection_string, DateTime.Parse(modified_date), channel_key, booking_id, room_booking_id, status)
                                    If ok = 1 Then
                                        MsgBox(status + " " + channel_key + " " + lead_name + " " + checkin.ToString + " " + checkout.ToString, MsgBoxStyle.Information)
                                    ElseIf ok = -1 Then
                                        MsgBox("Αποτυχία διαγραφής. Ισως η κράτηση να έχει διαγρραφεί ήδη: " + status + " " + channel_key + " " + lead_name + " " + checkin.ToString + " " + checkout.ToString, MsgBoxStyle.Exclamation)
                                    End If

                                ElseIf status.Equals("Modification") Then

                                    ok = execute_delete_kratisi(connection_string, DateTime.Parse(modified_date), channel_key, booking_id, room_booking_id, status)
                                    If ok = -1 Then
                                        MsgBox("Αποτυχία σε κατάσταση MODIFICATION: Κίνδυνος ΔΙΠΛΗΣ ΚΡΑΤΗΣΗΣ! " + status + " " + channel_key + " " + lead_name + " " + checkin.ToString + " " + checkout.ToString, MsgBoxStyle.Exclamation)

                                    End If
                                    If ok <> 2 Then
                                        ok = execute_fortosi_kratisi_transaction(connection_string, id, DateTime.Parse(modified_date), channel_key, booking_id, _
                                                               room_booking_id, roomratetype_id, DateTime.Parse(checkin), DateTime.Parse(checkout), _
                                                               mealplantype, guests, total_amount, total_taxes, status, confirmed, lead_email, state, phones, lead_name, guest, _
                                                               rates, requests, dwmatio)
                                        If ok = 1 Then
                                            sb.AppendLine("STATUS: " + status + " CHANNEL: " + channel_key + "  BOOKING_ID: " + booking_id + "  ROOM:" + dwmatio + "  NAME:" + lead_name + " ARRIVAL: " + DateTime.Parse(checkin).ToString("dd/MM/yyyy") + " DEPARTURE: " + DateTime.Parse(checkout).ToString("dd/MM/yyyy") + " TOTAL: " + total_amount + vbNewLine)

                                            If lead_email <> "" And Not dwmatio.Equals("") Then 'AndAlso DateTime.Parse(checkin).Subtract(System.DateTime.Today.Date).Days < 5
                                                resp = MsgBox("Αποστολή email σε " + lead_name + " ?" + ChrW(13) + "  CHANNEL: " + channel_key + ChrW(13) + "  ROOM:" + dwmatio + ChrW(13) + "  ARRIVAL: " + DateTime.Parse(checkin).ToString("dd/MM/yyyy") + ChrW(13) + "  DEPARTURE: " + DateTime.Parse(checkout).ToString("dd/MM/yyyy"), MsgBoxStyle.YesNo, "winfo\nikEl.")
                                                If resp = MsgBoxResult.Yes Then
                                                    Dim data As String = dwmatio + "+" + lead_email + "+" + lead_name
                                                    threadDirections = SendMailwithDirections(data)
                                                End If

                                            End If
                                            dwmatio = ""
                                        Else
                                            MsgBox("Αποτυχία εισαγωγής σε κατάσταση MODIFICATION. Πιθανώς έχει γίνει ήδη εισαγωγή: " + status + " " + channel_key + " " + lead_name + " " + checkin.ToString + " " + checkout.ToString, MsgBoxStyle.Exclamation)
                                        End If
                                    End If



                                Else

                                End If

                                'ReDim rates(-1)
                                ''    MsgBox(rates.Length)
                                'ReDim guest(-1)
                                'ReDim requests(-1)
                            Next
                            If Not sb.ToString.Equals("") Then
                                MsgBox(String.Format(sb.ToString()))
                            Else
                                MsgBox("Δεν βρέθηκαν νέες κρατήσεις! ")
                            End If


                            istOK = True
                        End If
                    End If


                End Using

            Catch ex As WebException
                MsgBox("Αποτυχία επικοινωνίας με HotelAvailabilities", MsgBoxStyle.Exclamation)
                Return False
            End Try
            Return istOK
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

                body_ = "Dear Mrs./Mr. " + parts(2) + "," + ChrW(13) + ChrW(13) + "in the Attachment you can find useful Informations how to to entry the Hotel on your Arrival" + ChrW(13) + ChrW(13) + "Best regards, " + ChrW(13) + "Stelios Christidis" + ChrW(13) + " Executive Director"

                SendMailMultiAttach(from, parts(1), subject, body_, parts(0), smtpServer, smtpUsername, smtpPassword)
            End If
          
        End Sub
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
                    Dim smtpClient As New SmtpClient(smtpServer, 587)

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
    End Class
    Private Function execute_delete_kratisi(ByVal connectionString As String, ByVal modified_date As Date, ByVal channel_key As String, ByVal booking_id As String, ByVal room_booking_id As String, ByVal status As String) As Int16
        Using connection As New OleDb.OleDbConnection(connectionString)
            Dim command As New OleDb.OleDbCommand()
            Dim transaction As OleDb.OleDbTransaction = Nothing
            Dim counter As Int16 = 0

            connection.Open()
            transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted)



            ' Assign transaction object for a pending local transaction.
            command.Connection = connection
            command.Transaction = transaction
            Dim myReader As OleDb.OleDbDataReader
            'If status.Equals("Modification") Then
            '    command.Parameters.AddWithValue("channel_key", channel_key)
            '    command.Parameters.AddWithValue("booking_id", booking_id)
            '    command.Parameters.AddWithValue("room_booking_id", room_booking_id)
            '    command.CommandText = "Select count(*) FROM Reservations WHERE (channel_key=?) AND (booking_id=?) AND (room_booking_id=?)"
            'Else
            '    command.Parameters.AddWithValue("channel_key", channel_key)
            '    command.Parameters.AddWithValue("booking_id", booking_id)
            '    '  command.Parameters.AddWithValue("room_booking_id", room_booking_id)
            '    command.CommandText = "Select count(*) FROM Reservations WHERE (channel_key=?) AND (booking_id=?)"
            'End If

            'myReader = command.ExecuteReader(CommandBehavior.SingleResult)
            'myReader.Read()
            'Try
            '    counter = myReader.Item(0)
            '    If counter <> 0 Then
            '        Return 2
            '    End If
            'Catch ex As InvalidCastException
            '    myReader.Close()
            '    command.Parameters.Clear()

            'End Try
            'myReader.Close()
            'command.Parameters.Clear()

            Dim kwdikosDelKrat As String

            If status.Equals("Modification") Then
                command.Parameters.AddWithValue("modified_date", CType(modified_date, Date))
                command.Parameters.AddWithValue("channel_key", channel_key)
                command.Parameters.AddWithValue("booking_id", booking_id)
                command.Parameters.AddWithValue("room_booking_id", room_booking_id)
                command.CommandText = "Select kratisi FROM Reservations WHERE (modified_date<?) AND (channel_key=?) AND (booking_id=?) AND (room_booking_id=?)"
            Else
                command.Parameters.AddWithValue("channel_key", channel_key)
                command.Parameters.AddWithValue("booking_id", booking_id)
                '     command.Parameters.AddWithValue("room_booking_id", room_booking_id)
                command.CommandText = "Select kratisi FROM Reservations WHERE (channel_key=?) AND (booking_id=?)"
            End If
          
            myReader = command.ExecuteReader(CommandBehavior.SingleResult)
            myReader.Read()
            Try
                kwdikosDelKrat = myReader.GetInt32(0)

            Catch ex As InvalidCastException
                myReader.Close()
                command.Parameters.Clear()
                Return -1
            Catch ex1 As InvalidOperationException
                myReader.Close()
                command.Parameters.Clear()
                Return -1
            End Try
            myReader.Close()
            command.Parameters.Clear()

            command.Parameters.AddWithValue("kratisi", kwdikosDelKrat)
            command.CommandText = "DELETE FROM Reservations where (kratisi=?)"
            command.ExecuteNonQuery()
            command.Parameters.Clear()

            command.Parameters.AddWithValue("kratisi", kwdikosDelKrat)
            command.CommandText = "DELETE FROM timeskratisis where (kratisi=?)"
            counter = command.ExecuteNonQuery()
            command.Parameters.Clear()
            If counter = 1 Then

                command.Parameters.AddWithValue("kratisi", kwdikosDelKrat)
                command.CommandText = "DELETE FROM enilikes where (kratisi=?)"
                command.ExecuteNonQuery()
                command.Parameters.Clear()

                command.Parameters.AddWithValue("kratisi", kwdikosDelKrat)
                command.CommandText = "DELETE FROM status where (kratisi=?)"
                command.ExecuteNonQuery()
                command.Parameters.Clear()

                command.Parameters.Clear()
                command.Parameters.AddWithValue("kwd", kwdikosDelKrat)
                command.CommandText = "DELETE FROM kratiseis where (kwd=?)"
                command.ExecuteNonQuery()
                command.Parameters.Clear()



               

                command.Parameters.AddWithValue("modified_date", CType(modified_date, Date))
                command.Parameters.AddWithValue("channel_key", channel_key)
                command.Parameters.AddWithValue("booking_id", booking_id)
                command.Parameters.AddWithValue("room_booking_id", room_booking_id)

                command.Parameters.AddWithValue("status", "Cancellation")

                command.CommandText = "INSERT INTO Reservations (modified_date,channel_key,booking_id,room_booking_id,status) " & _
                    "values (modified_date,channel_key,booking_id,room_booking_id,status)"
                command.ExecuteNonQuery()
                command.Parameters.Clear()
                transaction.Commit()
                Return 1
            Else
                transaction.Commit()
                Return -1
            End If
        End Using
    End Function
    Private Function execute_fortosi_kratisi_transaction(ByVal connectionString As String, ByVal id As String, ByVal modified_date As Date, ByVal channel_key As String, ByVal booking_id As String, _
                                                        ByVal room_booking_id As String, ByVal roomratetype_id As String, ByVal checkin As Date, ByVal checkout As Date, _
                                                        ByVal meal_plan As String, ByVal guests As String, ByVal total_amount As String, ByVal total_taxes As String, ByVal status As String, ByVal confirmed As String, ByVal email As String, ByVal state As String, ByVal phones As String, ByVal lead_name As String, ByVal guest() As String,
                                                        ByVal rates() As GetReservations.rate, ByVal requests() As String, ByRef dwm As String) As Int16
        Using connection As New OleDb.OleDbConnection(connectionString)
            Dim overKwd As Integer = -1
            Dim counter As Int16 = 0
            ' Dim arkrat As Int16
            Dim kwdneaskrat As Integer
            Dim command, command2 As New OleDb.OleDbCommand()
            Dim transaction As OleDb.OleDbTransaction = Nothing
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
                Dim myReader As OleDb.OleDbDataReader
                command.Parameters.AddWithValue("channel_key", channel_key)
                command.Parameters.AddWithValue("booking_id", booking_id)
                command.Parameters.AddWithValue("room_booking_id", room_booking_id)
                command.Parameters.AddWithValue("status", "Cancellation")
                command.CommandText = "Select count(*) FROM Reservations WHERE (channel_key=?) AND (booking_id=?) AND (room_booking_id=?) AND (status<>?)"
                myReader = command.ExecuteReader(CommandBehavior.SingleResult)
                myReader.Read()
                Try
                    counter = myReader.Item(0)
                    If counter <> 0 Then
                        Return -1
                    End If
                Catch ex As InvalidCastException
                    myReader.Close()
                    command.Parameters.Clear()

                End Try
                myReader.Close()
                command.Parameters.Clear()

                command.CommandText = "SELECT max(arithmos) FROM kratiseis"

                myReader = command.ExecuteReader()
                ' Always call Read before accessing data.
                myReader.Read()
                Dim arithmos As Int16 = myReader.GetInt16(0)
                arithmos += 1
                myReader.Close()

                command.Parameters.AddWithValue("id", CType(roomratetype_id, Integer))
                command.Parameters.AddWithValue("etos", checkin.Year)
                command.CommandText = "SELECT  RoomRateTypes.simbolaio, RoomRateTypes.tipos, simbolaia.praktoreio   FROM RoomRateTypes INNER JOIN simbolaia ON RoomRateTypes.simbolaio = simbolaia.kwd where (id=?) and (simbolaia.etos=?) "

                myReader = command.ExecuteReader()
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

                Dim praktimologio As Int32 = 1
                Select Case channel_key
                    Case "booking"
                        praktimologio = 2
                    Case "airbnb"
                        praktimologio = 4
                    Case "expedia"
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

                command.Parameters.AddWithValue("afixi", checkout.AddDays(-1).Date) 'checkout.AddDays(-1)
                command.Parameters.AddWithValue("anaxwrisi", checkin.Date)
                command.CommandText = "SELECT DISTINCT kratiseis.dwmatio FROM kratiseis WHERE (kratiseis.afixi<=?) and (kratiseis.anaxwrisi>?)"
                myReader = command.ExecuteReader()
                While myReader.Read()
                    Try
                        If myReader.GetString(0) <> "" Then
                            dwmatia.Add(myReader.GetString(0))
                        End If

                    Catch ex As InvalidCastException

                    End Try

                End While
                myReader.Close()
                command.Parameters.Clear()

                command.Parameters.AddWithValue("tipos", tipos)
                '  command.CommandText = "SELECT dwmatia.arithmos, dwmatia.klines FROM dwmatia INNER JOIN katigories ON dwmatia.katigoria=katigories.kwd WHERE (katigories.tipos=?) AND (dwmatia.arithmos NOT IN (SELECT DISTINCT kratiseis.dwmatio FROM kratiseis WHERE (kratiseis.afixi<?) and (kratiseis.anaxwrisi>?)))" 'WHERE   kratiseis.afixi<? AND   kratiseis.anaxwrisi>?
                command.CommandText = "SELECT dwmatia.arithmos, dwmatia.klines FROM dwmatia INNER JOIN katigories ON dwmatia.katigoria=katigories.kwd WHERE(katigories.tipos=?) "
                'WHERE tbl_dwmatia.arithmos NOT IN (
                '   SELECT DISTINCT tbl_kratiseis.dwmatio
                '   FROM tbl_kratiseis
                '   WHERE tbl_kratiseis.afixi < STR_TO_DATE('$mexri','%d/%m/%Y') AND tbl_kratiseis.anaxwrisi > STR_TO_DATE('$apo','%d/%m/%Y')) order by tbl_dwmatia.arithmos ASC"
                myReader = command.ExecuteReader()
                ' Always call Read before accessing data.

                '   Dim dwmatio As String = ""
                Dim klines As Int16
                While myReader.Read()
                    If Not dwmatia.Contains(myReader.GetString(0)) Then
                        dwm = myReader.GetString(0)
                        klines = myReader.GetInt16(1)
                        flag = 1

                        Exit While
                    End If
                End While
                myReader.Close()
                command.Parameters.Clear()
                If dwm = "" Then
                    MsgBox("Δεν μπόρεσε να γίνει allocation  στην κράτηση " + booking_id, MsgBoxStyle.Critical)
                    flag = 0
                End If


                Dim epithimia As String = String.Join(" / ", requests)
                If epithimia.Length > 250 Then
                    epithimia = epithimia.Trim.Substring(0, 249)
                End If

                command.Parameters.AddWithValue("etos", CType(modified_date, Date).Year)
                command.Parameters.AddWithValue("arithmos", arithmos)

                command.Parameters.AddWithValue("praktoreio", praktoreio)

                command.Parameters.AddWithValue("praktimologio", praktimologio)
                command.Parameters.AddWithValue("voucher", email)

                command.Parameters.AddWithValue("enilikes", enilikes)
                command.Parameters.AddWithValue("paidia", paidia)
                command.Parameters.AddWithValue("afixi", CType(checkin, Date))
                command.Parameters.AddWithValue("wra", checkin.TimeOfDay)
                command.Parameters.AddWithValue("anaxwrisi", CType(checkout, Date))
                command.Parameters.AddWithValue("klines", klines)
                command.Parameters.AddWithValue("tipos", tipos)
                ' command.Parameters.AddWithValue("guarantie", myReader.Item("guarantie"))
                If flag = 1 Then
                    command.Parameters.AddWithValue("dwmatio", dwm)
                End If


                command.Parameters.AddWithValue("pliromi", "Πίστωση")

                command.Parameters.AddWithValue("synolo", CType(total_amount, Single))

                command.Parameters.AddWithValue("anzethnikotites", enilikes)
                command.Parameters.AddWithValue("anzethnikotites2", 0)
                command.Parameters.AddWithValue("ethnikotites", 1)
                command.Parameters.AddWithValue("epithimdate", CType(modified_date, Date))
                command.Parameters.AddWithValue("epithimia", epithimia)
                '   command.Parameters.AddWithValue("prokataboli", myReader.Item("prokataboli"))
                command.Parameters.AddWithValue("prokatdate", CType(modified_date, Date))
                ' command.Parameters.AddWithValue("simetoxi", myReader.Item("simetoxi"))
                command.Parameters.AddWithValue("tilefonomem", phones)
                command.Parameters.AddWithValue("imeromkratisis", CType(modified_date, Date).Date)
                command.Parameters.AddWithValue("simbolaio", simbolaio)
                command.Parameters.AddWithValue("ethnikotites2", 0)
                'command.Parameters.AddWithValue("checkin", False)
                'command.Parameters.AddWithValue("checkout", False)
                command.Parameters.AddWithValue("datein", checkin)

                'command.Parameters.AddWithValue("ekptosi", myReader.Item("ekptosi"))
                'command.Parameters.AddWithValue("ekptposo", myReader.Item("ekptposo"))
                'command.Parameters.AddWithValue("ekptpososto", myReader.Item("ekptpososto"))
                'command.Parameters.AddWithValue("ekptimeres", myReader.Item("ekptimeres"))
                ' Execute the commands.
                'false', 'true', 'false', allagesdwmatiwn, checkin, checkout,
                If flag = 1 Then
                    command.CommandText = "INSERT INTO kratiseis (etos,  arithmos, praktoreio, praktimologio,voucher, enilikes, paidia, afixi, wra, anaxwrisi, " & _
               " klines, tipos,dwmatio,pliromi, synolo, anzethnikotites, anzethnikotites2, ethnikotites, epithimdate, " & _
               "epithimia,prokatdate, tilefonomem, imeromkratisis,simbolaio, ethnikotites2,  checkin, checkout, " & _
               "datein) values (etos, arithmos, praktoreio, " & _
               "praktimologio, voucher, enilikes, paidia, afixi,wra, anaxwrisi, klines, tipos, dwmatio,pliromi, synolo, " & _
               "anzethnikotites, anzethnikotites2, ethnikotites, epithimdate, epithimia, prokatdate, tilefonomem, " & _
               "imeromkratisis,simbolaio, ethnikotites2, false, false, datein)"
                ElseIf flag = 0 Then
                    command.CommandText = "INSERT INTO kratiseis (etos,  arithmos, praktoreio, praktimologio,voucher, enilikes, paidia, afixi, wra, anaxwrisi, " & _
              " klines, tipos,pliromi, synolo, anzethnikotites, anzethnikotites2, ethnikotites, epithimdate, " & _
              "epithimia,prokatdate, tilefonomem, imeromkratisis,simbolaio, ethnikotites2,  checkin, checkout, " & _
              "datein) values (etos, arithmos, praktoreio, " & _
              "praktimologio, voucher, enilikes, paidia, afixi,wra, anaxwrisi, klines, tipos,pliromi, synolo, " & _
              "anzethnikotites, anzethnikotites2, ethnikotites, epithimdate, epithimia, prokatdate, tilefonomem, " & _
              "imeromkratisis,simbolaio, ethnikotites2, false, false, datein)"
                End If



                command.ExecuteNonQuery()
                command.Parameters.Clear()


                command.Parameters.AddWithValue("etos", CType(modified_date, Date).Year)
                command.Parameters.AddWithValue("arithmos", arithmos)
                command.CommandText = "SELECT kwd FROM kratiseis where (etos=?) and (arithmos=?)"

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
                    Return -1
                End If

                command.Parameters.AddWithValue("aakratisis", arithmos)
                command.CommandText = "UPDATE etaireia SET  aakratisis=?"
                command.ExecuteNonQuery()
                command.Parameters.Clear()

                If flag = 1 Then
                    command.Parameters.AddWithValue("dwmatio", dwm)
                    command.Parameters.AddWithValue("kratsi", kwdneaskrat)
                    command.Parameters.AddWithValue("enarxi", CType(checkin, Date))
                    command.Parameters.AddWithValue("lixi", CType(checkout.AddDays(-1), Date))
                    command.Parameters.AddWithValue("dwmatiostatus", 1)
                    command.CommandText = "Insert into status (dwmatio, kratisi, enarxi, lixi, dwmatiostatus) VALUES (dwmatio, kratisi, enarxi, lixi, dwmatiostatus)"
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

                        command2.Parameters.AddWithValue("simbolaio", simbolaio)
                        command2.Parameters.AddWithValue("apo", CType(rates(i).day, Date))
                        command2.Parameters.AddWithValue("mexri", CType(rates(j).day.AddDays(-1), Date))
                        command2.CommandText = "SELECT kwd FROM touristperiodoi where (simbolaio=?) and (apo<=?) and (mexri>=?)"
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

                                command.Parameters.AddWithValue("kratisi", kwdneaskrat)
                                command.Parameters.AddWithValue("timi", -1)
                                command.Parameters.AddWithValue("apo", rates(i).day)
                                If j < rates.Length - 1 Then
                                    command.Parameters.AddWithValue("mexri", rates(j - 1).day)
                                    imeres = rates(j).day.Date.Subtract(rates(i).day.Date).Days
                                Else
                                    command.Parameters.AddWithValue("mexri", checkout)
                                    imeres = checkout.Date.Subtract(rates(i).day.Date).Days
                                End If

                                command.Parameters.AddWithValue("ypnos", ammount + day_taxes)
                                'MsgBox("apo " + rates(i).day)
                                'MsgBox("mexri " + rates(j).day)

                                'MsgBox("imeres" + rates(j).day.Date.Subtract(rates(i).day.Date).Days.ToString)
                                command.Parameters.AddWithValue("imeres", imeres)
                                command.Parameters.AddWithValue("synolo", (CType(rates(i).amount, Single) + day_taxes) * imeres)
                                command.Parameters.AddWithValue("touristperiod", touristperiod)
                                command.Parameters.AddWithValue("xrewsi", xrewsi)
                                command.CommandText = "INSERT INTO timeskratisis (kratisi, timi,  apo, mexri,  ypnos,imeres,synolo, touristperiod, xrewsi)" & _
                          "values (kratisi, timi,apo, mexri,ypnos, imeres,  synolo, touristperiod, xrewsi)"
                                command.ExecuteNonQuery()
                                command.Parameters.Clear()

                                ' always call Close when done reading.

                                command.Parameters.Clear()
                                i = j

                            Else 'Αλλαγή τιμών χωρις αλλαγή τουρ. περιόδου!!!!!!!!!!!!!!!!!!!!!
                                Try
                                    'ddelete ta proigoumena insert stis timeskratisis
                                    command.Parameters.AddWithValue("kratisi", kwdneaskrat)
                                    command.CommandText = "DELETE FROM timeskratisis where (kratisi=?)"
                                    command.ExecuteNonQuery()
                                    command.Parameters.Clear()

                                    'PROSOXI ALAZEI KATHEE XRONO!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                                    'kwdikoi toyristikis periodou KAI simbolaiou ME TO XERI!!!!!!!!!!!!!
                                    touristperiod = 614

                                    Dim xrewsi As Int16

                                    If meal_plan.Contains("bb") Then
                                        xrewsi = 2
                                    Else
                                        xrewsi = 1

                                    End If

                                    command.Parameters.AddWithValue("kratisi", kwdneaskrat)
                                    command.Parameters.AddWithValue("timi", -1)
                                    command.Parameters.AddWithValue("apo", checkin)
                                    command.Parameters.AddWithValue("mexri", checkout)

                                    command.Parameters.AddWithValue("ypnos", Math.Round(total_amount / checkout.Date.Subtract(checkin).Days, 2) + day_taxes)
                                    'MsgBox("apo " + rates(i).day)
                                    'MsgBox("mexri " + rates(j).day)
                                    imeres = checkout.Date.Subtract(checkin).Days
                                    'MsgBox("imeres" + rates(j).day.Date.Subtract(rates(i).day.Date).Days.ToString)
                                    command.Parameters.AddWithValue("imeres", imeres)
                                    command.Parameters.AddWithValue("synolo", (CType(total_amount, Single) + day_taxes) * imeres)
                                    command.Parameters.AddWithValue("touristperiod", touristperiod)
                                    command.Parameters.AddWithValue("xrewsi", xrewsi)
                                    command.CommandText = "INSERT INTO timeskratisis (kratisi, timi,  apo, mexri,  ypnos,imeres,synolo, touristperiod, xrewsi)" & _
                              "values (kratisi, timi,apo, mexri,ypnos, imeres,  synolo, touristperiod, xrewsi)"
                                    command.ExecuteNonQuery()
                                    command.Parameters.Clear()

                                    ' always call Close when done reading.

                                    command.Parameters.Clear()
                                    command.Parameters.AddWithValue("simbolaio", 68)
                                    command.Parameters.AddWithValue("kwd", kwdneaskrat)
                                    command.CommandText = "UPDATE kratiseis SET simbolaio=? WHERE (kwd=?)"
                                    command.ExecuteNonQuery()
                                    command.Parameters.Clear()
                                    Exit While
                                Catch ex As InvalidOperationException
                                    MsgBox("Δεν μπόρεσε φορτωθεί η κράτηση: " + booking_id + " Αλλαγή τουρ. περιόδου χωρις αλλαγή τιμών", MsgBoxStyle.Critical)
                                    transaction.Rollback()
                                    Return -1
                                End Try
                                'MsgBox("Δεν μπόρεσε φορτωθεί η κράτηση: " + booking_id + " Αλλαγή τιμών χωρις αλλαγή τουρ. περιόδου", MsgBoxStyle.Critical)
                                'transaction.Rollback()
                                'Return -1
                            End If
                            ' den brethike tourisitkh periodos
                        Catch ex As InvalidOperationException
                            MsgBox("Δεν μπόρεσε φορτωθεί η κράτηση: " + booking_id + " Αλλαγή τουρ. περιόδου χωρις αλλαγή τιμών", MsgBoxStyle.Critical)
                            transaction.Rollback()
                            Return -1
                        End Try

                        'End While
                        'myReader.Close()
                        'elegxos ean ypa;rxei allagi timwn xwris allagi peri;odwn ->ERROR

                    End While
                Else
                    command.Parameters.AddWithValue("simbolaio", simbolaio)
                    command.Parameters.AddWithValue("apo", checkin)

                    command.Parameters.AddWithValue("mexri", checkout.AddDays(-1))
                    command.CommandText = "SELECT kwd FROM touristperiodoi where (simbolaio=?) and (apo<=?) and (mexri>=?)"
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

                        command.Parameters.AddWithValue("kratisi", kwdneaskrat)
                        command.Parameters.AddWithValue("timi", -1)
                        command.Parameters.AddWithValue("apo", checkin)
                        command.Parameters.AddWithValue("mexri", checkout)

                        command.Parameters.AddWithValue("ypnos", Math.Round(total_amount / checkout.Date.Subtract(checkin).Days, 2) + day_taxes)
                        'MsgBox("apo " + rates(i).day)
                        'MsgBox("mexri " + rates(j).day)
                        imeres = checkout.Date.Subtract(checkin).Days
                        'MsgBox("imeres" + rates(j).day.Date.Subtract(rates(i).day.Date).Days.ToString)
                        command.Parameters.AddWithValue("imeres", imeres)
                        command.Parameters.AddWithValue("synolo", (CType(total_amount, Single) + day_taxes) * imeres)
                        command.Parameters.AddWithValue("touristperiod", touristperiod)
                        command.Parameters.AddWithValue("xrewsi", xrewsi)
                        command.CommandText = "INSERT INTO timeskratisis (kratisi, timi,  apo, mexri,  ypnos,imeres,synolo, touristperiod, xrewsi)" & _
                  "values (kratisi, timi,apo, mexri,ypnos, imeres,  synolo, touristperiod, xrewsi)"
                        command.ExecuteNonQuery()
                        command.Parameters.Clear()

                        ' always call Close when done reading.

                        command.Parameters.Clear()
                    Catch ex As InvalidOperationException
                        MsgBox("Δεν μπόρεσε φορτωθεί η κράτηση: " + booking_id + " Αλλαγή τουρ. περιόδου χωρις αλλαγή τιμών", MsgBoxStyle.Critical)
                        transaction.Rollback()
                        Return -1
                    End Try
                End If


                If guest.Length = 0 Then
                    command.Parameters.AddWithValue("kratisi", kwdneaskrat)
                    If lead_name <> "" Then
                        command.Parameters.AddWithValue("onomateponimo", lead_name)
                    Else
                        command.Parameters.AddWithValue("onomateponimo", booking_id)
                    End If


                    command.CommandText = "INSERT INTO enilikes (kratisi, onomateponimo)" & _
                      "values (kratisi, onomateponimo)"

                    command.ExecuteNonQuery()
                    command.Parameters.Clear()
                Else
                    For i = 0 To guest.Length - 1
                        command.Parameters.AddWithValue("kratisi", kwdneaskrat)
                        command.Parameters.AddWithValue("onomateponimo", guest(i))
                        command.CommandText = "INSERT INTO enilikes (kratisi, onomateponimo)" & _
                          "values (kratisi, onomateponimo)"

                        command.ExecuteNonQuery()
                        command.Parameters.Clear()
                    Next
                End If




                command.Parameters.AddWithValue("kratisi", kwdneaskrat)
                command.Parameters.AddWithValue("name", lead_name)
                command.Parameters.AddWithValue("id", id)
                command.Parameters.AddWithValue("modified_date", CType(modified_date, Date))
                command.Parameters.AddWithValue("channel_key", channel_key)
                command.Parameters.AddWithValue("booking_id", booking_id)
                command.Parameters.AddWithValue("room_booking_id", room_booking_id)
                command.Parameters.AddWithValue("room_rate_type", roomratetype_id)
                command.Parameters.AddWithValue("status", status)
                command.Parameters.AddWithValue("confirmed", CType(confirmed, Byte))
                command.Parameters.AddWithValue("state", state)
                command.Parameters.AddWithValue("afixi", CType(checkin, Date))

                command.Parameters.AddWithValue("anaxwrisi", CType(checkout, Date))
                command.CommandText = "INSERT INTO Reservations (kratisi,name,id,modified_date,channel_key,booking_id,room_booking_id,room_rate_type, status, confirmed,state, afixi, anaxwrisi) " & _
                    "values (kratisi,name,id,modified_date,channel_key,booking_id,room_booking_id,room_rate_type, status, confirmed,state, afixi, anaxwrisi)"
                command.ExecuteNonQuery()
                command.Parameters.Clear()
                'edw NEO copy kratisis   command.Parameters.AddWithValue("kwd", myReader.Item("kwd"))



                transaction.Commit()
                Return 1
            Catch ex As Exception
                MsgBox("Η Διαδικασία απέτυχε ! " + ex.Message, MsgBoxStyle.Critical, "winfo\nikEl.")
                Try
                    transaction.Rollback()
                    Return -1
                Catch
                    Return -1
                End Try

            End Try



        End Using


    End Function

    Public Class SetMainCalendar
        Dim link As String
        Dim user As String
        Dim password As String
        Dim property_id As String
        Dim roomratetype_id As String
        Dim fromDate As Date
        Dim iterations As Int16

        Dim greekCulture As New System.Globalization.CultureInfo("el-GR", False)
        Dim englishCulture As New System.Globalization.CultureInfo("en-US", False)
        Dim path As String
        'Dim oExcel As Microsoft.Office.Interop.Excel.Application
        'Dim oBook As Microsoft.Office.Interop.Excel.Workbook
        'Dim oSheet As Microsoft.Office.Interop.Excel.Sheets

        Public Sub New(ByVal lnk As String) ', ByVal file As String ByVal usr As String, ByVal pwd As String, ByVal prop_id As String, 


            link = lnk

        End Sub
        'Public Sub New(ByVal lnk As String, ByVal usr As String, ByVal pwd As String, ByVal prop_id As String, ByVal file As String) ', ByVal file As String ByVal usr As String, ByVal pwd As String, ByVal prop_id As String, 
        '    System.Threading.Thread.CurrentThread.CurrentCulture = englishCulture
        '    My.Application.Culture.NumberFormat.NumberDecimalSeparator = ","
        '    System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencySymbol = ","

        '    ' Add any initialization after the InitializeComponent() call.

        '    ' excelTbx.Text = "c:\winfo\cleanings.xls"
        '    path = File
        '    oExcel = CreateObject("Excel.Application")
        '    oBook = oExcel.Workbooks.Open(path)
        '    oSheet = oBook.Worksheets

        '    link = lnk
        '    user = usr
        '    password = pwd
        '    property_id = prop_id
        '    roomratetype_id = CType(oSheet(1).Cells(1, 1).value, String)
        '    fromDate = CType(oSheet(1).Cells(1, 2).value, Date)
        '    iterations = CType(oSheet(1).Cells(1, 3).value, Int16)
        'End Sub

        Public Sub make_XML_file_for_request()
            'Dim i As Int16
            ''   Dim result As String = ""
            'Dim Stream As New MemoryStream()


            'Dim mySettings As New XmlWriterSettings()
            'mySettings.NewLineOnAttributes = True
            'mySettings.Encoding = System.Text.Encoding.UTF8
            'mySettings.Indent = True
            'mySettings.IndentChars = "      "

            'Dim writer = (XmlTextWriter).Create("file.xml", mySettings)

            ''   Dim writer As New XmlTextWriter(Stream, System.Text.Encoding.UTF8)
            ''  Dim writer As New XmlTextWriter("file.xml", System.Text.Encoding.UTF8)

            ''  Dim writer As New StringWriter(sb)

            ''  writer.WriteProcessingInstruction("xml", "version=""1.0"" encoding=""UTF-8""")
            'writer.WriteStartDocument(True)
            ''writer.Formatting = Formatting.Indented
            ''writer.Indentation = 2
            'writer.WriteStartElement("Request")

            'writer.WriteStartElement("Language")
            'writer.WriteString("el")
            'writer.WriteEndElement()

            'writer.WriteStartElement("Authentication")
            'writer.WriteAttributeString("User", user)
            'writer.WriteAttributeString("Password", password)

            'writer.WriteEndElement()

            'writer.WriteStartElement("SetMainCalendar")
            'writer.WriteAttributeString("property_id", property_id)
            'writer.WriteAttributeString("roomratetype_id", roomratetype_id)


            'For i = 0 To iterations - 1
            '    writer.WriteStartElement("CalendarDate")
            '    writer.WriteAttributeString("from", DateTime.Parse(fromDate.AddDays(i)).ToString("yyyy-MM-dd"))
            '    writer.WriteAttributeString("to", DateTime.Parse(fromDate.AddDays(i)).ToString("yyyy-MM-dd"))
            '    writer.WriteAttributeString("availabilities", CType(oSheet(1).Cells(2, i + 1).value, String))
            '    writer.WriteEndElement()
            'Next
            'writer.WriteEndElement()

            'writer.WriteEndElement()
            ''writer.Flush()
            'writer.WriteEndDocument()
            'writer.close()
            ''Dim reader = New StreamReader(Stream, Encoding.UTF8, True)
            ''Stream.Seek(0, SeekOrigin.Begin)
            ''result = reader.ReadToEnd()

        End Sub

        Public Function send_request() As Boolean
            ' Dim xmldoc As New XmlDataDocument
            Dim requestString As String
            Dim xmldoc As New XmlDocument
            Dim xmlnode As XmlNodeList
            Dim istOK As Boolean
            'Dim fs As New FileStream("file.xml", FileMode.Open, FileAccess.Read)
            '     xmldoc.Load(fs)
            Dim reader = New StreamReader("file.xml", Encoding.UTF8, True)
            '  reader.Seek(0, SeekOrigin.Begin)
            requestString = reader.ReadToEnd()

            'MsgBox(requestString)
            'Return False
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
            Dim request As WebRequest = WebRequest.Create(link)
            request.Credentials = CredentialCache.DefaultCredentials
            request.Method = "POST"

            Dim byteArray As Byte() = Encoding.UTF8.GetBytes(requestString)

            request.ContentType = "text/xml"
            request.ContentLength = byteArray.Length

            ' Get the request stream.  
            Dim dataStream As Stream = request.GetRequestStream()
            ' Write the data to the request stream.  
            dataStream.Write(byteArray, 0, byteArray.Length)
            ' Close the Stream object.  
            dataStream.Close()

            Dim response As WebResponse = request.GetResponse()

            Using Stream As Stream = response.GetResponseStream()
                ' Open the stream using a StreamReader for easy access.  

                ' Read the content.  
                xmldoc.Load(Stream)

                xmlnode = xmldoc.GetElementsByTagName("Error")

                If xmlnode.Count <> 0 Then
                    For Each node1 As XmlNode In xmlnode
                        MsgBox(node1.InnerText)
                        istOK = False
                    Next
                Else
                    xmlnode = xmldoc.GetElementsByTagName("Success")
                    If xmlnode.Count <> 0 Then

                        istOK = True
                    End If
                End If
            End Using
            reader.close()
            Return istOK
        End Function
    End Class



    Public Class SetMainCalendarKratisis


        Dim link As String

        Dim user As String
        Dim password As String
        Dim property_id As String
        Dim roomratetype_id As String
        Dim fromDate As Date
        Dim toDate As Date
        Dim availabilities_operator As String
        Dim availabilities As String = "plus"
        Dim stop_sell As String = "1" 'ti ginetai??????????????????

        Public Sub New(ByVal lnk As String, ByVal usr As String, ByVal pwd As String, ByVal prop_id As String, ByVal apo As Date, ByVal mexri As Date, ByVal avail As String) ', ByVal file As String ByVal usr As String, ByVal pwd As String, ByVal prop_id As String, 

            link = lnk
            user = usr
            password = pwd
            property_id = prop_id

            fromDate = apo
            toDate = mexri

            availabilities = avail

        End Sub
        Public Sub set_roomratetype_id(ByVal roomrateid As String)
            roomratetype_id = roomrateid
        End Sub
        Public Sub set_availabilities_operator(ByVal value As String)
            availabilities_operator = value
        End Sub
        Public Function make_send_XML_file_for_Availabilities_request() As Boolean
            Dim i As Int16
            Dim result As String = ""
            Dim Stream As New MemoryStream()


            Dim mySettings As New XmlWriterSettings()
            mySettings.NewLineOnAttributes = True
            mySettings.Encoding = System.Text.Encoding.UTF8
            mySettings.Indent = True
            mySettings.IndentChars = "      "

            Dim writer = (XmlTextWriter).Create(Stream, mySettings)

            '  Dim writer As New XmlTextWriter(Stream, System.Text.Encoding.UTF8)
            '  Dim writer As New XmlTextWriter("file.xml", System.Text.Encoding.UTF8)

            '  Dim writer As New StringWriter(sb)

            writer.WriteProcessingInstruction("xml", "version=""1.0"" encoding=""UTF-8""")
            ' writer.WriteStartDocument(True)
            'writer.Formatting = Formatting.Indented
            'writer.Indentation = 2
            writer.WriteStartElement("Request")

            writer.WriteStartElement("Language")
            writer.WriteString("el")
            writer.WriteEndElement()

            writer.WriteStartElement("Authentication")
            writer.WriteAttributeString("User", user)
            writer.WriteAttributeString("Password", password)

            writer.WriteEndElement()

            writer.WriteStartElement("SetMainCalendar")
            writer.WriteAttributeString("property_id", property_id)
            writer.WriteAttributeString("roomratetype_id", roomratetype_id)



            writer.WriteStartElement("CalendarDate")
            writer.WriteAttributeString("from", DateTime.Parse(fromDate).ToString("yyyy-MM-dd"))
            writer.WriteAttributeString("to", DateTime.Parse(toDate).ToString("yyyy-MM-dd"))
            'writer.WriteAttributeString("from", DateTime.AddDays(1).Parse(fromDate.ToString("yyyy-MM-dd")))
            'writer.WriteAttributeString("to", DateTime.Parse(toDate.ToString("yyyy-MM-dd")))
            writer.WriteAttributeString("availabilities_operator", availabilities_operator)
            writer.WriteAttributeString("availabilities", availabilities)
            writer.WriteEndElement()

            writer.WriteEndElement()

            writer.WriteEndElement()
            writer.Flush()
            'writer.WriteEndDocument()
            'writer.Close()
            Dim reader = New StreamReader(Stream, Encoding.UTF8, True)
            Stream.Seek(0, SeekOrigin.Begin)
            result = reader.ReadToEnd()

            Return send_request(result)
        End Function

        Public Function send_request(ByVal requestString As String) As Boolean
            Dim xmldoc As New XmlDocument

            Dim xmlnode As XmlNodeList
            Dim istOK As Boolean

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
            Dim request As WebRequest = WebRequest.Create(link)
            '    request.Headers("sadsad", asdasdsad)
            request.Credentials = CredentialCache.DefaultCredentials
            request.Method = "POST"

            Dim byteArray As Byte() = Encoding.UTF8.GetBytes(requestString)

            request.ContentType = "text/xml"
            request.ContentLength = byteArray.Length

            ' Get the request stream.  
            Dim dataStream As Stream = request.GetRequestStream()
            ' Write the data to the request stream.  
            dataStream.Write(byteArray, 0, byteArray.Length)
            ' Close the Stream object.  
            dataStream.Close()

            Try
                Dim response As WebResponse = request.GetResponse()

                Using Stream As Stream = response.GetResponseStream()
                    ' Open the stream using a StreamReader for easy access.  

                    ' Read the content.  
                    xmldoc.Load(Stream)

                    xmlnode = xmldoc.GetElementsByTagName("Error")

                    If xmlnode.Count <> 0 Then
                        For Each node1 As XmlNode In xmlnode
                            MsgBox(node1.InnerText)
                            istOK = False
                        Next
                    Else
                        xmlnode = xmldoc.GetElementsByTagName("Success")
                        If xmlnode.Count <> 0 Then

                            istOK = True
                        End If
                    End If
                End Using
            Catch ex As WebException
                MsgBox("Αποτυχία επικοινωνίας με HotelAvailabilities", MsgBoxStyle.Exclamation)
                istOK = False
            End Try

            Return istOK
        End Function
    End Class

    Public Class SetPricesCalendar
        Dim link As String
        Dim user As String
        Dim password As String
        Dim property_id As String
        Dim roomratetype_id As String
        Dim fromDate As Date
       
        Dim path As String
        'Dim oExcel As Microsoft.Office.Interop.Excel.Application
        'Dim oBook As Microsoft.Office.Interop.Excel.Workbook
        'Dim oSheet As Microsoft.Office.Interop.Excel.Sheets

        Public Sub New(ByVal lnk As String) ', ByVal file As String ByVal usr As String, ByVal pwd As String, ByVal prop_id As String, 


            link = lnk

        End Sub
       

     

        Public Function send_request() As Boolean
            ' Dim xmldoc As New XmlDataDocument
            Dim requestString As String
            Dim xmldoc As New XmlDocument
            Dim xmlnode As XmlNodeList
            Dim istOK As Boolean
            'Dim fs As New FileStream("file.xml", FileMode.Open, FileAccess.Read)
            '     xmldoc.Load(fs)
            Dim reader = New StreamReader("prices.xml", Encoding.UTF8, True)
            '  reader.Seek(0, SeekOrigin.Begin)
            requestString = reader.ReadToEnd()

            'MsgBox(requestString)
            'Return False
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
            Dim request As WebRequest = WebRequest.Create(link)
            request.Credentials = CredentialCache.DefaultCredentials
            request.Method = "POST"

            Dim byteArray As Byte() = Encoding.UTF8.GetBytes(requestString)

            request.ContentType = "text/xml"
            request.ContentLength = byteArray.Length

            ' Get the request stream.  
            Dim dataStream As Stream = request.GetRequestStream()
            ' Write the data to the request stream.  
            dataStream.Write(byteArray, 0, byteArray.Length)
            ' Close the Stream object.  
            dataStream.Close()

            Dim response As WebResponse = request.GetResponse()

            Using Stream As Stream = response.GetResponseStream()
                ' Open the stream using a StreamReader for easy access.  

                ' Read the content.  

                xmldoc.Load(Stream)

                xmlnode = xmldoc.GetElementsByTagName("Error")

                If xmlnode.Count <> 0 Then
                    For Each node1 As XmlNode In xmlnode
                        MsgBox(node1.InnerText)
                        istOK = False
                    Next
                Else
                    xmlnode = xmldoc.GetElementsByTagName("Success")
                    If xmlnode.Count <> 0 Then

                        istOK = True
                    End If
                End If
            End Using
            reader.close()
            Return istOK
        End Function
    End Class
    

    Public Class SetAvailabilities


        Dim link As String

        Dim user As String
        Dim password As String
        Dim property_id As String
        Dim roomratetype_id As String
        Dim fromDate As Date
        ' Dim toDate As Date
        Dim datumKrat() As Int16

        Dim stop_sell As String = "1" 'ti ginetai??????????????????
        Dim anzahlDwm As Byte
        Public Sub New(ByVal lnk As String, ByVal usr As String, ByVal pwd As String, ByVal prop_id As String, ByVal apo As Date, ByVal datumKratiseis() As Int16, ByVal anzahlDwma As Byte) ', ByVal file As String ByVal usr As String, ByVal pwd As String, ByVal prop_id As String, 

            link = lnk
            user = usr
            password = pwd
            property_id = prop_id

            fromDate = apo
            '   toDate = mexri

            datumKrat = datumKratiseis
            anzahlDwm = anzahlDwma

        End Sub
        Public Sub set_roomratetype_id(ByVal roomrateid As String)
            roomratetype_id = roomrateid
        End Sub
        'Public Sub set_availabilities_operator(ByVal value As String)
        '    availabilities_operator = value
        'End Sub
        Public Function make_send_XML_file_for_Availabilities_request() As Boolean
            Dim i, index, count As Int16
            Dim result As String = ""
            Dim Stream As New MemoryStream()


            Dim mySettings As New XmlWriterSettings()
            mySettings.NewLineOnAttributes = True
            mySettings.Encoding = System.Text.Encoding.UTF8
            mySettings.Indent = True
            mySettings.IndentChars = "      "

            Dim writer = (XmlTextWriter).Create(Stream, mySettings)

            '  Dim writer As New XmlTextWriter(Stream, System.Text.Encoding.UTF8)
            '  Dim writer As New XmlTextWriter("file.xml", System.Text.Encoding.UTF8)

            '  Dim writer As New StringWriter(sb)

            writer.WriteProcessingInstruction("xml", "version=""1.0"" encoding=""UTF-8""")
            ' writer.WriteStartDocument(True)
            'writer.Formatting = Formatting.Indented
            'writer.Indentation = 2
            writer.WriteStartElement("Request")

            writer.WriteStartElement("Language")
            writer.WriteString("el")
            writer.WriteEndElement()

            writer.WriteStartElement("Authentication")
            writer.WriteAttributeString("User", user)
            writer.WriteAttributeString("Password", password)

            writer.WriteEndElement()

            writer.WriteStartElement("SetAvailabilities")
            writer.WriteAttributeString("property_id", property_id)
            writer.WriteAttributeString("roomratetype_id", roomratetype_id)

            Do While index <= datumKrat.Length - 1
                writer.WriteStartElement("CalendarDate")
                writer.WriteAttributeString("from", DateTime.Parse(fromDate.AddDays(index)).ToString("yyyy-MM-dd"))

                count = get_days_of_same_availabilities(index)
                writer.WriteAttributeString("to", DateTime.Parse(fromDate.AddDays(index + count)).ToString("yyyy-MM-dd"))



                writer.WriteAttributeString("availabilities", anzahlDwm - datumKrat(index))

                writer.WriteEndElement()
                index = index + count + 1

            Loop


            writer.WriteEndElement()

            writer.WriteEndElement()
            writer.Flush()
            'writer.WriteEndDocument()
            'writer.Close()
            Dim reader = New StreamReader(Stream, Encoding.UTF8, True)
            Stream.Seek(0, SeekOrigin.Begin)
            'Dim file As New FileStream("file.xml", FileMode.Create, FileAccess.Write)
            'Stream.WriteTo(file)
            result = reader.ReadToEnd()
            '  MsgBox(result)
            ' Return True
            Return send_request(result)
           
        End Function

        Public Function send_request(ByVal requestString As String) As Boolean
            Dim xmldoc As New XmlDocument

            Dim xmlnode As XmlNodeList
            Dim istOK As Boolean

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
            Dim request As WebRequest = WebRequest.Create(link)
            request.Credentials = CredentialCache.DefaultCredentials
            request.Method = "POST"

            Dim byteArray As Byte() = Encoding.UTF8.GetBytes(requestString)

            request.ContentType = "text/xml"
            request.ContentLength = byteArray.Length

            ' Get the request stream.  
            Dim dataStream As Stream = request.GetRequestStream()
            ' Write the data to the request stream.  
            dataStream.Write(byteArray, 0, byteArray.Length)
            ' Close the Stream object.  
            dataStream.Close()

            Try
                Dim response As WebResponse = request.GetResponse()

                Using Stream As Stream = response.GetResponseStream()
                    ' Open the stream using a StreamReader for easy access.  

                    ' Read the content.  
                    xmldoc.Load(Stream)

                    xmlnode = xmldoc.GetElementsByTagName("Error")

                    If xmlnode.Count <> 0 Then
                        For Each node1 As XmlNode In xmlnode
                            MsgBox(node1.InnerText)
                            istOK = False
                        Next
                    Else
                        xmlnode = xmldoc.GetElementsByTagName("Success")
                        If xmlnode.Count <> 0 Then

                            istOK = True
                        End If
                    End If
                End Using
            Catch ex As WebException
                MsgBox("Αποτυχία επικοινωνίας με HotelAvailabilities", MsgBoxStyle.Exclamation)
                istOK = False
            End Try

            Return istOK
        End Function


        Private Function get_days_of_same_availabilities(ByVal index1) As Int16
            Dim i, j As Int16
            j = 0
            For i = index1 To datumKrat.Length - 1
                If i = datumKrat.Length - 1 Then
                    Return j
                Else
                    If datumKrat(index1) <> datumKrat(i + 1) Then
                        Return j
                    Else
                        j += 1

                    End If
                End If

            Next

        End Function
    End Class
End Module
