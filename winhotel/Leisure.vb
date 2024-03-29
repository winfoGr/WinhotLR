Option Strict Off
Option Explicit On
'Imports System.Runtime.CompilerServices

Friend Class Leisure
    Dim dataset As New dbhotelDataSet
    'Dim target As String = "https://www.leisure-group.net"
    Dim target As String '= "  https://www.leisure-group.net/cgi/lars/eign/huis/huisplan?R=0x0000000000068f80&hspl=0x0000000000013fc5&Jaar=2014"
    'Dim username As String = "reservations@grecianland.gr"
    'Dim passwd As String = "sk7re4"
    Dim pageready As Boolean = False
    Dim datum As String
    Dim bila As String
    Public Sub New(ByVal vila As String, ByVal imerom As Date)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        'System.Diagnostics.Process.Start("rundll32.exe", "InetCpl.cpl,ClearMyTracksByProcess 32")
        bila = vila
        Dim targetAdapter As New dbhotelDataSetTableAdapters.linksTableAdapter
        targetAdapter.FillLinksByVila(dataset.links, vila)
        linkTbx.Text = "https://www.leisure-group.net"
        userTbx.Text = "reservations@grecianland.gr"
        passwdTbx.Text = "sk7re4"
        datum = Format(imerom, "dd-MM-yyyy").ToString '"21-06-2014"
        'target = trgt.Replace("#", "")
        'Navigate(linkTbx.Text)


        linkwimdu.Text = "https://www.wimdu.gr/users/login" '/users/login
        userwimdu.Text = "reservations@grecianland.gr"
        pwdwimdu.Text = "kapetanakis"


        linkholiday.Text = "https://www.holidaylettings.co.uk/content/property_listing" '/users/loginrty
        userholiday.Text = "17326"
       

        wbrWebBrowser.ScriptErrorsSuppressed = True

        Navigate("http://www.grecianland.gr/en/")
        'AddHandler wbrWebBrowser.DocumentCompleted, New WebBrowserDocumentCompletedEventHandler(AddressOf holiday_lettings)
        'TextBox1.Text = "reservations@grecianland.gr"
        'TextBox2.Text = "sk7re4"
        ' Add any initialization after the InitializeComponent() call.
    End Sub
    Private Function find_target(ByVal descr As String) As String
        Dim j As Int16

        For j = 0 To dataset.links.Count - 1
            If dataset.links(j).description.Equals(descr) Then
                Return dataset.links(j).link
            End If
        Next
        Return ""
    End Function
    Private Sub Navigate(ByVal address As String)
        'Dim docElements As HtmlElementCollection
        'Dim j As HtmlElement

        If String.IsNullOrEmpty(address) Then Return
        If address.Equals("about:blank") Then Return
        'If Not address.StartsWith("http://") Then
        '    address = "https://" & address
        'End If
        Try
            wbrWebBrowser.Navigate(New Uri(address))
            'Dim doc As Xml.XmlDocument = wbrWebBrowser.Document
        Catch ex As System.UriFormatException
            Return
        End Try
    End Sub
    Private Sub ReloadBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Login.Click

        target = find_target("leisure").Replace("#", "")

        Navigate(linkTbx.Text)

        WaitForPageLoad()

        Dim Identifiers() As String = {"loginid", "passwd"}

        'Dim oXML As Object = wbrWebBrowser.Document.DomDocument.XMLDocument
        'Dim XmlNodeList = oXML.SelectNodes(path).length

        Dim Items = _
        ( _
            From T In wbrWebBrowser.Document.GetElementsByTagName("input").Cast(Of HtmlElement)() _
            Where Identifiers.Contains(T.GetAttribute("name").ToString) _
        ).ToList
        'MsgBox(Items(0).Inne)

        'Dim docElements As HtmlElementCollection
        If Items.Count > 0 Then
            For x As Integer = 0 To Items.Count - 1

                If Items(x).Name = "loginid" Then
                    Items(x).SetAttribute("value", userTbx.Text) 'Console.WriteLine("Label1.Text={0} from id=dn", Items(x).InnerHtml)
                ElseIf Items(x).Name = "passwd" Then
                    Items(x).SetAttribute("value", passwdTbx.Text)  '  Console.WriteLine("Label2.Text={0} from id=dl", Items(x).InnerHtml)
                End If

            Next
        End If
        Items.Clear()
        Dim Identifiers2() As String = {"submit"}
        Items = _
       ( _
           From T In wbrWebBrowser.Document.GetElementsByTagName("input").Cast(Of HtmlElement)() _
           Where Identifiers2.Contains(T.GetAttribute("type").ToString) _
       ).ToList
        If Items.Count > 0 Then
            Items(0).InvokeMember("click")
        End If
        WaitForPageLoad()
        'Threading.Thread.Sleep(5000)

        Navigate(target)
        WaitForPageLoad()
        fuehle_datum()

    End Sub
    Private Sub logimwimdu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles logimwimdu.Click

        target = find_target("wimdu")

        Navigate(linkwimdu.Text)

        WaitForPageLoad()
        Dim Identifiers() As String = {"user[email]", "user[password]"}


        Dim Items1 = _
        ( _
            From T In wbrWebBrowser.Document.GetElementsByTagName("input").Cast(Of HtmlElement)() _
            Where Identifiers.Contains(T.GetAttribute("name").ToString) _
        ).ToList

        If Items1.Count > 0 Then
            For x As Integer = 0 To Items1.Count - 1

                If Items1(x).Name = "user[email]" Then
                    Items1(x).focus()
                    Items1(x).SetAttribute("value", userTbx.Text) 'Console.WriteLine("Label1.Text={0} from id=dn", Items(x).InnerHtml)

                ElseIf Items1(x).Name = "user[password]" Then
                    Items1(x).focus()
                    Items1(x).SetAttribute("value", pwdwimdu.Text)  '  Console.WriteLine("Label2.Text={0} from id=dl", Items(x).InnerHtml)

                End If

            Next
        End If
        'Items.Clear()
        Dim Identifiers2() As String = {"submit"}
        Dim Items2 = _
       ( _
           From T In wbrWebBrowser.Document.GetElementsByTagName("input").Cast(Of HtmlElement)() _
           Where Identifiers2.Contains(T.GetAttribute("type").ToString) _
       ).ToList
        If Items2.Count > 0 Then
            Items2(0).focus()
            Items2(0).InvokeMember("click")
        End If
        'Exit Sub
        WaitForPageLoad()

        'Threading.Thread.Sleep(5000)
        'MsgBox(target)
        Navigate(Trim(target.Replace("#", ""))) '"https://www.wimdu.gr/user/offers/5NPUEC9X/calendar/edit"
        WaitForPageLoad()
        fuehle_ical()
    End Sub

    Private Sub fuehle_datum()
        Dim Identifiers() As String = {datum}

        'Dim oXML As Object = wbrWebBrowser.Document.DomDocument.XMLDocument
        'Dim XmlNodeList = oXML.SelectNodes(path).length

        Dim Items = _
        ( _
            From T In wbrWebBrowser.Document.GetElementsByTagName("td").Cast(Of HtmlElement)() _
            Where Identifiers.Contains(T.GetAttribute("title").ToString) _
        ).ToList
        'MsgBox(Items(0).Inne)

        'Dim docElements As HtmlElementCollection
        If Items.Count > 0 Then
            For x As Integer = 0 To Items.Count - 1
                Items(x).InvokeMember("click")
            Next
        End If


    End Sub
    Private Sub fuehle_ical()
        Dim calenderAdapter As New dbhotelDataSetTableAdapters.calendarTableAdapter

        'Dim oXML As Object = wbrWebBrowser.Document.DomDocument.XMLDocument
        'Dim XmlNodeList = oXML.SelectNodes(path).length
        Try
            Dim Identifiers() As String = {"url"}
            Dim Items = _
           ( _
               From T In wbrWebBrowser.Document.GetElementsByTagName("input").Cast(Of HtmlElement)() _
               Where Identifiers.Contains(T.GetAttribute("name").ToString) _
           ).ToList

            If Items.Count > 0 Then
                For x As Integer = 0 To Items.Count - 1

                    If Items(x).Name = "url" Then
                        Items(x).SetAttribute("value", calenderAdapter.GetIcallByVilla(bila)) 'Console.WriteLine("Label1.Text={0} from id=dn", Items(x).InnerHtml)
                        'ElseIf Items(x).Name = "user[password]" Then
                        '    Items(x).SetAttribute("value", pwdwimdu.Text)  '  Console.WriteLine("Label2.Text={0} from id=dl", Items(x).InnerHtml)
                    End If

                Next
            End If
        Catch ex As Exception

        End Try



    End Sub
    Private Sub WaitForPageLoad()
        AddHandler wbrWebBrowser.DocumentCompleted, New WebBrowserDocumentCompletedEventHandler(AddressOf PageWaiter)
        While Not pageready
            Application.DoEvents()
        End While
        pageready = False
    End Sub

    Private Sub PageWaiter(ByVal sender As Object, ByVal e As WebBrowserDocumentCompletedEventArgs)
        If wbrWebBrowser.ReadyState = WebBrowserReadyState.Complete Then
            'MsgBox(wbrWebBrowser.Url.ToString)
            pageready = True
            RemoveHandler wbrWebBrowser.DocumentCompleted, New WebBrowserDocumentCompletedEventHandler(AddressOf PageWaiter)
        End If
    End Sub
   
    Private Sub ReloadBtn_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReloadBtn.Click
        Navigate(linkTbx.Text)
    End Sub
    

    Private Sub loginholiday_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles loginholiday.Click
        'target = find_target("holidaylettings")
        'target = "https://www.holidaylettings.co.uk/content/availability_calendar/"
        'MsgBox(target)

        'Dim instance as (SHDocVw.WebBrowser)wbrWebBrowser.ActiveXInstance
        'instance.NavigateError += new SHDocVw.DWebBrowserEvents2_NavigateErrorEventHandler(instance_NavigateError);
        'webBrowser1.Navigate("http://www.google.com/foo");
        Dim target As String = "https://www.holidaylettings.co.uk/content/property_listing"
        'Do not use more than one assignment at a time.
        'This also works with FTP.
        'Dim target As String = "ftp://ftp.microsoft.com"
        'This also works with a file.
        'Dim target As String = "C:\Program Files\Microsoft Visual Studio\INSTALL.HTM"
        Dim calenderAdapter As New dbhotelDataSetTableAdapters.calendarTableAdapter
        Try
            System.Diagnostics.Process.Start(target)

        Catch noBrowser As System.ComponentModel.Win32Exception _
            When noBrowser.ErrorCode = -2147467259
            MessageBox.Show(noBrowser.Message)

        Catch other As System.ComponentModel.Win32Exception
            MessageBox.Show(other.Message)

        End Try
        icalholiday.Text = calenderAdapter.GetIcallByVilla(bila)
    End Sub

End Class