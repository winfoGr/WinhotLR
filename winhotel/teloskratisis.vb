Imports System.Data.SqlClient
Public Class teloskratisis
    Dim connectionString_ As String
    Dim kwdkrat_ As Int64
    Dim villa_ As String
    Dim praktoreio_ As Int64
    Dim synolo_ As Single
    Dim ekptosi_ As Single
    Dim afixi_ As Date
    Dim anaxwrisi_ As Date
    'Dim imeres_ As Int16
    Dim timeskratSum_ As Single
    Dim discountdays As Single = 0 ' 
    Dim tiposrate As Byte = 0 'viles=1 urban =2
    Dim partialSum1 As Single = 0
    Dim partialSum2 As Single = 0
    Dim partialDays1 As Int16 = 0
    Dim partialDays2 As Int16 = 0
    Dim dimeres As Int16 = 0
    Dim telos As Single = 0
    Dim rateDictionary_ As New Dictionary(Of Integer, Single)()



    Public Sub New(ByVal conn As String, ByVal kratisi As Int64, ByVal villa As String, ByVal praktoreio As Int64, ByVal afixi As Date, ByVal anaxwrisi As Date, ByVal synolo As Single, ByVal ekptosi As Single, ByVal status As Byte)
        'aadeUserId_ = aadeUserId
        'apiSubKey_ = apiSubKey
        connectionString_ = conn
        kwdkrat_ = kratisi
        villa_ = villa
        praktoreio_ = praktoreio
        synolo_ = synolo
        ekptosi_ = ekptosi
        afixi_ = afixi
        anaxwrisi_ = anaxwrisi

        timeskratSum_ = synolo_ + ekptosi_
        If synolo > 0 Then  ' midenikes kratiseis tipota!
            rateDictionary_ = fetch_rate_villa_praktoreio(villa_, praktoreio_)
            If rateDictionary_.Count = 0 Then
                rateDictionary_ = fetch_rate_villa(villa_)
            End If
            If rateDictionary_.Count <> 0 Then
                If tiposrate <> 2 Or CInt(Math.Ceiling((anaxwrisi_ - afixi_).Days)) < 60 Then ' gia urban > 60  imeres tipota!!!
                    If status = 1 Then ' nea kratisi


                        berechne_fake_telos_klima()
                        modify_new_kratisi()
                    ElseIf status = 2 Then 'u

                        Using connection As New SqlConnection(connectionString_)
                            Dim command As New SqlCommand()
                            Dim myReader As SqlDataReader
                            'Dim vill As String
                            Dim imer As Int16
                            'Dim partiald1 As Int16
                            'Dim partialp1 As Single
                            'Dim partiald2 As Int16
                            'Dim partialp2 As Single
                            'Dim dimer As Int16
                            Dim pos As Single
                            Try
                                connection.Open()
                                command.Connection = connection
                                command.Parameters.AddWithValue("@kratisi", kwdkrat_)
                                command.CommandText = "SELECT imeres,poso FROM telosdiamonis  WHERE kratisi = @kratisi"
                                myReader = command.ExecuteReader(CommandBehavior.SingleRow)
                                myReader.Read()
                                command.Parameters.Clear()

                                If myReader.HasRows() Then
                                    imer = myReader.Item("imeres")
                                    pos = myReader.Item("poso")

                                    If CInt(Math.Ceiling((anaxwrisi_ - afixi_).Days)) <> imer Then


                                        ekptosi_ = ekptosi_ - pos
                                        berechne_fake_telos_klima()

                                        modify_update_kratisi()



                                    End If
                                Else

                                    berechne_fake_telos_klima()

                                    modify_new_kratisi()
                                End If

                            Catch ex As Exception

                            End Try

                        End Using

                    ElseIf status = 3 Then

                        Using connection As New SqlConnection(connectionString_)
                            Dim command As New SqlCommand()
                            Dim myReader As SqlDataReader
                            'Dim vill As String
                            Dim imer As Int16
                            'Dim partiald1 As Int16
                            'Dim partialp1 As Single
                            'Dim partiald2 As Int16
                            'Dim partialp2 As Single
                            'Dim dimer As Int16
                            Dim pos As Single
                            Try
                                connection.Open()
                                command.Connection = connection
                                command.Parameters.AddWithValue("@kratisi", kwdkrat_)
                                command.CommandText = "SELECT imeres,poso FROM telosdiamonis  WHERE kratisi = @kratisi"
                                myReader = command.ExecuteReader(CommandBehavior.SingleRow)
                                myReader.Read()
                                command.Parameters.Clear()

                                If myReader.HasRows() Then
                                    imer = myReader.Item("imeres")
                                    pos = myReader.Item("poso")

                                    If pos > ekptosi_ Then
                                        imer = CInt(Math.Ceiling((anaxwrisi_ - afixi_).Days))
                                        afixi_ = anaxwrisi_.AddDays(-1)
                                        berechne_fake_telos_klima()
                                        command.Parameters.AddWithValue("@kratisi", kwdkrat_)
                                        command.Parameters.AddWithValue("@villa", villa_)
                                        command.Parameters.AddWithValue("@imeres", imer)
                                        command.Parameters.AddWithValue("@partialdays1", partialDays1)
                                        command.Parameters.AddWithValue("@partialposo1", partialSum1)
                                        command.Parameters.AddWithValue("@partialdays2", partialDays2)
                                        command.Parameters.AddWithValue("@partialposo2", partialSum2)
                                        command.Parameters.AddWithValue("@dimeres", 1)
                                        command.Parameters.AddWithValue("@poso", telos)

                                        ' Set the condition for the update (assuming you have an 'id' column as primary key)
                                        command.CommandText = "UPDATE telosdiamonis SET  villa = @villa, imeres = @imeres, " &
                              "partialdays1 = @partialdays1, partialposo1 = @partialposo1, " &
                              "partialdays2 = @partialdays2, partialposo2 = @partialposo2, " &
                              "dimeres = @dimeres, poso = @poso WHERE kratisi= @kratisi"

                                        ' Set the 'id' parameter based on your scenario


                                        ' Execute the update query
                                        command.ExecuteNonQuery()
                                        command.Parameters.Clear()

                                    End If





                                End If

                            Catch ex As Exception

                            End Try

                        End Using




                    End If

                End If '


            End If
        End If



    End Sub


    Function fetch_rate_villa_praktoreio(villa As String, praktoreio As Int32) As Dictionary(Of Integer, Single)
        Dim posoDictionary As New Dictionary(Of Integer, Single)()
        Using connection As New SqlConnection(connectionString_)
            Dim command As New SqlCommand()
            Dim myReader As SqlDataReader
            Try
                connection.Open()
                command.Connection = connection
                command.Parameters.AddWithValue("@villa", villa_)
                command.Parameters.AddWithValue("@praktoreio", praktoreio_)
                'command.CommandText = "SELECT kr.month, kr.poso, kv.discountdays, kv.tiposrate FROM klimavilla kv INNER JOIN klimarates kr ON kv.tiposrate = kr.tiposrate WHERE kv.villa = @Villa and  kv.praktoreio = @praktoreio ORDER BY kr.month"
                command.CommandText = "SELECT kr.month, kr.poso, kv.discountdays, kv.tiposrate FROM klimavilla kv INNER JOIN klimarates kr ON kv.tiposrate = kr.tiposrate WHERE kv.villa = @Villa AND kv.praktoreio = @praktoreio ORDER BY kr.month;"


                myReader = command.ExecuteReader()

                While myReader.Read()
                    Dim month As Byte = myReader.GetByte(0)
                    Dim poso As Single = myReader.GetFloat(1)
                    tiposrate = myReader.GetByte(3)
                    If discountdays = 0 Then
                        discountdays = myReader.GetFloat(2)
                    End If

                    ' Add the values to the dictionary
                    posoDictionary(month) = poso
                End While


            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "winfo\nikEl.")

            End Try


        End Using
        ' Connection string for your SQL Server database

        ' Return the dictionary with poso values
        Return posoDictionary
    End Function
    Function fetch_rate_villa(villa As String) As Dictionary(Of Integer, Single)
        Dim posoDictionary As New Dictionary(Of Integer, Single)()
        Using connection As New SqlConnection(connectionString_)
            Dim command As New SqlCommand()
            Dim myReader As SqlDataReader
            Try
                connection.Open()
                command.Connection = connection
                command.Parameters.AddWithValue("@villa", villa_)

                'command.CommandText = "SELECT kr.month, kr.poso, kv.discountdays, kv.tiposrate FROM klimavilla kv INNER JOIN klimarates kr ON kv.tiposrate = kr.tiposrate WHERE kv.villa = @Villa and  kv.praktoreio = @praktoreio ORDER BY kr.month"
                command.CommandText = "SELECT kr.month, kr.poso, kv.discountdays, kv.tiposrate FROM klimavilla kv INNER JOIN klimarates kr ON kv.tiposrate = kr.tiposrate WHERE kv.villa = @Villa  ORDER BY kr.month;"


                myReader = command.ExecuteReader()

                While myReader.Read()
                    Dim month As Byte = myReader.GetByte(0)
                    Dim poso As Single = myReader.GetFloat(1)
                    tiposrate = myReader.GetByte(3)
                    discountdays = 1


                    ' Add the values to the dictionary
                    posoDictionary(month) = poso
                End While


            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "winfo\nikEl.")

            End Try


        End Using
        ' Connection string for your SQL Server database

        ' Return the dictionary with poso values
        Return posoDictionary
    End Function
    Sub berechne_fake_telos_klima()
        ' Calculate 1/4 of the duration

        Dim checkOutDate As Date = anaxwrisi_
        'dimeres = CInt(Math.Ceiling((anaxwrisi_ - afixi_).Days * discountdays))
        If discountdays <> 0 Then
            dimeres = CInt(Math.Floor((anaxwrisi_ - afixi_).Days * discountdays))
        Else
            dimeres = CInt(Math.Floor((anaxwrisi_ - afixi_).Days))
        End If

        'If dimeres = 0 Then
        '    dimeres = 1
        'End If

        Dim checkInDate As Date = anaxwrisi_.AddDays(-dimeres)
        Dim currentDate As Date = checkInDate
        While currentDate < checkOutDate
            Dim currentMonth As Integer = currentDate.Month

            ' Fetch tax rate from the local collection
            Dim taxRate As Single
            If rateDictionary_.TryGetValue(currentMonth, taxRate) Then
                ' Calculate taxes for the current night
                Dim taxesForNight As Single = taxRate

                ' Update partial sums based on the tax rate period and 1/4 duration
                If currentMonth >= 3 AndAlso currentMonth <= 10 Then
                    ' March to October
                    partialDays2 += 1
                    partialSum2 += taxesForNight
                    ' Increment the days for period 1

                ElseIf currentMonth >= 11 OrElse currentMonth <= 2 Then
                    ' November to February
                    partialDays1 += 1
                    partialSum1 += taxesForNight
                    ' Increment the days for period 2

                End If

                ' Move to the next night
                currentDate = currentDate.AddDays(1)
            Else
                ' Handle missing tax rate for the month (throw an error, set a default rate, etc.)
                ' You may also want to break out of the loop or handle the situation differently
                Exit While
            End If
        End While

        telos = partialSum1 + partialSum2


    End Sub
    Sub modify_new_kratisi()
        Using connection As New SqlConnection(connectionString_)
            Dim command As New SqlCommand()
            Dim transaction As SqlTransaction = Nothing

            Dim rows As Int16 = 0
            Try
                connection.Open()

                transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted)
                command.Connection = connection
                command.Transaction = transaction


                If discountdays <> 0 Then
                    command.Parameters.AddWithValue("@synolo", timeskratSum_ - (ekptosi_ + telos))

                    command.Parameters.AddWithValue("@ekptosi", 1)
                    command.Parameters.AddWithValue("@ekptposo", (ekptosi_ + telos))
                    command.Parameters.AddWithValue("@kwd", kwdkrat_)
                    command.CommandText = "UPDATE kratiseis SET synolo=@synolo,ekptosi=@ekptosi,ekptposo=@ekptposo  WHERE (kwd=@kwd)"
                    rows = command.ExecuteNonQuery()
                    command.Parameters.Clear()
                End If



                If rows = 1 Or discountdays = 0 Then
                    command.Parameters.AddWithValue("@kratisi", kwdkrat_)
                    command.Parameters.AddWithValue("@villa", villa_)
                    command.Parameters.AddWithValue("@imeres", CInt(Math.Ceiling((anaxwrisi_ - afixi_).Days)))
                    command.Parameters.AddWithValue("@partialdays1", partialDays1)
                    command.Parameters.AddWithValue("@partialposo1", partialSum1)
                    command.Parameters.AddWithValue("@partialdays2", partialDays2)
                    command.Parameters.AddWithValue("@partialposo2", partialSum2)

                    command.Parameters.AddWithValue("@dimeres", dimeres)
                    command.Parameters.AddWithValue("@poso", telos)
                    command.CommandText = "INSERT INTO telosdiamonis (kratisi, villa, imeres,partialdays1, partialposo1, partialdays2, partialposo2, dimeres, poso) " &
                                "VALUES (@kratisi, @villa, @imeres, @partialdays1,@partialposo1, @partialdays2,@partialposo2, @dimeres, @poso)"
                    rows = command.ExecuteNonQuery()
                    command.Parameters.Clear()

                    If rows = 1 Then
                        transaction.Commit()

                    Else
                        transaction.Rollback()
                    End If
                Else
                    transaction.Rollback()
                End If
            Catch ex As Exception

            End Try

        End Using
    End Sub


    Sub modify_update_kratisi()
        Using connection As New SqlConnection(connectionString_)
            Dim command As New SqlCommand()
            Dim transaction As SqlTransaction = Nothing

            Dim rows As Int16 = 0
            Try
                connection.Open()

                transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted)
                command.Connection = connection
                command.Transaction = transaction
                If discountdays <> 0 Then
                    command.Parameters.AddWithValue("@synolo", timeskratSum_ - (ekptosi_ + telos))

                    command.Parameters.AddWithValue("@ekptosi", 1)
                    command.Parameters.AddWithValue("@ekptposo", (ekptosi_ + telos))
                    command.Parameters.AddWithValue("@kwd", kwdkrat_)
                    command.CommandText = "UPDATE kratiseis SET synolo=@synolo,ekptosi=@ekptosi,ekptposo=@ekptposo  WHERE (kwd=@kwd)"
                    rows = command.ExecuteNonQuery()
                    command.Parameters.Clear()
                End If



                If rows = 1 Or discountdays = 0 Then
                    command.Parameters.AddWithValue("@kratisi", kwdkrat_)
                    command.Parameters.AddWithValue("@villa", villa_)
                    command.Parameters.AddWithValue("@imeres", CInt(Math.Ceiling((anaxwrisi_ - afixi_).Days)))
                    command.Parameters.AddWithValue("@partialdays1", partialDays1)
                    command.Parameters.AddWithValue("@partialposo1", partialSum1)
                    command.Parameters.AddWithValue("@partialdays2", partialDays2)
                    command.Parameters.AddWithValue("@partialposo2", partialSum2)
                    command.Parameters.AddWithValue("@dimeres", dimeres)
                    command.Parameters.AddWithValue("@poso", telos)

                    ' Set the condition for the update (assuming you have an 'id' column as primary key)
                    command.CommandText = "UPDATE telosdiamonis SET  villa = @villa, imeres = @imeres, " &
                              "partialdays1 = @partialdays1, partialposo1 = @partialposo1, " &
                              "partialdays2 = @partialdays2, partialposo2 = @partialposo2, " &
                              "dimeres = @dimeres, poso = @poso WHERE kratisi= @kratisi"

                    ' Set the 'id' parameter based on your scenario


                    ' Execute the update query
                    Dim rows2 As Integer = command.ExecuteNonQuery()



                    If rows2 = 1 Then
                        transaction.Commit()

                    Else
                        transaction.Rollback()
                    End If
                Else
                    transaction.Rollback()
                End If
            Catch ex As Exception

            End Try

        End Using
    End Sub

End Class


