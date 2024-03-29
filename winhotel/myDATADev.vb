Imports System.IO
Imports System.Xml
Imports System.Text
Imports System.Net
Imports System.Globalization
Imports System.Threading
Imports System.Net.Mail
Imports System.Net.Http
Imports System.Web
Imports System.Net.Http.Headers
Imports System.Data.SqlClient
Imports System.Xml.Linq
Module myDATADev

    Public Class SendInvoices
        Dim myinvoicesID As Int32 ' 0= insert ew enrty in DB myinnvoices  ,  1=update in database
        'auto einai To DOKIMASTIKO  url!!!!!!!!!!
        Const url_ As String = "https://mydataapidev.aade.gr/SendInvoices"
        'Const url_ As String = "https://mydatapi.aade.gr/myDATA/SendInvoices?"
        'Dim qrcode As String = ""
        Dim aadeUserId_ As String ' = "mkallergis"
        Dim apiSubKey_ As String ' = "4a903ebf82df4dd7a5b2492aeda46e09"
        Dim connectionString_ As String
        Dim epixirisi_ As String
        Dim eidos_ As String
        Dim kwdTim_ As Int64
        'issuer
        Dim vatnumberEkd_ As String
        Dim countryEkd_ As String
        Dim branchEkd_ As String = "0"
        Dim postalCodeEkd_ As String
        Dim cityEkd_ As String

        'counterpart 
        Dim vatnumberLpt_ As String
        Dim countryLpt_ As String
        Dim branchLpt_ As String = "0"
        Dim onomateponimo_ As String
        Dim nameLpt_ As String
        Dim postalCodeLpt_ As String
        Dim cityLpt_ As String

        'invoiceHeader -> InvoiceHeaderParty
        Dim series_ As String
        Dim aa_ As String
        Dim issueDate_ As Date
        Dim invoiceType_ As String
        Dim corelatedInv_ As String = ""
        'payment 
        Dim paymType_ As Int16
        Dim paymAmount_ As Single
        'invoiceDetails -> InvoiceRowParty

        Dim netYpnos_ As Single ' NET TIMES META APO TYXON EKPTOSEIS
        Dim netPrwino_ As Single
        Dim netGeuma_ As Single
        Dim netExtra_ As Single
        Dim vatPosYpnos_ As Single 'POSOSTA FPA
        Dim vatPosPrwino_ As Single
        Dim vatPosGeuma_ As Single
        Dim vatPosExtra_ As Single

        Dim totalNetValue As Decimal = 0
        Dim totalVatAmount As Decimal = 0
        Dim totalGrossValue As Decimal = 0
        Dim classificationType As String
        Dim classificationCategory As String
        Structure InvoiceRowStruct
            Dim netValue_ As Single
            Dim vatPososto_ As Single
            Dim vatAmount_ As Single ' ypologizetai meta!
        End Structure

        Dim InvoiceRowArray() As InvoiceRowStruct

        'Structure InvoiceRowType!
        '    Dim lineNumber As Int64
        '    Dim netValue As Single
        '    Dim vatCategory As Int32 '1=24% 4=17% 8=aneu fpa foros diamonis
        '    Dim vatAmount As Single ' FPA
        '    Dim feesAmount As Single ' foros parepidimoyntwn
        'End Structure

        'Dim parastatikoRows() As InvoiceRowType
        Dim englishCulture As New CultureInfo("en-US", False)
        'Dim greekCulture As New CultureInfo("el-GR", False)
        'Dim threadSendInvoice As Thread
        'aadeUserId_ = "mkallergis"
        'apiSubKey_ = "4a903ebf82df4dd7a5b2492aeda46e09"
        Public Sub New(ByVal conn As String, ByVal aadeUserId As String, ByVal apiSubKey As String)
            'aadeUserId_ = aadeUserId
            'apiSubKey_ = apiSubKey
            connectionString_ = conn
            aadeUserId_ = "mkallergis"
            apiSubKey_ = "4a903ebf82df4dd7a5b2492aeda46e09"
            vatnumberEkd_ = 131485023
        End Sub
        Public Sub New(ByVal conn As String, ByVal aadeUserId As String, ByVal apiSubKey As String, ByVal epixirisi As String, ByVal eidos As String, ByVal kwdTimol As Int64, ByVal tipos As String, ByVal vatnumberEkd As String,
                                    ByVal countryEkd As String, ByVal branchEkd As String, ByVal postalCodeEkd As String, ByVal cityEkd As String,
                               ByVal vatnumberLpt As String, ByVal countryLpt As String, ByVal branchLpt As String, ByVal onomateponimo As String, ByVal nameLpt As String, ByVal postalCodeLpt As String, ByVal cityLpt As String,
                                ByVal series As String, ByVal aa As String, ByVal issueDAte As Date, ByVal paymType As String, ByVal corelatedInvoic As String,
                                ByVal paymAmount As Single, ByVal netYpnos As Single, ByVal netPrwino As Single, ByVal netGeuma As Single, ByVal netExtras As Single,
                                ByVal vatPosYpnos As Single, ByVal vatPosPrwino As Single, ByVal vatPosGeuma As Single, ByVal vatPosExtras As Single) ', ByVal dimForos As Single)
            '  Thread.CurrentThread.CurrentCulture = englishCulture
            connectionString_ = conn
            'aadeUserId_ = aadeUserId
            'apiSubKey_ = apiSubKey
            aadeUserId_ = "mkallergis"
            apiSubKey_ = "4a903ebf82df4dd7a5b2492aeda46e09"
            'vatnumberEkd_ = vatnumberEkd '  131485023 
            vatnumberEkd_ = 131485023
            epixirisi_ = epixirisi
            eidos_ = eidos
            kwdTim_ = kwdTimol
            invoiceType_ = tipos
            If invoiceType_ = "5.1" Then
                corelatedInv_ = corelatedInvoic
            End If


            countryEkd_ = countryEkd
            branchEkd_ = branchEkd
            postalCodeEkd_ = postalCodeEkd
            cityEkd_ = cityEkd
            vatnumberLpt_ = vatnumberLpt
            countryLpt_ = countryLpt
            branchLpt_ = branchLpt
            onomateponimo_ = onomateponimo
            nameLpt_ = nameLpt
            postalCodeLpt_ = postalCodeLpt
            cityLpt_ = cityLpt

            Select Case paymType
                Case "Επί Πιστώση"
                    paymType_ = 5
                Case "Μετρητοίς"
                    paymType_ = 3
                Case "Επιταγή"
                    paymType_ = 3
                Case "Foreigncard"
                    paymType_ = 2
                Case Else
                    paymType_ = 1
            End Select
            series_ = series
            aa_ = aa
            issueDate_ = issueDAte
            netYpnos_ = netYpnos ' NET TIMES META APO TYXON EKPTOSEIS
            netPrwino_ = netPrwino
            netGeuma_ = netGeuma
            netExtra_ = netExtras
            vatPosYpnos_ = vatPosYpnos 'POSOSTA FPA
            vatPosPrwino_ = vatPosPrwino
            vatPosGeuma_ = vatPosGeuma
            vatPosExtra_ = vatPosExtras
            'Dim InvoiceR() As InvoiceRowStruct
            'InvoiceR = make_rows_fpa(netYpnos_, vatPosYpnos_, netPrwino_, vatPosPrwino_, netGeuma_, vatPosGeuma_, netExtra_, vatPosExtra_)
            'InvoiceRowArr = normalize_invoice_array(InvoiceR)
            '   otherTaxAmount_ = dimForos
            Dim InvoiceR() As InvoiceRowStruct
            ' Creating an array using the function make_rows_fpa
            InvoiceR = make_rows_fpa(netYpnos_, vatPosYpnos_, netPrwino_, vatPosPrwino_, netGeuma_, vatPosGeuma_, netExtra_, vatPosExtra_)
            ' Normalizing the array and assigning the result to InvoiceRowArr
            InvoiceRowArray = normalize_invoice_array(InvoiceR)
        End Sub
        Public Sub set_mode(ByVal id As Int32)
            myinvoicesID = id
        End Sub

        Function make_rows_fpa(ByVal netYpnos As Single, ByVal vatYpnos As Single, ByVal netPrwino As Single, ByVal vatPrwino As Single, ByVal netGeuma As Single,
                          ByVal vatGeuma As Single, ByVal netExtra As Single, ByVal vatExtra As Single) As InvoiceRowStruct()

            Dim InvoiceRowArr() As InvoiceRowStruct
            If vatYpnos = vatPrwino AndAlso vatPrwino = vatGeuma AndAlso vatGeuma = vatExtra Then
                ReDim InvoiceRowArr(0)
                InvoiceRowArr(0).netValue_ = netYpnos + netPrwino + netGeuma + netExtra
                InvoiceRowArr(0).vatPososto_ = vatYpnos
            ElseIf vatYpnos = vatPrwino AndAlso vatPrwino = vatGeuma Then
                ReDim InvoiceRowArr(1)
                InvoiceRowArr(0).netValue_ = netYpnos + netPrwino + netGeuma
                InvoiceRowArr(0).vatPososto_ = vatYpnos
                InvoiceRowArr(1).netValue_ = netExtra
                InvoiceRowArr(1).vatPososto_ = vatExtra
            ElseIf vatYpnos = vatPrwino AndAlso vatPrwino = vatExtra Then
                ReDim InvoiceRowArr(1)
                InvoiceRowArr(0).netValue_ = netYpnos + netPrwino + netExtra
                InvoiceRowArr(0).vatPososto_ = vatYpnos
                InvoiceRowArr(1).netValue_ = netGeuma
                InvoiceRowArr(1).vatPososto_ = vatGeuma
            ElseIf vatYpnos = vatGeuma AndAlso vatGeuma = vatExtra Then
                ReDim InvoiceRowArr(1)
                InvoiceRowArr(0).netValue_ = netYpnos + netGeuma + netExtra
                InvoiceRowArr(0).vatPososto_ = vatYpnos
                InvoiceRowArr(1).netValue_ = netPrwino
                InvoiceRowArr(1).vatPososto_ = vatPrwino
            ElseIf vatPrwino = vatGeuma AndAlso vatGeuma = vatExtra Then
                ReDim InvoiceRowArr(1)
                InvoiceRowArr(0).netValue_ = netYpnos
                InvoiceRowArr(0).vatPososto_ = vatYpnos
                InvoiceRowArr(1).netValue_ = netPrwino + netGeuma + netExtra
                InvoiceRowArr(1).vatPososto_ = vatPrwino
            ElseIf vatYpnos = vatPrwino Then
                If vatGeuma = vatExtra Then
                    ReDim InvoiceRowArr(1)
                    InvoiceRowArr(0).netValue_ = netYpnos + netPrwino
                    InvoiceRowArr(0).vatPososto_ = vatYpnos
                    InvoiceRowArr(1).netValue_ = netGeuma + netExtra
                    InvoiceRowArr(1).vatPososto_ = vatGeuma
                Else
                    ReDim InvoiceRowArr(2)
                    InvoiceRowArr(0).netValue_ = netYpnos + netPrwino
                    InvoiceRowArr(0).vatPososto_ = vatYpnos
                    InvoiceRowArr(1).netValue_ = netGeuma
                    InvoiceRowArr(1).vatPososto_ = vatGeuma
                    InvoiceRowArr(2).netValue_ = netExtra
                    InvoiceRowArr(2).vatPososto_ = vatExtra
                End If
            ElseIf vatYpnos = vatGeuma Then
                If vatPrwino = vatExtra Then
                    ReDim InvoiceRowArr(1)
                    InvoiceRowArr(0).netValue_ = netYpnos + netGeuma
                    InvoiceRowArr(0).vatPososto_ = vatYpnos
                    InvoiceRowArr(1).netValue_ = netPrwino + netExtra
                    InvoiceRowArr(1).vatPososto_ = vatPrwino
                Else
                    ReDim InvoiceRowArr(2)
                    InvoiceRowArr(0).netValue_ = netYpnos + netGeuma
                    InvoiceRowArr(0).vatPososto_ = vatYpnos
                    InvoiceRowArr(1).netValue_ = netPrwino
                    InvoiceRowArr(1).vatPososto_ = vatPrwino
                    InvoiceRowArr(2).netValue_ = netExtra
                    InvoiceRowArr(2).vatPososto_ = vatExtra
                End If
            ElseIf vatYpnos = vatExtra Then
                If vatPrwino = vatGeuma Then
                    ReDim InvoiceRowArr(1)
                    InvoiceRowArr(0).netValue_ = netYpnos + netExtra
                    InvoiceRowArr(0).vatPososto_ = vatYpnos
                    InvoiceRowArr(1).netValue_ = netPrwino + netGeuma
                    InvoiceRowArr(1).vatPososto_ = vatPrwino
                Else
                    ReDim InvoiceRowArr(2)
                    InvoiceRowArr(0).netValue_ = netYpnos + netExtra
                    InvoiceRowArr(0).vatPososto_ = vatYpnos
                    InvoiceRowArr(1).netValue_ = netPrwino
                    InvoiceRowArr(1).vatPososto_ = vatPrwino
                    InvoiceRowArr(2).netValue_ = netGeuma
                    InvoiceRowArr(2).vatPososto_ = vatGeuma
                End If
            ElseIf vatPrwino = vatGeuma Then
                If vatYpnos = vatExtra Then
                    ReDim InvoiceRowArr(1)
                    InvoiceRowArr(0).netValue_ = netYpnos + netExtra
                    InvoiceRowArr(0).vatPososto_ = vatYpnos
                    InvoiceRowArr(1).netValue_ = netPrwino + netGeuma
                    InvoiceRowArr(1).vatPososto_ = vatPrwino
                Else
                    ReDim InvoiceRowArr(2)
                    InvoiceRowArr(0).netValue_ = netYpnos
                    InvoiceRowArr(0).vatPososto_ = vatYpnos
                    InvoiceRowArr(1).netValue_ = netPrwino + netGeuma
                    InvoiceRowArr(1).vatPososto_ = vatPrwino
                    InvoiceRowArr(2).netValue_ = netExtra
                    InvoiceRowArr(2).vatPososto_ = vatExtra
                End If
            ElseIf vatPrwino = vatExtra Then
                If vatYpnos = vatGeuma Then
                    ReDim InvoiceRowArr(1)
                    InvoiceRowArr(0).netValue_ = netYpnos + netGeuma
                    InvoiceRowArr(0).vatPososto_ = vatYpnos
                    InvoiceRowArr(1).netValue_ = netPrwino + netExtra
                    InvoiceRowArr(1).vatPososto_ = vatPrwino
                Else
                    ReDim InvoiceRowArr(2)
                    InvoiceRowArr(0).netValue_ = netYpnos
                    InvoiceRowArr(0).vatPososto_ = vatYpnos
                    InvoiceRowArr(1).netValue_ = netPrwino + netExtra
                    InvoiceRowArr(1).vatPososto_ = vatPrwino
                    InvoiceRowArr(2).netValue_ = netGeuma
                    InvoiceRowArr(2).vatPososto_ = vatGeuma
                End If
            ElseIf vatGeuma = vatExtra Then
                If vatYpnos = vatPrwino Then
                    ReDim InvoiceRowArr(1)
                    InvoiceRowArr(0).netValue_ = netYpnos + netPrwino
                    InvoiceRowArr(0).vatPososto_ = vatYpnos
                    InvoiceRowArr(1).netValue_ = netGeuma + netExtra
                    InvoiceRowArr(1).vatPososto_ = vatGeuma
                Else
                    ReDim InvoiceRowArr(2)
                    InvoiceRowArr(0).netValue_ = netYpnos
                    InvoiceRowArr(0).vatPososto_ = vatYpnos
                    InvoiceRowArr(1).netValue_ = netPrwino
                    InvoiceRowArr(1).vatPososto_ = vatPrwino
                    InvoiceRowArr(2).netValue_ = netGeuma + netExtra
                    InvoiceRowArr(2).vatPososto_ = vatGeuma
                End If
            Else
                ReDim InvoiceRowArr(3)
                InvoiceRowArr(0).netValue_ = netYpnos
                InvoiceRowArr(0).vatPososto_ = vatYpnos
                InvoiceRowArr(1).netValue_ = netPrwino
                InvoiceRowArr(1).vatPososto_ = vatPrwino
                InvoiceRowArr(2).netValue_ = netGeuma
                InvoiceRowArr(2).vatPososto_ = vatGeuma
                InvoiceRowArr(3).netValue_ = netExtra
                InvoiceRowArr(3).vatPososto_ = vatExtra
            End If

            Return InvoiceRowArr
        End Function
        Private Function normalize_invoice_array(ByVal InvoiceRowArr() As InvoiceRowStruct) As InvoiceRowStruct()
            Dim InvoiceRow() As InvoiceRowStruct = Nothing
            Dim count As Integer = 0

            For i As Integer = 0 To InvoiceRowArr.Length - 1
                If InvoiceRowArr(i).netValue_ <> 0 Then
                    ReDim Preserve InvoiceRow(count)
                    InvoiceRow(count).netValue_ = InvoiceRowArr(i).netValue_
                    InvoiceRow(count).vatPososto_ = InvoiceRowArr(i).vatPososto_
                    count += 1
                End If
            Next

            If InvoiceRowArr Is Nothing Then
                ReDim Preserve InvoiceRow(0)
                InvoiceRow(0).netValue_ = 0
                InvoiceRow(0).vatPososto_ = InvoiceRowArr(0).vatPososto_
            End If

            Return InvoiceRow
        End Function

        'Sub array_load(ByVal parasRows() As InvoiceRowType)
        '    Dim j As Int16

        '    For j = 0 To parasRows.Length - 1
        '        ReDim Preserve parastatikoRows(j)
        '        parastatikoRows(j).lineNumber = j + 1
        '        parastatikoRows(j).netValue = parasRows(j).netValue
        '        parastatikoRows(j).vatCategory = parasRows(j).vatCategory
        '        parastatikoRows(j).vatAmount = parasRows(j).vatAmount
        '        parastatikoRows(j).feesAmount = parasRows(j).feesAmount
        '    Next
        'End Sub
        Public Function send_invoice() As Threading.Thread
            Dim theThread _
           As New Threading.Thread(AddressOf make_send_XML_file_for_invoice_requestAsync)

            theThread.Start()
            Return theThread
        End Function

        Private Sub make_send_XML_file_for_invoice_requestAsync()
            Dim i As Int16
            Dim result As String = ""
            Dim Stream As New MemoryStream()

            '    Dim tempValue As Single = 0
            Dim mySettings As New XmlWriterSettings()
            mySettings.NewLineOnAttributes = True
            mySettings.Encoding = System.Text.Encoding.UTF8
            mySettings.Indent = True
            mySettings.IndentChars = "      "

            'System.Threading.Thread.Sleep(10000)
            '   Dim writer = (XmlTextWriter).Create(Stream, mySettings)
            Dim writer As New XmlTextWriter(Stream, System.Text.Encoding.UTF8)
            ' Dim writer As New XmlTextWriter("file.xml", System.Text.Encoding.UTF8)




            ' writer.WriteStartDocument(True)
            writer.Formatting = Formatting.Indented
            writer.Indentation = 2
            writer.WriteStartElement("InvoicesDoc")
            writer.WriteAttributeString("xmlns", Nothing, Nothing, "http://www.aade.gr/myDATA/invoice/v1.0")
            writer.WriteAttributeString("xmlns", "xsi", Nothing, "http://www.w3.org/2001/XMLSchema-instance")
            writer.WriteAttributeString("xmlns", "icls", Nothing, "https://www.aade.gr/myDATA/incomeClassificaton/v1.0")
            writer.WriteAttributeString("xmlns", "ecls", Nothing, "https://www.aade.gr/myDATA/expensesClassificaton/v1.0")
            writer.WriteAttributeString("xmlns", "schemaLocation", Nothing, "http://www.aade.gr/myDATA/invoice/v1.0/InvoicesDoc-v0.6.xsd")

            writer.WriteStartElement("invoice")

            writer.WriteStartElement("issuer")

            writer.WriteStartElement("vatNumber")
            writer.WriteString(vatnumberEkd_)
            writer.WriteEndElement() 'vatNumber

            writer.WriteStartElement("country")
            writer.WriteString(countryEkd_)
            writer.WriteEndElement() 'country

            writer.WriteStartElement("branch")
            writer.WriteString(branchEkd_)
            writer.WriteEndElement() 'branch

            writer.WriteEndElement() 'issuer


            If invoiceType_.Equals("2.1") Or invoiceType_.Equals("5.1") Or invoiceType_.Equals("5.2") Or invoiceType_.Equals("8.2") Then 'Or invoiceType_.Equals("2.2") 
                writer.WriteStartElement("counterpart")


                writer.WriteStartElement("vatNumber")
                'If Not invoiceType_.Equals("2.2") Then
                '    writer.WriteString(vatnumberLpt_)
                'Else
                '    writer.WriteString("")
                'End If
                writer.WriteString(vatnumberLpt_)

                writer.WriteEndElement() 'vatNumber


                writer.WriteStartElement("country")
                writer.WriteString(countryLpt_)
                writer.WriteEndElement() 'country

                writer.WriteStartElement("branch")
                writer.WriteString(branchLpt_)
                writer.WriteEndElement() 'branch

                If Not countryLpt_.Equals("GR") Then
                    writer.WriteStartElement("name")
                    writer.WriteString(nameLpt_)
                    writer.WriteEndElement() 'name
                End If


                writer.WriteStartElement("address")

                writer.WriteStartElement("postalCode")
                writer.WriteString(postalCodeLpt_)
                writer.WriteEndElement() 'postalCode
                writer.WriteStartElement("city")
                writer.WriteString(cityLpt_)
                writer.WriteEndElement() 'city

                writer.WriteEndElement() 'adress

                writer.WriteEndElement() 'counterpart
            End If



            writer.WriteStartElement("invoiceHeader")

            writer.WriteStartElement("series")
            writer.WriteString(series_)
            writer.WriteEndElement() 'series
            writer.WriteStartElement("aa")
            writer.WriteString(aa_)
            writer.WriteEndElement() 'aa
            writer.WriteStartElement("issueDate")
            writer.WriteString(issueDate_.ToString("yyyy-MM-dd", englishCulture))
            writer.WriteEndElement() 'issueDate
            writer.WriteStartElement("invoiceType")
            writer.WriteString(invoiceType_)
            writer.WriteEndElement() 'invoiceType
            writer.WriteStartElement("currency")
            writer.WriteString("EUR")
            writer.WriteEndElement() 'currency

            If Not String.IsNullOrEmpty(corelatedInv_) Then
                writer.WriteStartElement("correlatedInvoices")
                writer.WriteString(corelatedInv_)
                writer.WriteEndElement() 'correlatedInvoices
            End If

            writer.WriteEndElement() 'invoiceHeader


            writer.WriteStartElement("paymentMethods")
            writer.WriteStartElement("paymentMethodDetails")
            writer.WriteStartElement("type")
            writer.WriteString(paymType_.ToString)
            writer.WriteEndElement() ' type
            writer.WriteStartElement("amount")
            writer.WriteString(paymAmount_.ToString("F02", englishCulture))
            writer.WriteEndElement() ' amount
            writer.WriteEndElement() ' paymentMethodDetails
            writer.WriteEndElement() 'paymentMethods

            For i = 0 To InvoiceRowArray.Length - 1

                writer.WriteStartElement("invoiceDetails")

                writer.WriteStartElement("lineNumber")
                writer.WriteString((i + 1).ToString)
                writer.WriteEndElement() 'lineNumber

                writer.WriteStartElement("netValue")
                writer.WriteString(InvoiceRowArray(i).netValue_.ToString("F02", englishCulture))
                ' tempValue = Math.Round(InvoiceRowArray(i).netValue_, 2)
                '  MsgBox("netValue" + InvoiceRowArray(i).netValue_.ToString)
                'MsgBox("remp" + tempValue.ToString)
                '       MsgBox("stelnw netValue" + InvoiceRowArray(i).netValue_.ToString("F02", englishCulture))
                totalNetValue = totalNetValue + InvoiceRowArray(i).netValue_
                writer.WriteEndElement() 'netValue

                writer.WriteStartElement("vatCategory")
                writer.WriteString(get_vatCategory(InvoiceRowArray(i).vatPososto_).ToString)
                writer.WriteEndElement() 'vatCategor

                writer.WriteStartElement("vatAmount")

                InvoiceRowArray(i).vatAmount_ = InvoiceRowArray(i).netValue_ * InvoiceRowArray(i).vatPososto_ / 100
                writer.WriteString(InvoiceRowArray(i).vatAmount_.ToString("F02", englishCulture))
                'tempValue = Math.Round(InvoiceRowArray(i).vatAmount_, 2)
                'MsgBox("stelnw vatAmount" + InvoiceRowArray(i).vatAmount_.ToString("F02", englishCulture))
                'totalVatAmount = totalVatAmount + Math.Round(InvoiceRowArray(i).vatAmount_, 2)
                totalVatAmount = totalVatAmount + InvoiceRowArray(i).vatAmount_
                writer.WriteEndElement() 'vatAmount


                'writer.WriteEndElement() 'vatAmount

                'If i = 0 AndAlso otherTaxAmount_ <> 0 Then
                '    writer.WriteStartElement("otherTaxesPercentCategory")
                '    writer.WriteString(otherTaxAmount_.ToString("F02", englishCulture))
                '    writer.WriteEndElement() 'feesAmount
                '    writer.WriteStartElement("otherTaxesAmount")
                '    writer.WriteString(otherTaxAmount_.ToString("F02", englishCulture))
                '    writer.WriteEndElement() 'feesAmount
                'End If
                If Not invoiceType_.Equals("8.2") Then
                    writer.WriteStartElement("incomeClassification")
                    writer.WriteStartElement("icls:classificationType")
                    If invoiceType_.Equals("2.1") Or invoiceType_.Equals("5.1") Or invoiceType_.Equals("5.2") Then
                        writer.WriteString("E3_561_001")
                    ElseIf invoiceType_.Equals("11.2") Or invoiceType_.Equals("11.4") Then '?????????????Or invoiceType_.Equals("5.2"
                        writer.WriteString("E3_561_003")
                    ElseIf invoiceType_.Equals("2.2") Then '?????????????
                        writer.WriteString("E3_561_005")
                    End If
                    writer.WriteEndElement() 'icls:classificationType
                    writer.WriteStartElement("icls:classificationCategory")
                    writer.WriteString("category1_3")
                    writer.WriteEndElement() 'icls:classificationCategory
                    writer.WriteStartElement("icls:amount")
                    writer.WriteString(InvoiceRowArray(i).netValue_.ToString("F02", englishCulture))
                    writer.WriteEndElement() 'icls:amount
                    writer.WriteEndElement() 'incomeClassification

                End If


                writer.WriteEndElement() 'invoiceDetails


            Next
            'writer.WriteStartElement("taxesTotals")
            'writer.WriteStartElement("taxes")
            'writer.WriteStartElement("taxType")
            'writer.WriteString("2")
            'writer.WriteEndElement() 'taxType

            'writer.WriteStartElement("underlyingValue")
            'writer.WriteString(totalNetValue.ToString("F02", englishCulture))
            'writer.WriteEndElement() 'underlyingValue

            'writer.WriteStartElement("taxAmount")
            'writer.WriteString(otherTaxAmount_.ToString("F02", englishCulture))
            'writer.WriteEndElement() 'taxAmount
            'writer.WriteEndElement() 'taxes
            'writer.WriteEndElement() 'taxestotal

            writer.WriteStartElement("invoiceSummary")

            writer.WriteStartElement("totalNetValue")
            writer.WriteString(totalNetValue.ToString("F02", englishCulture))

            '   MsgBox("stelnw totalNetValue" + totalNetValue.ToString("F02", englishCulture))
            writer.WriteEndElement() 'totalNetValue

            writer.WriteStartElement("totalVatAmount")
            writer.WriteString(totalVatAmount.ToString("F02", englishCulture))
            'MsgBox("stelnw totalVatAmount" + totalVatAmount.ToString("F02", englishCulture))
            writer.WriteEndElement() 'totalVatAmount

            writer.WriteStartElement("totalWithheldAmount")
            writer.WriteString("0.00")
            writer.WriteEndElement() 'totalWithheldAmount

            writer.WriteStartElement("totalFeesAmount")
            writer.WriteString("0.00")
            writer.WriteEndElement() 'totalWithheldAmount

            writer.WriteStartElement("totalStampDutyAmount")
            writer.WriteString("0.00")
            writer.WriteEndElement() 'totalStampDutyAmount

            writer.WriteStartElement("totalOtherTaxesAmount")
            writer.WriteString("0.00")
            writer.WriteEndElement() 'totalOtherTaxesAmount

            writer.WriteStartElement("totalDeductionsAmount")
            writer.WriteString("0.00")
            writer.WriteEndElement() 'totalDeductionsAmount

            writer.WriteStartElement("totalGrossValue")
            totalGrossValue = totalNetValue + totalVatAmount
            totalGrossValue = Decimal.Round(totalGrossValue, 2)
            writer.WriteString(totalGrossValue.ToString(englishCulture))
            '      MsgBox("stelnw totalGrossValue" + totalGrossValue.ToString("F02", englishCulture))
            writer.WriteEndElement() 'totalGrossValue

            If Not invoiceType_.Equals("8.2") Then
                writer.WriteStartElement("incomeClassification")
                writer.WriteStartElement("icls:classificationType")
                If invoiceType_.Equals("2.1") Or invoiceType_.Equals("5.1") Or invoiceType_.Equals("5.2") Then
                    writer.WriteString("E3_561_001")
                    classificationType = "E3_561_001"
                ElseIf invoiceType_.Equals("11.2") Or invoiceType_.Equals("11.4") Then '????????????? Or invoiceType_.Equals("5.2")
                    writer.WriteString("E3_561_003")
                    classificationType = "E3_561_003"
                ElseIf invoiceType_.Equals("2.2") Then '?????????????
                    writer.WriteString("E3_561_005")
                    classificationType = "E3_561_005"
                End If
                writer.WriteEndElement() 'icls:classificationType
                writer.WriteStartElement("icls:classificationCategory")

                writer.WriteString("category1_3")
                classificationCategory = "category1_3"
                writer.WriteEndElement() 'icls:classificationCategory
                writer.WriteStartElement("icls:amount")
                writer.WriteString(totalNetValue.ToString("F02", englishCulture))
                'MsgBox("totalNetValue clASAS" + totalNetValue.ToString("F02", englishCulture))
                writer.WriteEndElement() 'icls:amount
                writer.WriteEndElement() 'incomeClassification
            End If


            writer.WriteEndElement() 'invoiceSummary



            writer.WriteEndElement() 'invoice
            writer.WriteEndElement() 'InvoiceDoc

            writer.Flush()
            'writer.WriteEndDocument()
            'writer.Close()

            Dim reader = New StreamReader(Stream, Encoding.UTF8, True)
            Stream.Seek(0, SeekOrigin.Begin)

            Try
                Dim folderPath As String = ""
                If invoiceType_.Equals("11.2") Then
                    folderPath = "C:\winfo\mydata\apy\"
                ElseIf invoiceType_.Equals("2.1") Then
                    folderPath = "C:\winfo\mydata\tpy\"
                ElseIf invoiceType_.Equals("8.2") Then
                    folderPath = "C:\winfo\mydata\fd\"
                ElseIf invoiceType_.Equals("5.1") Or invoiceType_.Equals("5.2") Or invoiceType_.Equals("11.4") Then
                    folderPath = "C:\winfo\mydata\pistwtika\"
                End If

                If Not String.IsNullOrEmpty(folderPath) Then
                    Dim fileName As String = aa_ + ".xml"
                    Dim filePath As String = Path.Combine(folderPath, fileName)

                    ' Check if the folder exists, and create it if it doesn't
                    If Not Directory.Exists(folderPath) Then
                        Directory.CreateDirectory(folderPath)
                    End If

                    ' Create and write to the file
                    Using fs As New FileStream(filePath, FileMode.Create, FileAccess.Write)
                        ' Write data to the file using the Stream object (assuming it's already defined)
                        Stream.WriteTo(fs)
                    End Using

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
            result = reader.ReadToEnd()
            '    MsgBox(result)
            ' Return True


            Send_request(result)


            'If Send_request(result) Then

            'End If
        End Sub
        Private Function get_vatCategory(ByVal fpa As Single) As Int16
            Select Case fpa
                Case 24
                    Return 1
                Case 13
                    Return 2
                Case 6
                    Return 3
                Case 17
                    Return 4
                Case 9
                    Return 5
                Case 4
                    Return 6
                Case Else
                    Return 8

            End Select

        End Function

        Private Sub Send_request(ByVal requestString As String)
            Dim errosMessage As String = "Αποτυχία ενημέρωσης του myData"
            Dim invoiceMark As String = ""
            Dim invoiceUid As String = ""
            Dim cancelMark As String = ""
            Dim qrurl As String = ""
            Dim xmldoc As New XmlDocument

            Dim xmlnode As XmlNodeList
            Dim istOK As Boolean = True
            Dim client = New HttpClient()
            client.DefaultRequestHeaders.Add("aade-user-id", "mkallergis")
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "4a903ebf82df4dd7a5b2492aeda46e09")
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
            Dim request As WebRequest = WebRequest.Create(url_)
            request.Headers.Add("aade-user-id", aadeUserId_)
            request.Headers.Add("Ocp-Apim-Subscription-Key", apiSubKey_)
            '  request.Credentials = CredentialCache.DefaultCredentials
            request.Method = "POST"

            Dim byteArray As Byte() = Encoding.UTF8.GetBytes(requestString)

            request.ContentType = "text/plain"
            request.ContentLength = byteArray.Length
            Try
                ' Get the request stream.  
                Dim dataStream As Stream = request.GetRequestStream()
                ' Write the data to the request stream.  
                dataStream.Write(byteArray, 0, byteArray.Length)
                ' Close the Stream object.  
                dataStream.Close()


                Dim response As WebResponse = request.GetResponse()
                'Dim reader As New StreamReader(response.GetResponseStream)
                'Dim streamTetx As String = reader.ReadToEnd
                'MsgBox(streamTetx)
                'Exit Sub
                Using Stream As Stream = response.GetResponseStream()
                    ' Open the stream using a StreamReader for easy access.  

                    ' Read the content.  
                    xmldoc.Load(Stream)

                    xmlnode = xmldoc.GetElementsByTagName("error")
                    If xmlnode.Count <> 0 Then
                        For Each node1 As XmlNode In xmlnode
                            errosMessage = errosMessage + vbCrLf + node1.InnerText

                            'For Each attr As XmlAttribute In node1.Attributes
                            '    If attr.Name.Equals("message") Then
                            '        errosMessage = errosMessage + attr.InnerText + vbCrLf
                            '    End If


                            'Next

                        Next
                        MsgBox(errosMessage)
                    Else
                        xmlnode = xmldoc.GetElementsByTagName("invoiceMark")
                        If xmlnode.Count <> 0 Then
                            For Each node As XmlNode In xmlnode
                                invoiceMark = node.InnerText
                            Next
                        End If
                        xmlnode = xmldoc.GetElementsByTagName("qrUrl")
                        If xmlnode.Count <> 0 Then
                            For Each node As XmlNode In xmlnode
                                qrurl = node.InnerText
                            Next
                        End If
                        xmlnode = xmldoc.GetElementsByTagName("invoiceUid")
                        If xmlnode.Count <> 0 Then
                            For Each node As XmlNode In xmlnode
                                invoiceUid = node.InnerText
                            Next
                        End If
                        xmlnode = xmldoc.GetElementsByTagName("cancellationMark")
                        If xmlnode.Count <> 0 Then
                            For Each node As XmlNode In xmlnode
                                invoiceUid = node.InnerText
                            Next
                        End If

                    End If

                End Using
            Catch ex As WebException

                MsgBox("Αποτυχία επικοινωνίας με MyData", MsgBoxStyle.Exclamation)
                istOK = False
            End Try
            If myinvoicesID = 0 Then
                execute_insert_myInvoice(invoiceMark, invoiceUid, cancelMark, qrurl)
            ElseIf myinvoicesID = 1 Then
                execute_update_myInvoices(invoiceMark, invoiceUid, cancelMark, qrurl)
            ElseIf myinvoicesID = 2 Then
                'execute_insert_myInvoice(invoiceMark, invoiceUid, cancelMark, qrurl)
                execute_update_timologio_with_qr(requestString, qrurl)
                If istOK Then
                    MsgBox("Εγινε ενημέρωση του MyData!", MsgBoxStyle.Information)


                End If
            End If


            'Return istOK
        End Sub
        Private Sub execute_update_timologio_with_qr(ByVal requestString As String, ByVal qrurl As String)
            Dim xmlDoc As XDocument = XDocument.Parse(requestString)

            ' Set the XML namespace
            Dim ns As XNamespace = "http://www.aade.gr/myDATA/invoice/v1.0"

            ' Access the <invoiceHeader> element
            Dim invoiceHeader As XElement = xmlDoc.Root.Element(ns + "invoice").Element(ns + "invoiceHeader")
            Dim invoiceSummary As XElement = xmlDoc.Root.Element(ns + "invoice").Element(ns + "invoiceSummary")
            ' Now you can access individual elements within <invoiceHeader>
            Dim series As String = invoiceHeader.Element(ns + "series").Value
            Dim aa As String = invoiceHeader.Element(ns + "aa").Value
            Dim issueDate As String = invoiceHeader.Element(ns + "issueDate").Value
            Dim invoiceType As String = invoiceHeader.Element(ns + "invoiceType").Value
            Dim totalGrossValue As String = invoiceSummary.Element(ns + "totalGrossValue").Value

            Using connection As New SqlConnection(connectionString_)
                Dim command As New SqlCommand()
                Dim transaction As SqlTransaction = Nothing
                Try
                    connection.Open()
                    transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted)
                    command.Connection = connection
                    command.Transaction = transaction

                    command.Parameters.AddWithValue("qrcode", qrurl)
                    command.Parameters.AddWithValue("imerominia", issueDate)
                    command.Parameters.AddWithValue("aa", aa)
                    command.Parameters.AddWithValue("synolo", totalGrossValue)
                    command.CommandText = "UPDATE timologia SET qrcode = @qrcode WHERE  (imerominia=@imerominia) and(aa = @aa) and (synola=@synolo) and (akyromeno = 0)"
                    command.ExecuteNonQuery()
                    command.Parameters.Clear()
                    transaction.Commit()
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try


            End Using



            ' Print or use the values as needed
            'Console.WriteLine($"Series: {series}, AA: {aa}, Issue Date: {issueDate}, Invoice Type: {invoiceType}, Currency: {currency}")
        End Sub
        'Private Sub execute_update_myInvoices(ByVal invoiceMark As String, ByVal invoiceUid As String, ByVal cancelInv As String)

        '    Using connection As New OleDb.OleDbConnection(connectionString_)
        '        Dim command As New OleDb.OleDbCommand()
        '        Dim transaction As OleDb.OleDbTransaction = Nothing
        '        Try

        '            connection.Open()
        '            transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted)
        '            command.Connection = connection
        '            command.Transaction = transaction

        '            command.Parameters.AddWithValue("uid", invoiceUid)
        '            command.Parameters.AddWithValue("mark", invoiceMark)
        '            command.Parameters.AddWithValue("cancelmark", cancelInv)
        '            command.Parameters.AddWithValue("tipos", invoiceType_)
        '            command.Parameters.AddWithValue("vatnumberEkd", vatnumberEkd_)
        '            command.Parameters.AddWithValue("countryEkd", countryEkd_)
        '            command.Parameters.AddWithValue("branchEkd", branchEkd_)
        '            command.Parameters.AddWithValue("postalCodeEkd", postalCodeEkd_)
        '            command.Parameters.AddWithValue("cityEkd", cityEkd_)
        '            command.Parameters.AddWithValue("vatnumberLpt", vatnumberLpt_)
        '            command.Parameters.AddWithValue("countryLpt", countryLpt_)
        '            command.Parameters.AddWithValue("branchLpt", branchLpt_)

        '            command.Parameters.AddWithValue("nameLpt", nameLpt_)
        '            command.Parameters.AddWithValue("postalCodeLpt", postalCodeLpt_)
        '            command.Parameters.AddWithValue("cityLpt", cityLpt_)

        '            command.Parameters.AddWithValue("series", series_)
        '            command.Parameters.AddWithValue("aa", aa_)
        '            command.Parameters.AddWithValue("issueDate", issueDate_)
        '            command.Parameters.AddWithValue("paymType", paymType_)
        '            command.Parameters.AddWithValue("corelatedInvoic", corelatedInv_)
        '            command.Parameters.AddWithValue("paymAmount", paymAmount_)

        '            command.Parameters.AddWithValue("netYpnos", netYpnos_)
        '            command.Parameters.AddWithValue("netPrwino", netPrwino_)
        '            command.Parameters.AddWithValue("netGeuma", netGeuma_)
        '            command.Parameters.AddWithValue("netExtras", netExtra_)
        '            command.Parameters.AddWithValue("vatPosYpnos", vatPosYpnos_)
        '            command.Parameters.AddWithValue("vatPosPrwino", vatPosPrwino_)


        '            command.Parameters.AddWithValue("vatPosGeuma", vatPosGeuma_)
        '            command.Parameters.AddWithValue("vatPosExtras", vatPosExtra_)

        '            command.Parameters.AddWithValue("totalNetvalue", totalNetValue)
        '            command.Parameters.AddWithValue("totalVatvalue", totalVatAmount)
        '            command.Parameters.AddWithValue("totalGrossvalue", totalGrossValue)

        '            command.Parameters.AddWithValue("classificationType", classificationType)
        '            command.Parameters.AddWithValue("classificationCategory", classificationCategory)
        '            command.Parameters.AddWithValue("id", myinvoicesID)


        '            command.CommandText = "UPDATE myinvoices SET uid=?, mark=?, cancelmark=?,tipos=?, vatnumberEkd=?, countryEkd=?, branchEkd=?,postalCodeEkd=?,cityEkd=?," &
        '             "vatnumberLpt=?,countryLpt=?,branchLpt=?,nameLpt=?,postalCodeLpt=?,cityLpt=?,series=? ,aa=?,issueDate=?,paymType=?,corelatedInvoic=?,paymAmount=?,netYpnos=?,netPrwino=?,netGeuma=?,netExtras=?,vatPosYpnos=?,vatPosPrwino=?,vatPosGeuma=?,vatPosExtras=?,totalNetvalue=?,totalVatvalue=?,totalGrossvalue=?,classificationType=?,classificationCategory=?" &
        '            "WHERE (id=?)"
        '            command.ExecuteNonQuery()
        '            command.Parameters.Clear()

        '            transaction.Commit()
        '            '   Return 1
        '        Catch ex As Exception
        '            MsgBox("Η Διαδικασία ενημέρωσης βάσης απέτυχε !", MsgBoxStyle.Exclamation, "winfo\nikEl.")
        '            Try
        '                transaction.Rollback()
        '                '  Return -1
        '            Catch
        '                '    Return -1
        '            End Try

        '        End Try
        '    End Using
        'End Sub
        Public Sub send_XML_file_from_pc()
            'Dim result As String = ""
            'Dim Stream As New MemoryStream()
            'Dim fs As New FileStream("file3.xml", FileMode.Open, FileAccess.Read)
            'Dim reader = New StreamReader(fs, True) = 
            'Stream.Seek(0, SeekOrigin.Begin)
            'result = reader.ReadToEnd()
            'Send_request(result)



            Dim dialog As New OpenFileDialog()
            dialog.Title = "Select File to Send"
            dialog.InitialDirectory = "C:\winfo\mydata"

            If dialog.ShowDialog() = DialogResult.OK Then
                Dim result As String = ""
                Dim Stream As New MemoryStream()
                Dim fs As New FileStream(dialog.FileName, FileMode.Open, FileAccess.Read)
                Dim reader = New StreamReader(fs, True)
                Stream.Seek(0, SeekOrigin.Begin)

                result = reader.ReadToEnd()
                'MsgBox(result)
                Send_request(result)

            End If

        End Sub
        Private Sub execute_update_myInvoices(ByVal invoiceMark As String, ByVal invoiceUid As String, ByVal cancelInv As String, ByVal qrurl As String)

            Using connection As New SqlConnection(connectionString_)
                Dim command As New SqlCommand()
                Dim transaction As SqlTransaction = Nothing
                Try

                    connection.Open()
                    transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted)
                    command.Connection = connection
                    command.Transaction = transaction

                    command.Parameters.AddWithValue("@uid", invoiceUid)
                    command.Parameters.AddWithValue("@mark", invoiceMark)
                    command.Parameters.AddWithValue("@cancelmark", cancelInv)
                    command.Parameters.AddWithValue("@tipos", invoiceType_)
                    command.Parameters.AddWithValue("@vatnumberEkd", vatnumberEkd_)
                    command.Parameters.AddWithValue("@countryEkd", countryEkd_)
                    command.Parameters.AddWithValue("@branchEkd", branchEkd_)
                    command.Parameters.AddWithValue("@postalCodeEkd", postalCodeEkd_)
                    command.Parameters.AddWithValue("@cityEkd", cityEkd_)
                    command.Parameters.AddWithValue("@vatnumberLpt", vatnumberLpt_)
                    command.Parameters.AddWithValue("@countryLpt", countryLpt_)
                    command.Parameters.AddWithValue("@branchLpt", branchLpt_)

                    command.Parameters.AddWithValue("@nameLpt", nameLpt_)
                    command.Parameters.AddWithValue("@postalCodeLpt", postalCodeLpt_)
                    If cityLpt_ Is Nothing Then
                        command.Parameters.AddWithValue("@cityLpt", DBNull.Value)
                    Else
                        command.Parameters.AddWithValue("@cityLpt", cityLpt_)
                    End If
                    'command.Parameters.AddWithValue("@cityLpt", cityLpt_)

                    command.Parameters.AddWithValue("@series", series_)
                    command.Parameters.AddWithValue("@aa", aa_)
                    command.Parameters.AddWithValue("@issueDate", issueDate_)
                    command.Parameters.AddWithValue("@paymType", paymType_)
                    command.Parameters.AddWithValue("@corelatedInvoic", corelatedInv_)
                    command.Parameters.AddWithValue("@paymAmount", paymAmount_)

                    command.Parameters.AddWithValue("@netYpnos", netYpnos_)
                    command.Parameters.AddWithValue("@netPrwino", netPrwino_)
                    command.Parameters.AddWithValue("@netGeuma", netGeuma_)
                    command.Parameters.AddWithValue("@netExtras", netExtra_)
                    command.Parameters.AddWithValue("@vatPosYpnos", vatPosYpnos_)
                    command.Parameters.AddWithValue("@vatPosPrwino", vatPosPrwino_)

                    command.Parameters.AddWithValue("@vatPosGeuma", vatPosGeuma_)
                    command.Parameters.AddWithValue("@vatPosExtras", vatPosExtra_)

                    command.Parameters.AddWithValue("@totalNetvalue", totalNetValue)
                    command.Parameters.AddWithValue("@totalVatvalue", totalVatAmount)
                    command.Parameters.AddWithValue("@totalGrossvalue", totalGrossValue)

                    command.Parameters.AddWithValue("@classificationType", classificationType)
                    command.Parameters.AddWithValue("@classificationCategory", classificationCategory)
                    command.Parameters.AddWithValue("@qrcode", qrurl)
                    command.Parameters.AddWithValue("@id", myinvoicesID)

                    command.CommandText = "UPDATE myinvoices SET uid=@uid, mark=@mark, cancelmark=@cancelmark, tipos=@tipos, vatnumberEkd=@vatnumberEkd, countryEkd=@countryEkd, branchEkd=@branchEkd, postalCodeEkd=@postalCodeEkd, cityEkd=@cityEkd, " &
                                 "vatnumberLpt=@vatnumberLpt, countryLpt=@countryLpt, branchLpt=@branchLpt, nameLpt=@nameLpt, postalCodeLpt=@postalCodeLpt, cityLpt=@cityLpt, series=@series, aa=@aa, issueDate=@issueDate, paymType=@paymType, corelatedInvoic=@corelatedInvoic, paymAmount=@paymAmount, " &
                                 "netYpnos=@netYpnos, netPrwino=@netPrwino, netGeuma=@netGeuma, netExtras=@netExtras, vatPosYpnos=@vatPosYpnos, vatPosPrwino=@vatPosPrwino, vatPosGeuma=@vatPosGeuma, vatPosExtras=@vatPosExtras, totalNetvalue=@totalNetvalue, totalVatvalue=@totalVatvalue, " &
                                 "totalGrossvalue=@totalGrossvalue, classificationType=@classificationType, classificationCategory=@classificationCategory, qrcode=@qrcode WHERE id=@id"
                    command.ExecuteNonQuery()
                    command.Parameters.Clear()

                    transaction.Commit()
                    '   Return 1
                Catch ex As Exception
                    MsgBox("Η Διαδικασία ενημέρωσης βάσης απέτυχε!", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                    Try
                        transaction.Rollback()
                        '  Return -1
                    Catch
                        '    Return -1
                    End Try

                End Try
            End Using
        End Sub


        'Private Sub execute_insert_myInvoice(ByVal invoiceMark As String, ByVal invoiceUid As String, ByVal cancelInv As String)

        '    Using connection As New OleDb.OleDbConnection(connectionString_)
        '        Dim command As New OleDb.OleDbCommand()
        '        Dim transaction As OleDb.OleDbTransaction = Nothing
        '        Try

        '            connection.Open()
        '            transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted)
        '            command.Connection = connection
        '            command.Transaction = transaction
        '            command.Parameters.AddWithValue("aadeUserId", aadeUserId_)
        '            command.Parameters.AddWithValue("apiSubKey", apiSubKey_)
        '            command.Parameters.AddWithValue("epixirisi", epixirisi_)
        '            command.Parameters.AddWithValue("eidos", eidos_)
        '            command.Parameters.AddWithValue("timologio", kwdTim_)
        '            command.Parameters.AddWithValue("uid", invoiceUid)
        '            command.Parameters.AddWithValue("mark", invoiceMark)
        '            command.Parameters.AddWithValue("cancelmark", cancelInv)
        '            command.Parameters.AddWithValue("tipos", invoiceType_)
        '            command.Parameters.AddWithValue("vatnumberEkd", vatnumberEkd_)
        '            command.Parameters.AddWithValue("countryEkd", countryEkd_)
        '            command.Parameters.AddWithValue("branchEkd", branchEkd_)
        '            command.Parameters.AddWithValue("postalCodeEkd", postalCodeEkd_)
        '            command.Parameters.AddWithValue("cityEkd", cityEkd_)
        '            command.Parameters.AddWithValue("vatnumberLpt", vatnumberLpt_)
        '            command.Parameters.AddWithValue("countryLpt", countryLpt_)
        '            command.Parameters.AddWithValue("branchLpt", branchLpt_)
        '            command.Parameters.AddWithValue("onomateponimo", onomateponimo_)
        '            command.Parameters.AddWithValue("nameLpt", nameLpt_)
        '            command.Parameters.AddWithValue("postalCodeLpt", postalCodeLpt_)
        '            command.Parameters.AddWithValue("cityLpt", cityLpt_)

        '            command.Parameters.AddWithValue("series", series_)
        '            command.Parameters.AddWithValue("aa", aa_)
        '            command.Parameters.AddWithValue("issueDate", issueDate_)
        '            command.Parameters.AddWithValue("paymType", paymType_)
        '            command.Parameters.AddWithValue("corelatedInvoic", corelatedInv_)
        '            command.Parameters.AddWithValue("paymAmount", paymAmount_)

        '            command.Parameters.AddWithValue("netYpnos", netYpnos_)
        '            command.Parameters.AddWithValue("netPrwino", netPrwino_)
        '            command.Parameters.AddWithValue("netGeuma", netGeuma_)
        '            command.Parameters.AddWithValue("netExtras", netExtra_)
        '            command.Parameters.AddWithValue("vatPosYpnos", vatPosYpnos_)
        '            command.Parameters.AddWithValue("vatPosPrwino", vatPosPrwino_)


        '            command.Parameters.AddWithValue("vatPosGeuma", vatPosGeuma_)
        '            command.Parameters.AddWithValue("vatPosExtras", vatPosExtra_)

        '            command.Parameters.AddWithValue("totalNetvalue", totalNetValue)
        '            command.Parameters.AddWithValue("totalVatvalue", totalVatAmount)
        '            command.Parameters.AddWithValue("totalGrossvalue", totalGrossValue)

        '            command.Parameters.AddWithValue("classificationType", classificationType)
        '            command.Parameters.AddWithValue("classificationCategory", classificationCategory)



        '            command.CommandText = "INSERT INTO myinvoices (aadeUserId, apiKey ,epixirisi, eidos,timologio, uid, mark, cancelmark,tipos, vatnumberEkd, countryEkd, branchEkd,postalCodeEkd,cityEkd," &
        '             "vatnumberLpt,countryLpt,branchLpt,onomateponimo, nameLpt,postalCodeLpt,cityLpt,series ,aa,issueDate,paymType,corelatedInvoic,paymAmount,netYpnos,netPrwino,netGeuma,netExtras,vatPosYpnos,vatPosPrwino,vatPosGeuma,vatPosExtras,totalNetvalue,totalVatvalue,totalGrossvalue,classificationType,classificationCategory)" &
        '            "values(aadeUserId,apiSubKey , epixirisi, eidos,timologio, uid, mark, cancelmark,tipos, vatnumberEkd, countryEkd, branchEkd,postalCodeEkd,cityEkd," &
        '            "vatnumberLpt,countryLpt,branchLpt,onomateponimo,nameLpt,postalCodeLpt,cityLpt,series, aa,issueDate,paymType,corelatedInvoic,paymAmount,netYpnos,netPrwino,netGeuma,netExtras,vatPosYpnos,vatPosPrwino,vatPosGeuma,vatPosExtras,totalNetvalue,totalVatvalue,totalGrossvalue,classificationType,classificationCategory)"
        '            command.ExecuteNonQuery()
        '            command.Parameters.Clear()

        '            transaction.Commit()
        '            '   Return 1
        '        Catch ex As Exception
        '            MsgBox("Η Διαδικασία ενημέρωσης βάσης απέτυχε !", MsgBoxStyle.Exclamation, "winfo\nikEl.")
        '            Try
        '                transaction.Rollback()
        '                '  Return -1
        '            Catch
        '                '    Return -1
        '            End Try

        '        End Try
        '    End Using
        'End Sub
        Private Sub execute_insert_myInvoice(ByVal invoiceMark As String, ByVal invoiceUid As String, ByVal cancelInv As String, ByVal qrurl As String)


            Using connection As New SqlConnection(connectionString_)
                Dim command As New SqlCommand()
                Dim transaction As SqlTransaction = Nothing

                Try
                    connection.Open()
                    transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted)
                    command.Connection = connection
                    command.Transaction = transaction

                    command.Parameters.AddWithValue("@aadeUserId", aadeUserId_)
                    command.Parameters.AddWithValue("@apiKey", apiSubKey_)
                    command.Parameters.AddWithValue("@epixirisi", epixirisi_)
                    command.Parameters.AddWithValue("@eidos", eidos_)
                    command.Parameters.AddWithValue("@timologio", kwdTim_)
                    command.Parameters.AddWithValue("@uid", invoiceUid)
                    command.Parameters.AddWithValue("@mark", invoiceMark)
                    command.Parameters.AddWithValue("@cancelmark", cancelInv)
                    command.Parameters.AddWithValue("@tipos", invoiceType_)
                    command.Parameters.AddWithValue("@vatnumberEkd", vatnumberEkd_)
                    command.Parameters.AddWithValue("@countryEkd", countryEkd_)
                    command.Parameters.AddWithValue("@branchEkd", branchEkd_)
                    command.Parameters.AddWithValue("@postalCodeEkd", postalCodeEkd_)
                    command.Parameters.AddWithValue("@cityEkd", cityEkd_)
                    command.Parameters.AddWithValue("@vatnumberLpt", vatnumberLpt_)
                    command.Parameters.AddWithValue("@countryLpt", countryLpt_)

                    If branchLpt_ Is Nothing Then
                        command.Parameters.AddWithValue("@branchLpt", DBNull.Value)
                    Else
                        command.Parameters.AddWithValue("@branchLpt", branchLpt_)
                    End If

                    'command.Parameters.AddWithValue("@branchLpt", branchLpt_)
                    command.Parameters.AddWithValue("@onomateponimo", onomateponimo_)
                    command.Parameters.AddWithValue("@nameLpt", nameLpt_)
                    command.Parameters.AddWithValue("@postalCodeLpt", postalCodeLpt_)
                    If cityLpt_ Is Nothing Then
                        command.Parameters.AddWithValue("@cityLpt", DBNull.Value)
                    Else
                        command.Parameters.AddWithValue("@cityLpt", cityLpt_)
                    End If

                    'command.Parameters.AddWithValue("@cityLpt", cityLpt_)

                    command.Parameters.AddWithValue("@series", series_)
                    command.Parameters.AddWithValue("@aa", aa_)
                    command.Parameters.AddWithValue("@issueDate", issueDate_)
                    command.Parameters.AddWithValue("@paymType", paymType_)
                    command.Parameters.AddWithValue("@corelatedInvoic", corelatedInv_)
                    command.Parameters.AddWithValue("@paymAmount", paymAmount_)

                    command.Parameters.AddWithValue("@netYpnos", netYpnos_)
                    command.Parameters.AddWithValue("@netPrwino", netPrwino_)
                    command.Parameters.AddWithValue("@netGeuma", netGeuma_)
                    command.Parameters.AddWithValue("@netExtras", netExtra_)
                    command.Parameters.AddWithValue("@vatPosYpnos", vatPosYpnos_)
                    command.Parameters.AddWithValue("@vatPosPrwino", vatPosPrwino_)
                    command.Parameters.AddWithValue("@vatPosGeuma", vatPosGeuma_)
                    command.Parameters.AddWithValue("@vatPosExtras", vatPosExtra_)

                    command.Parameters.AddWithValue("@totalNetvalue", totalNetValue)
                    command.Parameters.AddWithValue("@totalVatvalue", totalVatAmount)
                    command.Parameters.AddWithValue("@totalGrossvalue", totalGrossValue)

                    command.Parameters.AddWithValue("@classificationType", classificationType)
                    command.Parameters.AddWithValue("@classificationCategory", classificationCategory)
                    command.Parameters.AddWithValue("@qrcode", qrurl)
                    command.CommandText = "INSERT INTO myinvoices (aadeUserId, apiKey, epixirisi, eidos, timologio, uid, mark, cancelmark, tipos, vatnumberEkd, countryEkd, branchEkd, postalCodeEkd, cityEkd, " &
                                  "vatnumberLpt, countryLpt, branchLpt, onomateponimo, nameLpt, postalCodeLpt, cityLpt, series, aa, issueDate, paymType, corelatedInvoic, paymAmount, " &
                                  "netYpnos, netPrwino, netGeuma, netExtras, vatPosYpnos, vatPosPrwino, vatPosGeuma, vatPosExtras, totalNetvalue, totalVatvalue, totalGrossvalue, " &
                                  "classificationType, classificationCategory, qrcode) " &
                                  "VALUES (@aadeUserId, @apiKey, @epixirisi, @eidos, @timologio, @uid, @mark, @cancelmark, @tipos, @vatnumberEkd, @countryEkd, @branchEkd, @postalCodeEkd, @cityEkd, " &
                                  "@vatnumberLpt, @countryLpt, @branchLpt, @onomateponimo, @nameLpt, @postalCodeLpt, @cityLpt, @series, @aa, @issueDate, @paymType, @corelatedInvoic, @paymAmount, " &
                                  "@netYpnos, @netPrwino, @netGeuma, @netExtras, @vatPosYpnos, @vatPosPrwino, @vatPosGeuma, @vatPosExtras, @totalNetvalue, @totalVatvalue, @totalGrossvalue, " &
                                  "@classificationType, @classificationCategory, @qrcode)"

                    command.ExecuteNonQuery()
                    command.Parameters.Clear()

                    transaction.Commit()
                Catch ex As Exception
                    MsgBox("Η Διαδικασία ενημέρωσης βάσης απέτυχε!", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                    Try
                        transaction.Rollback()
                    Catch
                        ' Handle rollback exception
                    End Try
                End Try
            End Using
        End Sub

    End Class







    Public Class CancelInvoice
        'TEST URL
        'Const url_ As String = "https://mydataapidev.aade.gr/CancelInvoice?"
        'PRAGMATIKO URL
        Const url_ As String = "https://mydatapi.aade.gr/myDATA/CancelInvoice?"
        Dim connectionString_ As String
        Dim id_ As Int32
        Public Sub New(ByVal connectionString As String, ByVal myInvID As Int32)
            connectionString_ = connectionString
            id_ = myInvID
        End Sub

        Public Sub Send_request()
            Dim errosMessage As String = "Αποτυχία ενημέρωσης του myData"
            Dim invoiceMark As String = ""
            Dim invoiceKwd As String = ""
            Dim cancelMark As String = ""
            Dim xmldoc As New XmlDocument

            Dim xmlnode As XmlNodeList
            Dim istOK As Boolean
            Dim aadeUserId_ As String = ""
            Dim apiSubKey_ As String = ""

            Using connection As New SqlConnection(connectionString_)
                Dim command As New SqlCommand()
                Dim myReader As SqlDataReader
                connection.Open()
                command.Connection = connection

                command.Parameters.AddWithValue("@id", id_)
                command.CommandText = "SELECT aadeUserId,apiKey, timologio, mark, cancelmark FROM myinvoices WHERE (id=@id)" 'and (identifikation=?)
                myReader = command.ExecuteReader()
                command.Parameters.Clear()
                ' Always call Read before accessing data.
                While myReader.Read()
                    aadeUserId_ = myReader.GetString(0)
                    apiSubKey_ = myReader.GetString(1)
                    'aadeUserId_ = "mkallergis"
                    'apiSubKey_ = "4a903ebf82df4dd7a5b2492aeda46e09"
                    invoiceMark = myReader.GetString(3)
                    If Not IsDBNull(myReader.GetString(4)) Then
                        cancelMark = myReader.GetString(4)
                    End If

                    invoiceKwd = myReader.GetInt32(2)

                End While

                myReader.Close()

            End Using

            If String.IsNullOrEmpty(cancelMark) Then
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12

                Dim request As WebRequest = WebRequest.Create(url_ + "mark=" + invoiceMark)
                request.Headers.Add("aade-user-id", aadeUserId_)
                request.Headers.Add("Ocp-Apim-Subscription-Key", apiSubKey_)
                '  request.Credentials = CredentialCache.DefaultCredentials
                request.Method = "POST"

                'Dim byteArray As Byte() = Encoding.UTF8.GetBytes(requestString)

                request.ContentType = "text/plain"
                ' request.ContentLength = byteArray.Length
                Try
                    ' Get the request stream.  
                    Dim dataStream As Stream = request.GetRequestStream()
                    ' Write the data to the request stream.  
                    '  dataStream.Write(byteArray, 0, byteArray.Length)
                    ' Close the Stream object.  
                    dataStream.Close()


                    Dim response As WebResponse = request.GetResponse()
                    'Dim reader As New StreamReader(response.GetResponseStream)
                    'Dim streamTetx As String = reader.ReadToEnd
                    'MsgBox(streamTetx)
                    'Exit Sub
                    Using Stream As Stream = response.GetResponseStream()
                        ' Open the stream using a StreamReader for easy access.  

                        ' Read the content.  
                        xmldoc.Load(Stream)

                        xmlnode = xmldoc.GetElementsByTagName("error")
                        If xmlnode.Count <> 0 Then
                            For Each node1 As XmlNode In xmlnode
                                errosMessage = errosMessage + vbCrLf + node1.InnerText

                                'For Each attr As XmlAttribute In node1.Attributes
                                '    If attr.Name.Equals("message") Then
                                '        errosMessage = errosMessage + attr.InnerText + vbCrLf
                                '    End If


                                'Next

                            Next
                            MsgBox(errosMessage)
                        Else
                            xmlnode = xmldoc.GetElementsByTagName("cancellationMark")
                            If xmlnode.Count <> 0 Then
                                For Each node As XmlNode In xmlnode
                                    cancelMark = node.InnerText
                                Next
                            End If



                        End If

                    End Using
                Catch ex As WebException

                    MsgBox("Αποτυχία επικοινωνίας με MyData", MsgBoxStyle.Exclamation)
                    istOK = False
                End Try


            Else
                MsgBox("Το παραστατικό είναι ήδη ακυρωμένο: " + cancelMark, MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            execute_update_myInvoice(id_, cancelMark)
            'Return istOK
        End Sub


        Private Sub execute_update_myInvoice(ByVal id As Int32, ByVal cancelMark As String)

            'Using connection As New OleDb.OleDbConnection(connectionString_)
            '    Dim command As New OleDb.OleDbCommand()
            '    Dim transaction As OleDb.OleDbTransaction = Nothing
            '    Try

            '        connection.Open()
            '        transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted)
            '        command.Connection = connection
            '        command.Transaction = transaction

            '        command.Parameters.AddWithValue("cancelmark", cancelMark)
            '        command.Parameters.AddWithValue("id", id)
            '        command.CommandText = "UPDATE myinvoices SET cancelmark=? WHERE (id=?)"
            '        command.ExecuteNonQuery()
            '        command.Parameters.Clear()

            '        transaction.Commit()
            '        '   Return 1
            '    Catch ex As Exception
            '        MsgBox("Η Διαδικασία ενημέρωσης βάσης απέτυχε !", MsgBoxStyle.Exclamation, "winfo\nikEl.")
            '        Try
            '            transaction.Rollback()
            '            '  Return -1
            '        Catch
            '            '    Return -1
            '        End Try

            '    End Try
            'End Using
            Using connection As New SqlConnection(connectionString_)
                Dim command As New SqlCommand()
                Dim transaction As SqlTransaction = Nothing
                Try
                    connection.Open()
                    transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted)
                    command.Connection = connection
                    command.Transaction = transaction

                    command.Parameters.AddWithValue("@cancelmark", cancelMark)
                    command.Parameters.AddWithValue("@id", id)
                    command.CommandText = "UPDATE myinvoices SET cancelmark=@cancelmark WHERE (id=@id)"
                    command.ExecuteNonQuery()
                    command.Parameters.Clear()

                    transaction.Commit()
                    ' Return 1
                Catch ex As Exception
                    MsgBox("Η Διαδικασία ενημέρωσης βάσης απέτυχε!", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                    Try
                        transaction.Rollback()
                        ' Return -1
                    Catch
                        ' Return -1
                    End Try

                End Try
            End Using

        End Sub

    End Class
End Module
